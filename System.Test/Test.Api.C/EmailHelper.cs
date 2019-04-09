using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using Newtonsoft.Json;

namespace Test.Api.C
{
    public class EmailHelper
    {
        public static void SendHealthEmail(EmailSettings settings, string content)
        {
            try
            {
                //dynamic list = JsonConvert.DeserializeObject(content);
                if (!string.IsNullOrEmpty(content))
                {
                    //var emailBody = new StringBuilder("健康检查故障:\r\n");
                    //foreach (var noticy in list)
                    //{
                    //    emailBody.AppendLine($"--------------------------------------");
                    //    emailBody.AppendLine($"Node:{noticy.Node}");
                    //    emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                    //    emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                    //    emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                    //    emailBody.AppendLine($"Check Name:{noticy.Name}");
                    //    emailBody.AppendLine($"Check Status:{noticy.Status}");
                    //    emailBody.AppendLine($"Check Output:{noticy.Output}");
                    //    emailBody.AppendLine($"--------------------------------------");
                    //}

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(settings.FromWho, settings.FromAccount));
                    message.To.Add(new MailboxAddress(settings.ToWho, settings.ToAccount));
                    var bytes = Encoding.Default.GetBytes(settings.Subject);                 
                    message.Subject = Encoding.UTF8.GetString(bytes);
                    message.Body = new TextPart("plain") {Text = content };
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect(settings.SmtpServer, settings.SmtpPort, false);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(settings.AuthAccount, settings.AuthPassword);
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
