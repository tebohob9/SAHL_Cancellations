using Cancellations_Tests.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHL_Cancellations.Utilities
{

    public sealed class Locators

    {
        // URL
        public static readonly string url = "https://uat.e4.co.za/Login/Auth?returnUrl=https%3A%2F%2Fuat.e4.co.za%2FLogin";

        // Login details
        public static readonly string LUN = "//input[@id='LUN']";
        public static readonly string password = "Hillsong@123!";
        public static readonly string login_btn = "//input[@value='LOGIN']";


        // Home page
        public static readonly string products_drop_down = "//a[@id='productMenu']";
        public static readonly string news = "//a[normalize-space()='News']";
        public static readonly string downloads = "//a[normalize-space()='Downloads']";
        public static readonly string contact_us = "//a[normalize-space()='Contact Us']";
        public static readonly string logout = "//a[normalize-space()='Log Out']";


        // Absa Cancellations Landing page
        public static readonly string products_dop_down = "Hillsong@123!";
        public static readonly string request_cancellation_tab = "Hillsong@123!";
        public static readonly string archived_tab = "Hillsong@123!";
        //public static readonly string archived_tab = "Hillsong@123!";
        //public static readonly string cancellations_tab = "//div[@class='tab selected ABSACancellation']";
        //public static readonly string archived_tab = "Hillsong@123!";

        // Request Cancellation page
        public static readonly string account_number = "10321615554";
        public static readonly string initials = "T";
        public static readonly string full_name = "Tester Bodibe";

    }
}


