using Emp.Domain.core;
using Microsoft.EntityFrameworkCore;

namespace Emp.Domain.Repositry
{
	public class EmployeeContext : DbContext
	{

		public EmployeeContext(DbContextOptions options)  :  base(options)
		{

		}
		DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			BaseEntityMap(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private void BaseEntityMap(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasKey(x => x.EmployeeId);

			modelBuilder.Entity<Employee>()
				.Property(x => x.EmployeeId)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Employee>()
				.Property(x => x.Name)
				.HasMaxLength(100);
		}

	}
}
