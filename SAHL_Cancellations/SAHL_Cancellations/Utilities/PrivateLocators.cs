using Cancellations_Tests.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHL_Cancellations.Utilities
{
    public class PrivateLocators
    {

        public static readonly string LUN = "//input[@id='LUN']";
        public static readonly string password = "Hillsong@123!";
        public static readonly string login_btn = "//input[@value='LOGIN']";


        public static string lun 
        {

            get { return LUN; } //end get

        }

        public static string Password
        {

            get { return password; } //end get

        }

    }
}


