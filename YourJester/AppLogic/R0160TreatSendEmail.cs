using System.Net.Mail;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Send e-mail FROM -> TO
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0160TreatSendEmail
    {
        public void Routine0160TreatSendEmail(string emailSubject, string emailTo, string emailFrom, string emailBody)
        {
            try
            {
                string userEmailFrom = emailFrom.ToString();
                string userEmailPassword = "$samsung1";

                MailMessage mail = new MailMessage();
                mail.To.Add(emailTo);
                mail.From = new MailAddress(userEmailFrom, "YourJester", System.Text.Encoding.UTF8);
                mail.Subject = emailSubject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = emailBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(userEmailFrom, userEmailPassword);
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Send(mail);

                mail.Dispose();
                client.Dispose();
            }

            catch (SmtpException RoutineError)
            {
                R9000TreatErrorException object01 = new R9000TreatErrorException();
                object01.Routine9000TreatErrorException(RoutineError);
            }
        }
    }
}

    