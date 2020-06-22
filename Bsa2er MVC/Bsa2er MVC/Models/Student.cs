using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Student
    {
        
        [ForeignKey("ApplicationUser")]
        [Key]
        public string StdId { get; set; }

        public string WhereYouHearAboutUs { get; set; }
        public virtual ICollection<StudentsPrograms> StudentPrograms { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
  
    }
}