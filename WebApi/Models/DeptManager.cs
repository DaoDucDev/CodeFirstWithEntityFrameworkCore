using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("dept_manager")]
    public class DeptManager
    {
        [Column("dept_no")]
        public Guid DeptNo { get; set; }

        [Column("emp_no")]
        public Guid EmpNo { get; set; }

        [Column("from_date")]
        public DateTime FromDate { get; set; }

        [Column("to_date")]
        public DateTime ToDate { get; set; }

        public Employee Employee { get; set; }

        public Department Department { get; set; }
    }
}
