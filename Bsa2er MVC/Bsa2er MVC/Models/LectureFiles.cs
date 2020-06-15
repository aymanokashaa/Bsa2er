using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class LectureFiles
    {
        [Key,Column(Order =0)]
        [ForeignKey("Lecture")]
        public int Lecture_Id { get; set; }

        [Key,Column(Order =1)]
        public string FilePath { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}