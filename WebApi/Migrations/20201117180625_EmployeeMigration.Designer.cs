﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.DatabaseContext;

namespace WebApi.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20201117180625_EmployeeMigration")]
    partial class EmployeeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApi.Models.Department", b =>
                {
                    b.Property<Guid>("DeptNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("dept_no");

                    b.Property<string>("DeptName")
                        .HasColumnType("text")
                        .HasColumnName("dept_name");

                    b.HasKey("DeptNo");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("WebApi.Models.DeptManager", b =>
                {
                    b.Property<Guid>("DeptNo")
                        .HasColumnType("uuid")
                        .HasColumnName("dept_no");

                    b.Property<Guid>("EmpNo")
                        .HasColumnType("uuid")
                        .HasColumnName("emp_no");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("from_date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("to_date");

                    b.HasKey("DeptNo", "EmpNo");

                    b.ToTable("dept_manager");
                });

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.Property<Guid>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("emp_no");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("sex");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("hire_date");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("EmpNo");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("WebApi.Models.Salary", b =>
                {
                    b.Property<Guid>("EmpNo")
                        .HasColumnType("uuid")
                        .HasColumnName("emp_no");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("from_date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("to_date");

                    b.Property<double>("EmpSalary")
                        .HasColumnType("double precision")
                        .HasColumnName("salary");

                    b.HasKey("EmpNo", "FromDate", "ToDate");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("WebApi.Models.Title", b =>
                {
                    b.Property<Guid>("EmpNo")
                        .HasColumnType("uuid")
                        .HasColumnName("emp_no");

                    b.Property<string>("EmpTitle")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid?>("EmployeeEmpNo")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("from_date");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("to_date");

                    b.HasKey("EmpNo", "EmpTitle");

                    b.HasIndex("EmployeeEmpNo");

                    b.ToTable("titles");
                });

            modelBuilder.Entity("WebApi.Models.Title", b =>
                {
                    b.HasOne("WebApi.Models.Employee", "Employee")
                        .WithMany("Titles")
                        .HasForeignKey("EmployeeEmpNo");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.Navigation("Titles");
                });
#pragma warning restore 612, 618
        }
    }
}
