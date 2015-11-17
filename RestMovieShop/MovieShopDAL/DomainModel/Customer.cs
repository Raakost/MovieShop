using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.DomainModel
{
    [DataContract(IsReference = true)]
    [Table("Customer")]
    public class Customer
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string StreetNumber { get; set; }
        [DataMember]
        public int Zipcode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Email { get; set; }
        
        public virtual List<Order> Orders { get; set; }

    }
}
