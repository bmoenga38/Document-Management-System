namespace FINNETT.data
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="EmailSender" />
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        /// The SendMail
        /// </summary>
        /// <param name="fromemail">The fromemail<see cref="string"/></param>
        /// <param name="toaddress">The toaddress<see cref="string"/></param>
        /// <param name="subject">The subject<see cref="string"/></param>
        /// <param name="mailbody">The mailbody<see cref="string"/></param>
        /// <param name="frommask">The frommask<see cref="string"/></param>
        /// <param name="frommaskname">The frommaskname<see cref="string"/></param>
        /// <param name="cclist">The cclist<see cref="string"/></param>
        /// <param name="bcclist">The bcclist<see cref="string"/></param>
        /// <param name="attachmentPath">The attachmentPath<see cref="string"/></param>
        /// <param name="ishtml">The ishtml<see cref="bool"/></param>
        /// <param name="profileid">The profileid<see cref="string"/></param>
        /// <param name="username">The username<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool SendMail(string fromemail, string toaddress, string subject, string mailbody, string frommask,
            string frommaskname, string cclist, string bcclist, string attachmentPath, bool ishtml, string profileid,
            string username)
        {
            bool state = false;
            string thisBody = string.Empty;
            string responseStatus = EmailCredentials.GetGatewayData(fromemail);
            if (responseStatus == "FLIP")
            {
                MailMessage nMail = new MailMessage();
                string fromAddress = fromemail;
                string fromPassword = EmailCredentials.psd;
                string toAddress = toaddress;

                if (toAddress.Contains(";"))
                {
                    string[] sendToThisGuys = toAddress.Split(Convert.ToChar(";"));
                    foreach (string sentotGuy in sendToThisGuys)
                    {
                        nMail.To.Add(sentotGuy);
                    }
                }
                else
                {
                    nMail.To.Add(toAddress);
                }

                if (frommask.Length > 0)
                {
                    nMail.From = new MailAddress(frommask, frommaskname);
                }
                else
                {
                    nMail.From = new MailAddress(fromemail, EmailCredentials.displayName);
                }

                nMail.IsBodyHtml = ishtml;
                //nMail.BodyEncoding = System.Text.Encoding.UTF8;
                thisBody = WebUtility.HtmlDecode(mailbody);
                //thisBody = WebUtility.HtmlEncode(mailbody);
                nMail.Body = thisBody;
                nMail.Subject = subject;

                if (cclist.Length > 0)
                {
                    if (cclist.Contains(";"))
                    {
                        string[] ccThisGuys = cclist.Split(Convert.ToChar(";"));
                        foreach (string ccGuy in ccThisGuys)
                        {
                            nMail.CC.Add(ccGuy);
                        }
                    }
                    else
                    {
                        nMail.CC.Add(cclist);
                    }
                }


                if (bcclist.Length > 0)
                {
                    if (bcclist.Contains(";"))
                    {
                        string[] bccThisGuys = bcclist.Split(Convert.ToChar(";"));
                        foreach (string bccGuy in bccThisGuys)
                        {
                            nMail.CC.Add(bccGuy);
                        }
                    }
                    else
                    {
                        nMail.CC.Add(bcclist);
                    }
                }


                nMail.SubjectEncoding = new UTF8Encoding();

                if (attachmentPath.Length > 0)
                {
                    if (attachmentPath.Contains(";"))
                    {
                        string[] attachments = attachmentPath.Split(Convert.ToChar(";"));
                        foreach (string attachment in attachments)
                        {
                            nMail.Attachments.Add(new Attachment(attachment));
                        }
                    }
                    else
                    {
                        nMail.Attachments.Add(new Attachment(attachmentPath));
                    }
                }

                SmtpClient smtp = new SmtpClient(EmailCredentials.smstpserver);
                {
                    if (EmailCredentials.port > 0)
                    {
                        smtp.Port = EmailCredentials.port;
                    }

                    smtp.Credentials = new NetworkCredential(fromAddress.Trim(), fromPassword.Trim());
                    smtp.EnableSsl = EmailCredentials.usesSSL;
                }
                try
                {
                    smtp.Timeout = 999999999;
                    smtp.Send(nMail);

                    //Log EMails

                    state = true;
                }
                catch (Exception)
                {
                    state = false;
                    //Log EMails
                    //db.LogChamaSentEmails(profileid, toaddress, cclist, bcclist, fromemail, subject, mailbody,
                    //    attachmentPath, "FAILED", ex.Message, username);
                }
            }
            else
            {
                state = false;
            }

            string response = string.Empty;


            return state;
        }
    }
}