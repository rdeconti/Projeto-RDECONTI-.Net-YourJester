using System;
using System.IO;
using System.Web;
using YourJester.AppLogic;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat errors from portal and save error in a LOG
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester
{
    class R9000TreatErrorException
    {
        public void Routine9000TreatErrorException(Exception exceptionData)
        {
            string LogFile = "~/ErrorLogException.txt";
            LogFile = HttpContext.Current.Server.MapPath(LogFile);

            StreamWriter streamWriter = new StreamWriter(LogFile, true);
            streamWriter.WriteLine("********** {0} **********", DateTime.Now);

            if (exceptionData.InnerException != null)
            {
                streamWriter.Write("Inner Exception Type: ");
                streamWriter.WriteLine(exceptionData.InnerException.GetType().ToString());
                streamWriter.Write("Inner Exception: ");
                streamWriter.WriteLine(exceptionData.InnerException.Message);
                streamWriter.Write("Inner Source: ");
                streamWriter.WriteLine(exceptionData.InnerException.Source);

                if (exceptionData.InnerException.StackTrace != null)
                {
                    streamWriter.WriteLine("Inner Stack Trace: ");
                    streamWriter.WriteLine(exceptionData.InnerException.StackTrace);
                }
            }

            streamWriter.Write("Exception Type: ");
            streamWriter.WriteLine(exceptionData.GetType().ToString());
            streamWriter.WriteLine("Exception: " + exceptionData.Message);
            streamWriter.WriteLine("Stack Trace: ");

            if (exceptionData.StackTrace != null)
            {
                streamWriter.WriteLine(exceptionData.StackTrace);
                streamWriter.WriteLine();
            }

            if (HttpContext.Current.Session["sessionUserCode"] != null)
            {
                string userCode = HttpContext.Current.Session["sessionUserCode"].ToString();
                string userName = HttpContext.Current.Session["sessionUserName"].ToString();
                string userBirthday = HttpContext.Current.Session["sessionuserBirthday"].ToString();
                string userBirthMonth = HttpContext.Current.Session["sessionuserBirthMonth"].ToString();
                string userBirthYear = HttpContext.Current.Session["sessionuserBirthYear"].ToString();

                streamWriter.WriteLine("User code ............. " + userCode);
                streamWriter.WriteLine("User name ............. " + userName);
                streamWriter.WriteLine("User birthday ......... " + userBirthday);
                streamWriter.WriteLine("User birthMonth ....... " + userBirthMonth);
                streamWriter.WriteLine("User birthYear ........ " + userBirthYear);
            }

            streamWriter.Close();

            R0030TreatNewPage object02 = new R0030TreatNewPage();
            object02.Routine0030TreatNewPage("~/PageError.aspx");
        }
    }
}

