using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class AddressModel   // This should be declared public to be accessed outside
    {
        public int ID { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
