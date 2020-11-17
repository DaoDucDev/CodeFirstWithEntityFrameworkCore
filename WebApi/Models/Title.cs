using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("titles")]
    public class Title
    {
        [Column("emp_no")]
        public Guid EmpNo { get; set; }

        [Column("title")]
        public string EmpTitle { get; set; }

        [Column("from_date")]
        public DateTime FromDate { get; set; }

        [Column("to_date")]
        public DateTime ToDate { get; set; }

        public Employee Employee { get; set; }
    }
}
