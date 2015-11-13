using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
