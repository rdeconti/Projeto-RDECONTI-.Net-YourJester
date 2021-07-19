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
/// Goal:           Treat Step04: Show to user the results from CPS test
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep04CpsResults : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;
        public string finalAnalysis;
        public string currentDate;
        public string calculatePercentage;
        public string descriptionText;
        public string characteristicPositive;
        public string characteristicNegative;
        public string keyType;
        public string keyCode;
        public string fieldValue001 = "001";
        public string fieldValue002 = "002";
        public string fieldValueComma = ", ";
        public string valueNumber;
        public string rangeNumber;
        public string rangeName;
        public string triadNumber;

        public int counterCharacteristicsPositive;
        public int counterCharacteristicsNegative;
        public int counterCharacteristicsNeutral;
        public int counterCharacteristicsQuestions;
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
        public int valueTypeNumber;
        public int calculatePercentageValue;

        public int[] calculateTypeValues;
        public int[] calculatePercentageValues;

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

            typeRangeNumber1.Text = "";
            typeResult1.Text = "";
            typeDescription1.Text = "";
            typeRangeNumber2.Text = "";
            typeResult2.Text = "";
            typeDescription2.Text = "";
            typeRangeNumber3.Text = "";
            typeResult3.Text = "";
            typeDescription3.Text = "";
            typeRangeNumber4.Text = "";
            typeResult4.Text = "";
            typeDescription4.Text = "";
            typeRangeNumber5.Text = "";
            typeResult5.Text = "";
            typeDescription5.Text = "";
            typeRangeNumber6.Text = "";
            typeResult6.Text = "";
            typeDescription6.Text = "";
            typeRangeNumber7.Text = "";
            typeResult7.Text = "";
            typeDescription7.Text = "";
            typeRangeNumber8.Text = "";
            typeResult8.Text = "";
            typeDescription8.Text = "";
            typeRangeNumber9.Text = "";
            typeResult9.Text = "";
            typeDescription9.Text = "";
            typeRangeNumber10.Text = "";
            typeResult10.Text = "";
            typeDescription10.Text = "";
            txtPositiveCharacteristics.Text = "";
            txtNegativeCharacteristics.Text = "";

            userCode = (Session["sessionUserCode"]).ToString();

            R0110DatabaseGetResults();
            R0120DatabaseGetImage();
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
        /// Goal:           Get user answers from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0110DatabaseGetResults()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            calculateTypeValues = new int[010];
            calculatePercentageValues = new int[010];

            calculateTypeValues[000] = 0;
            calculateTypeValues[001] = 0;
            calculateTypeValues[002] = 0;
            calculateTypeValues[003] = 0;
            calculateTypeValues[004] = 0;
            calculateTypeValues[005] = 0;
            calculateTypeValues[006] = 0;
            calculateTypeValues[007] = 0;
            calculateTypeValues[008] = 0;
            calculateTypeValues[009] = 0;

            calculatePercentageValues[000] = 0;
            calculatePercentageValues[001] = 0;
            calculatePercentageValues[002] = 0;
            calculatePercentageValues[003] = 0;
            calculatePercentageValues[004] = 0;
            calculatePercentageValues[005] = 0;
            calculatePercentageValues[006] = 0;
            calculatePercentageValues[007] = 0;
            calculatePercentageValues[008] = 0;
            calculatePercentageValues[009] = 0;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Cpsresults WHERE userCode = @userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    calculateTypeValues[000] = databaseContainer.GetInt32("type_01");
                    calculateTypeValues[001] = databaseContainer.GetInt32("type_02");
                    calculateTypeValues[002] = databaseContainer.GetInt32("type_03");
                    calculateTypeValues[003] = databaseContainer.GetInt32("type_04");
                    calculateTypeValues[004] = databaseContainer.GetInt32("type_05");
                    calculateTypeValues[005] = databaseContainer.GetInt32("type_06");
                    calculateTypeValues[006] = databaseContainer.GetInt32("type_07");
                    calculateTypeValues[007] = databaseContainer.GetInt32("type_08");
                    calculateTypeValues[008] = databaseContainer.GetInt32("type_09");
                    calculateTypeValues[009] = databaseContainer.GetInt32("type_10");
                }

                if (calculateTypeValues[000] != 0)
                {
                    valueNumber = calculateTypeValues[000].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("001", valueNumber);
                }

                if (calculateTypeValues[001] != 0)
                {
                    valueNumber = calculateTypeValues[001].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("002", valueNumber);
                }

                if (calculateTypeValues[002] != 0)
                {
                    valueNumber = calculateTypeValues[002].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("003", valueNumber);
                }

                if (calculateTypeValues[003] != 0)
                {
                    valueNumber = calculateTypeValues[003].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("004", valueNumber);
                }

                if (calculateTypeValues[004] != 0)
                {
                    valueNumber = calculateTypeValues[004].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("005", valueNumber);
                }
                if (calculateTypeValues[005] != 0)
                {
                    valueNumber = calculateTypeValues[005].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("006", valueNumber);
                }
                if (calculateTypeValues[006] != 0)
                {
                    valueNumber = calculateTypeValues[006].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("007", valueNumber);
                }
                if (calculateTypeValues[007] != 0)
                {
                    valueNumber = calculateTypeValues[007].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("008", valueNumber);
                }
                if (calculateTypeValues[008] != 0)
                {
                    valueNumber = calculateTypeValues[008].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("009", valueNumber);
                }
                if (calculateTypeValues[009] != 0)
                {
                    valueNumber = calculateTypeValues[009].ToString();
                    valueNumber = valueNumber.PadLeft(3, '0');
                    R0200DatabaseGetPercentage("010", valueNumber);
                }

                counterIndex0 = 0;
                calculatePercentageValue = calculatePercentageValues[000];

                while (counterIndex0 < 10)
                {
                    if (calculatePercentageValues[counterIndex0] > calculatePercentageValue)
                    {
                        if (calculatePercentageValue < calculatePercentageValues[counterIndex0])
                        {
                            valueTypeNumber = counterIndex0 + 1;
                        }
                    }

                    counterIndex0 = counterIndex0 + 1;
                }

                keyCode = valueTypeNumber.ToString();
                keyCode = keyCode.PadLeft(3, '0');
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
        /// Goal:           Base on the code of oracle the portal get an image related with the code
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0120DatabaseGetImage()
        {
            imageCodeImage.ImageUrl = "../Images/Cps/" + keyCode + ".jpg";
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get type description from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0130DatabaseGetType(string valueType)
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Cps_types WHERE code=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", valueType);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    descriptionText = databaseContainer.GetString("description").ToString();
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
        /// Goal:           Get range name from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0140DatabaseGetRangeNumber()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_CpsrangeNumbers WHERE code=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", rangeNumber);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    rangeName = databaseContainer.GetString("name");
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
        /// Goal:           Base on code of user get positive characteristics related with the data
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0150DatabaseGetPositiveCharacteristics()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                keyType = fieldValue001.ToString();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step04_personality_Cps_characteristics WHERE code=@code and type=@type";
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
                databaseCommand.Dispose();
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
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                keyType = fieldValue002.ToString();

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step04_personality_Cps_characteristics WHERE code=@code and type=@type";
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
                databaseCommand.Dispose();
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
            MySqlCommand databaseCommand = new MySqlCommand();

            R0050TreatDatetime object00 = new R0050TreatDatetime();
            currentDate = object00.Routine0050TreatDatetime();
            
            counterCharacteristicsNeutral = 0;
            counterCharacteristicsQuestions = counterCharacteristicsPositive + counterCharacteristicsNegative;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04results WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("phase01") == "N"))
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

                        databaseCommand01.CommandText = "UPDATE users_step04results SET test_start=@test_start, positive=@positive, negative=@negative, neutral=@neutral, questions=@questions, phase01=@phase01 WHERE userCode=@userCode";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@test_start", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@test_finish", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@positive", counterCharacteristicsPositiveAfter);
                        databaseCommand01.Parameters.AddWithValue("@negative", counterCharacteristicsNegativeAfter);
                        databaseCommand01.Parameters.AddWithValue("@neutral", counterCharacteristicsNeutralAfter);
                        databaseCommand01.Parameters.AddWithValue("@questions", counterCharacteristicsQuestionsAfter);
                        databaseCommand01.Parameters.AddWithValue("@phase01", "Y");
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

                    databaseCommand02.CommandText = "INSERT INTO users_step04results (userCode, test_start, test_finish, positive, negative, neutral, questions, phase01) VALUES (@userCode, @test_start, @test_finish, @positive, @negative, @neutral, @questions, @phase01)";
                    databaseCommand02.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand02.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@positive", counterCharacteristicsPositive);
                    databaseCommand02.Parameters.AddWithValue("@negative", counterCharacteristicsNegative);
                    databaseCommand02.Parameters.AddWithValue("@neutral",counterCharacteristicsNeutral);
                    databaseCommand02.Parameters.AddWithValue("@questions", counterCharacteristicsQuestions);
                    databaseCommand02.Parameters.AddWithValue("@phase01", "Y");
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
                databaseCommand.Dispose();
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
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

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
                databaseCommand.Dispose();
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
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

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
                databaseCommand.Dispose();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Calculate percentage of CPS
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0200DatabaseGetPercentage(string valueType, string valueNumeric)
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Cps_Percentage WHERE type=@type and value=@value";
                databaseCommand.Parameters.AddWithValue("@type", valueType);
                databaseCommand.Parameters.AddWithValue("@value", valueNumeric);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    calculatePercentage = databaseContainer.GetString("Percentage").ToString();
                    rangeNumber = databaseContainer.GetString("range").ToString();
                }

                R0130DatabaseGetType(valueType);
                R0140DatabaseGetRangeNumber();
                R0210FormatRangeNumberData();
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
        /// Goal:           Format data to number rage
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0210FormatRangeNumberData()
        {
            switch (rangeNumber)
            {
                case "001":
                    typeResult1.Text = calculatePercentage.ToString();
                    typeRangeNumber1.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[000] = Int32.Parse(calculatePercentage);
                    break;

                case "002":
                    typeResult2.Text = calculatePercentage.ToString();
                    typeRangeNumber2.Text = rangeName.ToString();
                    typeDescription2.Text = descriptionText.ToString();
                    calculatePercentageValues[001] = Int32.Parse(calculatePercentage);
                    break;

                case "003":
                    typeResult3.Text = calculatePercentage.ToString();
                    typeRangeNumber3.Text = rangeName.ToString();
                    typeDescription3.Text = descriptionText.ToString();
                    calculatePercentageValues[002] = Int32.Parse(calculatePercentage); ;
                    break;

                case "004":
                    typeResult4.Text = calculatePercentage.ToString();
                    typeRangeNumber4.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[003] = Int32.Parse(calculatePercentage);
                    break;

                case "005":
                    typeResult5.Text = calculatePercentage.ToString();
                    typeRangeNumber5.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[004] = Int32.Parse(calculatePercentage);
                    break;

                case "006":
                    typeResult6.Text = calculatePercentage.ToString();
                    typeRangeNumber6.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[005] = Int32.Parse(calculatePercentage);
                    break;

                case "007":
                    typeResult7.Text = calculatePercentage.ToString();
                    typeRangeNumber7.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[006] = Int32.Parse(calculatePercentage);
                    break;

                case "008":
                    typeResult8.Text = calculatePercentage.ToString();
                    typeRangeNumber8.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[007] = Int32.Parse(calculatePercentage);
                    break;

                case "009":
                    typeResult9.Text = calculatePercentage.ToString();
                    typeRangeNumber9.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[008] = Int32.Parse(calculatePercentage);
                    break;

                case "010":
                    typeResult10.Text = calculatePercentage.ToString();
                    typeRangeNumber10.Text = rangeName.ToString();
                    typeDescription1.Text = descriptionText.ToString();
                    calculatePercentageValues[009] = Int32.Parse(calculatePercentage);
                    break;
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