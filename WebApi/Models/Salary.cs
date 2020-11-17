using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("salaries")]
    public class Salary
    {
        [Column("emp_no")]
        public Guid EmpNo { get; set; }

        [Column("from_date")]
        public DateTime FromDate { get; set; }

        [Column("to_date")]
        public DateTime ToDate { get; set; }

        [Column("salary")]
        public double EmpSalary { get; set; }
    }
}
