using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class news
    {
        [Key]
        public int id { set; get; }

        [Display(Name ="عنوان الخبر")]
        public string title { set; get; }
        [Display(Name ="محتوى الخبر")]
        public string body { set; get; }

        [NotMapped]
        public HttpPostedFile Image { set; get; }

        public string ImagePath { set; get; }

    }
}