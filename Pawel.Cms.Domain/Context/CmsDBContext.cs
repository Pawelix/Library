using Microsoft.EntityFrameworkCore;
using Pawel.Cms.Domain.Model;

namespace Pawel.Cms.Domain.Context
{
    public class CmsDBContext : DbContext
    {
        public CmsDBContext(DbContextOptions<CmsDBContext> options)
       : base(options)
        { }

        public CmsDBContext()
        {

        }

        public DbSet<Book> Books { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=CmsDB;Trusted_Connection=True;");
        }
    }
}
