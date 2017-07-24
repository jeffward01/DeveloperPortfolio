using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Port.Net.Data.Infrastructure;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public Email Create(Email image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Added;
                context.SaveChanges();
                return image;
            }
        }

        public Email Edit(Email image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Modified;
                context.SaveChanges();
                return image;
            }
        }

        public List<Email> GetAllEmails()
        {
            using (var context = new PortfolioContext())
            {
                return context.Emails.ToList();
            }
        }

        public Email GetByImageId(int imageId)
        {
            using (var context = new PortfolioContext())
            {
                return context.Emails.FirstOrDefault(_ => _.EmailId == imageId);
            }
        }

        public Email Delete(Email image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Deleted;
                context.SaveChanges();
                return image;
            }
        }
    }
}
