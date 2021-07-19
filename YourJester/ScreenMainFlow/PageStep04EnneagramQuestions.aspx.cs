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
/// Goal:           Treat Step04: Allow to user does the Enneagram test
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep04EnneagramQuestions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string userAnswer;
        public string imageUrlAddress;
        public string currentDate;
        public string firstLine;
        public string keyCode;
        public string progressBarPercentage;
        public string progressBarQuestions;
        public string progressBarAnswers;

        public string fieldValueComma = ", ";
        public string fieldValuePercentage = "%";
        public string fieldValueSpace = " ";
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
        public int triadNumber1;
        public int triadNumber2;
        public int triadNumber3;
        public int valueType1;
        public int valueType2;
        public int valueType3;
        public int valueType4;
        public int valueType5;
        public int valueType6;
        public int valueType7;
        public int valueType8;
        public int valueType9;
        public int counterAnswers;
        public int counterQuestions;
        public int triadNumber1Before;
        public int triadNumber2Before;
        public int triadNumber3Before;
        public int valueType1Before;
        public int valueType2Before;
        public int valueType3Before;
        public int valueType4Before;
        public int valueType5Before;
        public int valueType6Before;
        public int valueType7Before;
        public int valueType8Before;
        public int valueType9Before;
        public int triadNumber1After;
        public int triadNumber2After;
        public int triadNumber3After;
        public int valueType1After;
        public int valueType2After;
        public int valueType3After;
        public int valueType4After;
        public int valueType5After;
        public int valueType6After;
        public int valueType7After;
        public int valueType8After;
        public int valueType9After;

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
            auxiliaryArea01.DataField = "question";
            auxiliaryArea01.ReadOnly = true;
            auxiliaryArea01.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textNumber").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea01);

            BoundField auxiliaryArea02 = new BoundField();
            auxiliaryArea02.DataField = "space1";
            auxiliaryArea02.ReadOnly = true;
            auxiliaryArea02.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea02);

            BoundField auxiliaryArea04 = new BoundField();
            auxiliaryArea04.DataField = "space2";
            auxiliaryArea04.ReadOnly = true;
            auxiliaryArea04.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea04);

            BoundField w_column3 = new BoundField();
            w_column3.DataField = "answer";
            w_column3.ReadOnly = true;
            w_column3.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textAnswer").ToString();
            gridQuestionList.Columns.Add(w_column3);

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
                formatColumn.ColumnName = "question";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space1";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space2";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "answer";
                formatTable.Columns.Add(formatColumn);

                progressBarTotalQuestions = 0;
                progressBarTotalAnswers = 0;

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step04_personality_enneagram_questions LEFT JOIN users_step04_enneagram_answers ON step04_personality_enneagram_questions.language=@language AND users_step04_enneagram_answers.userCode=@userCode AND users_step04_enneagram_answers.question_code=code";
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
                            ///txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
                        }

                        formatLine = formatTable.NewRow();
                        formatLine["question"] = databaseContainer.GetString("code").ToString();
                        formatLine["answer"] = " - ";

                        progressBarTotalQuestions = progressBarTotalQuestions + 1;

                        if (databaseContainer["answer"] != DBNull.Value)
                        {
                            progressBarTotalAnswers = progressBarTotalAnswers + 1;

                            switch (databaseContainer.GetString("answer"))
                            {
                                case "1":
                                    formatLine["answer"] = databaseContainer.GetString("question1").ToString();
                                    break;
                                case "2":
                                    formatLine["answer"] = databaseContainer.GetString("question2").ToString();
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

                databaseCommand.CommandText = "SELECT * FROM step04_personality_enneagram_questions WHERE language=@language and code=@question_code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                    ///txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
                    radioAnswer1.Text = databaseContainer.GetString("question1").ToString();
                    radioAnswer2.Text = databaseContainer.GetString("question2").ToString();
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

                databaseCommand.CommandText = "SELECT * FROM users_step04_enneagram_answers WHERE userCode=@userCode and question_code=@question_code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@question_code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionNumber.Text = databaseContainer.GetString("question_code").ToString();
                    ///txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
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
            R0140TreatEnneagramAnswer();
            R0150DatabaseDeleteAnswer();
            R0160DatabaseInsertAnswer();
            R0170DatabaseUpdateResults();
            R0300TreatProgressBar();
            R0310DatabaseUpdateUserProgress();
        }

        /// *********************************************************************************************************************

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

        protected void R0140TreatEnneagramAnswer()
        {
            switch (txtTestQuestionNumber.Text)
            {
                case "001":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "002":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "003":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "004":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "005":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "006":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "007":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "008":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "009":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "010":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "011":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "012":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "013":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "014":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "015":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "016":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "017":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "018":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "019":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "020":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "021":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "022":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "023":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "024":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "025":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "026":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "027":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "028":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "029":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "030":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "031":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "032":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "033":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "034":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "035":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "036":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "037":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "038":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "039":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "040":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "041":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "042":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "043":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "044":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "045":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "046":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "047":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "048":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "049":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "050":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "051":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "052":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "053":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "054":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "055":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "056":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "057":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "058":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "059":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "060":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "061":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "062":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "063":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "064":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "065":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "066":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "067":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "068":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "069":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "070":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "071":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "072":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "073":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "074":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "075":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "076":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "077":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "078":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "079":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "080":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "081":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "082":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "083":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "084":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "085":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "086":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "087":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "088":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "089":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "090":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "091":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "092":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "093":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "094":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "095":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "096":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "097":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "098":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "099":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "100":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "101":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "102":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "103":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "104":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "105":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "106":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "107":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "108":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "109":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "110":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "111":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "112":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "113":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "114":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "115":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "116":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "117":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "118":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "119":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "120":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "121":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "122":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "123":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "124":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; }; break;
                case "125":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "126":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "127":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "128":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "129":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
                case "130":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "131":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "132":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "133":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "134":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "135":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; }; break;
                case "136":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "137":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; }; break;
                case "138":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "139":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; }; break;
                case "140":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType2 = valueType2 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; }; break;
                case "141":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType7 = valueType7 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType5 = valueType5 + 1; }; break;
                case "142":
                    if (radioAnswer1.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType1 = valueType1 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType4 = valueType4 + 1; }; break;
                case "143":
                    if (radioAnswer1.Checked == true) { triadNumber2 = triadNumber2 + 1; valueType6 = valueType6 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType9 = valueType9 + 1; }; break;
                case "144":
                    if (radioAnswer1.Checked == true) { triadNumber3 = triadNumber3 + 1; valueType8 = valueType8 + 1; };
                    if (radioAnswer2.Checked == true) { triadNumber1 = triadNumber1 + 1; valueType3 = valueType3 + 1; }; break;
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

                databaseCommand.CommandText = "DELETE FROM users_step04_enneagram_answers WHERE userCode=@userCode and question_code=@question_code";
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

                databaseCommand.CommandText = "INSERT INTO users_step04_enneagram_answers (userCode, question_code, answer_date, answer) VALUES (@userCode, @question_code, @answer_date, @answer)";
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

                databaseCommand.CommandText = "SELECT * FROM users_step04_enneagramresults WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    triadNumber1Before = databaseContainer.GetInt32("triad1");
                    triadNumber2Before = databaseContainer.GetInt32("triad2");
                    triadNumber3Before = databaseContainer.GetInt32("triad3");

                    valueType1Before = databaseContainer.GetInt32("type1");
                    valueType2Before = databaseContainer.GetInt32("type2");
                    valueType3Before = databaseContainer.GetInt32("type3");
                    valueType4Before = databaseContainer.GetInt32("type4");
                    valueType5Before = databaseContainer.GetInt32("type5");
                    valueType6Before = databaseContainer.GetInt32("type6");
                    valueType7Before = databaseContainer.GetInt32("type7");
                    valueType8Before = databaseContainer.GetInt32("type_8");
                    valueType9Before = databaseContainer.GetInt32("type_9");

                    triadNumber1After = triadNumber1Before + triadNumber1;
                    triadNumber2After = triadNumber2Before + triadNumber2;
                    triadNumber3After = triadNumber3Before + triadNumber3;

                    valueType1After = valueType1Before + valueType1;
                    valueType2After = valueType2Before + valueType2;
                    valueType3After = valueType3Before + valueType3;
                    valueType4After = valueType4Before + valueType4;
                    valueType5After = valueType5Before + valueType5;
                    valueType6After = valueType6Before + valueType6;
                    valueType7After = valueType7Before + valueType7;
                    valueType8After = valueType8Before + valueType8;
                    valueType9After = valueType9Before + valueType9;

                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "UPDATE users_step04_enneagramresults SET test_start=@test_start, test_finish=@test_finish, triad1=@triad1, triad2=@triad2, triad3=@triad3, type1=@type1, type2=@type2, type3=@type3, type4=@type4, type5=@type5, type6=@type6, type7=@type7, type_8=@type_8, type_9=@type_9 WHERE userCode=@userCode";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@triad1", triadNumber1After);
                    databaseCommand.Parameters.AddWithValue("@triad2", triadNumber2After);
                    databaseCommand.Parameters.AddWithValue("@triad3", triadNumber3After);
                    databaseCommand.Parameters.AddWithValue("@type1", valueType1After);
                    databaseCommand.Parameters.AddWithValue("@type2", valueType2After);
                    databaseCommand.Parameters.AddWithValue("@type3", valueType3After);
                    databaseCommand.Parameters.AddWithValue("@type4", valueType4After);
                    databaseCommand.Parameters.AddWithValue("@type5", valueType5After);
                    databaseCommand.Parameters.AddWithValue("@type6", valueType6After);
                    databaseCommand.Parameters.AddWithValue("@type7", valueType7After);
                    databaseCommand.Parameters.AddWithValue("@type_8", valueType8After);
                    databaseCommand.Parameters.AddWithValue("@type_9", valueType9After);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_step04_enneagramresults (userCode, test_start, test_finish, triad1, triad2, triad3, type1, type2, type3, type4, type5, type6, type7, type_8, type_9) VALUES (@userCode, @test_start, @test_finish, @triad1, @triad2, @triad3, @type1, @type2, @type3, @type4, @type5, @type6, @type7, @type_8, @type_9)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@triad1", triadNumber1);
                    databaseCommand.Parameters.AddWithValue("@triad2", triadNumber2);
                    databaseCommand.Parameters.AddWithValue("@triad3", triadNumber3);
                    databaseCommand.Parameters.AddWithValue("@type1", valueType1);
                    databaseCommand.Parameters.AddWithValue("@type2", valueType2);
                    databaseCommand.Parameters.AddWithValue("@type3", valueType3);
                    databaseCommand.Parameters.AddWithValue("@type4", valueType4);
                    databaseCommand.Parameters.AddWithValue("@type5", valueType5);
                    databaseCommand.Parameters.AddWithValue("@type6", valueType6);
                    databaseCommand.Parameters.AddWithValue("@type7", valueType7);
                    databaseCommand.Parameters.AddWithValue("@type_8", valueType8);
                    databaseCommand.Parameters.AddWithValue("@type_9", valueType9);
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
            ///txtTestQuestionCharacteristic.Text = row.Cells[3].Text;
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
            ///txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[3].Text;

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
            ///txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[3].Text;

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
                databaseCommand.Parameters.AddWithValue("@phase_level_2", "02");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "02");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_2", "02");
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
                    databaseCommand02.Parameters.AddWithValue("@phase_level_2", "02");
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