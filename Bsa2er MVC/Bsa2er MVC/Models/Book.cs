using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace Bsa2er_MVC.Models
{
    public class Book
    {
        [Key]
        public int Id { set; get; }
        public String Title { set; get; }

        [NotMapped]
        public HttpPostedFileBase PdfFile { set; get; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { set; get; }

        public String PdfFilepath { set; get; }

        public string imageFilePath { set; get; }

    }
}