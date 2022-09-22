using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }


        [Required, StringLength(50)]
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
