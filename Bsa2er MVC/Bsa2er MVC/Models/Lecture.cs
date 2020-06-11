using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Lecture
    {
        [Key]
        public int Lecture_Id { get; set; }
        public string Lecture_Title { get; set; }
        public string Lecture_VideoLink { get; set; }

        [ForeignKey("Program")]
        public int Program_Id { get; set; }

        public virtual ICollection<LectureFiles> LectureFiles { get; set; }
        public virtual Program Program { get; set; }
    }
}