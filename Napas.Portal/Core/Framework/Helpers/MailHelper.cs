using System;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Text;
using Microsoft.SharePoint;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    public static class MailHelper
    {
        /// <summary>
        ///   Sends an e-mail message.
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "messageHeaders"></param>
        /// <param name = "messageBody"></param>
        /// <returns></returns>
        public static void SendEmail(SPWeb web, StringDictionary messageHeaders, string messageBody)
        {
            var mailMessage = new MailMessage
                                  {
                                      IsBodyHtml = true,
                                      BodyEncoding = Encoding.UTF8,
                                      Body = messageBody
                                  };
            if (messageHeaders != null)
            {
                // From
                if (messageHeaders.ContainsKey("from"))
                {
                    var from = messageHeaders["from"];
                    if (!string.IsNullOrEmpty(from))
                    {
                        mailMessage.From = new MailAddress(from);
                    }
                }
                else
                {
                    var senderAddress = web.Site.WebApplication.OutboundMailSenderAddress;
                    if (!string.IsNullOrEmpty(senderAddress))
                    {
                        mailMessage.From = new MailAddress(senderAddress);
                    }
                }

                // To
                if (messageHeaders.ContainsKey("to"))
                {
                    var split = Convert.ToString(messageHeaders["to"]).Split(new[] {"; ", ";"},
                                                                             StringSplitOptions.RemoveEmptyEntries);
                    foreach (var value in split)
                    {
                        mailMessage.To.Add(value);
                    }
                }

                // Subject
                if (messageHeaders.ContainsKey("subject"))
                {
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Subject = messageHeaders["subject"];
                }

                // Content Type
                if (messageHeaders.ContainsKey("content-type"))
                {
                    var contentType = messageHeaders["content-type"];
                    if (string.IsNullOrEmpty(contentType))
                    {
                        contentType = "text/html";
                    }
                    mailMessage.Headers.Add("content-type", contentType);
                }

                // CC
                if (messageHeaders.ContainsKey("cc"))
                {
                    var split = Convert.ToString(messageHeaders["cc"]).Split(new[] {"; ", ";"},
                                                                             StringSplitOptions.RemoveEmptyEntries);
                    foreach (var value in split)
                    {
                        mailMessage.CC.Add(value);
                    }
                }

                // Bcc
                if (messageHeaders.ContainsKey("bcc"))
                {
                    var split = Convert.ToString(messageHeaders["bcc"]).Split(new[] {"; ", ";"},
                                                                              StringSplitOptions.RemoveEmptyEntries);
                    foreach (var value in split)
                    {
                        mailMessage.Bcc.Add(value);
                    }
                }
            }

            SendEmail(web, mailMessage);
        }

        public static void SendEmail(SPWeb web, string to, string subject, string htmlBody)
        {
            var messageHeaders = new StringDictionary {{"to", to}, {"subject", subject}};
            SendEmail(web, messageHeaders, htmlBody);
        }

        public static void SendEmail(SPWeb web, string from, string to, string subject, string htmlBody)
        {
            var messageHeaders = new StringDictionary {{"from", from}, {"to", to}, {"subject", subject}};
            SendEmail(web, messageHeaders, htmlBody);
        }

        /// <summary>
        ///   Sends an e-mail message.
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "mailMessage"></param>
        public static void SendEmail(SPWeb web, MailMessage mailMessage)
        {
            var mailService = web.Site.WebApplication.OutboundMailServiceInstance;
            if (mailService == null)
            {
                throw new ArgumentException("Cannot get instance of mail service, please contact with administrator to get support.");
            }

            var smtpServerAddress = mailService.Server.Address;
            if (string.IsNullOrEmpty(smtpServerAddress))
            {
                throw new ArgumentException("The mail service is not configuration, please contact with administrator to get support.");
            }

            if (mailMessage.From == null)
            {
                mailMessage.From = new MailAddress(web.Site.WebApplication.OutboundMailSenderAddress);
            }

            var smtpClient = new SmtpClient(smtpServerAddress) {UseDefaultCredentials = false};

            //smtpClient.SendAsync(mailMessage, null);
            // QuangLH
            smtpClient.Send(mailMessage);

        }
    }
}