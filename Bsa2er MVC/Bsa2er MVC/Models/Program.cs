using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Program
    {
        [Key]
        public int Program_Id { get; set; }
        public string Program_Title { get; set; }
        public string Program_Duration { get; set; }
        public string Program_Advantages { get; set; }
        public string Program_Goals { get; set; }
        public string Program_ImagePath { get; set; }
        public string Program_VideoLink { get; set; }
        public string Program_TargetGroup { get; set; }
        public ProgramType Program_Type { get; set; }
        public int NumOfLecture { get; set; }

        [ForeignKey("Instructor")]
        public string Ins_Id { get; set; }
        public virtual ICollection<Lecture> lectures { get; set; }
        
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<StudentsPrograms> StudentsProgram { get; set; }
    }
    public enum ProgramType
    {
        Private,Public
    }
}