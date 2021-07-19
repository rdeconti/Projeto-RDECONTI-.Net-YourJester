using System;
using System.Threading;
using System.Globalization;
using System.Web;
using YourJester.AppLogic;
using MySql.Data.MySqlClient;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat Step03: Several characteristics (values, temperaments, personality, fears, emotions ...) are
///                 explained to user, based on several horoscopes, numerology and angels. The user need to answer 
///                 if the characteristic is applicable or not to your life
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageStep03Questions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;

        public bool userPhase;

        public string databaseServer = "Server=localhost;Database=YourJester;Uid=rdeconti;Pwd=samsung";
        public MySqlConnection databaseConnection;

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat the culture and the language of this page. 
        ///                 Set session parameters to get data from database in the correct language. 
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected override void InitializeCulture()
        {
            if (Session["sessionUserCulture"] == null)
            {
                userCulture = Thread.CurrentThread.CurrentCulture.ToString();
            }
            else
            {
                userCulture = Session["sessionUserCulture"].ToString();
            }

            R0010TreatLanguageCurrent object01 = new R0010TreatLanguageCurrent();
            object01.Routine0010TreatLanguageCurrent(userCulture);

            userLanguage = Session["sessionUserLanguage"].ToString();

            Page.Culture = userCulture;
            Page.UICulture = userCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(userCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userCulture);

            base.InitializeCulture();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat Page_Load event triggered when a page loads.
        ///                 Use the Page.IsPostBack property to treat page load just in FIRST time that page is loaded
        ///                 Obtain the user photo and uploaded it in the page
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

            userLanguage = Session["sessionUserLanguage"].ToString();
            userCulture = Session["sessionUserCulture"].ToString();

            imageCodeImage1.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage2.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage3.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage4.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage5.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage6.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage7.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage8.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage9.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage10.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage11.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage12.ImageUrl = "~/Images/Icons/locked.jpg";
            imageCodeImage13.ImageUrl = "~/Images/Icons/locked.jpg";

            actionButton1.Enabled = false;
            actionButton2.Enabled = false;
            actionButton3.Enabled = false;
            actionButton4.Enabled = false;
            actionButton5.Enabled = false;
            actionButton6.Enabled = false;
            actionButton7.Enabled = false;
            actionButton8.Enabled = false;
            actionButton9.Enabled = false;
            actionButton10.Enabled = false;
            actionButton11.Enabled = false;
            actionButton12.Enabled = false;
            actionButton13.Enabled = false;

            R8000DatabaseCheckUserProgress(userCode, "03", "01");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "02");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "03");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "04");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "05");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "06");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "07");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "08");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "09");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;

                imageCodeImage9.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton9.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "10");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;

                imageCodeImage9.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton9.Enabled = true;

                imageCodeImage10.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton10.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "11");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;

                imageCodeImage9.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton9.Enabled = true;

                imageCodeImage10.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton10.Enabled = true;

                imageCodeImage11.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton11.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "12");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;

                imageCodeImage9.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton9.Enabled = true;

                imageCodeImage10.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton10.Enabled = true;

                imageCodeImage11.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton11.Enabled = true;

                imageCodeImage12.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton12.Enabled = true;
                return;
            }

            R8000DatabaseCheckUserProgress(userCode, "03", "14");

            if (!userPhase)
            {
                imageCodeImage1.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton1.Enabled = true;

                imageCodeImage2.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton2.Enabled = true;

                imageCodeImage3.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton3.Enabled = true;

                imageCodeImage4.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton4.Enabled = true;

                imageCodeImage5.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton5.Enabled = true;

                imageCodeImage6.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton6.Enabled = true;

                imageCodeImage7.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton7.Enabled = true;

                imageCodeImage8.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton8.Enabled = true;

                imageCodeImage9.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton9.Enabled = true;

                imageCodeImage10.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton10.Enabled = true;

                imageCodeImage11.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton11.Enabled = true;

                imageCodeImage12.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton12.Enabled = true;

                imageCodeImage13.ImageUrl = "~/Images/Icons/unlocked.jpg";
                actionButton13.Enabled = true;
                return;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user progress stage from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R8000DatabaseCheckUserProgress(string parameterUserCode, string parameterLevel01, string parameterLevel02)
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step00_progress WHERE usercode=@code and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@code", parameterUserCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", parameterLevel01);
                databaseCommand.Parameters.AddWithValue("@phase_level_2", parameterLevel02);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if (databaseContainer.GetString("questions") == databaseContainer.GetString("answers"))
                    {
                        userPhase = true;
                    }
                    else
                    {
                        userPhase = false;
                    }
                }
                else
                {
                    userPhase = false;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                userPhase = false;
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