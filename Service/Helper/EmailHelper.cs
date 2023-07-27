using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace Service.Helper
{
    public static class EmailHelper
    {
        public static void sendMail(string toEmail, string subject, string messageBody)
        {
            string fromEmail = "info@golden-seagull.com";

            SmtpClient eMailClient = new SmtpClient("sjcdevsmtp", 25);
            eMailClient.UseDefaultCredentials = true;
            //eMailClient.Credentials = new NetworkCredential(fromEmail,"");
            MailMessage objMail = new MailMessage();
            objMail.SubjectEncoding = Encoding.UTF8;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = Encoding.UTF8;
            objMail.From = new MailAddress(fromEmail);
            string[] strArrToEmails = null;
            strArrToEmails = toEmail.Split(';');
            string strToEmail = null;
            foreach (string strToEmail_loopVariable in strArrToEmails)
            {
                strToEmail = strToEmail_loopVariable;
                if ((!strToEmail.Equals(string.Empty)))
                {
                    objMail.To.Add(new MailAddress(strToEmail));
                }
            }
            objMail.Subject = subject;
            objMail.Body = messageBody;

            try
            {
                eMailClient.Send(objMail);
            }
            catch (Exception ex)
            {
                
            }
        }
        public static void sendMailAttachment(string toEmail, string subject, string messageBody, string sFileName)
        {
            //For e-Brochure

            MailMessage objMail = new MailMessage();
            objMail.SubjectEncoding = Encoding.UTF8;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = Encoding.UTF8;
            string[] strArrToEmails = null;
            strArrToEmails = toEmail.Split(';');
            string strToEmail = null;
            string strToName = null;
            foreach (string strToEmail_loopVariable in strArrToEmails)
            {
                strToEmail = strToEmail_loopVariable;

                if ((!strToEmail.Equals(string.Empty)))
                {

                    if (strToEmail.Contains('{'))
                    {
                        int startindex = strToEmail.IndexOf('{');
                        int endindex = strToEmail.IndexOf('}');
                        int len = endindex - startindex;
                        strToName = strToEmail.Substring(startindex + 1, len - 1);
                        strToEmail = strToEmail.Substring(endindex + 1);

                        objMail.To.Add(new MailAddress(strToEmail, strToName));
                    }

                    else
                    {
                        objMail.To.Add(new MailAddress(strToEmail));
                    }

                }
            }
            objMail.Subject = subject;
            objMail.Body = messageBody;

            /* Attach the newly created email attachment */
            try
            {
                objMail.Attachments.Add(new Attachment(sFileName));
            }
            catch
            {
            }

            SmtpClient eMailClient = new SmtpClient();
            //eMailClient.EnableSsl = True
            try
            {
                eMailClient.Send(objMail);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }





}
