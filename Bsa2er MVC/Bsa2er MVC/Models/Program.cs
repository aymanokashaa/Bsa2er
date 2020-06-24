using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bsa2er_MVC.Models
{
    public class Program
    {
        [Key]
        public int Program_Id { get; set; }
        [Display(Name = "عنوان البرنامج")]
        public string Program_Title { get; set; }
        [Display(Name = "مدة البرنامج")]
        public string Program_Duration { get; set; }
        [Display(Name = "مميزات البرنامج")]
        public string Program_Advantages { get; set; }
        [Display(Name = "اهداف البرنامج")]
        public string Program_Goals { get; set; }
        [Display(Name = "اضافة صورة")]
        public string Program_ImagePath { get; set; }
        [Display(Name = "نبذة عن البرنامج")]
        public string Program_Body { set; get; }
        [Display(Name = "لينك الفيديو الخاص بالبرنامج")]
        public string Program_VideoLink { get; set; }
        [Display(Name = "الفئة المستهدفة")]
        public string Program_TargetGroup { get; set; }
        [Display(Name = "نوع البرنامج")]
        public ProgramType Program_Type { get; set; }
        [Display(Name = "عدد المحاضرات")]

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
        Private, Public
    }
}