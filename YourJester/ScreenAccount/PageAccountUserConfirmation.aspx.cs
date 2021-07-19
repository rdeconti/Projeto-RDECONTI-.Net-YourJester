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
/// Goal:           Update user database password with data of account confirmation in case that confirmation code 
///                 informed by user is equal to confirmation code registered in portal database
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageAccountUserConfirmation : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userConfirmationCode;
        public string userCode;
        public string imageUrlAddress;
        public string LogOnAttempt2;
        public string toBeEncrypted;
        public string haveBeenEncrypted;
        public string emailSubject;
        public string emailTo;
        public string emailBody;
        public string logOnCorrect;
        public string logOnIncorrect;
        public string currentDate;
        public string userNumberAddress;

        public bool returnUserCode;
        public bool returnPassword;

        public int LogOnAttempt;

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
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update user confirmation date into database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R1010DatabaseUpdateConfirmationDate()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                R0050TreatDatetime object00 = new R0050TreatDatetime();
                currentDate = object00.Routine0050TreatDatetime();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "UPDATE users_password SET confirmationDate = @confirmationDate WHERE code=@userCode and password=@password";
                databaseCommand.Parameters.AddWithValue("@userCode", txtUserCode.Text);
                databaseCommand.Parameters.AddWithValue("@password", haveBeenEncrypted);
                databaseCommand.Parameters.AddWithValue("@confirmationDate", currentDate);
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
        /// Goal:           Use validator to check if the number of failed attempts LogON was not reached by user
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9190ValidatorLogOnAttempts(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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

            R0070TreatEncrypt object01 = new R0070TreatEncrypt();
            haveBeenEncrypted = object01.Routine0070TreatEncrypt(txtUserPassword.Text, "");

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
        /// Goal:           Use validator to check if the user already confirmed your account
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9215DatabaseValidatorGetConfirmationCode(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            R0070TreatEncrypt object01 = new R0070TreatEncrypt();
            haveBeenEncrypted = object01.Routine0070TreatEncrypt(txtUserPassword.Text, "");

            R9220DatabaseGetUserConfirmation();

            if (userConfirmationCode == txtUserCodeConfirmation.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user confirmation code from database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9220DatabaseGetUserConfirmation()
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
                    userConfirmationCode = databaseContainer.GetString("ConfirmationCode").ToString();
                }
                else
                {
                    userConfirmationCode = null;
                }

            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                userConfirmationCode = null;
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
        /// Goal:           Update confirmation date into database
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
            cookieuserCode.Value = txtUserCode.ToString();
            cookieuserCode.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookieuserCode);

            R1000DatabaseInsertLogOnAttempts("OK");

            R1010DatabaseUpdateConfirmationDate();

            args.IsValid = false;
        }
    }
}