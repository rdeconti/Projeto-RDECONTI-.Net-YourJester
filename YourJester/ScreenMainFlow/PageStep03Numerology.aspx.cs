using System;
using System.Threading;
using System.Globalization;
using MySql.Data.MySqlClient;
using YourJester.AppLogic;
using System.Web;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Based on user birthdate and user name the portal shows to user data from Numerology
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageStep03Numerology : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string userBirthday;
        public string userBirthMonth;
        public string userBirthYear;
        public string userFullName;
        public string currentDate;
        public string imageUrlAddress;
        public string characteristicPositive;
        public string characteristicNegative;
        public string keyType;
        public string keyCode;
        public string valueString;
        public string valueType;
        public string fieldValue001 = "001";
        public string fieldValue002 = "002";
        public string fieldValueComma = ", ";

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
        public int valueName;
        public int valueOneDigit;
        public int lengthName;
        public int counterIndex0;
        public int counterLine;
        public int counterTotalLines;

        public string[] charactersLetters;
        public string[] charactersTypes;
        public string[] tableName;

        public int[] charactersValues;

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

            userBirthday = (Session["sessionuserBirthday"]).ToString();
            userBirthMonth = (Session["sessionuserBirthMonth"]).ToString();
            userBirthYear = (Session["sessionuserBirthYear"]).ToString();
            userFullName = (Session["sessionUserName"]).ToString();

            valueType = "VC";

            R0110DatabaseGetNumber();
            R0120DatabaseGetImage();
            R0130DatabaseGetName();
            R0140DatabaseGetDescription();
            R0150DatabaseGetPositiveCharacteristics();
            R0160DatabaseGetNegativeCharacteristics();
            R0175DatabaseSetUserProgressCompletion();
            R0310DatabaseUpdateUserProgress();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           The portal defines the number of user
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0110DatabaseGetNumber()
        {
            try
            {
                userFullName = userFullName.Trim();

                tableName = new string[200];

                charactersLetters = new string[101];
                charactersTypes = new string[101];
                charactersValues = new int[101];

                charactersLetters[000] = "A";
                charactersLetters[001] = "B";
                charactersLetters[002] = "C";
                charactersLetters[003] = "D";
                charactersLetters[004] = "E";
                charactersLetters[005] = "F";
                charactersLetters[006] = "G";
                charactersLetters[007] = "H";
                charactersLetters[008] = "I";
                charactersLetters[009] = "J";
                charactersLetters[010] = "K";
                charactersLetters[011] = "L";
                charactersLetters[012] = "M";
                charactersLetters[013] = "N";
                charactersLetters[014] = "O";
                charactersLetters[015] = "P";
                charactersLetters[016] = "Q";
                charactersLetters[017] = "R";
                charactersLetters[018] = "S";
                charactersLetters[019] = "T";
                charactersLetters[020] = "U";
                charactersLetters[021] = "V";
                charactersLetters[022] = "W";
                charactersLetters[023] = "X";
                charactersLetters[024] = "Y";
                charactersLetters[025] = "Z";
                charactersLetters[026] = "a";
                charactersLetters[027] = "b";
                charactersLetters[028] = "c";
                charactersLetters[029] = "d";
                charactersLetters[030] = "e";
                charactersLetters[031] = "f";
                charactersLetters[032] = "g";
                charactersLetters[033] = "h";
                charactersLetters[034] = "i";
                charactersLetters[035] = "j";
                charactersLetters[036] = "k";
                charactersLetters[037] = "l";
                charactersLetters[038] = "m";
                charactersLetters[039] = "n";
                charactersLetters[040] = "o";
                charactersLetters[041] = "p";
                charactersLetters[042] = "q";
                charactersLetters[043] = "r";
                charactersLetters[044] = "s";
                charactersLetters[045] = "t";
                charactersLetters[046] = "u";
                charactersLetters[047] = "v";
                charactersLetters[048] = "w";
                charactersLetters[049] = "x";
                charactersLetters[050] = "y";
                charactersLetters[051] = "z";
                charactersLetters[052] = "À";
                charactersLetters[053] = "Á";
                charactersLetters[054] = "Â";
                charactersLetters[055] = "Ã";
                charactersLetters[056] = "Ä";
                charactersLetters[057] = "Ç";
                charactersLetters[058] = "È";
                charactersLetters[059] = "É";
                charactersLetters[060] = "Ê";
                charactersLetters[061] = "Ë";
                charactersLetters[062] = "Ì";
                charactersLetters[063] = "Í";
                charactersLetters[064] = "Î";
                charactersLetters[065] = "Ï";
                charactersLetters[066] = "Ñ";
                charactersLetters[067] = "Ò";
                charactersLetters[068] = "Ó";
                charactersLetters[069] = "Ô";
                charactersLetters[070] = "Õ";
                charactersLetters[071] = "Ö";
                charactersLetters[072] = "Ù";
                charactersLetters[073] = "Ú";
                charactersLetters[074] = "Û";
                charactersLetters[075] = "Ü";
                charactersLetters[076] = "Ý";
                charactersLetters[077] = "à";
                charactersLetters[078] = "á";
                charactersLetters[079] = "â";
                charactersLetters[080] = "ã";
                charactersLetters[081] = "ä";
                charactersLetters[082] = "ç";
                charactersLetters[083] = "è";
                charactersLetters[084] = "é";
                charactersLetters[085] = "ê";
                charactersLetters[086] = "ë";
                charactersLetters[087] = "ì";
                charactersLetters[088] = "í";
                charactersLetters[089] = "î";
                charactersLetters[090] = "ï";
                charactersLetters[091] = "ñ";
                charactersLetters[092] = "ò";
                charactersLetters[093] = "ó";
                charactersLetters[094] = "ô";
                charactersLetters[095] = "õ";
                charactersLetters[096] = "ö";
                charactersLetters[097] = "ù";
                charactersLetters[098] = "ú";
                charactersLetters[099] = "û";
                charactersLetters[100] = "ü";

                charactersValues[000] = 1;
                charactersValues[001] = 2;
                charactersValues[002] = 3;
                charactersValues[003] = 4;
                charactersValues[004] = 5;
                charactersValues[005] = 6;
                charactersValues[006] = 7;
                charactersValues[007] = 8;
                charactersValues[008] = 9;
                charactersValues[009] = 1;
                charactersValues[010] = 2;
                charactersValues[011] = 3;
                charactersValues[012] = 4;
                charactersValues[013] = 5;
                charactersValues[014] = 6;
                charactersValues[015] = 7;
                charactersValues[016] = 8;
                charactersValues[017] = 9;
                charactersValues[018] = 1;
                charactersValues[019] = 2;
                charactersValues[020] = 3;
                charactersValues[021] = 4;
                charactersValues[022] = 5;
                charactersValues[023] = 6;
                charactersValues[024] = 7;
                charactersValues[025] = 8;
                charactersValues[026] = 1;
                charactersValues[027] = 2;
                charactersValues[028] = 3;
                charactersValues[029] = 4;
                charactersValues[030] = 5;
                charactersValues[031] = 6;
                charactersValues[032] = 7;
                charactersValues[033] = 8;
                charactersValues[034] = 9;
                charactersValues[035] = 1;
                charactersValues[036] = 2;
                charactersValues[037] = 3;
                charactersValues[038] = 4;
                charactersValues[039] = 5;
                charactersValues[040] = 6;
                charactersValues[041] = 7;
                charactersValues[042] = 8;
                charactersValues[043] = 9;
                charactersValues[044] = 1;
                charactersValues[045] = 2;
                charactersValues[046] = 3;
                charactersValues[047] = 4;
                charactersValues[048] = 5;
                charactersValues[049] = 6;
                charactersValues[050] = 7;
                charactersValues[051] = 8;
                charactersValues[052] = 1;
                charactersValues[053] = 1;
                charactersValues[054] = 1;
                charactersValues[055] = 1;
                charactersValues[056] = 1;
                charactersValues[057] = 3;
                charactersValues[058] = 5;
                charactersValues[059] = 5;
                charactersValues[060] = 5;
                charactersValues[061] = 5;
                charactersValues[062] = 9;
                charactersValues[063] = 9;
                charactersValues[064] = 9;
                charactersValues[065] = 9;
                charactersValues[066] = 5;
                charactersValues[067] = 6;
                charactersValues[068] = 6;
                charactersValues[069] = 6;
                charactersValues[070] = 6;
                charactersValues[071] = 6;
                charactersValues[072] = 3;
                charactersValues[073] = 3;
                charactersValues[074] = 3;
                charactersValues[075] = 3;
                charactersValues[076] = 7;
                charactersValues[077] = 1;
                charactersValues[078] = 1;
                charactersValues[079] = 1;
                charactersValues[080] = 1;
                charactersValues[081] = 1;
                charactersValues[082] = 3;
                charactersValues[083] = 5;
                charactersValues[084] = 5;
                charactersValues[085] = 5;
                charactersValues[086] = 5;
                charactersValues[087] = 9;
                charactersValues[088] = 9;
                charactersValues[089] = 9;
                charactersValues[090] = 9;
                charactersValues[091] = 5;
                charactersValues[092] = 6;
                charactersValues[093] = 6;
                charactersValues[094] = 6;
                charactersValues[095] = 6;
                charactersValues[096] = 6;
                charactersValues[097] = 3;
                charactersValues[098] = 3;
                charactersValues[099] = 3;
                charactersValues[100] = 3;

                charactersTypes[000] = "V";
                charactersTypes[001] = "C";
                charactersTypes[002] = "C";
                charactersTypes[003] = "C";
                charactersTypes[004] = "V";
                charactersTypes[005] = "C";
                charactersTypes[006] = "C";
                charactersTypes[007] = "C";
                charactersTypes[008] = "V";
                charactersTypes[009] = "C";
                charactersTypes[010] = "C";
                charactersTypes[011] = "C";
                charactersTypes[012] = "C";
                charactersTypes[013] = "C";
                charactersTypes[014] = "V";
                charactersTypes[015] = "C";
                charactersTypes[016] = "C";
                charactersTypes[017] = "C";
                charactersTypes[018] = "C";
                charactersTypes[019] = "C";
                charactersTypes[020] = "V";
                charactersTypes[021] = "C";
                charactersTypes[022] = "C";
                charactersTypes[023] = "C";
                charactersTypes[024] = "C";
                charactersTypes[025] = "C";
                charactersTypes[026] = "V";
                charactersTypes[027] = "C";
                charactersTypes[028] = "C";
                charactersTypes[029] = "C";
                charactersTypes[030] = "V";
                charactersTypes[031] = "C";
                charactersTypes[032] = "C";
                charactersTypes[033] = "C";
                charactersTypes[034] = "V";
                charactersTypes[035] = "C";
                charactersTypes[036] = "C";
                charactersTypes[037] = "C";
                charactersTypes[038] = "C";
                charactersTypes[039] = "C";
                charactersTypes[040] = "V";
                charactersTypes[041] = "C";
                charactersTypes[042] = "C";
                charactersTypes[043] = "C";
                charactersTypes[044] = "C";
                charactersTypes[045] = "C";
                charactersTypes[046] = "V";
                charactersTypes[047] = "C";
                charactersTypes[048] = "C";
                charactersTypes[049] = "C";
                charactersTypes[050] = "C";
                charactersTypes[051] = "C";
                charactersTypes[052] = "V";
                charactersTypes[053] = "V";
                charactersTypes[054] = "V";
                charactersTypes[055] = "V";
                charactersTypes[056] = "V";
                charactersTypes[057] = "C";
                charactersTypes[058] = "V";
                charactersTypes[059] = "V";
                charactersTypes[060] = "V";
                charactersTypes[061] = "V";
                charactersTypes[062] = "V";
                charactersTypes[063] = "V";
                charactersTypes[064] = "V";
                charactersTypes[065] = "V";
                charactersTypes[066] = "C";
                charactersTypes[067] = "V";
                charactersTypes[068] = "V";
                charactersTypes[069] = "V";
                charactersTypes[070] = "V";
                charactersTypes[071] = "V";
                charactersTypes[072] = "V";
                charactersTypes[073] = "V";
                charactersTypes[074] = "V";
                charactersTypes[075] = "V";
                charactersTypes[076] = "C";
                charactersTypes[077] = "V";
                charactersTypes[078] = "V";
                charactersTypes[079] = "V";
                charactersTypes[080] = "V";
                charactersTypes[081] = "V";
                charactersTypes[082] = "C";
                charactersTypes[083] = "V";
                charactersTypes[084] = "V";
                charactersTypes[085] = "V";
                charactersTypes[086] = "V";
                charactersTypes[087] = "V";
                charactersTypes[088] = "V";
                charactersTypes[089] = "V";
                charactersTypes[090] = "V";
                charactersTypes[091] = "C";
                charactersTypes[092] = "V";
                charactersTypes[093] = "V";
                charactersTypes[094] = "V";
                charactersTypes[095] = "V";
                charactersTypes[096] = "V";
                charactersTypes[097] = "V";
                charactersTypes[098] = "V";
                charactersTypes[099] = "V";
                charactersTypes[100] = "V";

                lengthName = userFullName.Length;
                counterIndex0 = 0;

                while (counterIndex0 < lengthName)
                {
                    tableName[counterIndex0] = userFullName.Substring(counterIndex0, 1).ToString();
                    counterIndex0 = counterIndex0 + 1;
                }

                counterLine = 0;
                counterIndex0 = 0;
                counterTotalLines = 101;
                valueName = 0;

                while (counterIndex0 < lengthName)
                {
                    counterLine = 0;

                    while (counterLine < counterTotalLines)
                    {
                        if (tableName[counterIndex0] == charactersLetters[counterLine])
                        {
                            if (valueType == "VC")
                            {
                                valueName = valueName + charactersValues[counterLine];
                            }

                            if (valueType == charactersTypes[counterLine])
                            {
                                valueName = valueName + charactersValues[counterLine];
                            }
                        }

                        counterLine = counterLine + 1;
                    }

                    counterIndex0 = counterIndex0 + 1;
                }

                while (valueName > 9)
                {
                    valueString = valueName.ToString();

                    lengthName = valueString.Length;
                    counterIndex0 = 0;
                    valueOneDigit = 0;

                    while (counterIndex0 < lengthName)
                    {
                        valueOneDigit = valueOneDigit + Convert.ToInt32(valueString.Substring(counterIndex0, 1).ToString());
                        counterIndex0 = counterIndex0 + 1;
                    }

                    valueName = valueOneDigit;
                }

                keyCode = valueName.ToString();
                keyCode = keyCode.PadLeft(3, '0');

            }

            catch (MySqlException databaseError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(databaseError);
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
            imageCodeImage.ImageUrl = "../Images/numerology/" + keyCode + ".jpg";
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Base on the code of oracle the portal get the name related with the code
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0130DatabaseGetName()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT NAME FROM step03_numerology_names WHERE number=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    name.Text = databaseContainer.GetString("name");
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
        /// Goal:           Base on the code of oracle the portal get the long description related with the code
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0140DatabaseGetDescription()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT DESCRIPTION FROM step03_numerology_description WHERE number=@code and language=@language";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    txtDescription.Text = databaseContainer.GetString("description");
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
        /// Goal:           Base on the code of oracle the portal get the positive characteristics related with the code
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

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step03_numerology_characteristics WHERE number=@code and type=@type";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    counterCharacteristicsPositive = counterCharacteristicsPositive + 1;

                    keyCode = databaseContainer.GetString("characteristic").ToString();
                    R0180DatabaseGetCharacteristicText();
                    R0190DatabaseUpdateUsersStep03Characteristics();
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
        /// Goal:           Base on the code of oracle the portal get the negative characteristics related with the code
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

                databaseCommand.CommandText = "SELECT CHARACTERISTIC FROM step03_numerology_characteristics WHERE number=@code and type=@type";
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    counterCharacteristicsNegative = counterCharacteristicsNegative + 1;

                    keyCode = databaseContainer.GetString("characteristic").ToString();
                    R0180DatabaseGetCharacteristicText();
                    R0190DatabaseUpdateUsersStep03Characteristics();
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

                databaseCommand.CommandText = "SELECT * FROM users_step03_results WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("phase13") == "N"))
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

                        databaseCommand01.CommandText = "UPDATE users_step03_results SET test_start=@test_start, positive=@positive, negative=@negative, neutral=@neutral, questions=@questions, phase13=@phase13 WHERE userCode=@userCode";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@test_start", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@test_finish", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@positive", counterCharacteristicsPositiveAfter);
                        databaseCommand01.Parameters.AddWithValue("@negative", counterCharacteristicsNegativeAfter);
                        databaseCommand01.Parameters.AddWithValue("@neutral", counterCharacteristicsNeutralAfter);
                        databaseCommand01.Parameters.AddWithValue("@questions", counterCharacteristicsQuestionsAfter);
                        databaseCommand01.Parameters.AddWithValue("@phase13", "Y");
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

                    databaseCommand02.CommandText = "INSERT INTO users_step03_results (userCode, test_start, test_finish, positive, negative, neutral, questions, phase13) VALUES (@userCode, @test_start, @test_finish, @positive, @negative, @neutral, @questions, @phase13)";
                    databaseCommand02.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand02.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@positive", counterCharacteristicsPositive);
                    databaseCommand02.Parameters.AddWithValue("@negative", counterCharacteristicsNegative);
                    databaseCommand02.Parameters.AddWithValue("@neutral",counterCharacteristicsNeutral);
                    databaseCommand02.Parameters.AddWithValue("@questions", counterCharacteristicsQuestions);
                    databaseCommand02.Parameters.AddWithValue("@phase13", "Y");
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

        protected void R0190DatabaseUpdateUsersStep03Characteristics()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_Step03_characteristics WHERE userCode=@userCode and type=@type and characteristic=@characteristic";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@type", keyType);
                databaseCommand.Parameters.AddWithValue("@characteristic", keyCode);
                databaseCommand.Parameters.AddWithValue("@agree", "Y");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (!databaseContainer.Read())
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    MySqlCommand databaseCommand01 = new MySqlCommand();

                    databaseCommand01.CommandText = "INSERT INTO users_Step03_characteristics (userCode, type, characteristic, agree) VALUES (@userCode, @type, @characteristic, @agree)";
                    databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand01.Parameters.AddWithValue("@type", keyType);
                    databaseCommand01.Parameters.AddWithValue("@characteristic", keyCode);
                    databaseCommand01.Parameters.AddWithValue("@agree", "Y");
                    databaseCommand01.Connection = databaseConnection;
                    databaseCommand01.ExecuteNonQuery();
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
        /// Goal:           Update user data progress realated with the portal step 
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

            counterCharacteristicsQuestions = counterCharacteristicsPositive + counterCharacteristicsNegative;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step00_progress WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "03");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "13");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    MySqlCommand databaseCommand01 = new MySqlCommand();

                    databaseCommand01.CommandText = "UPDATE users_step00_progress SET startdate=@startdate, finishdate=@finishdate, questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                    databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand01.Parameters.AddWithValue("@phase_level_1", "03");
                    databaseCommand01.Parameters.AddWithValue("@phase_level_2", "13");
                    databaseCommand01.Parameters.AddWithValue("@startdate", currentDate);
                    databaseCommand01.Parameters.AddWithValue("@finishdate", currentDate);
                    databaseCommand01.Parameters.AddWithValue("@questions", counterCharacteristicsQuestions);
                    databaseCommand01.Parameters.AddWithValue("@answers", counterCharacteristicsQuestions);
                    databaseCommand01.Parameters.AddWithValue("@agree", counterCharacteristicsQuestions);
                    databaseCommand01.Connection = databaseConnection;
                    databaseCommand01.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    MySqlCommand databaseCommand01 = new MySqlCommand();

                    databaseCommand01.CommandText = "INSERT INTO users_step00_progress (userCode, phase_level_1, phase_level_2, startdate, finishdate, questions, answers, agree) VALUES (@userCode, @phase_level_1, @phase_level_2, @startdate, @finishdate, @questions, @answers, @agree)";
                    databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand01.Parameters.AddWithValue("@phase_level_1", "03");
                    databaseCommand01.Parameters.AddWithValue("@phase_level_2", "13");
                    databaseCommand01.Parameters.AddWithValue("@startdate", currentDate);
                    databaseCommand01.Parameters.AddWithValue("@finishdate", currentDate);
                    databaseCommand01.Parameters.AddWithValue("@questions", counterCharacteristicsQuestions);
                    databaseCommand01.Parameters.AddWithValue("@answers", counterCharacteristicsQuestions);
                    databaseCommand01.Parameters.AddWithValue("@agree", counterCharacteristicsQuestions);
                    databaseCommand01.Connection = databaseConnection;
                    databaseCommand01.ExecuteNonQuery();
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