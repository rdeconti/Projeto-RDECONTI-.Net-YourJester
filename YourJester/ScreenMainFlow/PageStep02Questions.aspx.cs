using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat Step02: Several characteristics (values, temperaments, personality, fears, emotions ...) are
///                 explained to user. The user need to answer if the characteristic is applicable or not to your life
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.ScreenMainFlow
{
    public partial class PageStep02Questions : System.Web.UI.Page
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

        public bool firstLine;

        public string fieldValueSpace = " ";
        public string fieldValuePercentage = "%";
        public string fieldValue001 = "001";

        public double progressBarTotalQuestions;
        public double progressBarTotalAnswers;

        public int progressBarTotalPercentage;
        public int questionNumber;
        public int answerNumber;
        public int counterIndex0;
        public int characteristicPositive;
        public int characteristicNegative;
        public int characteristicNeutral;
        public int counterCharacteristicsPositiveBefore;
        public int counterCharacteristicsNegativeBefore;
        public int counterCharacteristicsNeutralBefore;
        public int counterCharacteristicsQuestionsBefore;
        public int counterCharacteristicsPositiveAfter;
        public int counterCharacteristicsNegativeAfter;
        public int counterCharacteristicsNeutralAfter;
        public int counterCharacteristicsQuestionsAfter;
        public int counterAnswers;
        public int counterQuestions;

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
            auxiliaryArea01.DataField = "number";
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
            formatColumn.ColumnName = "number";
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
            formatColumn.ColumnName = "answer";
            formatTable.Columns.Add(formatColumn);

            progressBarTotalQuestions = 0;
            progressBarTotalAnswers = 0;
            firstLine = true;

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM list_characteristics LEFT JOIN users_step02_answers ON list_characteristics.language=@language AND users_step02_answers.userCode=@userCode AND users_step02_answers.question_code=code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    if ((databaseContainer.GetString("language")) == userLanguage)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                            txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                            txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
                            txtTestQuestionDescription.Text = databaseContainer.GetString("description").ToString();
                        }

                        formatLine = formatTable.NewRow();
                        formatLine["number"] = databaseContainer.GetString("code").ToString();
                        formatLine["question"] = databaseContainer.GetString("name").ToString();
                        formatLine["answer"] = " - ";

                        progressBarTotalQuestions = progressBarTotalQuestions + 1;

                        if (databaseContainer["answer"] != DBNull.Value)
                        {
                            progressBarTotalAnswers = progressBarTotalAnswers + 1;

                            switch (databaseContainer.GetString("answer"))
                            {
                                case "1":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textCharacteristicsPositive").ToString();
                                    break;
                                case "2":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textCharacteristicsNegative").ToString();
                                    break;
                                case "3":
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textCharacteristicsNeutral").ToString();
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

                formatColumn.Dispose();
                formatTable.Dispose();
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

                databaseCommand.CommandText = "SELECT * FROM list_characteristics WHERE language=@language and code=@code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionNumber.Text = databaseContainer.GetString("code").ToString();
                    txtTestQuestionCharacteristic.Text = databaseContainer.GetString("name").ToString();
                    txtTestQuestionDescription.Text = databaseContainer.GetString("description").ToString();
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
            radioAnswer1.Checked = false;
            radioAnswer2.Checked = false;
            radioAnswer3.Checked = false;

            MySqlCommand databaseCommand = new MySqlCommand();

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step02_answers WHERE userCode=@userCode and question_code=@code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@code", txtTestQuestionNumber.Text);
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

            R0140TreatAnswerFromUser();
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
                characteristicPositive = characteristicPositive + 1;
            }
            if (radioAnswer2.Checked == true)
            {
                userAnswer = "2";
                characteristicNegative = characteristicNegative + 1;
            }
            if (radioAnswer3.Checked == true)
            {
                userAnswer = "3";
                characteristicNeutral = characteristicNeutral + 1;
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

                databaseCommand.CommandText = "DELETE FROM users_step02_answers WHERE userCode=@userCode and question_code=@question_code";
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

                databaseCommand.CommandText = "INSERT INTO users_step02_answers (userCode, question_code, answer_date, answer) VALUES (@userCode, @question_code, @answer_date, @answer)";
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
        /// Goal:           Update user data related with characteristics positive, negative and neutral
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

                databaseCommand.CommandText = "SELECT * FROM users_step02_results WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    counterCharacteristicsPositiveBefore = databaseContainer.GetInt32("positive");
                    counterCharacteristicsNegativeBefore = databaseContainer.GetInt32("negative");
                    counterCharacteristicsNeutralBefore = databaseContainer.GetInt32("neutral");

                    counterCharacteristicsPositiveAfter = counterCharacteristicsPositiveBefore + characteristicPositive;
                    counterCharacteristicsNegativeAfter = counterCharacteristicsNegativeBefore + characteristicNegative;
                    counterCharacteristicsNeutralAfter = counterCharacteristicsNeutralBefore + characteristicNeutral;

                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "UPDATE users_step02_results SET test_start=@test_start, positive=@positive, negative=@negative, neutral=@neutral, questions=@questions WHERE userCode=@userCode";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@positive", counterCharacteristicsPositiveAfter);
                    databaseCommand.Parameters.AddWithValue("@negative", counterCharacteristicsNegativeAfter);
                    databaseCommand.Parameters.AddWithValue("@neutral", counterCharacteristicsNeutralAfter);
                    databaseCommand.Parameters.AddWithValue("@questions", progressBarTotalQuestions);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_step02_results (userCode, test_start, test_finish, positive, negative, neutral, questions) VALUES (@userCode, @test_start, @test_finish, @positive, @negative, @neutral, @questions)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@positive", characteristicPositive);
                    databaseCommand.Parameters.AddWithValue("@negative", characteristicNegative);
                    databaseCommand.Parameters.AddWithValue("@neutral", characteristicNeutral);
                    databaseCommand.Parameters.AddWithValue("@questions", progressBarTotalQuestions);
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
            MySqlCommand databaseCommand01 = new MySqlCommand();
            MySqlCommand databaseCommand02 = new MySqlCommand();

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
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    if (counterAnswers == counterQuestions)
                    {
                        databaseCommand01.CommandText = "UPDATE users_step00_progress SET finishdate=@finishdate, questions=@questions, answers=@answers, agree=@answers WHERE userCode=@userCode and phase_level_1=@phase_level_1 and phase_level_2=@phase_level_2";
                        databaseCommand01.Parameters.AddWithValue("@userCode", userCode);
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "02");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "02");
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
                    
                    databaseCommand02.CommandText = "INSERT INTO users_step00_progress (userCode, phase_level_1, phase_level_2, startdate, finishdate, questions, answers, agree) VALUES (@userCode, @phase_level_1, @phase_level_2, @startdate, @finishdate, @questions, @answers, @agree)";
                    databaseCommand02.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand02.Parameters.AddWithValue("@phase_level_1", "02");
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
                databaseCommand01.Dispose();
                databaseCommand02.Dispose();
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