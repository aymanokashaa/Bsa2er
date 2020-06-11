using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Models
{
    public class Exam
    {
        [Key]
        public int Exam_Id { set; get; }
        public string Title { set; get; }
        public int grads { set; get; }
        public int NumberOfQuestions { set; get; }
        public virtual ICollection<Question> Questions { set; get; }
        public virtual Program Program { set; get; }
        

    }
}