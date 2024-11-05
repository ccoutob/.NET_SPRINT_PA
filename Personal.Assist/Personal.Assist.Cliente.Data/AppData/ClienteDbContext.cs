using Microsoft.EntityFrameworkCore;
using Sprint4dotnet.Models;
using Personal.Assist.Model

namespace Sprint4dotnet.Data
{
	public class ClienteDbContext : DbContext
	{
		public DbSet<Cliente> Clientes { get; set; }

		public ClienteDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM97755;Password=050505;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cliente>(b =>
			{
				b.ToTable("Clientes");
				b.HasKey(c => c.Id);
				b.Property(c => c.Id)
					.ValueGeneratedOnAdd()
					.HasColumnType("VARCHAR2(255)");
				b.Property(c => c.Nome)
					.IsRequired()
					.HasColumnType("VARCHAR2(255)");
				b.Property(c => c.Sobrenome)
					.IsRequired()
					.HasColumnType("VARCHAR2(255)");
				b.Property(c => c.Email)
					.IsRequired()
					.HasColumnType("VARCHAR2(255)");
				b.Property(c => c.Idade)
					.ValueGeneratedOnAdd()
					.HasColumnType("NUMBER(10)");
			});
		}
	}
}