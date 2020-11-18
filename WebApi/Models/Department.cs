using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.JoiningEntityClasses;

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

        public ICollection<DeptManager> DeptManagers { get; set; }
        public IList<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
