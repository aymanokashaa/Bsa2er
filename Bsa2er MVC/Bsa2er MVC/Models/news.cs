using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class news
    {
        [Key]
        public int id { set; get; }
        
        public string title { set; get; }
                   
        public string body { set; get; }

        [NotMapped]
        public HttpPostedFile Image { set; get; }

        public string ImagePath { set; get; }

    }
}