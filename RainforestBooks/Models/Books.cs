using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Bootstraptest.Models
{
    public class Books
    {
        [ScaffoldColumn(false)]
        public int BookID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string BookName { get; set; }

        [Required, StringLength(50), Display(Name = "Author")]
        public string Author { get; set; }

        [Required, StringLength(10000), Display(Name = "Book Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public int? Price { get; set; }

        public int? GenreID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string GenreName { get; set; }

        //public virtual ICollection<Books> Books { get; set; }


    }
}