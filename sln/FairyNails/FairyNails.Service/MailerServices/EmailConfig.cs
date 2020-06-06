using System;
using System.Collections.Generic;
using System.Text;

namespace FairyNails.Service.MailerServices
{
   public class EmailConfig
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPortNumber { get; set; }
        public List<string> ToAddress { get; set; }
        public IEnumerable<string> DefaultAdress { get; set; }
    }
}
