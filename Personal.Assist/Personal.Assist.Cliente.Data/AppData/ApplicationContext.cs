using Personal.Assist.Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Personal.Assist.Cliente.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ClienteEntity> Cliente { get; set; }
    }
}
