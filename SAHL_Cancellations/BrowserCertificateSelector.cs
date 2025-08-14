using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

public class BrowserCertificateSelector
{
    private AutomationElement Desktop { get; set; }
    private AutomationElement[] ChromeBrowser { get; set; }

    public BrowserCertificateSelector()
    {
        // Initialize automation
        Desktop = null;
        ChromeBrowser = null;
    }

    public void SelectCertificateOnChrome(string selectionCertificate, bool moveOneUp = false)
    {
        Thread.Sleep(1500);
        if (ChromeBrowser == null)
        {
            Desktop = Automation.GetDesktop();
            Thread.Sleep(5000);
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            ChromeBrowser = Desktop.FindAllChildren(new AndCondition(conditionFactory.ByControlType(FlaUI.Core.Definitions.ControlType.Pane), conditionFactory.ByName("data:, - Google Chrome (Incognito)")));
        }

        var selectCertificate = ChromeBrowser.First().FindAllDescendants(child => child.ByName("Select a certificate"));
        AutomationElement CertificateToSelect = null, OKButton = null, Header = null;
        List<CertificateGroups> CertGroups = new List<CertificateGroups>();

        var certificateNames = selectCertificate.First().FindAllDescendants(new AndCondition());
        var onlyNames = certificateNames.Where(elem => !elem.Name.IsNullOrEmpty()).ToList();

        for (int i = 0; i < onlyNames.Count; i++)
        {
            int index = i / 3;
            if (i % 3 == 2)
            {
                string name = onlyNames[i].Name;
                Console.WriteLine("Reading This > " + onlyNames[i].Name);
                CertGroups.Add(new CertificateGroups(onlyNames[i].Name));
            }
        }

        CertGroups.Remove(CertGroups.Where(certs => certs.Subject.Equals("Select a certificate")).FirstOrDefault());
        CertGroups.Remove(CertGroups.Where(certs => certs.Subject.Equals("Subject")).FirstOrDefault());
        CertGroups.Remove(CertGroups.Where(certs => certs.Subject.Equals("Certificate information")).FirstOrDefault());

        for (int i = 0; i < selectCertificate.Length; i++) 
        { 
            var elementDesc = selectCertificate[i].FindAllDescendants(new AndCondition()); 
        }

        foreach (var certs in selectCertificate)
        {
            if (OKButton == null) OKButton = certs.FindAllDescendants(new AndCondition()).Where(elem => elem.Name.Equals("OK")).First();
            if (Header == null) Header = selectCertificate.First();
        }

        foreach (var certificatesToSelect in CertGroups)
        {
            Console.WriteLine("After Deletions > " + certificatesToSelect.Subject);
        }

        Header.AsTitleBar().Click();
        Console.WriteLine("Looking for This > " + selectionCertificate);

        foreach(var certificatesToSelect in CertGroups)
        {
            if (certificatesToSelect.Subject.Equals(selectionCertificate))
            {
                Console.WriteLine("Marked This > " + certificatesToSelect.Subject);
                certificatesToSelect.FindThis = true;
            }
        }

        for (int i = 0; i < CertGroups.Count; i++)
        {
            Console.WriteLine("Scrolled Here > " + CertGroups[i].Subject);
            if (!CertGroups[i].FindThis)
            {
                Thread.Sleep(995);
                Console.WriteLine("Scrolled Down Here > " + CertGroups[i].Subject);
                Keyboard.Press(VirtualKeyShort.DOWN);
            }
            else
            {
                break;
            }
        }
        
        if(moveOneUp)
        {
            Keyboard.Press(VirtualKeyShort.UP);
        }

        OKButton.AsButton().Click();
    }
}