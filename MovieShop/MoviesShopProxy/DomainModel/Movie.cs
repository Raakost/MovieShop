using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.DomainModel
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType("Date")]
        [Display(Name = "Year")]
        public DateTime Year { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Picture Path")]
        public string PicturePath { get; set; }

        [Display(Name = "URL")]
        public string TrailerURL { get; set; }

        [Display(Name = "Genre")]
        public virtual Genre Genre { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}
