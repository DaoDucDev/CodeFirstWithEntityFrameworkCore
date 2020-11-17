using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("departments")]
    public class Department
    {
        [Column("dept_no")]
        [Key]
        public Guid DeptNo { get; set; }

        [Column("dept_name")]
        public string DeptName { get; set; }

    }
}
