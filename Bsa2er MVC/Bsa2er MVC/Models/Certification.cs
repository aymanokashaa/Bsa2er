using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Certification
    {
        [Key]
        public int Cer_Id { get; set; }
        public string Cer_Title { get; set; }
        public string Cer_Body { get; set; }
        public string Cer_FilePath { get; set; }

     
        public virtual Program Program { get; set; }
    }
}