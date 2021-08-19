using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Model
{
    public class EmployeModel // We have this thing in DB too, but for separation of concern we don't disturb that
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? AddressID { get; set; }

        [Required]
        public string Code { get; set; }
        public AddressModel Address { get; set; }
    }
}
