using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Instructor
    {
       
       [ForeignKey("ApplicationUser")]
       [Key]
        public string InsId { get; set; }
        
        public string Degree { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}