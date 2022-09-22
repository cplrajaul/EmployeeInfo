using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.ViewModel
{
    public class EmployeeViewModel
    {
        [Key]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }


        [Required]
        [StringLength(13)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required, StringLength(100)]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }


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



        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }



        [Display(Name = "Department")]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }




        [Display(Name = "Image")]
        public string PhotoPath { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string ExistingPhotoPath { get; set; }
    }
}
