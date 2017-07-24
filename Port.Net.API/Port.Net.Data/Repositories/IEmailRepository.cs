using System.Collections.Generic;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Repositories
{
    public interface IEmailRepository
    {
        Email Create(Email image);
        Email Edit(Email image);
        List<Email> GetAllEmails();
        Email GetByImageId(int imageId);
        Email Delete(Email image);
    }
}