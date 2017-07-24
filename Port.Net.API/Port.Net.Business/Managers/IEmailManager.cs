using Port.Net.Models.Dto;

namespace Port.Net.Business.Managers
{
    public interface IEmailManager
    {
        bool SendEmail(EmailModel email);
    }
}