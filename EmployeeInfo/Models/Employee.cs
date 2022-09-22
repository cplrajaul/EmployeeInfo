using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name ="Name")]
        public string EmployeeName { get; set; }


        [Required]
        [StringLength(13)]
        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }


        [Required, StringLength(50)]
        public string Email { get; set; }


        [Required,StringLength(100)]
        public string Address { get; set; }


        [Display(Name = "Image")]
        public string PhotoPath { get; set; }


        [Required]
        [Display(Name = "Join Date")]
        [DataType(DataType.Date)]
        public string JoinDate { get; set; }



        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Created Time")]
        public DateTime CreatedTime { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Modified Time")]
        public DateTime ModifiedTime { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }


        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }


       
    }
}
