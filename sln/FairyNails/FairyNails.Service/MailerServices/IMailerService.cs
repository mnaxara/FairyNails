using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FairyNails.Service.MailerServices
{
    public interface IMailerService
    {
        string Content { get; set; }

        Task<bool> SendInfoEmailAsync(List<string> toAddress, string subject, string body, AttachmentCollection Attachments = null);
    }
}