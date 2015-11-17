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
    [Table("Genre")]
   public  class Genre
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
