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
/// Goal:           Treat Step04: Show to user the results from Enneagram test
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep04EnneagramResults : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;
        public string finalAnalysis;
        public string currentDate;        
        public string characteristicPositive;
        public string characteristicNegative;
        public string keyType;
        public string keyCode;
        public string fieldValue001 = "001";
        public string fieldValue002 = "002";
        public string fieldValueSpace = " ";
        public string fieldValueComma = ", ";
        public string valueType;
        public string triadNumber;

        public int counterCharacteristicsPositive;
        public int counterCharacteristicsNegative;
        public int counterCharacteristicsNeutral;
        public int counterCharacteristicsQuestions;
        public int valueTriadNumber;
        public int valueTypeNumber;
        public int counterCharacteristicsPositiveBefore;
        public int counterCharacteristicsNegativeBefore;
        public int counterCharacteristicsNeutralBefore;
        public int counterCharacteristicsQuestionsBefore;
        public int counterCharacteristicsPositiveAfter;
        public int counterCharacteristicsNegativeAfter;
        public int counterCharacteristicsNeutralAfter;
        public int counterCharacteristicsQuestionsAfter;
        public int counterIndex0;
        public int counterIndex1;
        public int counterIndex2;

        public int[] triadNumberValue;
        public int[] calculateTypeValues;

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

            triad.Text = "";
            name.Text = "";
            txtDescription.Text = "";
            profile.Text = "";
            good.Text = "";
            medium.Text = "";
            bad.Text = "";
            communication.Text = "";
            addiction.Text = "";
            virtue.Text = "";
            direction.Text = "";
            recommendation.Text = "";
            txtPositiveCharacteristics.Text = "";
            txtNegativeCharacteristics.Text = "";

            userCode = (Session["sessionUserCode"]).ToString();

            R0110DatabaseGetEnneagramResults();
            R0120DatabaseGetImage();
            R0130DatabaseGetEnneagramType();
            R0140DatabaseGetEnneagramTriad();
            R0150DatabaseGetPositiveCharacteristics();
            R0160DatabaseGetNegativeCharacteristics();
            R0175DatabaseSetUserProgressCompletion();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update enneagram results into database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0110DatabaseGetEnneagramResults()
        {
            triadNumberValue = new int[003];
            calculateTypeValues = new int[009];

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT * FROM users_step04_enneagramresults WHERE userCode = @userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    triadNumberValue[000] = databaseContainer.GetInt32("triad1");
                    triadNumberValue[001] = databaseContainer.GetInt32("triad2");
                    triadNumberValue[002] = databaseContainer.GetInt32("triad3");
                    calculateTypeValues[000] = databaseContainer.GetInt32("type1");
                    calculateTypeValues[001] = databaseContainer.GetInt32("type2");
                    calculateTypeValues[002] = databaseContainer.GetInt32("type3");
                    calculateTypeValues[003] = databaseContainer.GetInt32("type4");
                    calculateTypeValues[004] = databaseContainer.GetInt32("type5");
                    calculateTypeValues[005] = databaseContainer.GetInt32("type6");
                    calculateTypeValues[006] = databaseContainer.GetInt32("type7");
                    calculateTypeValues[007] = databaseContainer.GetInt32("type8");
                    calculateTypeValues[008] = databaseContainer.GetInt32("type9");
                }

                counterIndex0 = 0;
                valueTypeNumber = calculateTypeValues[000];

                while (counterIndex0 < 09)
                {
                    if (calculateTypeValues[counterIndex0] > valueTypeNumber)
                    {
                        if (valueTypeNumber < calculateTypeValues[counterIndex0])
                        {
                            valueTypeNumber = counterIndex0 + 1;
                        }
                    }

                    counterIndex0 = counterIndex0 + 1;
                }

                switch (valueTypeNumber)
                {
                    case 1:
                        valueTriadNumber = 3;
                        break;
                    case 2:
                        valueTriadNumber = 1;
                        break;
                    case 3:
                        valueTriadNumber = 1;
                        break;
                    case 4:
                        valueTriadNumber = 1;
                        break;
                    case 5:
                        valueTriadNumber = 2;
                        break;
                    case 6:
                        valueTriadNumber = 2;
                        break;
                    case 7:
                        valueTriadNumber = 2;
                        break;
                    case 8:
                        valueTriadNumber = 3;
                        break;
                    case 9:
                        valueTriadNumber = 3;
                        break;
                }

                valueType = valueTypeNumber.ToString();
                valueType = valueType.PadLeft(3, '0');
                keyCode = valueType.PadLeft(3, '0');

                triadNumber = valueTriadNumber.ToString();
                triadNumber = triadNumber.PadLeft(3, '0');
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Base on the code of oracle the portal get an image related with the code
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0120DatabaseGetImage()
        {
            imageCodeImage.ImageUrl = "~/Images/enneagram/Type_" + valueType + "_M.gif";
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get all data to enneagram type from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0130DatabaseGetEnneagramType()
        {
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_enneagram_types WHERE code=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", valueType);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    name.Text = databaseContainer.GetString("name");
                    txtDescription.Text = databaseContainer.GetString("description");
                    profile.Text = databaseContainer.GetString("profile");
                    good.Text = databaseContainer.GetString("good");
                    medium.Text = databaseContainer.GetString("medium");
                    bad.Text = databaseContainer.GetString("bad");
                    communication.Text = databaseContainer.GetString("communication");
                    addiction.Text = databaseContainer.GetString("addiction");
                    virtue.Text = databaseContainer.GetString("virtue");
                    direction.Text = databaseContainer.GetString("direction");
                    recommendation.Text = databaseContainer.GetString("recommendation");
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get triad name from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0140DatabaseGetEnneagramTriad()
        {
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_enneagram_triadas WHERE code=@type and language=@language";
                databaseCommand.Parameters.AddWithValue("@type", valueType);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    triad.Text = databaseContainer.GetString("name");
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Base on code of user get positive characteristics related with the data
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0150DatabaseGetPositiveCharacteristics()
        {
            try
            {
                keyType = fieldValue001.ToString();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step04_personality_enneagram_characteristics WHERE code=@code and type=@type";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    counterCharacteristicsPositive = counterCharacteristicsPositive + 1;

                    keyCode = databaseContainer.GetString("characteristic").ToString();
                    R0180DatabaseGetCharacteristicText();
                    R0190DatabaseUpdateUsersStep04Characteristics();
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Base on code of user get negative characteristics related with the data
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0160DatabaseGetNegativeCharacteristics()
        {
            try
            {
                keyType = fieldValue002.ToString();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step04_personality_enneagram_characteristics WHERE code=@code and type=@type";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    counterCharacteristicsNegative = counterCharacteristicsNegative + 1;

                    keyCode = databaseContainer.GetString("characteristic").ToString();
                    R0180DatabaseGetCharacteristicText();
                    R0190DatabaseUpdateUsersStep04Characteristics();
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update user database with the number of characteristics positive, negative and neutral
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0175DatabaseSetUserProgressCompletion()
        {
            R0050TreatDatetime object00 = new R0050TreatDatetime();
            currentDate = object00.Routine0050TreatDatetime();
            
            counterCharacteristicsNeutral = 0;
            counterCharacteristicsQuestions = counterCharacteristicsPositive + counterCharacteristicsNegative;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT * FROM users_step04results WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("phase02") == "N"))
                    {
                        counterCharacteristicsPositiveBefore = databaseContainer.GetInt32("positive");
                        counterCharacteristicsNegativeBefore = databaseContainer.GetInt32("negative");
                        counterCharacteristicsNeutralBefore = databaseContainer.GetInt32("neutral");
                        counterCharacteristicsQuestionsBefore = databaseContainer.GetInt32("questions");

                        counterCharacteristicsPositiveAfter = counterCharacteristicsPositiveBefore + counterCharacteristicsPositive;
                        counterCharacteristicsNegativeAfter = counterCharacteristicsNegativeBefore + counterCharacteristicsNegative;
                        counterCharacteristicsNeutralAfter = counterCharacteristicsNeutralBefore;
                        counterCharacteristicsQuestionsAfter = counterCharacteristicsQuestionsBefore + counterCharacteristicsQuestions;

                        databaseConnection.Close();
                        databaseConnection = new MySqlConnection(databaseServer);
                        databaseConnection.Open();

                        MySqlCommand databaseCommand01 = new MySqlCommand();

                        databaseCommand01.CommandText = "UPDATE users_step04results SET test_start=@test_start, positive=@positive, negative=@negative, neutral=@neutral, questions=@questions, phase02=@phase02 WHERE userCode=@userCode";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@test_start", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@test_finish", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@positive", counterCharacteristicsPositiveAfter);
                        databaseCommand01.Parameters.AddWithValue("@negative", counterCharacteristicsNegativeAfter);
                        databaseCommand01.Parameters.AddWithValue("@neutral", counterCharacteristicsNeutralAfter);
                        databaseCommand01.Parameters.AddWithValue("@questions", counterCharacteristicsQuestionsAfter);
                        databaseCommand01.Parameters.AddWithValue("@phase02", "Y");
                        databaseCommand01.Connection = databaseConnection;
                        databaseCommand01.ExecuteNonQuery();
                    }
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    MySqlCommand databaseCommand02 = new MySqlCommand();

                    databaseCommand02.CommandText = "INSERT INTO users_step04results (userCode, test_start, test_finish, positive, negative, neutral, questions, phase02) VALUES (@userCode, @test_start, @test_finish, @positive, @negative, @neutral, @questions, @phase02)";
                    databaseCommand02.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand02.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@positive", counterCharacteristicsPositive);
                    databaseCommand02.Parameters.AddWithValue("@negative", counterCharacteristicsNegative);
                    databaseCommand02.Parameters.AddWithValue("@neutral",counterCharacteristicsNeutral);
                    databaseCommand02.Parameters.AddWithValue("@questions", counterCharacteristicsQuestions);
                    databaseCommand02.Parameters.AddWithValue("@phase02", "Y");
                    databaseCommand02.Connection = databaseConnection;
                    databaseCommand02.ExecuteNonQuery();
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
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get characteristic name for each characterist code to show a resume to user about positive and negative
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0180DatabaseGetCharacteristicText()
        {
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT NAME FROM list_characteristics WHERE code=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if (keyType == fieldValue001)
                    {
                        characteristicPositive = databaseContainer.GetString("name").ToString();
                        txtPositiveCharacteristics.Text = characteristicPositive + fieldValueComma + txtPositiveCharacteristics.Text;
                    }
                    if (keyType == fieldValue002)
                    {
                        characteristicNegative = databaseContainer.GetString("name").ToString();
                        txtNegativeCharacteristics.Text = characteristicNegative + fieldValueComma + txtNegativeCharacteristics.Text;
                    }
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


            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update user data related with the option abouit each characteristic: positive, negative and neutral
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0190DatabaseUpdateUsersStep04Characteristics()
        {
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

                databaseCommand.CommandText = "SELECT * FROM users_Step04_characteristics WHERE userCode=@userCode and type=@type and characteristic=@characteristic";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Parameters.AddWithValue("@characteristic", keyCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (!databaseContainer.Read())
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_Step04_characteristics (userCode, type, characteristic) VALUES (@userCode, @type, @characteristic)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@type", keyType);
                    databaseCommand.Parameters.AddWithValue("@characteristic", keyCode);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
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
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

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
            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                MySqlCommand databaseCommand = new MySqlCommand();

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


            }
        }
    }
}