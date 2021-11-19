using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10,ErrorMessage ="Only 10 digits allowed")]
        [MaxLength(10,ErrorMessage ="Max 10 digits are allowed")]
        public string Contact_Number { get; set; }
        public bool Status { get; set; }
        public DateTime Joining_Date { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage ="Enter Valid date")]
        public string ProJoining_Date { get; set; }

    }
}