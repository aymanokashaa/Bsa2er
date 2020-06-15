using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class StudentsPrograms
    {
        [Key]
        [ForeignKey("Student"),Column(Order =0)]
        public string Std_Id { get; set; }
        [Key]
        [ForeignKey("Program"),Column(Order =1)]
        public int Program_Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public virtual Program Program { get; set; }
        public virtual Student Student { get; set; }
    }
}