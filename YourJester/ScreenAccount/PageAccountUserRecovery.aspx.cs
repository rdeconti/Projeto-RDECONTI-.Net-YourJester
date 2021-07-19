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
/// Goal:           Update user account database with recovery password information
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageAccountUserRecovery : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string userConfirmation;
        public string userPassword;
        public string imageUrlAddress;
        public string generatedPassword;
        public string toBeEncrypted;
        public string haveBeenEncrypted;
        public string currentDate;
        public string emailSubject;
        public string emailTo;
        public string emailBody;
        public string emailFrom;

        public bool userMail;

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
        /// Creation:	    June 2015
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user password ACTIVE from database
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R1020DatabaseGetPassword()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_password WHERE code=@userCode and status=@status";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@status", "001");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    userPassword = databaseContainer.GetString("password").ToString();
                }
                else
                {
                    userPassword = null;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                userPassword = null;
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
        /// Goal:           Use validator to check if email informed by user belongs to user
        ///                 Execute the routine just in case that there is no previous error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9140ValidatorDatabaseCheckUserEmail(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userMail)
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
        /// Goal:           Get user code from database by e-mail address
        /// *********************************************************************************************************************
        /// Maintenance:    dd/mm/yyyy
        /// Author:	    	name
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R914DatabaseGetUserCode()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_email WHERE email=@email";
                databaseCommand.Parameters.AddWithValue("@email", txtUserEmail);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    userMail = true;
                }
                else
                {
                    userMail = false;
                }
            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
                userMail = false;
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

            R1020DatabaseGetPassword();

            R0070TreatEncrypt object02 = new R0070TreatEncrypt();
            haveBeenEncrypted = object02.Routine0070TreatEncrypt(userPassword, "");

            R1010DatabaseUpdatePasswordStatus();

            R0170TreatCodeConfirmation object04 = new R0170TreatCodeConfirmation();
            userConfirmation = object04.Routine0170TreatCodeConfirmation();

            generatedPassword = userConfirmation.Replace("0", "$");
            generatedPassword = userConfirmation.Replace("1", "%");
            generatedPassword = userConfirmation.Replace("2", "#");
            generatedPassword = userConfirmation.Replace("3", "&");
            generatedPassword = userConfirmation.Replace("4", "$");
            generatedPassword = userConfirmation.Replace("5", "%");
            generatedPassword = userConfirmation.Replace("6", "#");
            generatedPassword = userConfirmation.Replace("7", "&");
            generatedPassword = userConfirmation.Replace("8", "*");
            generatedPassword = userConfirmation.Replace("9", "*");

            R0070TreatEncrypt object05 = new R0070TreatEncrypt();
            haveBeenEncrypted = object05.Routine0070TreatEncrypt(generatedPassword, "");

            R1000DatabaseInsertUserPassword();

            var variable01 = HttpContext.GetGlobalResourceObject("Resources", "mailTextSubject001");
            emailSubject = variable01.ToString();

            var variable02 = HttpContext.GetGlobalResourceObject("Resources", "mailTextBody001");
            emailBody = variable02.ToString() + " " + userCode + " " + userPassword + " " + userConfirmation;

            emailTo = txtUserEmail.Text.ToString();
            emailFrom = "YourJester2@gmail.com";

            R0160TreatSendEmail object07 = new R0160TreatSendEmail();
            object07.Routine0160TreatSendEmail(emailSubject, emailTo, emailFrom, emailBody);

            args.IsValid = false;
        }
    }
}