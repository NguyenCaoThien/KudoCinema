using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KudoCinema.Models
{
    public class Movie
    {
        public int  Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        public DateTime  ReleaseDate{ get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int GenreId{ get; set; }
        public Genre Genre { get; set; }
    }
}