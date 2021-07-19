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
/// Goal:           Change data from user account
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageAccountUserChange : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userConfirmation;
        public string userEmail;
        public string userCode;
        public string imageUrlAddress;
        public string haveBeenEncrypted;
        public string currentDate;
        public string emailSubject;
        public string emailTo;
        public string emailBody;
        public string emailFrom;

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
        /// Goal:           Create user password in database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R1000DatabaseInsertUserPassword()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                R0050TreatDatetime object00 = new R0050TreatDatetime();
                currentDate = object00.Routine0050TreatDatetime();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "INSERT INTO users_password (code, password, creation, status, confirmationDate, confirmationCode) VALUES (@userCode, @password, @creation, @status, @confirmationDate, @confirmationCode)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@password", haveBeenEncrypted);
                databaseCommand.Parameters.AddWithValue("@creation", currentDate);
                databaseCommand.Parameters.AddWithValue("@status", "001");
                databaseCommand.Parameters.AddWithValue("@confirmationDate", currentDate);
                databaseCommand.Parameters.AddWithValue("@confirmationCode", userConfirmation);
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
        /// Goal:           Update password status to CANCELED into database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R1010DatabaseUpdatePasswordStatus()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "UPDATE users_password SET (status = @status) WHERE (code=@userCode and password=@password)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@password", haveBeenEncrypted);
                databaseCommand.Parameters.AddWithValue("@status", "003");
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
        /// Goal:           Use validator to check if user had LogOn the portal and in positive case the user is 
        ///                 able to change the password
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9190ValidatorLogOnDone(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (HttpContext.Current.Session["sessionUserCode"] == null)
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
        /// Goal:           Generate a code confirmation and send it to user by e-mail
        ///                 Encrypt OLD password and update database of passwords with CANCELED status
        ///                 Encrypt NEW password and update database of passwords with NEW status                 
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

            R0170TreatCodeConfirmation object01 = new R0170TreatCodeConfirmation();
            userConfirmation = object01.Routine0170TreatCodeConfirmation();

            R9235DatabaseGetUserEmail();

            var variable01 = HttpContext.GetGlobalResourceObject("Resources", "mailTextSubject001");
            emailSubject = variable01.ToString();

            var variable02 = HttpContext.GetGlobalResourceObject("Resources", "mailTextBody001");
            emailBody = variable02.ToString() + " " + txtUserCode + " " + txtNewUserPassword.Text + " " + userConfirmation;

            emailTo = userEmail;
            emailFrom = "YourJester2@gmail.com";

            R0160TreatSendEmail object03 = new R0160TreatSendEmail();
            object03.Routine0160TreatSendEmail(emailSubject, emailTo, emailFrom, emailBody);

            R0070TreatEncrypt object04 = new R0070TreatEncrypt();
            haveBeenEncrypted = object04.Routine0070TreatEncrypt(txtUserPassword.Text, "");
            
            R1010DatabaseUpdatePasswordStatus();

            R0070TreatEncrypt object06 = new R0070TreatEncrypt();
            haveBeenEncrypted = object06.Routine0070TreatEncrypt(txtConfirmUserPassword.Text, "");

            R1000DatabaseInsertUserPassword();

            args.IsValid = false;
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user e-mail from database by user code
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R9235DatabaseGetUserEmail()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_email WHERE code=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", txtUserCode.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    userEmail = databaseContainer.GetString("email").ToString();
                }
                else
                {
                    userEmail = null;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                userEmail = null;
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
