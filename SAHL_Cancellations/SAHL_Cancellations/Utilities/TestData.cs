using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHL_Cancellations.Utilities
{
    public class TestData
    {
        // Login details
        public static readonly string LUN = "39547";

        // Products drop down menu
        public static readonly string SAHL_Cancellations = "SA Home Loans Cancellations - Attorney";

        // Home page All stages drop down menu and Search ID
        public static readonly string Awaiting_Guarantees = "Awaiting Guarantees";
        public static readonly string Search_ID = "124455";
        public static readonly string Account = "6450116";
        public static readonly string Parties = "Mr Arno du Toit";
        public static readonly string Property = "Unit 2, Ss Amcrest 1590, Gauteng";
        public static readonly string Blank = "";


        // Request Cancellation
        public static readonly string Account_Number = "46548237907";
        public static readonly string Cancellation_Type_Switch = "Switch";
        public static readonly string Cancellation_Type_Transfer = "Transfer";
        public static readonly string Cancellation_Type_Endorsement = "Endorsement";
        public static readonly string Title_Mr = "Mr";
        public static readonly string Initials = "T";
        public static readonly string Full_Name = "Teboho Bodibe";
        public static readonly string Region_Free_State = "Free State";
        public static readonly string Cancellation_Reason_EarlySettlementOfBond = "Early Settlement of Bond";

        // Setup Branch Details
        public static readonly string Branch = "Durban_1";
        public static readonly string Telephone = "0124600007_1";
        public static readonly string Fax = "08653917785_1";
        public static readonly string Email = "sjones@e4.co.za";
        public static readonly string Tax_Number = "923336_1";
        public static readonly string Docex = "34, Pretoria_1";
        public static readonly string Physical_AddressLine1 = "79 Charles Street_1";
        public static readonly string Postal_AddressLine1 = "P O BOX 3267_1";
        public static readonly string Physical_AddressLine2 = "371994_1";
        public static readonly string Postal_AddressLine2 = "Pretoria_1";
        public static readonly string Suburb = "BROOKLYN_1";
        public static readonly string Postal_Code = "0001_1";
        public static readonly string City = "Pretoria_1";
        public static readonly string Country = "South Africa";
        public static readonly string Province = "Gauteng";

        // Power of Attorney
        public static readonly string CancellationBank = "ABSA Bank";
        public static readonly string BankLegalDescription = "ABSA";
        public static readonly string DeedsOffice1 = "Mthatha";
        public static readonly string POANumber = "PA2000";
        public static readonly string DateRegistered = "2024-02-02";
        public static readonly string SignatoryNames = "Teboho Bodibe";



        // New Instructions 
        public static readonly string FileNote = "Entering a note to make sure this field works correctly";

		// Diary
		public static readonly string Description = "Shopping Complex";
		public static readonly string DescriptionEdit = "Apartment";
		public static readonly string DiaryNotes = "Entering a note to make sure this field works correctly";
		public static readonly string Duedate = "2025-03-15";


		// SMS
		public static readonly string ToCell = "0726063879";
        public static readonly string Message = "Sending an SMS to make sure this field works correctly";
        


        // Correspondents
        public static readonly string Search = "Test";
        public static readonly string EntityType = "Bank Team Lead";
        public static readonly string Contact_Person = "Teboho Bodibe";
        public static readonly string Contact_IDNo = "9105188566599";
        public static readonly string Tel_Work = "0726063879";
        public static readonly string Tel_Cell = "0726063879";
        public static readonly string Tel_home = "0726063879";
        public static readonly string Fax2 = "0726063879";
        public static readonly string Email2 = "tbodibe@e4.co.za";
        public static readonly string Letter_Caption = "For ABSA Cancellations";
        public static readonly string Company = "e4";
        public static readonly string Company_RegNo = "2346412045";
        public static readonly string Branch2 = "Gauteng";
        public static readonly string Docex2 = "Testing Example";

        public static readonly string PhysicalAddressLine1 = "Rosebank Mall";
        public static readonly string PhysicalAddressLine2 = "Fourways mall";
        public static readonly string PhysicalAddressLine3 = "Mall of Africa";
        public static readonly string City2 = "Randburg";
        public static readonly string PhysicalAddressCode = "78966";
        public static readonly string Province2 = "Province of the Free State";
        public static readonly string Country2 = "SOUTH AFRICA";
        public static readonly string POBoxLine1 = "Testing Example";
        public static readonly string POBoxLine2 = "Testing Example";
        public static readonly string POBoxLine3 = "Testing Example";
        public static readonly string PostalCode = "20147";


        // InfoSheet
        public static readonly string FileRef = "Deed Search - ABSA";

        // Deed Search
        public static readonly string DeedSearch = "ERF";

        // Instruction Details
        public static readonly string TitleDeedNumber = "5489";
        public static readonly string LegalBankDescription = "ABSA";
        public static readonly string PANumber = "1011155";
        public static readonly string Signatories = "Teboho Bodibe";
        public static readonly string BondNumber = "544899448420";
        public static readonly string BondAmount = "600000";

        // Property
        public static readonly string DeedsOffice = "Durban";
        public static readonly string PropertyType = "Erf";
        public static readonly string SubDivisionalTypeNA = "N/A";
        public static readonly string ErfNumber = "60841470";
        public static readonly string Township = "Umhlanga";
        public static readonly string RegistrationDivision = "Testing";
        public static readonly string Province3 = "KwaZulu-Natal";
        public static readonly string Extent1 = "C200";
        public static readonly string Extent2 = "Square Metres";
        public static readonly string Address3 = "Unhlanga Rocks 2001";
        public static readonly string LegalDescription = "New Development Apratments";
        public static readonly string HeldBy = "Deed of Transfer T";
        public static readonly string PortionNumber = "100";
        public static readonly string SubDivisionalTypePortion = "Portion";
        public static readonly string Description1 = "Test";
        public static readonly string Size = "100";
        public static readonly string SectionalPlanNo = "25877";
        public static readonly string ExtendingClause = "Test";

        // Refund details
        public static readonly string Bank = "ABSA - ITHALA";
        public static readonly string BranchName = "Reitz";
        public static readonly string BranchCode = "755026";
        public static readonly string AccountNumber = "6523101022255";
        public static readonly string AccountType = "Transmission";
        public static readonly string AccountHolder = "Teboho Bodibe";

        // Conveyencer
        public static readonly string DateOfSignature = "2025/03/26";
        public static readonly string PlaceOfSignature = "Sandton";
        public static readonly string Preparer = "CONVEYENCER ONE";
        public static readonly string CommisionerOfOaths = "CHANTAL BRUMMER";
        public static readonly string LodgementNumber = "00000001";
        public static readonly string CorrespondentName = "Couzyns Inc";
        public static readonly string CorrespondentBranch = "Durban";

        // Parties
        public static readonly string SelectPartyTypeNaturalPerson = "Natural Person";
        public static readonly string FirstName = "Teboho";
        public static readonly string Surname = "Bodibe";
        public static readonly string Gender = "Female";
        public static readonly string MethodOfIdentification = "Identity Document (correct)";
        public static readonly string IdentityNumber1 = "910565 6545 66 5";
        public static readonly string MaritalStatus = "Unmarried"; 

        public static readonly string SelectPartyTypeEntity = "Entity";
        public static readonly string CompanyType = "Public Company - LIMITED";
        public static readonly string NameOfCompany = "e4";
        public static readonly string RegistrationNumber1 = "1222";
        public static readonly string RegistrationNumber2 = "200000";
        public static readonly string RegistrationNumber3 = "06";
        public static readonly string EntityTypeCloseCorporation = "Close Corporation";
        public static readonly string NameOfCloseCorporation = "e4";
        public static readonly string NameOfTrust = "e4 Trust";
        public static readonly string EntityTypeTrust = "Trust";
        public static readonly string TrustType = "inter vivos";
        public static readonly string AuthorityNumber = "012547788";

        public static readonly string SelectPartyTypePartnership = "Partnership";
        public static readonly string Name = "e4 Test"; 
        public static readonly string ReasonForExclusion = "Condition in the Deed of Donation";
        public static readonly string MaritalStatus2 = "Married in Community of Property with Exclusion";

        public static readonly string PartyTypeInstitution = "Institution"; 
        public static readonly string TypeCityTownCouncil = "City / Town Council";
        public static readonly string Council = "North Riding";
        public static readonly string NameOfStatutoryBody = "e4 Test";
        public static readonly string EstablishmentInTermsOf = "e4 Test";

        public static readonly string TypeStatutoryBody = "Statutory Body";
        public static readonly string Province4 = "Free State";
        public static readonly string TypeProvincialAdministration = "Provincial Administration";
        public static readonly string TypeNationalGovernment = "National Government";
        public static readonly string NationalGovernmentLegalDescription = " Test Text"; 


        // Accounts
        public static readonly string Item = "Deeds Office 3";
        public static readonly string Debit = "50000";
        public static readonly string Credit = "60000";
        public static readonly string PaymentMethod = "Cheque";


        // Audit Trail
        public static readonly string Comment = "Testing";
        public static readonly string Search2 = "Testing";









    }
}


