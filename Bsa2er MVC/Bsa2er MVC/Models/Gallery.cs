using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Gallery
    {
        [Key]
        public int G_Id { get; set; }
        public string Gallery_path { get; set; }
    }
}