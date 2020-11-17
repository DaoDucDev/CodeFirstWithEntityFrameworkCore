using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DatabaseContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DeptManager> DeptManagers { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Titles)
                        .WithOne(t => t.Employee);

            modelBuilder.Entity<DeptManager>()
                        .HasKey(d => new { d.DeptNo, d.EmpNo });

            modelBuilder.Entity<Salary>()
                        .HasKey(s => new { s.EmpNo, s.FromDate, s.ToDate });

            modelBuilder.Entity<Title>()
                        .HasKey(t => new { t.EmpNo, t.EmpTitle });
        }
    }
}
