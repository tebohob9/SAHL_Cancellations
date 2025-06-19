using NUnit.Framework;
using Cancellations_Tests.BasePage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SAHL_Cancellations.Utilities
{
    public class CertificateManager
    {
        private Dictionary<string, string> certificateMapping;
        private IWebDriver driver;

        public CertificateManager(IWebDriver driver)
        {
            this.driver = driver;
            LoadCertificateMappings();
        }

        private void LoadCertificateMappings()
        {
            certificateMapping = new Dictionary<string, string>();
            try
            {
                // Load from XML file
                string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates.xml");
                if (File.Exists(xmlPath))
                {
                    XDocument doc = XDocument.Load(xmlPath);
                    foreach (var element in doc.Root.Elements())
                    {
                        certificateMapping[element.Name.LocalName.Replace("_", " ")] = element.Value;
                    }
                }
                else
                {
                    // Fallback to hardcoded values
                    certificateMapping = new Dictionary<string, string>
                    {
                        { "UAT", "Demo Test" },
                        
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading certificate mappings: {ex.Message}");
                // Fallback to hardcoded values
                certificateMapping = new Dictionary<string, string>
                {
                    { "UAT", "Mohammad Laeeq Brown" },
                    { "Bonds", "Law Trust 1" },
                    { "Transfers", "Law Trust 1" },
                    { "SBSA Debt Review - Bank", "Musa Ngwenya" },
                    { "Nadir", "Sphiwe Nkambule" },
                    { "Tracer", "Musa Ngwenya" },
                    { "Credits", "Musa Ngwenya" }
                };
            }
        }

        public string GetCertificateForContext(string context)
        {
            if (certificateMapping.ContainsKey(context))
            {
                return certificateMapping[context];
            }

            // Default to UAT certificate if context not found
            return certificateMapping.ContainsKey("UAT") ? certificateMapping["UAT"] : "Mohammad Laeeq Brown";
        }

        public void SelectCertificateOnChrome(string selectionCertificate, bool moveOneUp = false)
        {
            try
            {
                Console.WriteLine($"Attempting to select certificate: {selectionCertificate}");

                // Wait for the certificate dialog to appear
                Thread.Sleep(3000);

                // Create an Actions object
                Actions actions = new Actions(driver);

                // First, try to focus on the dialog by pressing Tab a few times
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    Thread.Sleep(200);
                }

                // Navigate through certificates using down arrow
                for (int i = 0; i < 10; i++) // Try up to 10 certificates
                {
                    actions.SendKeys(Keys.Down).Perform();
                    Thread.Sleep(300);

                    // If we need to move up one, do it on the last iteration
                    if (i == 9 && moveOneUp)
                    {
                        actions.SendKeys(Keys.Up).Perform();
                        Thread.Sleep(300);
                    }
                }

                // Tab to the OK button
                for (int i = 0; i < 2; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    Thread.Sleep(200);
                }

                // Press Enter to select the certificate
                actions.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(1000);

                Console.WriteLine($"Certificate selection completed for: {selectionCertificate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting certificate: {ex.Message}");
            }
        }
    }

    public class CertificateGroups
    {
        public string Subject { get; set; }
        public bool FindThis { get; set; }

        public CertificateGroups(string subject)
        {
            Subject = subject;
            FindThis = false;
        }
    }
}




