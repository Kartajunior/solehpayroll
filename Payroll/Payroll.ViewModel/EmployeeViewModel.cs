using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "NIP"), MaxLength(10), Required]
        public string BadgeId { get; set; }

        [Display(Name = "Job Position")]
        public int JobPositionId { get; set; }

        [Display(Name = "Job Position")]
        public string JobName { get; set; }

        [Display(Name = "Job Position")]
        public string JobCode { get; set; }

        [Display(Name = "Job Position")]
        public string JobCodeName
        {
            get
            {
                return "[" + JobCode + "] " + JobName;
            }
        }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department")]
        public string DepartmentCode { get; set; }

        [Display(Name = "Department")]
        public string DepCodeName
        {
            get
            {
                return "[" + DepartmentCode + "] " + DepartmentName;
            }
        }

        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Division")]
        public string DivisionCode { get; set; }

        [Display(Name = "Division")]
        public string DivCodeName
        {
            get
            {
                return "[" + DivisionCode + "] " + DivisionName;
            }
        }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName) + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
            }
        }

        public string Address { get; set; }

        [Display(Name = "Date Of Hire"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime DateOfHire { get; set; }

        [Display(Name = "Date Of Resign"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DateOfResign { get; set; }

        [Display(Name = "Place Of Birth"), MaxLength(30), Required]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Date Of Birth"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Gender")]
        public string GenderName
        {
            get
            {
                if (Gender == "M")
                {
                    return "Male";
                }
                else if (Gender == "F")
                {
                    return "Female";
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        public bool IsActivated { get; set; }
    }

}
