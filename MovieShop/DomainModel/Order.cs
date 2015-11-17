using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [DataContract]
    [Table("Order")]
    public class Order
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public List<Movie> Movies { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

    }
}
