using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.JoiningEntityClasses;

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
            //Tạo quan hệ 1-n giữa Employee và Title
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Titles)
                        .WithOne(t => t.Employee);

            //Tạo quan hệ 1-n giữa Employee và Salary
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Salaries)
                        .WithOne(s => s.Employee);

            //Tạo quan hệ 1-n giữa Employee và DeptManager
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.DeptManagers)
                        .WithOne(d => d.Employee);

            //Tạo quan hệ 1-n giữa Department và DeptManager
            modelBuilder.Entity<Department>()
                        .HasMany(de => de.DeptManagers)
                        .WithOne(dm => dm.Department);

            //Set Primary Key trong bảng DeptManager
            modelBuilder.Entity<DeptManager>()
                        .HasKey(d => new { d.DeptNo, d.EmpNo });

            //Set Primary Key trong bảng Salary
            modelBuilder.Entity<Salary>()
                        .HasKey(s => new { s.EmpNo, s.FromDate, s.ToDate });

            //Set Primary Key trong bảng Title
            modelBuilder.Entity<Title>()
                        .HasKey(t => new { t.EmpNo, t.EmpTitle });


            modelBuilder.Entity<DepartmentEmployee>()
                        .HasKey(de => new { de.DeptNo, de.EmpNo });

            //Quan hệ n-n giữa Employee và Department dc tách thành 2 quan hệ 1-n 
            //với bảng trung gian DepartmentEmployee
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.DepartmentEmployees)
                        .WithOne(de => de.Employee);

            modelBuilder.Entity<Department>()
                        .HasMany(d => d.DepartmentEmployees)
                        .WithOne(de => de.Department);


        }
    }
}
