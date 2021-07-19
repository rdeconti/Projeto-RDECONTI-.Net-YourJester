using System;
using YourJester.AppLogic;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Web;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat Step01: The portal ask to user about basic life questions
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageStep01Questions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;
        public string currentDate;
        public string userFullName;
        public string userFirstName;
        public string userMiddleName;
        public string userLastName;
        public string userBirthday;
        public string userBirthMonth;
        public string userBirthYear;
        public string userBirthHour;
        public string userBirthMinute;
        public string userBirthSecond;
        public string userBirthCountry;
        public string userBirthRegion;
        public string userBirthCity;
        public string userLiveCountry;
        public string userLiveRegion;
        public string userLiveCity;
        public string userFieldOptionGender;
        public string userFieldOptionSexuality;
        public string userFieldOptionMaritalStatus;
        public string userFieldOptionSchooling;
        public string userFieldOptionWageRange;
        public string userFieldOptionOccupation;
        public string userFieldOptionLanguage;
        public string userFieldOptionReligion;
        public string userFieldOptionHobby;
        public string userFieldOptionSport;
        public string userFieldOptionCurrency;
        public string userFieldOptionSkinColour;

        public string progressBarPercentage;
        public string progressBarQuestions;
        public string progressBarAnswers;

        public string fieldValuePercentage = "%";

        public double progressBarTotalQuestions;
        public double progressBarTotalAnswers;

        public int progressBarTotalPercentage;
        public int counterQuestions;
        public int counterAnswers;

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

            R0110DatabaseGetUserMasterDataAll();
        }
        
        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Set user language and culture to be able to the portal get database information with correct language
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0040SetLanguageSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            userLanguage = Session["sessionUserLanguage"].ToString();
            userCulture = Session["sessionUserCulture"].ToString();

            Page.Culture = userCulture;
            Page.UICulture = userCulture;

            e.Command.Parameters["@parameterLanguage"].Value = userLanguage;
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Check all data informed by user and send messages in case of error
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0020UpdateClick(object sender, EventArgs e)
        {
            if (!IsValid) return;

            userCode = Session["sessionUserCode"].ToString();

            userFirstName = txtFirstName.Text;
            userMiddleName = txtMiddleName.Text;
            userLastName = txtLastName.Text;
            userFullName = txtFullName.Text;

            userBirthday = txtBirthday.Text;
            userBirthMonth = txtBirthMonth.Text;
            userBirthYear = txtBirthYear.Text;
            userBirthHour = txtBirthHour.Text;
            userBirthMinute = txtBirthMinute.Text;
            userBirthSecond = txtBirthSecond.Text;

            userBirthCountry = userOptionBirthCountry.SelectedValue.ToString();
            userBirthRegion = userOptionBirthRegion.SelectedValue.ToString();
            userBirthCity = userOptionBirthCity.SelectedValue.ToString();
            userLiveCountry = userOptionLiveCountry.SelectedValue.ToString();
            userLiveRegion = userOptionLiveRegion.SelectedValue.ToString();
            userLiveCity = userOptionLiveCity.SelectedValue.ToString();

            userFieldOptionGender = userOptionGender.SelectedValue.ToString();
            userFieldOptionSexuality = userOptionSexuality.SelectedValue.ToString();
            userFieldOptionMaritalStatus = userOptionMaritalStatus.SelectedValue.ToString();
            userFieldOptionSchooling = userOptionSchooling.SelectedValue.ToString();
            userFieldOptionWageRange = userOptionWageRange.SelectedValue.ToString();
            userFieldOptionCurrency = userOptionCurrency.SelectedValue.ToString();
            userFieldOptionOccupation = userOptionOccupation.SelectedValue.ToString();
            userFieldOptionLanguage = userOptionLanguage.SelectedValue.ToString();
            userFieldOptionReligion = userOptionReligion.SelectedValue.ToString();
            userFieldOptionHobby = userOptionHobby.SelectedValue.ToString();
            userFieldOptionSport = userOptionSport.SelectedValue.ToString();

            R0140DatabaseUpdateUsersMasterData();
            R0310DatabaseUpdateUserProgress();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user data information from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0110DatabaseGetUserMasterDataAll()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_master WHERE code=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    txtFirstName.Text = databaseContainer.GetString("firstName").ToString();
                    txtMiddleName.Text = databaseContainer.GetString("middleName").ToString();
                    txtLastName.Text = databaseContainer.GetString("lastName").ToString();
                    txtFullName.Text = databaseContainer.GetString("fullName").ToString();
                    txtBirthday.Text = databaseContainer.GetString("birthday").ToString();
                    txtBirthMonth.Text = databaseContainer.GetString("birthMonth").ToString();
                    txtBirthYear.Text = databaseContainer.GetString("birthYear").ToString();
                    txtBirthHour.Text = databaseContainer.GetString("birthHour").ToString();
                    txtBirthMinute.Text = databaseContainer.GetString("birthMinute").ToString();
                    txtBirthSecond.Text = databaseContainer.GetString("birthSecond").ToString();
                    userOptionBirthCountry.SelectedValue = databaseContainer.GetString("BirthCountry").ToString();
                    userOptionBirthRegion.SelectedValue = databaseContainer.GetString("BirthRegion").ToString();
                    userOptionBirthCity.SelectedValue = databaseContainer.GetString("BirthCity").ToString();
                    userOptionLiveCountry.SelectedValue = databaseContainer.GetString("LiveCountry").ToString();
                    userOptionLiveRegion.SelectedValue = databaseContainer.GetString("LiveRegion").ToString();
                    userOptionLiveCity.SelectedValue = databaseContainer.GetString("LiveCity").ToString();
                    userOptionGender.SelectedValue = databaseContainer.GetString("gender").ToString();
                    userOptionSexuality.SelectedValue = databaseContainer.GetString("sexuality").ToString();
                    userOptionMaritalStatus.SelectedValue = databaseContainer.GetString("maritalstatus").ToString();
                    userOptionLanguage.SelectedValue = databaseContainer.GetString("language").ToString();
                    userOptionSchooling.SelectedValue = databaseContainer.GetString("scholarity").ToString();
                    userOptionReligion.SelectedValue = databaseContainer.GetString("religion").ToString();
                    userOptionHobby.SelectedValue = databaseContainer.GetString("hobby").ToString();
                    userOptionSport.SelectedValue = databaseContainer.GetString("sport").ToString();
                    userOptionOccupation.SelectedValue = databaseContainer.GetString("occupation").ToString();
                    userOptionWageRange.SelectedValue = databaseContainer.GetString("wage").ToString();
                    userOptionCurrency.SelectedValue = databaseContainer.GetString("currency").ToString();
                    userOptionSkinColour.SelectedValue = databaseContainer.GetString("skinColour").ToString();
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update database with user data
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0140DatabaseUpdateUsersMasterData()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "UPDATE users_master SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, FullName = @fullName, Birthday = @birthday, BirthMonth = @birthMonth, BirthYear = @birthYear, BirthHour = @birthHour, BirthMinute = @birthMinute, BirthSecond = @birthSecond, BirthCountry = @BirthCountry, BirthRegion = @BirthRegion, BirthCity = @BirthCity, LiveCountry = @LiveCountry, LiveRegion = @LiveRegion, LiveCity = @LiveCity, Gender = @gender, Sexuality = @sexuality, MaritalStatus = @maritalstatus, Language = @language, scholarity = @Schooling, Religion = @religion, Hobby = @hobby, Sport = @sport, Occupation = @occupation, wage = @wage, Currency = @currency, SkinColour = @SkinColour WHERE (code = @userCode)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@FirstName", userFirstName);
                databaseCommand.Parameters.AddWithValue("@MiddleName", userMiddleName);
                databaseCommand.Parameters.AddWithValue("@LastName", userLastName);
                databaseCommand.Parameters.AddWithValue("@FullName", userFullName);
                databaseCommand.Parameters.AddWithValue("@Birthday", userBirthday);
                databaseCommand.Parameters.AddWithValue("@BirthMonth", userBirthMonth);
                databaseCommand.Parameters.AddWithValue("@BirthYear", userBirthYear);
                databaseCommand.Parameters.AddWithValue("@BirthHour", userBirthHour);
                databaseCommand.Parameters.AddWithValue("@BirthMinute", userBirthMinute);
                databaseCommand.Parameters.AddWithValue("@BirthSecond", userBirthSecond);
                databaseCommand.Parameters.AddWithValue("@BirthCountry", userBirthCountry);
                databaseCommand.Parameters.AddWithValue("@BirthRegion", userBirthRegion);
                databaseCommand.Parameters.AddWithValue("@BirthCity", userBirthCity);
                databaseCommand.Parameters.AddWithValue("@LiveCountry", userLiveCountry);
                databaseCommand.Parameters.AddWithValue("@LiveRegion", userLiveRegion);
                databaseCommand.Parameters.AddWithValue("@LiveCity", userLiveCity);
                databaseCommand.Parameters.AddWithValue("@Gender", userFieldOptionGender);
                databaseCommand.Parameters.AddWithValue("@Sexuality", userFieldOptionSexuality);
                databaseCommand.Parameters.AddWithValue("@MaritalStatus", userFieldOptionMaritalStatus);
                databaseCommand.Parameters.AddWithValue("@Schooling", userFieldOptionSchooling);
                databaseCommand.Parameters.AddWithValue("@Wage", userFieldOptionWageRange);
                databaseCommand.Parameters.AddWithValue("@Currency", userFieldOptionCurrency);
                databaseCommand.Parameters.AddWithValue("@Occupation", userFieldOptionOccupation);
                databaseCommand.Parameters.AddWithValue("@Language", userFieldOptionLanguage);
                databaseCommand.Parameters.AddWithValue("@Religion", userFieldOptionReligion);
                databaseCommand.Parameters.AddWithValue("@Hobby", userFieldOptionHobby);
                databaseCommand.Parameters.AddWithValue("@Sport", userFieldOptionSport);
                databaseCommand.Parameters.AddWithValue("@SkinColour", userFieldOptionSkinColour);
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
        /// Goal:           Get user data progress realated with the portal step and determine how to update database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0310DatabaseUpdateUserProgress()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            R0050TreatDatetime object00 = new R0050TreatDatetime();
            currentDate = object00.Routine0050TreatDatetime();

            counterAnswers = Convert.ToInt32(progressBarTotalAnswers);
            counterQuestions = Convert.ToInt32(progressBarTotalQuestions);

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step00_progress WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "02");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "01");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if (counterAnswers == counterQuestions)
                    {
                        R0311DatabaseUpdateUserProgress();
                    }
                    else
                    {
                        R0312DatabaseUpdateUserProgress();
                    }
                }
                else
                {
                    R0313DatabaseUpdateUserProgress();
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
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get user data progress realated with the portal step and determine how to update database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0311DatabaseUpdateUserProgress()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "UPDATE users_step00_progress SET finishdate=@finishdate, questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "02");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "01");
                databaseCommand.Parameters.AddWithValue("@finishdate", currentDate);
                databaseCommand.Parameters.AddWithValue("@questions", counterQuestions);
                databaseCommand.Parameters.AddWithValue("@answers", counterAnswers);
                databaseCommand.Parameters.AddWithValue("@agree", counterAnswers);
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
        /// Goal:           Get user data progress realated with the portal step and determine how to update database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0312DatabaseUpdateUserProgress()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "UPDATE users_step00_progress SET questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "02");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "01");
                databaseCommand.Parameters.AddWithValue("@questions", counterQuestions);
                databaseCommand.Parameters.AddWithValue("@answers", counterAnswers);
                databaseCommand.Parameters.AddWithValue("@agree", counterAnswers);
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
        /// Goal:           Get user data progress realated with the portal step and determine how to update database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0313DatabaseUpdateUserProgress()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "INSERT INTO users_step00_progress (userCode, phase_level_1, phase_level_2, startdate, finishdate, questions, answers, agree) VALUES (@userCode, @phase_level_1, @phase_level_2, @startdate, @finishdate, @questions, @answers, @agree)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "02");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "01");
                databaseCommand.Parameters.AddWithValue("@startdate", currentDate);
                databaseCommand.Parameters.AddWithValue("@finishdate", currentDate);
                databaseCommand.Parameters.AddWithValue("@questions", counterQuestions);
                databaseCommand.Parameters.AddWithValue("@answers", counterAnswers);
                databaseCommand.Parameters.AddWithValue("@agree", counterAnswers);
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

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9000ValidatorFirstName(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtFirstName.Text == null)
            {
                args.IsValid = false;
                CustomValidator1.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator1.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9010ValidatorMiddleName(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtMiddleName.Text == null)
            {
                args.IsValid = false;
                CustomValidator2.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator2.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9020ValidatorLastName(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtLastName.Text == null)
            {
                args.IsValid = false;
                CustomValidator3.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator3.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 


        protected void R9030ValidatorFullName(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtFullName.Text == null)
            {
                args.IsValid = false;
                CustomValidator4.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator4.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9040ValidatorTextBirthday(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthday.Text == null)
            {
                args.IsValid = false;
                CustomValidator5.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator5.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 
 
        protected void R9050ValidatorTextBirthMonth(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthMonth.Text == null)
            {
                args.IsValid = false;
                CustomValidator6.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator6.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9060ValidatorTextBirthYear(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthYear.Text == null)
            {
                args.IsValid = false;
                CustomValidator7.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator7.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9070ValidatorTextBirthHour(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthHour.Text == null)
            {
                args.IsValid = false;
                CustomValidator8.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator8.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9080ValidatorTextBirthMinute(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthMinute.Text == null)
            {
                args.IsValid = false;
                CustomValidator9.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator9.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 


        protected void R9090ValidatorTextBirthSecond(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (txtBirthSecond.Text == null)
            {
                args.IsValid = false;
                CustomValidator10.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator10.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9100ValidatorUserOptionBirthCountry(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionBirthCountry.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator11.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator11.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9110ValidatorUserOptionBirthRegion(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionBirthRegion.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator12.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator12.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9120ValidatorUserOptionBirthCity(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionBirthCity.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator13.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator13.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 
        
        protected void R9130ValidatorUserOptionLiveCountry(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionLiveCountry.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator14.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator14.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9140ValidatorUserOptionLiveRegion(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionLiveRegion.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator15.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator15.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9150ValidatorUserOptionLiveCity(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionLiveCity.SelectedValue == "0")
            {
                args.IsValid = false;
                CustomValidator16.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator16.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9160ValidatorUserOptionGender(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionGender.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator17.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator17.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9170ValidatorUserOptionSexuality(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionSexuality.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator23.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator23.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9180ValidatorUserOptionSkinColour(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionSkinColour.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator24.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator24.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9190ValidatorUserOptionMaritalStatus(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionMaritalStatus.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator25.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator25.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9200ValidatorUserOptionSchooling(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionSchooling.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator19.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator19.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9210ValidatorUserOptionOccupation(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionOccupation.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator20.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator20.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9220ValidatorUserOptionWageRange(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionWageRange.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator21.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator21.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9230ValidatorUserOptionCurrency(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionCurrency.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator22.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator22.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9240ValidatorUserOptionLanguage(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionLanguage.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator26.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator26.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9250ValidatorUserOptionReligion(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionReligion.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator27.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator27.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9260ValidatorUserOptionHobby(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionHobby.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator28.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator28.Text = "".ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Use validator to check if field was informed by user and if the informatio is valid
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R9110ValidatorUserOptionSport(object source, ServerValidateEventArgs args)
        {
            if (!IsValid) return;

            if (userOptionHobby.SelectedValue == "000")
            {
                args.IsValid = false;
                CustomValidator18.Text = HttpContext.GetGlobalResourceObject("Resources", "messageCode031").ToString();
            }
            else
            {
                args.IsValid = true;
                CustomValidator18.Text = "".ToString();
            }
        }
    }
}
