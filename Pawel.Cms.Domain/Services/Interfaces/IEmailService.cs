
using System;

namespace Pawel.Cms.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string subject, string body, string to = null);
        string CreateActivationLinkBody(Guid id);
    }
}
