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
        [ForeignKey("Student")]
        public string StdId { get; set; }

        [Key]
        [ForeignKey("Program")]
        public int program_Id { get; set; }
   
     

        public virtual Student Student { get; set; }
        public virtual Program Program { get; set; }
    }
}