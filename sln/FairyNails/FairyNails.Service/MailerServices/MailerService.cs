using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FairyNails.Service.MailerServices
{
    public class MailerService : IMailerService
    {
        private readonly EmailConfig es;
        private readonly string _logoPath = @"C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\wwwroot\img\logo3.png";
        public string Content { get; set; }
        public MailerService(EmailConfig _es)
        {
            es = _es;
        }

        public async Task<bool> SendInfoEmailAsync(List<String> toAddress, string subject, string body, AttachmentCollection attachments = null)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("FairyNails - Informations", "selryam@hotmail.fr"));
                message.Subject = subject;
                foreach (string address in toAddress)
                {
                    message.To.Add(new MailboxAddress("", address));
                }
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                var bodyBuilder = new BodyBuilder();
                var bodyWithLogo = new StringBuilder();

                bodyWithLogo.Append(@"<center><img src=""cid:{0}""></center> <br>");
                bodyWithLogo.Append(body);
                //TODO: Fin de mail

                var image = bodyBuilder.LinkedResources.Add(_logoPath);
                image.ContentId = MimeUtils.GenerateMessageId();

                bodyBuilder.HtmlBody = string.Format(bodyWithLogo.ToString(), image.ContentId);

                if (attachments != null)
                {
                    for (int i = 0; i < attachments.Count; ++i)
                        bodyBuilder.Attachments.Add(attachments[i]);
                }

                message.Body = bodyBuilder.ToMessageBody();

                return await ConnectAndSendEmail(message);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

        private async Task<bool> ConnectAndSendEmail(MimeMessage message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    // SSL connection failed with client.CheckCertificateRevocation defaukt value (true)
                    // "MailKit.Security.SslHandshakeException: An error occurred while attempting to establish an SSL or TLS connection."
                    // https://github.com/jstedfast/MailKit/blob/master/FAQ.md#SslHandshakeException
                    //http://www.mimekit.net/docs/html/P_MailKit_IMailService_CheckCertificateRevocation.htm

                    client.CheckCertificateRevocation = false;

                    //*********************************************************
                    var credentials = new NetworkCredential
                    {
                        UserName = es.UserName,
                        Password = es.Password
                    };

                    await client.ConnectAsync(es.SmtpServer, es.SmtpPortNumber, SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(credentials);
                    await client.SendAsync(message).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

    }
}
