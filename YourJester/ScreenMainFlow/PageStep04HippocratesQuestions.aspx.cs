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
/// Goal:           Treat Step04: Allow to user does the Hippocrates test
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep04HippocratesQuestions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string imageUrlAddress;
        public string currentDate;
        public string firstLine;
        public string userAnswer;
        public string keyCode;
        public string progressBarPercentage;
        public string progressBarQuestions;
        public string progressBarAnswers;

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
        public int valueType01Before;
        public int valueType02Before;
        public int valueType03Before;
        public int valueType04Before;
        public int valueType01After;
        public int valueType02After;
        public int valueType03After;
        public int valueType04After;
        public int counterAnswers;
        public int counterQuestions;

        string[] w_question_answers;
        string[] w_question_types;

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

                progressBarTotalQuestions = 0;
                progressBarTotalAnswers = 0;

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Hippocrates_questions LEFT JOIN users_step04_Hippocrates_answers ON step04_personality_Hippocrates_questions.language=@language AND users_step04_Hippocrates_answers.userCode=@userCode AND users_step04_Hippocrates_answers.question_code=code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                firstLine = "yes";

                while (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("language")) == userLanguage)
                    {
                        if (firstLine == "yes")
                        {
                            firstLine = "no";
                            txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                            txtTestQuestionCharacteristic.Text = databaseContainer.GetString("question").ToString();
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
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textYes").ToString();
                                    break;
                                case "2":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textNo").ToString();
                                    break;
                            }
                        }

                        formatTable.Rows.Add(formatLine);
                    }
                }
        
                gridQuestionList.DataSource = formatTable;
                gridQuestionList.DataBind();

                labelNumberQuestions.Text = progressBarTotalQuestions.ToString();
                labelNumberAnswers.Text = progressBarTotalAnswers.ToString();
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

                databaseCommand.CommandText = "SELECT * FROM step04_personality_Hippocrates_questions WHERE language=@language and code=@question_code";
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
                databaseCommand.Dispose();
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

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Hippocrates_answers WHERE userCode=@userCode and question_code=@question_code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionNumber.Text = databaseContainer.GetString("question_code").ToString();
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

        protected void R0130DatabaseUpdateUsers()
        {
            R0050TreatDatetime object00 = new R0050TreatDatetime();
            currentDate = object00.Routine0050TreatDatetime();

            R0135TreatAnswerFromUser();
            R0140TreatAnswer();
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
        /// Goal:           Treat the answer from user
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0135TreatAnswerFromUser()
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
        }
        /// *********************************************************************************************************************

        protected void R0140TreatAnswer()
        {
            w_question_answers = new string[080];
            w_question_types = new string[080];

            w_question_answers[000] = "S";
            w_question_answers[001] = "S";
            w_question_answers[002] = "S";
            w_question_answers[003] = "S";
            w_question_answers[004] = "S";
            w_question_answers[005] = "S";
            w_question_answers[006] = "S";
            w_question_answers[007] = "S";
            w_question_answers[008] = "S";
            w_question_answers[009] = "N";
            w_question_answers[010] = "S";
            w_question_answers[011] = "S";
            w_question_answers[012] = "S";
            w_question_answers[013] = "S";
            w_question_answers[014] = "N";
            w_question_answers[015] = "S";
            w_question_answers[016] = "S";
            w_question_answers[017] = "S";
            w_question_answers[018] = "S";
            w_question_answers[019] = "S";
            w_question_answers[020] = "S";
            w_question_answers[021] = "N";
            w_question_answers[022] = "S";
            w_question_answers[023] = "N";
            w_question_answers[024] = "S";
            w_question_answers[025] = "S";
            w_question_answers[026] = "S";
            w_question_answers[027] = "S";
            w_question_answers[028] = "S";
            w_question_answers[029] = "S";
            w_question_answers[030] = "N";
            w_question_answers[031] = "N";
            w_question_answers[032] = "S";
            w_question_answers[033] = "S";
            w_question_answers[034] = "S";
            w_question_answers[035] = "S";
            w_question_answers[036] = "N";
            w_question_answers[037] = "S";
            w_question_answers[038] = "N";
            w_question_answers[039] = "N";
            w_question_answers[040] = "S";
            w_question_answers[041] = "S";
            w_question_answers[042] = "N";
            w_question_answers[043] = "S";
            w_question_answers[044] = "S";
            w_question_answers[045] = "N";
            w_question_answers[046] = "N";
            w_question_answers[047] = "S";
            w_question_answers[048] = "S";
            w_question_answers[049] = "N";
            w_question_answers[050] = "S";
            w_question_answers[051] = "S";
            w_question_answers[052] = "N";
            w_question_answers[053] = "S";
            w_question_answers[054] = "S";
            w_question_answers[055] = "N";
            w_question_answers[056] = "S";
            w_question_answers[057] = "N";
            w_question_answers[058] = "S";
            w_question_answers[059] = "N";
            w_question_answers[060] = "N";
            w_question_answers[061] = "N";
            w_question_answers[062] = "N";
            w_question_answers[063] = "N";
            w_question_answers[064] = "N";
            w_question_answers[065] = "S";
            w_question_answers[066] = "N";
            w_question_answers[067] = "N";
            w_question_answers[068] = "S";
            w_question_answers[069] = "N";
            w_question_answers[070] = "N";
            w_question_answers[071] = "N";
            w_question_answers[072] = "N";
            w_question_answers[073] = "N";
            w_question_answers[074] = "N";
            w_question_answers[075] = "N";
            w_question_answers[076] = "N";
            w_question_answers[077] = "S";
            w_question_answers[078] = "N";
            w_question_answers[079] = "S";

            w_question_types[000] = "002";
            w_question_types[001] = "002";
            w_question_types[002] = "002";
            w_question_types[003] = "002";
            w_question_types[004] = "002";
            w_question_types[005] = "002";
            w_question_types[006] = "002";
            w_question_types[007] = "002";
            w_question_types[008] = "002";
            w_question_types[009] = "002";
            w_question_types[010] = "002";
            w_question_types[011] = "002";
            w_question_types[012] = "002";
            w_question_types[013] = "002";
            w_question_types[014] = "002";
            w_question_types[015] = "002";
            w_question_types[016] = "002";
            w_question_types[017] = "002";
            w_question_types[018] = "002";
            w_question_types[019] = "002";
            w_question_types[020] = "001";
            w_question_types[021] = "001";
            w_question_types[022] = "001";
            w_question_types[023] = "001";
            w_question_types[024] = "001";
            w_question_types[025] = "001";
            w_question_types[026] = "001";
            w_question_types[027] = "001";
            w_question_types[028] = "001";
            w_question_types[029] = "001";
            w_question_types[030] = "001";
            w_question_types[031] = "001";
            w_question_types[032] = "001";
            w_question_types[033] = "001";
            w_question_types[034] = "001";
            w_question_types[035] = "001";
            w_question_types[036] = "001";
            w_question_types[037] = "001";
            w_question_types[038] = "001";
            w_question_types[039] = "001";
            w_question_types[040] = "003";
            w_question_types[041] = "003";
            w_question_types[042] = "003";
            w_question_types[043] = "003";
            w_question_types[044] = "003";
            w_question_types[045] = "003";
            w_question_types[046] = "003";
            w_question_types[047] = "003";
            w_question_types[048] = "003";
            w_question_types[049] = "003";
            w_question_types[050] = "003";
            w_question_types[051] = "003";
            w_question_types[052] = "003";
            w_question_types[053] = "003";
            w_question_types[054] = "003";
            w_question_types[055] = "003";
            w_question_types[056] = "003";
            w_question_types[057] = "003";
            w_question_types[058] = "003";
            w_question_types[059] = "003";
            w_question_types[060] = "004";
            w_question_types[061] = "004";
            w_question_types[062] = "004";
            w_question_types[063] = "004";
            w_question_types[064] = "004";
            w_question_types[065] = "004";
            w_question_types[066] = "004";
            w_question_types[067] = "004";
            w_question_types[068] = "004";
            w_question_types[069] = "004";
            w_question_types[070] = "004";
            w_question_types[071] = "004";
            w_question_types[072] = "004";
            w_question_types[073] = "004";
            w_question_types[074] = "004";
            w_question_types[075] = "004";
            w_question_types[076] = "004";
            w_question_types[077] = "004";
            w_question_types[078] = "004";
            w_question_types[079] = "004";

            answerNumber = Int32.Parse(userAnswer);
            questionNumber = Int32.Parse(txtTestQuestionNumber.Text);

            valueType01 = 0;
            valueType02 = 0;
            valueType03 = 0;
            valueType04 = 0;

            if (userAnswer == "1")
            {
                if (w_question_answers[questionNumber - 1] == "S")
                {
                    switch (w_question_types[questionNumber - 1])
                    {
                        case "001":
                            valueType01 = valueType01 + 1;
                            break;
                        case "002":
                            valueType02 = valueType02 + 1;
                            break;
                        case "003":
                            valueType03 = valueType03 + 1;
                            break;
                        case "004":
                            valueType04 = valueType04 + 1;
                            break;
                    }
                }
                else
                {
                    switch (w_question_types[questionNumber - 1])
                    {
                        case "001":
                            valueType01 = valueType01 - 1;
                            break;
                        case "002":
                            valueType02 = valueType02 - 1;
                            break;
                        case "003":
                            valueType03 = valueType03 - 1;
                            break;
                        case "004":
                            valueType04 = valueType04 - 1;
                            break;
                    }
                }
            }
            else
            {
                if (w_question_answers[questionNumber - 1] == "N")
                {
                    switch (w_question_types[questionNumber - 1])
                    {
                        case "001":
                            valueType01 = valueType01 + 1;
                            break;
                        case "002":
                            valueType02 = valueType02 + 1;
                            break;
                        case "003":
                            valueType03 = valueType03 + 1;
                            break;
                        case "004":
                            valueType04 = valueType04 + 1;
                            break;
                    }
                }
                else
                {
                    switch (w_question_types[questionNumber - 1])
                    {
                        case "001":
                            valueType01 = valueType01 - 1;
                            break;
                        case "002":
                            valueType02 = valueType02 - 1;
                            break;
                        case "003":
                            valueType03 = valueType03 - 1;
                            break;
                        case "004":
                            valueType04 = valueType04 - 1;
                            break;
                    }
                }
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

                databaseCommand.CommandText = "DELETE FROM users_step04_Hippocrates_answers WHERE userCode=@userCode and question_code=@question_code";
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

                databaseCommand.CommandText = "INSERT INTO users_step04_Hippocrates_answers (userCode, question_code, answer_date, answer) VALUES (@userCode, @question_code, @answer_date, @answer)";
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

                databaseCommand.CommandText = "SELECT * FROM users_step04_Hippocratesresults WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    valueType01Before = databaseContainer.GetInt32("type_01");
                    valueType02Before = databaseContainer.GetInt32("type_02");
                    valueType03Before = databaseContainer.GetInt32("type_03");
                    valueType04Before = databaseContainer.GetInt32("type_04");

                    valueType01After = valueType01Before + valueType01;
                    valueType02After = valueType02Before + valueType02;
                    valueType03After = valueType03Before + valueType03;
                    valueType04After = valueType04Before + valueType04;

                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "UPDATE users_step04_Hippocratesresults SET test_start=@test_start, test_finish=@test_finish, type_01=@type_01, type_02=@type_02, type_03=@type_03, type_04=@type_04 WHERE userCode=@userCode";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@type_01", valueType01After);
                    databaseCommand.Parameters.AddWithValue("@type_02", valueType02After);
                    databaseCommand.Parameters.AddWithValue("@type_03", valueType03After);
                    databaseCommand.Parameters.AddWithValue("@type_04", valueType04After);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_step04_Hippocratesresults (userCode, test_start, test_finish, type_01, type_02, type_03, type_04) VALUES (@userCode, @test_start, @test_finish, @type_01, @type_02, @type_03, @type_04)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@type_01", valueType01);
                    databaseCommand.Parameters.AddWithValue("@type_02", valueType02);
                    databaseCommand.Parameters.AddWithValue("@type_03", valueType03);
                    databaseCommand.Parameters.AddWithValue("@type_04", valueType04);
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
        /// Goal:           Get answer from user
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary>

        protected void R0190DatabaseGetAnswerList()
        {
            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                radioAnswer1.Checked = false;
                radioAnswer2.Checked = false;

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step04_Hippocrates_answers WHERE userCode=@userCode and question_code=@question_code";
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
            R0130DatabaseUpdateUsers();
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
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "03");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "03");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "03");
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
                    databaseCommand02.Parameters.AddWithValue("@phase_level_2", "03");
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