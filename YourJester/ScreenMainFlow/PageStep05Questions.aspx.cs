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
/// Goal:           Treat Step05: Questions about several life areas are explained to user in order to reach at final of
///                 questionary an vision about how the user life is balanced or not
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    public partial class PageStep05Questions : System.Web.UI.Page
    {
        public string userLanguage;
        public string userCulture;
        public string userCode;
        public string userAnswer;
        public string imageUrlAddress;
        public string currentDate;
        public string keyCode;
        public string keyArea;
        public string firstLine;
        public string progressBarPercentage;
        public string progressBarQuestions;
        public string progressBarAnswers;

        public string fieldValueSpace = " ";
        public string fieldValuePercentage = "%";
        public string fieldValue01 = "01";

        public double progressBarTotalQuestions;
        public double progressBarTotalAnswers;

        public int counterIndex0;
        public int valueNumber;
        public int progressBarTotalPercentage;
        public int counterAnswers;
        public int counterQuestions;
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

            BoundField auxiliaryArea00 = new BoundField();
            auxiliaryArea00.DataField = "space1";
            auxiliaryArea00.ReadOnly = true;
            auxiliaryArea00.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea00);

            BoundField auxiliaryArea01 = new BoundField();
            auxiliaryArea01.DataField = "area_number";
            auxiliaryArea01.ReadOnly = true;
            auxiliaryArea01.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textNumber").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea01);

            BoundField auxiliaryArea02 = new BoundField();
            auxiliaryArea02.DataField = "space2";
            auxiliaryArea02.ReadOnly = true;
            auxiliaryArea02.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea02);

            BoundField auxiliaryArea03 = new BoundField();
            auxiliaryArea03.DataField = "area_name";
            auxiliaryArea03.ReadOnly = true;
            auxiliaryArea03.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textArea").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea03);

            BoundField auxiliaryArea04 = new BoundField();
            auxiliaryArea04.DataField = "space3";
            auxiliaryArea04.ReadOnly = true;
            auxiliaryArea04.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea04);

            BoundField auxiliaryArea05 = new BoundField();
            auxiliaryArea05.DataField = "code";
            auxiliaryArea05.ReadOnly = true;
            auxiliaryArea05.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textNumber").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea05);

            BoundField auxiliaryArea06 = new BoundField();
            auxiliaryArea06.DataField = "space4";
            auxiliaryArea06.ReadOnly = true;
            auxiliaryArea06.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea06);

            BoundField auxiliaryArea07 = new BoundField();
            auxiliaryArea07.DataField = "question";
            auxiliaryArea07.ReadOnly = true;
            auxiliaryArea07.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textQuestion").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea07);

            BoundField auxiliaryArea08 = new BoundField();
            auxiliaryArea08.DataField = "space5";
            auxiliaryArea08.ReadOnly = true;
            auxiliaryArea08.HeaderText = fieldValueSpace.ToString();
            gridQuestionList.Columns.Add(auxiliaryArea08);

            BoundField auxiliaryArea09 = new BoundField();
            auxiliaryArea09.DataField = "answer";
            auxiliaryArea09.ReadOnly = true;
            auxiliaryArea09.HeaderText = HttpContext.GetGlobalResourceObject("Resources", "textAnswer").ToString();
            gridQuestionList.Columns.Add(auxiliaryArea09);

            R0080DatabaseGetQuestionList();

            txtTestQuestionNumber.Text = fieldValue01;
            txtTestQuestionAreaNumber.Text = fieldValue01;

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

            calculateAverage01 = 0;
            calculateAverage02 = 0;
            calculateAverage03 = 0;
            calculateAverage04 = 0;
            calculateAverage05 = 0;
            calculateAverage06 = 0;
            calculateAverage07 = 0;
            calculateAverage08 = 0;
            calculateAverage09 = 0;
            calculateAverage10 = 0;
            calculateAverage11 = 0;
            calculateAverage12 = 0;
            calculateAverage13 = 0;
            calculateAverage14 = 0;
            calculateAverage15 = 0;
            calculateAverage16 = 0;

            firstLine = "yes";

            R0090DatabaseGetAreaNames();

            try
            {
                DataTable formatTable = new DataTable();
                formatTable.Locale = CultureInfo.InvariantCulture;
                DataColumn formatColumn;
                DataRow formatLine;

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space1";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "area_number";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space2";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "area_name";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space3";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "code";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space4";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "question";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "space5";
                formatTable.Columns.Add(formatColumn);

                formatColumn = new DataColumn();
                formatColumn.DataType = Type.GetType("System.String");
                formatColumn.ColumnName = "answer";
                formatTable.Columns.Add(formatColumn);

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM step05_wheel_life_questions LEFT JOIN users_step05_wheel_answers ON step05_wheel_life_questions.language=@language AND users_step05_wheel_answers.userCode=@userCode AND users_step05_wheel_answers.code=question AND users_step05_wheel_answers.area=question_area";
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
                            counterIndex0 = databaseContainer.GetInt32("question_area");
                            txtTestQuestionAreaNumber.Text = databaseContainer.GetInt32("question_area").ToString();
                            txtTestQuestionAreaName.Text = areaNames[counterIndex0].ToString();
                            txtTestQuestionNumber.Text = databaseContainer.GetString("question").ToString();
                            txtTestQuestionCharacteristic.Text = databaseContainer.GetString("description").ToString();
                        }

                        formatLine = formatTable.NewRow();

                        counterIndex0 = databaseContainer.GetInt32("question_area");
                        formatLine["area_number"] = databaseContainer.GetInt32("question_area").ToString();
                        formatLine["area_name"] = areaNames[counterIndex0].ToString();
                        formatLine["code"] = databaseContainer.GetString("question").ToString();
                        formatLine["question"] = databaseContainer.GetString("description").ToString();
                        formatLine["answer"] = " - ";

                        progressBarTotalQuestions = progressBarTotalQuestions + 1;

                        if (databaseContainer["answer_value"] != DBNull.Value)
                        {
                            progressBarTotalAnswers = progressBarTotalAnswers + 1;

                            switch (databaseContainer.GetInt32("area"))
                            {
                                case 01:
                                    calculateAverage01 = calculateAverage01 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 02:
                                    calculateAverage02 = calculateAverage02 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 03:
                                    calculateAverage03 = calculateAverage03 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 04:
                                    calculateAverage04 = calculateAverage04 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 05:
                                    calculateAverage05 = calculateAverage05 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 06:
                                    calculateAverage06 = calculateAverage06 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 07:
                                    calculateAverage07 = calculateAverage07 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 08:
                                    calculateAverage08 = calculateAverage08 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 09:
                                    calculateAverage09 = calculateAverage09 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 10:
                                    calculateAverage10 = calculateAverage10 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 11:
                                    calculateAverage11 = calculateAverage11 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 12:
                                    calculateAverage12 = calculateAverage12 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 13:
                                    calculateAverage13 = calculateAverage13 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 14:
                                    calculateAverage14 = calculateAverage14 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 15:
                                    calculateAverage15 = calculateAverage15 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                                case 16:
                                    calculateAverage16 = calculateAverage16 + (databaseContainer.GetInt32("answer_value"));
                                    break;
                            }

                            switch (databaseContainer.GetInt32("answer_value"))
                            {
                                case 0:
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswerLow").ToString();
                                    break;
                                case 5:
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswerMedium").ToString();
                                    break;
                                case 10:
                                    formatLine["answer"] = HttpContext.GetGlobalResourceObject("Resources", "textAnswerHigh").ToString();
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
        /// Goal:           Get area name from database
        /// *********************************************************************************************************************
        /// Maintenance:    yyyy/mm/dd
        /// Author:	    	Rosemeire Deconti
        /// Goal:           inform the description of maintenance
        /// *********************************************************************************************************************
        /// </summary> 

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

                databaseCommand.CommandText = "SELECT * FROM step05_wheel_life_questions WHERE language=@language and question_area=@area and question=@code";
                databaseCommand.Parameters.AddWithValue("@language", userLanguage);
                databaseCommand.Parameters.AddWithValue("@area", txtTestQuestionAreaNumber.Text);
                databaseCommand.Parameters.AddWithValue("@code", txtTestQuestionNumber.Text);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    txtTestQuestionAreaNumber.Text = databaseContainer.GetInt32("question_area").ToString();
                    txtTestQuestionAreaName.Text = areaNames[counterIndex0].ToString();
                    txtTestQuestionNumber.Text = databaseContainer.GetString("question").ToString();
                    txtTestQuestionCharacteristic.Text = databaseContainer.GetString("description").ToString();
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
            radioAnswer3.Checked = false;

            keyArea = txtTestQuestionAreaNumber.Text.PadLeft(2, '0');
            keyCode = txtTestQuestionNumber.Text.PadLeft(2, '0');

            try
            {
                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step05_wheel_answers WHERE userCode=@userCode and area=@area and code=@code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@area", keyArea);
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                while (databaseContainer.Read())
                {
                    userAnswer = databaseContainer.GetInt32("answer_value").ToString();
                }

                switch (userAnswer)
                {
                    case "0":
                        radioAnswer1.Checked = true;
                        break;
                    case "5":
                        radioAnswer2.Checked = true;
                        break;
                    case "10":
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
                valueNumber = 0;
            }
            if (radioAnswer2.Checked == true)
            {
                valueNumber = 5;
            }
            if (radioAnswer3.Checked == true)
            {
                valueNumber = 10;
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
                keyArea = txtTestQuestionAreaNumber.Text.PadLeft(2, '0');
                keyCode = txtTestQuestionNumber.Text.PadLeft(2, '0');

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "DELETE FROM users_step05_wheel_answers WHERE userCode=@userCode and area=@area and code=@code";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@area", keyArea);
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
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
                keyArea = txtTestQuestionAreaNumber.Text.PadLeft(2, '0');
                keyCode = txtTestQuestionNumber.Text.PadLeft(2, '0');

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "INSERT INTO users_step05_wheel_answers (userCode, area, code, answer_value) VALUES (@userCode, @area, @code, @answer_value)";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Parameters.AddWithValue("@area", keyArea);
                databaseCommand.Parameters.AddWithValue("@code", keyCode);
                databaseCommand.Parameters.AddWithValue("@answer_value", valueNumber);
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
                calculateAverage01 = calculateAverage01 / 10;
                calculateAverage02 = calculateAverage02 / 10;
                calculateAverage03 = calculateAverage03 / 10;
                calculateAverage04 = calculateAverage04 / 10;
                calculateAverage05 = calculateAverage05 / 10;
                calculateAverage06 = calculateAverage06 / 10;
                calculateAverage07 = calculateAverage07 / 10;
                calculateAverage08 = calculateAverage08 / 10;
                calculateAverage09 = calculateAverage09 / 10;
                calculateAverage10 = calculateAverage10 / 10;
                calculateAverage11 = calculateAverage11 / 10;
                calculateAverage12 = calculateAverage12 / 10;
                calculateAverage13 = calculateAverage13 / 10;
                calculateAverage14 = calculateAverage14 / 10;
                calculateAverage15 = calculateAverage15 / 10;
                calculateAverage16 = calculateAverage16 / 10;

                databaseConnection = new MySqlConnection(databaseServer);
                databaseConnection.Open();

                databaseCommand.CommandText = "SELECT * FROM users_step05_wheelresults WHERE userCode=@userCode";
                databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                databaseCommand.Connection = databaseConnection;

                MySqlDataReader databaseContainer = databaseCommand.ExecuteReader();

                if (databaseContainer.Read())
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "UPDATE users_step05_wheelresults SET test_start=@test_start, test_finish=@test_finish, average_01=@average_01, average_02=@average_02, average_03=@average_03, average_04=@average_04, average_05=@average_05, average_06=@average_06, average_07=@average_07, average_08=@average_08, average_09=@average_09, average10=@average10, average11=@average11, average12=@average12, average13=@average13, average14=@average14, average15=@average15, average16=@average16 WHERE userCode=@userCode";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@average_01", calculateAverage01);
                    databaseCommand.Parameters.AddWithValue("@average_02", calculateAverage02);
                    databaseCommand.Parameters.AddWithValue("@average_03", calculateAverage03);
                    databaseCommand.Parameters.AddWithValue("@average_04", calculateAverage04);
                    databaseCommand.Parameters.AddWithValue("@average_05", calculateAverage05);
                    databaseCommand.Parameters.AddWithValue("@average_06", calculateAverage06);
                    databaseCommand.Parameters.AddWithValue("@average_07", calculateAverage07);
                    databaseCommand.Parameters.AddWithValue("@average_08", calculateAverage08);
                    databaseCommand.Parameters.AddWithValue("@average_09", calculateAverage09);
                    databaseCommand.Parameters.AddWithValue("@average10", calculateAverage10);
                    databaseCommand.Parameters.AddWithValue("@average11", calculateAverage11);
                    databaseCommand.Parameters.AddWithValue("@average12", calculateAverage12);
                    databaseCommand.Parameters.AddWithValue("@average13", calculateAverage13);
                    databaseCommand.Parameters.AddWithValue("@average14", calculateAverage14);
                    databaseCommand.Parameters.AddWithValue("@average15", calculateAverage15);
                    databaseCommand.Parameters.AddWithValue("@average16", calculateAverage16);
                    databaseCommand.Connection = databaseConnection;
                    databaseCommand.ExecuteNonQuery();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection = new MySqlConnection(databaseServer);
                    databaseConnection.Open();

                    databaseCommand.CommandText = "INSERT INTO users_step05_wheelresults (userCode, test_start, test_finish, average_01, average_02, average_03, average_04, average_05, average_06, average_07, average_08, average_09, average10, average11, average12, average13, average14, average15, average16) VALUES (@userCode, @test_start, @test_finish, @average_01, @average_02, @average_03, @average_04, @average_05, @average_06, @average_07, @average_08, @average_09, @average10, @average11, @average12, @average13, @average14, @average15, @average16)";
                    databaseCommand.Parameters.AddWithValue("@userCode", userCode);
                    databaseCommand.Parameters.AddWithValue("@test_start", currentDate);
                    databaseCommand.Parameters.AddWithValue("@test_finish", currentDate);
                    databaseCommand.Parameters.AddWithValue("@average_01", calculateAverage01);
                    databaseCommand.Parameters.AddWithValue("@average_02", calculateAverage02);
                    databaseCommand.Parameters.AddWithValue("@average_03", calculateAverage03);
                    databaseCommand.Parameters.AddWithValue("@average_04", calculateAverage04);
                    databaseCommand.Parameters.AddWithValue("@average_05", calculateAverage05);
                    databaseCommand.Parameters.AddWithValue("@average_06", calculateAverage06);
                    databaseCommand.Parameters.AddWithValue("@average_07", calculateAverage07);
                    databaseCommand.Parameters.AddWithValue("@average_08", calculateAverage08);
                    databaseCommand.Parameters.AddWithValue("@average_09", calculateAverage09);
                    databaseCommand.Parameters.AddWithValue("@average10", calculateAverage10);
                    databaseCommand.Parameters.AddWithValue("@average11", calculateAverage11);
                    databaseCommand.Parameters.AddWithValue("@average12", calculateAverage12);
                    databaseCommand.Parameters.AddWithValue("@average13", calculateAverage13);
                    databaseCommand.Parameters.AddWithValue("@average14", calculateAverage14);
                    databaseCommand.Parameters.AddWithValue("@average15", calculateAverage15);
                    databaseCommand.Parameters.AddWithValue("@average16", calculateAverage16);
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

            txtTestQuestionAreaNumber.Text = row.Cells[2].Text;
            txtTestQuestionAreaName.Text = row.Cells[4].Text;
            txtTestQuestionNumber.Text = row.Cells[6].Text;
            txtTestQuestionCharacteristic.Text = row.Cells[8].Text;

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

            txtTestQuestionAreaNumber.Text = row.Cells[2].Text;
            txtTestQuestionAreaName.Text = row.Cells[4].Text;
            txtTestQuestionNumber.Text = row.Cells[6].Text;
            txtTestQuestionCharacteristic.Text = row.Cells[8].Text;
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
            R0080DatabaseGetQuestionList();
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

            txtTestQuestionAreaNumber.Text = gridQuestionList.Rows[0].Cells[2].Text;
            txtTestQuestionAreaName.Text = gridQuestionList.Rows[0].Cells[4].Text;
            txtTestQuestionNumber.Text = gridQuestionList.Rows[0].Cells[6].Text;
            txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[8].Text;

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

            txtTestQuestionAreaNumber.Text = gridQuestionList.Rows[0].Cells[2].Text;
            txtTestQuestionAreaName.Text = gridQuestionList.Rows[0].Cells[4].Text;
            txtTestQuestionNumber.Text = gridQuestionList.Rows[0].Cells[6].Text;
            txtTestQuestionCharacteristic.Text = gridQuestionList.Rows[0].Cells[8].Text;

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
                databaseCommand.Parameters.AddWithValue("@phase_level_1", "05");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "05");
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
                        databaseCommand01.Parameters.AddWithValue("@phase_level_1", "05");
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
                    databaseCommand02.Parameters.AddWithValue("@phase_level_1", "05");
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
