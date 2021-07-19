using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Update user account database with LogOn informations
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageAccountUserLogOn : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userConfirmation;
        public string userCode;
        public string imageUrlAddress;
        public string cookiesUserCode;
        public string toBeEncrypted;
        public string haveBeenEncrypted;
        public string logOnCorrect;
        public string logOnIncorrect;
        public string currentDate;
        public string userNumberAddress;

        public int LogOnAttempt;

        public bool returnConfirmation;
        public bool returnUserCode;
        public bool returnPassword;

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
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update password database with LogOn information
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R1000DatabaseInsertLogOnAttempts(string valueLogOnAttempt)
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                R0050TreatDatetime object00 = new R0050TreatDatetime();
                currentDate = object00.Routine0050TreatDatetime();

                if (valueLogOnAttempt == "OK")
                {
                    logOnCorrect = "X";
                    logOnIncorrect = " ";
                }
                else
                {
                    logOnCorrect = " ";
                    logOnIncorrect = "X";
                }

                userNumberAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (userNumberAddress == null)
                {
                    userNumberAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "INSERT INTO users_login (code, last_login, login_correct, login_incorrect, ipnumber) VALUES (@code, @login_datetime, @login_correct, @login_incorrect, @ip_address)";
                databaseCommand.Parameters.AddWithValue("@code", txtUserCode.Text);
                databaseCommand.Parameters.AddWithValue("@login_datetime", currentDate);
                databaseCommand.Parameters.AddWithValue("@login_correct", logOnCorrect);
                databaseCommand.Parameters.AddWithValue("@login_incorrect", logOnIncorrect);
                databaseCommand.Parameters.AddWithValue("@ip_address", userNumberAddress);
                databaseCommand.Connection = databaseConnection;
                databaseCommand.ExecuteNonQuery();
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if user code informed by user already exists in database
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9130ValidatorUserCodeExists(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R9135DatabaseCheckUserCode();

            if (!returnUserCode)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Check if user informed a user code that exists in database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9135DatabaseCheckUserCode()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_password WHERE code=@userCode";    
                databaseCommand.Parameters.AddWithValue("@userCode", txtUserCode.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    returnUserCode = true;
                }
                else
                {
                    returnUserCode = false;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                returnUserCode = false;
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if lenght of password informed by user is valid
        ///                 password lenght MUST be betweeen minimun and maximun
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9140ValidatorPasswordLength(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0130TreatLength object01 = new R0130TreatLength();
            bool returnLength = object01.Routine0130TreatLength(txtUserPassword.Text, 05, 10);

            if (!returnLength)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if password informed by user is valid
        ///                 password MUST have at least one letter (upper or lower)
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9150ValidatorPasswordLetters(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0090TreatLetters object01 = new R0090TreatLetters();
            bool returnLetters = object01.Routine0090TreatLetters(txtUserPassword.Text);

            if (!returnLetters)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if password informed by user is valid
        ///                 password MUST have at least one digit
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9160ValidatorPasswordDigits(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0100TreatNumbers object01 = new R0100TreatNumbers();
            bool returnNumbers = object01.Routine0100TreatNumbers(txtUserPassword.Text);

            if (!returnNumbers)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if password informed by user is valid
        ///                 password MUST have at least one special character
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9170ValidatorPasswordSpecial(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0120TreatSpecials object01 = new R0120TreatSpecials();
            bool returnSpecials = object01.Routine0120TreatSpecials(txtUserPassword.Text);

            if (!returnSpecials)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if password informed by user is valid
        ///                 password CAN NOT HAVE more that limited repeated characteres
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9180ValidatorPasswordRepeated(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0110TreatRepetition object01 = new R0110TreatRepetition();
            bool returnRepetition = object01.Routine0110TreatRepetition(txtUserPassword.Text);

            if (!returnRepetition)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if the number of LogOn attempts was not reached and the user is blocked
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9190ValidatorPasswordAttempts(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R9195DatabaseGetLogOnAttempts();

            R0180TreatLogOnAttempts object02 = new R0180TreatLogOnAttempts();
            bool returnAttempts = object02.Routine0180TreatLogOnAttempts(LogOnAttempt);

            if (!returnAttempts)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get number of incorrect LogOn done by user from database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9195DatabaseGetLogOnAttempts()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_login having code=@userCode and login_incorrect = @login_incorrect";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@login_incorrect", "X");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                LogOnAttempt = 0;

                while (databaseContainer.Read())
                {
                    logOnIncorrect = databaseContainer.GetString("login_incorrect").ToString();

                    if (logOnIncorrect == "X")
                    {
                        LogOnAttempt = LogOnAttempt + 1;
                    }
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                LogOnAttempt = 0;
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if the user already confirmed the account
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9200ValidatorPasswordConfirmed(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0070TreatEncrypt object01 = new R0070TreatEncrypt();
            haveBeenEncrypted = object01.Routine0070TreatEncrypt(txtUserPassword.Text, "");

            R9205DatabaseCheckUserConfirmation();

            if (!returnConfirmation)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Check in database if the user already have done the confirmation of account
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9205DatabaseCheckUserConfirmation()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_password WHERE code=@userCode and password=@password";
                databaseCommand.Parameters.AddWithValue("@userCode", txtUserCode.Text);
                databaseCommand.Parameters.AddWithValue("@password", haveBeenEncrypted);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if (databaseContainer["confirmationDate"] != DBNull.Value)
                    {
                        returnConfirmation = true;
                    }
                    else
                    {
                        returnConfirmation = false;
                    }
                }
                else
                {
                    returnConfirmation = false;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                returnConfirmation = false;
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if password informed by user belongs to user
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9210ValidatorPasswordNotValid(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R9215DatabaseCheckUserPassword();

            if (!returnPassword)
            {
                R1000DatabaseInsertLogOnAttempts("NOK");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Check if user password is already into database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9215DatabaseCheckUserPassword()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_password WHERE code=@userCode and password=@password";
                databaseCommand.Parameters.AddWithValue("@userCode", txtUserCode.Text);
                databaseCommand.Parameters.AddWithValue("@password", haveBeenEncrypted);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    returnPassword = true;
                }
                else
                {
                    returnPassword = false;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                returnPassword = false;
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Save cookie with usercode
        ///                 Update database with the LogOn data
        ///                 Execute the routine just in case that there is no previous error
        ///                 Set validator with NO errors found
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9230ValidatorUpdateDatabase(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            HttpCookie cookieuserCode = new HttpCookie("YourJesterUserCode");
            cookieuserCode.Value = txtUserCode.Text.ToString();
            cookieuserCode.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookieuserCode);

            R1000DatabaseInsertLogOnAttempts("OK");

            R9900DatabaseGetUserData();

            R0030TreatNewPage object03 = new R0030TreatNewPage();
            object03.Routine0030TreatNewPage("~/PagePanel.aspx");

            args.IsValid = false;
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