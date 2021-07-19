using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat user option to change portal language
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageLanguage : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCultureChange;
        public string userCode;
        public string imageUrlAddress;

        public string databaseServer = "Server=localhost;Database=YourJester;Uid=rdeconti;Pwd=samsung";
        public MySqlConnection databaseConnection;

        

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat Page_Load event triggered when a page loads.
        ///                 Use the Page.IsPostBack property to treat page load just in FIRST time that page is loaded
        ///                 Obtain the user photo and uploaded it in the page. These are the allowed languages:
        ///                     1 menu_language.Items.Add("Portuguese"); 
        ///                     2 menu_language.Items.Add("Spanish");
        ///                     3 menu_language.Items.Add("English");
        ///                     4 menu_language.Items.Add("French");
        ///                     5 menu_language.Items.Add("German");
        ///                     6 menu_language.Items.Add("Arabic");
        ///                     7 menu_language.Items.Add("Japanese");
        ///                     8 menu_language.Items.Add("Chinese");
        ///                     9 menu_language.Items.Add("Italian");        
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["sessionUserCode"] != null)
            {
                userCode = Session["sessionUserCode"].ToString();
            }
            else
            {
                if (Request.Cookies["YourJesterUserCode"] == null)
                {
                    R0030TreatNewPage object01 = new R0030TreatNewPage();
                    object01.Routine0030TreatNewPage("~/ScreenAccount/PageAccountUserLogOn.aspx");
                    return;
                }
                else
                {
                    userCode = Request.Cookies["YourJesterUserCode"].Value.ToString();
                    R9900DatabaseGetUserData();
                }
            }

            if (IsPostBack) return;

            R9910DatabaseGetUserPhoto();
            imageUserPhoto.ImageUrl = imageUrlAddress;
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0100LanguagePortuguese(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("1");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0110LanguageSpanish(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("2");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0120LanguageEnglish(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("3");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0130LanguageFrench(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("4");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0140LanguageGerman(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("5");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0150LanguageArabic(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("6");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0160LanguageJapanese(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("7");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0170LanguageChinese(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("8");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat language selected by user    
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0180LanguageItalian(object sender, ImageClickEventArgs e)
        {
            R0020TreatLanguageUser object01 = new R0020TreatLanguageUser();
            userCultureChange = object01.Routine0020TreatLanguageUser("9");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCultureChange);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCultureChange);

            Page.UICulture = userCultureChange;
            Page.Culture = userCultureChange;

            userLanguage = Session["sessionUserLanguage"].ToString();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageHome.aspx");
        }


        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user data from database and set session parameters to be used in the portal
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9900DatabaseGetUserData()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_master having code=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    HttpContext.Current.Session["sessionUserCode"] = databaseContainer.GetString("code");

                    if (databaseContainer["fullName"] == DBNull.Value)
                    {
                        HttpContext.Current.Session["sessionUserName"] = "*";
                        HttpContext.Current.Session["sessionuserBirthday"] = "*";
                        HttpContext.Current.Session["sessionuserBirthMonth"] = "*";
                        HttpContext.Current.Session["sessionuserBirthYear"] = "*";
                        HttpContext.Current.Session["sessionuserBirthHour"] = "*";
                        HttpContext.Current.Session["sessionuserBirthMinute"] = "*";
                        HttpContext.Current.Session["sessionuserBirthSecond"] = "*";
                        HttpContext.Current.Session["sessionuserFirstName"] = "*";
                        HttpContext.Current.Session["sessionuserMiddleName"] = "*";
                        HttpContext.Current.Session["sessionuserLastName"] = "*";
                    }
                    else
                    {
                        HttpContext.Current.Session["sessionUserName"] = databaseContainer.GetString("fullName");
                        HttpContext.Current.Session["sessionuserBirthday"] = databaseContainer.GetString("birthday");
                        HttpContext.Current.Session["sessionuserBirthMonth"] = databaseContainer.GetString("birthMonth");
                        HttpContext.Current.Session["sessionuserBirthYear"] = databaseContainer.GetString("birthYear");
                        HttpContext.Current.Session["sessionuserBirthHour"] = databaseContainer.GetString("birthHour");
                        HttpContext.Current.Session["sessionuserBirthMinute"] = databaseContainer.GetString("birthMinute");
                        HttpContext.Current.Session["sessionuserBirthSecond"] = databaseContainer.GetString("birthSecond");
                        HttpContext.Current.Session["sessionuserFirstName"] = databaseContainer.GetString("firstName");
                        HttpContext.Current.Session["sessionuserMiddleName"] = databaseContainer.GetString("middleName");
                        HttpContext.Current.Session["sessionuserLastName"] = databaseContainer.GetString("lastName");
                    }
                }
                else
                {
                    HttpContext.Current.Session["sessionUserCode"] = null;
                    HttpContext.Current.Session["sessionUserName"] = null;
                    HttpContext.Current.Session["sessionuserBirthday"] = null;
                    HttpContext.Current.Session["sessionuserBirthMonth"] = null;
                    HttpContext.Current.Session["sessionuserBirthYear"] = null;
                    HttpContext.Current.Session["sessionuserBirthHour"] = null;
                    HttpContext.Current.Session["sessionuserBirthMinute"] = null;
                    HttpContext.Current.Session["sessionuserBirthSecond"] = null;
                    HttpContext.Current.Session["sessionuserFirstName"] = null;
                    HttpContext.Current.Session["sessionuserMiddleName"] = null;
                    HttpContext.Current.Session["sessionuserLastName"] = null;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
            }

            finally
            {
                databaseConnection.Close();
                databaseConnection.Dispose();
                databaseCommand.Dispose();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user photo from database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9910DatabaseGetUserPhoto()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_master having code=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if (databaseContainer["photo"] is DBNull)
                    {
                        imageUrlAddress = "~/Images/Icons/smile.png";
                    }
                    else
                    {
                        byte[] counterBytes = (byte[])(databaseContainer["photo"]);

                        if (counterBytes != null)
                        {
                            string conversionBytes = Convert.ToBase64String(counterBytes, 0, counterBytes.Length);
                            imageUrlAddress = "data:image/jpeg;base64," + conversionBytes;
                        }
                        else
                        {
                            imageUrlAddress = "~/Images/Icons/smile.png";
                        }
                    }
                }
                else
                {
                    imageUrlAddress = "~/Images/Icons/smile.png";
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                imageUrlAddress = "~/Images/Icons/smile.png";
            }

            finally
            {
                databaseConnection.Close();
                databaseConnection.Dispose();
                databaseCommand.Dispose();
            }
        }
    }
}