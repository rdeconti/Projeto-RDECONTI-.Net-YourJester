using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat Step04: Allow to user does the CPS test
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep04CpsQuestions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string userAnswer;
        public string imageUrlAddress;
        public string currentDate;
        public string keyCode;
        public string progressBarPercentage;
        public string progressBarQuestions;
        public string progressBarAnswers;
        public string firstLine;
        public string fieldValueComma = ", ";
        public string fieldValueSpace = " ";
        public string fieldValuePercentage = "%";
        public string fieldValue001 = "001";

        public double progressBarTotalQuestions;
        public double progressBarTotalAnswers;

        public int progressBarTotalPercentage;
        public int questionNumber;
        public int questionNumberList;
        public int factorNumber;
        public int answerNumber;
        public int counterIndex0;
        public int counterCalculation;
        public int valueType01;
        public int valueType02;
        public int valueType03;
        public int valueType04;
        public int valueType05;
        public int valueType06;
        public int valueType07;
        public int valueType08;
        public int valueType09;
        public int valueType10;
        public int valueType01Before;
        public int valueType02Before;
        public int valueType03Before;
        public int valueType04Before;
        public int valueType05Before;
        public int valueType06Before;
        public int valueType07Before;
        public int valueType08Before;
        public int valueType09Before;
        public int valueType10Before;
        public int valueType01After;
        public int valueType02After;
        public int valueType03After;
        public int valueType04After;
        public int valueType05After;
        public int valueType06After;
        public int valueType07After;
        public int valueType08After;
        public int valueType09After;
        public int valueType10After;
        public int counterAnswers;
        public int counterQuestions;

        string[] questionScales;

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

            BoundField auxiliaryArea00 = new BoundField();
            auxiliaryArea00.DataField = "space0";
            auxiliaryArea00.ReadOnly = true;
            auxiliaryArea00.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea00);

            BoundField auxiliaryArea01 = new BoundField();
            auxiliaryArea01.DataField = "code";
            auxiliaryArea01.ReadOnly = true;
            auxiliaryArea01.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textNumber").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea01);

            BoundField auxiliaryArea02 = new BoundField();
            auxiliaryArea02.DataField = "space1";
            auxiliaryArea02.ReadOnly = true;
            auxiliaryArea02.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea02);

            BoundField auxiliaryArea03 = new BoundField();
            auxiliaryArea03.DataField = "question";
            auxiliaryArea03.ReadOnly = true;
            auxiliaryArea03.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textQuestion").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea03);

            BoundField auxiliaryArea04 = new BoundField();
            auxiliaryArea04.DataField = "space2";
            auxiliaryArea04.ReadOnly = true;
            auxiliaryArea04.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea04);

            BoundField auxiliaryArea05 = new BoundField();
            auxiliaryArea05.DataField = "space3";
            auxiliaryArea05.ReadOnly = true;
            auxiliaryArea05.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea05);

            BoundField auxiliaryArea06 = new BoundField();
            auxiliaryArea06.DataField = "answer";
            auxiliaryArea06.ReadOnly = true;
            auxiliaryArea06.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textAnswer").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea06);

            R0080DatabaseGetQuestionList();
            txtTestQuestionNumber.Text = fieldValue001.ToString();

            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
            R0300TreatProgressBar();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Get questions from step and show it to user gives the answers
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0080DatabaseGetQuestionList()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            progressBarTotalQuestions = 0;
            progressBarTotalAnswers = 0;

            try
            {
                DataTable formatTable = new DataTable();
                formatTable.Locale = CultureInfo.InvariantCulture;
                DataColumn formatColumn;
                DataRow formatLine;

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space0";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "code";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space1";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "question";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space2";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space3";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "answer";
                formatTable.Columns.Add(formatColumn);

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Cps_questions LEFT JOIN users_step04_Cps_answers ON step04_personality_Cps_questions.language=@language AND users_step04_Cps_answers.userCode=@userCode AND users_step04_Cps_answers.question_code=code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("language")) == userLanguage)
                    {
                        if (firstLine == "yes")
                        {
                            firstLine = "no";
                            txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                            txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
                        }

                        formatLine = formatTable.NewRow();
                        formatLine["code"] = databaseContainer.GetString("code").ToString();
                        formatLine["question"] = databaseContainer.GetString("question").ToString();
                        formatLine["answer"] = " - ";

                        progressBarTotalQuestions = progressBarTotalQuestions + 1;

                        if (databaseContainer["answer"] != DBNull.Value)
                        {
                            progressBarTotalAnswers = progressBarTotalAnswers + 1;

                            switch (databaseContainer.GetString("answer"))
                            {
                                case "1":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer1").ToString();
                                    break;
                                case "2":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer2").ToString();
                                    break;
                                case "3":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textradioAnswer3").ToString();
                                    break;
                                case "4":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer4").ToString();
                                    break;
                                case "5":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer5").ToString();
                                    break;
                                case "6":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer6").ToString();
                                    break;
                                case "7":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswer7").ToString();
                                    break;
                            }
                        }

                        formatTable.Rows.Add(formatLine);
                    }

                    gridQuestionList.DataSource = formatTable;
                    gridQuestionList.DataBind();

                    labelNumberQuestions.Text = progressBarTotalQuestions.ToString();
                    labelNumberAnswers.Text = progressBarTotalAnswers.ToString();
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
        /// Goal:           Get data from each characteristic
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0100DatabaseGetQuestion()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Cps_questions WHERE language=@language and code=@question_code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                    txtTestQuestionCharacteristic.Text = databaseContainer.GetString("question").ToString();
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
        /// Goal:           Get the answers to each question
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0110DatabaseGetAnswer()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            radioAnswer1.Checked = false;
            radioAnswer2.Checked = false;
            radioAnswer3.Checked = false;
            radioAnswer4.Checked = false;
            radioAnswer5.Checked = false;
            radioAnswer6.Checked = false;
            radioAnswer7.Checked = false;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Cps_answers WHERE userCode=@userCode and question_code=@question_code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    userAnswer = databaseContainer.GetString("answer").ToString();
                }

                switch (userAnswer)
                {
                    case "1":
                        radioAnswer1.Checked = true;
                        break;
                    case "2":
                        radioAnswer2.Checked = true;
                        break;
                    case "3":
                        radioAnswer3.Checked = true;
                        break;
                    case "4":
                        radioAnswer4.Checked = true;
                        break;
                    case "5":
                        radioAnswer5.Checked = true;
                        break;
                    case "6":
                        radioAnswer6.Checked = true;
                        break;
                    case "7":
                        radioAnswer7.Checked = true;
                        break;
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
        /// Goal:           Update the databasse answers and the user progress
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

        protected void R0130DatabaseUpdateUsers_Cps()
        {
            R0050TreatDatetime object00 = new R0050TreatDatetime();
            currentDate = object00.Routine0050TreatDatetime();

            R0140TreatAnswerFromUser();
            R0145TreatCpsAnswer();
            R0150DatabaseDeleteAnswer();
            R0160DatabaseInsertAnswer();
            R0170DatabaseUpdateResults();
            R0300TreatProgressBar();
            R0310DatabaseUpdateUserProgress();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat the answer from user and calculate the number of questions and answers
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0140TreatAnswerFromUser()
        {
            progressBarTotalAnswers = (Convert.ToInt32(labelNumberAnswers.Text));
            progressBarTotalQuestions = (Convert.ToInt32(labelNumberQuestions.Text));
            progressBarTotalAnswers = progressBarTotalAnswers + 1;

            if (radioAnswer1.Checked == true)
            {
                userAnswer = "1";
            }
            if (radioAnswer2.Checked == true)
            {
                userAnswer = "2";
            }
            if (radioAnswer3.Checked == true)
            {
                userAnswer = "3";
            }
            if (radioAnswer4.Checked == true)
            {
                userAnswer = "4";
            }
            if (radioAnswer5.Checked == true)
            {
                userAnswer = "5";
            }
            if (radioAnswer6.Checked == true)
            {
                userAnswer = "6";
            }
            if (radioAnswer7.Checked == true)
            {
                userAnswer = "7";
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat the answer from user
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0145TreatCpsAnswer()
        {
            questionScales = new string[100];

            /// Upload array with Cps scales
            /// T (001) = Defensive Attitude X Confidence
            /// O (002) = Order x Lack of Compulsion
            /// C (003) = Social Conformity x Rebellion
            /// A (004) = Activity x Lack of Energy
            /// S (005) = Emotional Stability x Instability
            /// E (006) = Extroversion x Introversion
            /// M (007) = Masculinity x Femininity
            /// P (008) = Empathy x Egocentrism
            /// V (009) = Validity
            /// R (010) = Bias in responses

            questionScales[000] = "T";
            questionScales[001] = "O";
            questionScales[002] = "C";
            questionScales[003] = "A";
            questionScales[004] = "V";
            questionScales[005] = "S";
            questionScales[006] = "E";
            questionScales[007] = "M";
            questionScales[008] = "P";
            questionScales[009] = "R";
            questionScales[010] = "T";
            questionScales[011] = "O";
            questionScales[012] = "C";
            questionScales[013] = "A";
            questionScales[014] = "V";
            questionScales[015] = "S";
            questionScales[016] = "E";
            questionScales[017] = "M";
            questionScales[018] = "P";
            questionScales[019] = "R";
            questionScales[020] = "T";
            questionScales[021] = "O";
            questionScales[022] = "C";
            questionScales[023] = "A";
            questionScales[024] = "V";
            questionScales[025] = "S";
            questionScales[026] = "E";
            questionScales[027] = "M";
            questionScales[028] = "P";
            questionScales[029] = "R";
            questionScales[030] = "T";
            questionScales[031] = "O";
            questionScales[032] = "C";
            questionScales[033] = "A";
            questionScales[034] = "V";
            questionScales[035] = "S";
            questionScales[036] = "E";
            questionScales[037] = "M";
            questionScales[038] = "P";
            questionScales[039] = "R";
            questionScales[040] = "T";
            questionScales[041] = "O";
            questionScales[042] = "C";
            questionScales[043] = "A";
            questionScales[044] = "V";
            questionScales[045] = "S";
            questionScales[046] = "E";
            questionScales[047] = "M";
            questionScales[048] = "P";
            questionScales[049] = "R";
            questionScales[050] = "T";
            questionScales[051] = "O";
            questionScales[052] = "C";
            questionScales[053] = "A";
            questionScales[054] = "V";
            questionScales[055] = "S";
            questionScales[056] = "E";
            questionScales[057] = "M";
            questionScales[058] = "P";
            questionScales[059] = "R";
            questionScales[060] = "T";
            questionScales[061] = "O";
            questionScales[062] = "C";
            questionScales[063] = "A";
            questionScales[064] = "V";
            questionScales[065] = "S";
            questionScales[066] = "E";
            questionScales[067] = "M";
            questionScales[068] = "P";
            questionScales[069] = "R";
            questionScales[070] = "T";
            questionScales[071] = "O";
            questionScales[072] = "C";
            questionScales[073] = "A";
            questionScales[074] = "V";
            questionScales[075] = "S";
            questionScales[076] = "E";
            questionScales[077] = "M";
            questionScales[078] = "P";
            questionScales[079] = "R";
            questionScales[080] = "T";
            questionScales[081] = "O";
            questionScales[082] = "C";
            questionScales[083] = "A";
            questionScales[084] = "V";
            questionScales[085] = "S";
            questionScales[086] = "E";
            questionScales[087] = "M";
            questionScales[088] = "P";
            questionScales[089] = "R";
            questionScales[090] = "T";
            questionScales[091] = "O";
            questionScales[092] = "C";
            questionScales[093] = "A";
            questionScales[094] = "V";
            questionScales[095] = "S";
            questionScales[096] = "E";
            questionScales[097] = "M";
            questionScales[098] = "P";
            questionScales[099] = "R";

            answerNumber = Int32.Parse(userAnswer);
            questionNumber = Int32.Parse(txtTestQuestionNumber.Text);

            Boolean w_number = (questionNumber % 2) == 0;
            if (w_number)
            {
                factorNumber = -1;
            }
            else
            {
                factorNumber = +1;
            }

            counterCalculation = (factorNumber - 1) * (-4) + factorNumber * answerNumber;

            valueType01 = 0;
            valueType02 = 0;
            valueType03 = 0;
            valueType04 = 0;
            valueType05 = 0;
            valueType06 = 0;
            valueType07 = 0;
            valueType08 = 0;
            valueType09 = 0;
            valueType10 = 0;

            switch (questionScales[questionNumber - 1])
            {
                case "T":
                    valueType01 = counterCalculation;
                    break;
                case "O":
                    valueType02 = counterCalculation;
                    break;
                case "C":
                    valueType03 = counterCalculation;
                    break;
                case "A":
                    valueType04 = counterCalculation;
                    break;
                case "V":
                    valueType05 = counterCalculation;
                    break;
                case "S":
                    valueType06 = counterCalculation;
                    break;
                case "E":
                    valueType07 = counterCalculation;
                    break;
                case "M":
                    valueType08 = counterCalculation;
                    break;
                case "P":
                    valueType09 = counterCalculation;
                    break;
                case "R":
                    valueType10 = counterCalculation;
                    break;
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Delete previous answers from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0150DatabaseDeleteAnswer()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "DELETE FROM users_step04_Cps_answers WHERE userCode=@userCode and question_code=@question_code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
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
        /// Goal:           Insert the answer into database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0160DatabaseInsertAnswer()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "INSERT INTO users_step04_Cps_answers (userCode, question_code, answer_date, answer) VALUES (@userCode, @question_code, @answer_date, @answer)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Parameters.AddWithValue("@answer_date", currentDate);
                databaseCommand.Parameters.AddWithValue("@answer", userAnswer);
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
        /// Goal:           Update user data related with results of test
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0170DatabaseUpdateResults()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Cpsresults WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    /// T (001) = Defensive Attitude X Confidence
                    /// O (002) = Order x Lack of Compulsion
                    /// C (003) = Social Conformity x Rebellion
                    /// A (004) = Activity x Lack of Energy
                    /// S (005) = Emotional Stability x Instability
                    /// E (006) = Extroversion x Introversion
                    /// M (007) = Masculinity x Femininity
                    /// P (008) = Empathy x Egocentrism
                    /// V (009) = Validity
                    /// R (010) = Bias in responses

                    valueType01Before = databaseContainer.GetInt32("type_01");
                    valueType02Before = databaseContainer.GetInt32("type_02");
                    valueType03Before = databaseContainer.GetInt32("type_03");
                    valueType04Before = databaseContainer.GetInt32("type_04");
                    valueType05Before = databaseContainer.GetInt32("type_05");
                    valueType06Before = databaseContainer.GetInt32("type_06");
                    valueType07Before = databaseContainer.GetInt32("type_07");
                    valueType08Before = databaseContainer.GetInt32("type_08");
                    valueType09Before = databaseContainer.GetInt32("type_09");
                    valueType10Before = databaseContainer.GetInt32("type10");

                    valueType01After = valueType01Before + valueType01;
                    valueType02After = valueType02Before + valueType02;
                    valueType03After = valueType03Before + valueType03;
                    valueType04After = valueType04Before + valueType04;
                    valueType05After = valueType05Before + valueType05;
                    valueType06After = valueType06Before + valueType06;
                    valueType07After = valueType07Before + valueType07;
                    valueType08After = valueType08Before + valueType08;
                    valueType09After = valueType09Before + valueType09;
                    valueType10After = valueType10Before + valueType10;

                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "UPDATE users_step04_Cpsresults SET test_start=@test_start, test_finish=@test_finish, type_01=@type_01, type_02=@type_02, type_03=@type_03, type_04=@type_04, type_05=@type_05, type_06=@type_06, type_07=@type_07, type_08=@type_08, type_09=@type_09, type10=@type10 WHERE userCode=@userCode";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@type_01", valueType01After);
                    databaseCommand.Parameters.AddWithValue("@type_02", valueType02After);
                    databaseCommand.Parameters.AddWithValue("@type_03", valueType03After);
                    databaseCommand.Parameters.AddWithValue("@type_04", valueType04After);
                    databaseCommand.Parameters.AddWithValue("@type_05", valueType05After);
                    databaseCommand.Parameters.AddWithValue("@type_06", valueType06After);
                    databaseCommand.Parameters.AddWithValue("@type_07", valueType07After);
                    databaseCommand.Parameters.AddWithValue("@type_08", valueType08After);
                    databaseCommand.Parameters.AddWithValue("@type_09", valueType09After);
                    databaseCommand.Parameters.AddWithValue("@type10", valueType10After);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_step04_Cpsresults (userCode, test_start, test_finish, type_01, type_02, type_03, type_04, type_05, type_06, type_07, type_08, type_09, type10) VALUES (@userCode, @test_start, @test_finish, @type_01, @type_02, @type_03, @type_04, @type_05, @type_06, @type_07, @type_08, @type_09, @type10)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@type_01", valueType01);
                    databaseCommand.Parameters.AddWithValue("@type_02", valueType02);
                    databaseCommand.Parameters.AddWithValue("@type_03", valueType03);
                    databaseCommand.Parameters.AddWithValue("@type_04", valueType04);
                    databaseCommand.Parameters.AddWithValue("@type_05", valueType05);
                    databaseCommand.Parameters.AddWithValue("@type_06", valueType06);
                    databaseCommand.Parameters.AddWithValue("@type_07", valueType07);
                    databaseCommand.Parameters.AddWithValue("@type_08", valueType08);
                    databaseCommand.Parameters.AddWithValue("@type_09", valueType09);
                    databaseCommand.Parameters.AddWithValue("@type10", valueType10);
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

        /// *********************************************************************************************************************

        protected void R0190DatabaseGetAnswerList()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                radioAnswer1.Checked = false;
                radioAnswer2.Checked = false;
                radioAnswer3.Checked = false;
                radioAnswer4.Checked = false;
                radioAnswer5.Checked = false;
                radioAnswer6.Checked = false;
                radioAnswer7.Checked = false;

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Cps_answers WHERE userCode=@userCode and question_code=@question_code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", questionNumberList);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    userAnswer = databaseContainer.GetString("answer").ToString();
                }

                switch (userAnswer)
                {
                    case "1":
                        radioAnswer1.Checked = true;
                        break;
                    case "2":
                        radioAnswer2.Checked = true;
                        break;
                    case "3":
                        radioAnswer3.Checked = true;
                        break;
                    case "4":
                        radioAnswer4.Checked = true;
                        break;
                    case "5":
                        radioAnswer5.Checked = true;
                        break;
                    case "6":
                        radioAnswer6.Checked = true;
                        break;
                    case "7":
                        radioAnswer7.Checked = true;
                        break;
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
        /// Goal:           Treat GridView selections and obtain the data related with question and answer
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0240RowSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridQuestionList.SelectedRow;

            txtTestQuestionNumber.Text = row.Cells[2].Text;
            txtTestQuestionCharacteristic.Text = row.Cells[3].Text;

            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat GridView selections and obtain the data related with question and answer
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0250RowSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gridQuestionList.Rows[e.NewSelectedIndex];

            txtTestQuestionNumber.Text = row.Cells[2].Text;
            txtTestQuestionCharacteristic.Text = row.Cells[3].Text;

            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat GridView selections and obtain the data related with question and answer
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0260CheckedChanged(object sender, EventArgs e)
        {
            R0130DatabaseUpdateUsers_Cps();
            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
            R0080DatabaseGetQuestionList();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat GridView selections and obtain the data related with question and answer
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0270PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridQuestionList.PageIndex = e.NewPageIndex;
            gridQuestionList.SelectedIndex = -1;

            txtTestQuestionNumber.Text = gridQuestionList.Rows[0].Cells[2].Text;
            txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[3].Text;

            R0080DatabaseGetQuestionList();
            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat GridView selections and obtain the data related with question and answer
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0280PageIndexChanged(object sender, EventArgs e)
        {
            gridQuestionList.SelectedIndex = -1;

            txtTestQuestionNumber.Text = gridQuestionList.Rows[0].Cells[2].Text;
            txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[3].Text;

            R0080DatabaseGetQuestionList();
            R0100DatabaseGetQuestion();
            R0110DatabaseGetAnswer();
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Treat GridView and format the text of button selection
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0290DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridQuestionList.Rows)
            {
               Button w_actionButton = (Button)row.Cells[0].Controls[0];
                w_actionButton.Text = HttpContext.GetGlobalResourceObject("Resources", "textSelect").ToString();
            }
        }

        /// <summary>
        /// *********************************************************************************************************************
        /// Copyright©: 	2015 YourJester Company. All rights reserved.
        /// *********************************************************************************************************************
        /// Creation:	    2015, June
        /// Author:	    	Rosemeire Deconti
        /// Goal:           Update progress bar with percentage and totals data about questions and asnwers
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0300TreatProgressBar()
        {
            progressBarTotalPercentage = (Convert.ToInt32((progressBarTotalAnswers / progressBarTotalQuestions) * 100));

            progressBarPercentage = progressBarTotalPercentage.ToString();
            progressBarQuestions = progressBarTotalQuestions.ToString();
            progressBarAnswers = progressBarTotalAnswers.ToString();

            progressBar1.Style.Add("width", progressBarPercentage + fieldValuePercentage);
            labelProgressPercentage.Text = (progressBarPercentage + fieldValuePercentage).ToString();

            labelNumberQuestions.Text = progressBarQuestions.ToString();
            labelNumberAnswers.Text = progressBarAnswers.ToString();
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

            counterAnswers = Convert.ToInt32(progressBarTotalAnswers);
            counterQuestions = Convert.ToInt32(progressBarTotalQuestions);

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step00_progress WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "04");
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "01");
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    MySqlCommand databaseCommand01 = new MySqlCommand();

                    if (counterAnswers == counterQuestions)
                    {
                        databaseCommand01.CommandText = "UPDATE users_step00_progress SET finishdate=@finishdate, questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "04");
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "01");
                        databaseCommand01.Parameters.AddWithValue("@finishdate", currentDate);
                        databaseCommand01.Parameters.AddWithValue("@questions", counterQuestions);
                        databaseCommand01.Parameters.AddWithValue("@answers", counterAnswers);
                        databaseCommand01.Parameters.AddWithValue("@agree", counterAnswers);
                        databaseCommand01.Connection = databaseConnection;
                        databaseCommand01.ExecuteNonQuery();
                    }
                    else
                    {
                        databaseCommand01.CommandText = "UPDATE users_step00_progress SET questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "04");
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "01");
                        databaseCommand01.Parameters.AddWithValue("@questions", counterQuestions);
                        databaseCommand01.Parameters.AddWithValue("@answers", counterAnswers);
                        databaseCommand01.Parameters.AddWithValue("@agree", counterAnswers);
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

                    databaseCommand02.CommandText = "INSERT INTO users_step00_progress (userCode, phase_level_1, phase_level_2, startdate, finishdate, questions, answers, agree) VALUES (@userCode, @phase_level_1, @phase_level_2, @startdate, @finishdate, @questions, @answers, @agree)";
                    databaseCommand02.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand02.Parameters.AddWithValue("@phase_level_1", "04");
                    databaseCommand02.Parameters.AddWithValue("@phase_level_2", "01");
                    databaseCommand02.Parameters.AddWithValue("@startdate", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@finishdate", currentDate);
                    databaseCommand02.Parameters.AddWithValue("@questions", counterQuestions);
                    databaseCommand02.Parameters.AddWithValue("@answers", counterAnswers);
                    databaseCommand02.Parameters.AddWithValue("@agree", counterAnswers);
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

