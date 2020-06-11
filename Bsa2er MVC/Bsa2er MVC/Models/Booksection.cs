using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bsa2er_MVC.Models
{
    public class Booksection
    {

        public Booksection()
        {
            this.Books = new HashSet<Book>();
        }
        [Key]
        public int id { set; get; }

        public String title { set; get; }

        [NotMapped]
        public HttpPostedFileBase Image { set; get; }
        public string imagepath { set; get; }

        public ICollection<Book> Books { set; get; }

    }
}