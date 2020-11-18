using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.JoiningEntityClasses;

namespace WebApi.Models
{
    public enum Sex { Male, Female };
    [Table("employees")]
    public class Employee
    {
        [Column("emp_no")]
        [Key]
        public Guid EmpNo { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("sex")]
        public Sex Gender { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        public ICollection<Title> Titles { get; set; }
        public ICollection<Salary> Salaries { get; set; }
        public ICollection<DeptManager> DeptManagers { get; set; }

        public IList<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
