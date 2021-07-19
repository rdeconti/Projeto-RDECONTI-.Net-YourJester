using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat Step05: Based on the anwers from users the portal does a final analysis and shows with a graoh
///                 the areas of life that needs more care and the areas that are very well
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep05Results : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;
        public string finalAnalysis;
        public string fieldValueSpace = " ";
        public string fieldValueComma = ", ";
        public string keyCode;
        public string descriptionText;
        public string valueNumber;

        public int counterIndex0;
        public int counterIndex1;
        public int counterIndex2;
        public int calculateAverage01;
        public int calculateAverage02;
        public int calculateAverage03;
        public int calculateAverage04;
        public int calculateAverage05;
        public int calculateAverage06;
        public int calculateAverage07;
        public int calculateAverage08;
        public int calculateAverage09;
        public int calculateAverage10;
        public int calculateAverage11;
        public int calculateAverage12;
        public int calculateAverage13;
        public int calculateAverage14;
        public int calculateAverage15;
        public int calculateAverage16;

        public string[] areaNames;

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

            R0090DatabaseGetAreaNames();
            R0110DatabaseGetResults();
            R0200SetChartProprieties();
        }

        /// *********************************************************************************************************************

        protected void R0090DatabaseGetAreaNames()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                areaNames = new string[017];

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step05_wheel_life_areas WHERE language = @language";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                counterIndex0 = 0;

                while (databaseContainer.Read())
                {
                    counterIndex0 = counterIndex0 + 1;
                    areaNames[counterIndex0] = databaseContainer.GetString("name").ToString();
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

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step05_wheelresults WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    calculateAverage01 = databaseContainer.GetInt32("average_01");
                    calculateAverage02 = databaseContainer.GetInt32("average_02");
                    calculateAverage03 = databaseContainer.GetInt32("average_03");
                    calculateAverage04 = databaseContainer.GetInt32("average_04");
                    calculateAverage05 = databaseContainer.GetInt32("average_05");
                    calculateAverage06 = databaseContainer.GetInt32("average_06");
                    calculateAverage07 = databaseContainer.GetInt32("average_07");
                    calculateAverage08 = databaseContainer.GetInt32("average_08");
                    calculateAverage09 = databaseContainer.GetInt32("average_09");
                    calculateAverage10 = databaseContainer.GetInt32("average10");
                    calculateAverage11 = databaseContainer.GetInt32("average11");
                    calculateAverage12 = databaseContainer.GetInt32("average12");
                    calculateAverage13 = databaseContainer.GetInt32("average13");
                    calculateAverage14 = databaseContainer.GetInt32("average14");
                    calculateAverage15 = databaseContainer.GetInt32("average15");
                    calculateAverage16 = databaseContainer.GetInt32("average16");
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
        /// Goal:           Format graphs about characteristics
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0200SetChartProprieties()
        {
            string title_01 = areaNames[01].ToString();
            string title_02 = areaNames[02].ToString();
            string title_03 = areaNames[03].ToString();
            string title_04 = areaNames[04].ToString();
            string title_05 = areaNames[05].ToString();
            string title_06 = areaNames[06].ToString();
            string title_07 = areaNames[07].ToString();
            string title_08 = areaNames[08].ToString();
            string title_09 = areaNames[09].ToString();
            string title10 = areaNames[10].ToString();
            string title11 = areaNames[11].ToString();
            string title12 = areaNames[12].ToString();
            string title13 = areaNames[13].ToString();
            string title14 = areaNames[14].ToString();
            string title15 = areaNames[15].ToString();
            string title16 = areaNames[16].ToString();

            string[] xValues = { title_01, title_02, title_03, title_04, title_05, title_06, title_07, title_08, title_09, title10, title11, title12, title13, title14, title15, title16 };
            double[] yValues = { calculateAverage01, calculateAverage02, calculateAverage03, calculateAverage04, calculateAverage05, calculateAverage06, calculateAverage07, calculateAverage08, calculateAverage09, calculateAverage10, calculateAverage11, calculateAverage12, calculateAverage13, calculateAverage14, calculateAverage15, calculateAverage16 };

            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Default"].Points[0].Color = System.Drawing.Color.MediumBlue;
            Chart1.Series["Default"].Points[1].Color = System.Drawing.Color.MediumOrchid;
            Chart1.Series["Default"].Points[2].Color = System.Drawing.Color.MediumSpringGreen;
            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;
            Chart1.Series["Default"]["PieLabelStyle"] = "Outside";

            Chart1.Legends.Add("Legends");
            Chart1.Legends[0].Enabled = true;
            Chart1.Legends[0].Docking = Docking.Bottom;
            Chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

            Chart1.Series[0].LegendText = "#VALX (#PERCENT{P2})";

            double[] valueNumbers = new double[4];
            double w_maximun;

            valueNumbers[0] = 10;
            valueNumbers[1] = 20;
            valueNumbers[2] = 30;
            valueNumbers[3] = 40;

            counterIndex1 = 0;
            counterIndex2 = 0;
            w_maximun = 0;

            while (counterIndex1 < 4)
            {
                if (valueNumbers[counterIndex1] > w_maximun)
                {
                    w_maximun = valueNumbers[counterIndex1];
                    counterIndex2 = counterIndex1;
                }

                counterIndex1 = counterIndex1 + 1;
            }

            switch (counterIndex2)
            {
                case 0:
                    finalAnalysis = HttpContext.GetGlobalResourceObject("Resources", "longtextFinalAnalysisStep05Positive").ToString();
                    txtFinalAnalysis.Text = finalAnalysis + txtFinalAnalysis.Text;
                    break;
                case 1:
                    finalAnalysis = HttpContext.GetGlobalResourceObject("Resources", "longtextFinalAnalysisStep05Negative").ToString();
                    txtFinalAnalysis.Text = finalAnalysis + txtFinalAnalysis.Text;
                    break;
                case 2:
                    finalAnalysis = HttpContext.GetGlobalResourceObject("Resources", "longtextFinalAnalysisStep05Neutral").ToString();
                    txtFinalAnalysis.Text = finalAnalysis + txtFinalAnalysis.Text;
                    break;
                case 3:
                    finalAnalysis = HttpContext.GetGlobalResourceObject("Resources", "longtextFinalAnalysisStep05Incomplete").ToString();
                    txtFinalAnalysis.Text = finalAnalysis + fieldValueComma + txtFinalAnalysis.Text;
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