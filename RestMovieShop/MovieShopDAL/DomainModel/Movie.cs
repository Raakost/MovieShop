using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.DomainModel
{
    [DataContract(IsReference = true)]
    [Table("Movie")]
    public class Movie
    {
        [DataMember]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [DataMember]
        [Display(Name = "Title")]
        [StringLength(100)]
        public string Title { get; set; }

        [DataMember]
        [DataType("Date")]
        [Display(Name = "Year")]
        public DateTime Year { get; set; }

        [DataMember]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [DataMember]
        [Display(Name = "Picture Path")]
        public string PicturePath { get; set; }

        [DataMember]
        [Display(Name = "URL")]
        public string TrailerURL { get; set; }

        [DataMember]
        [Display(Name = "Genre")]
        public virtual Genre Genre { get; set; }

        [DataMember]
        public virtual List<Order> Orders { get; set; }

    }
}
