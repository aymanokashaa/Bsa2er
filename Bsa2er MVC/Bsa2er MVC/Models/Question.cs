using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bsa2er_MVC.Models
{
    public class Question
    {
        [Key]
        public int Q_Id { get; set; }

        public QuestionType QuestionType { get; set; }
        public int Q_Marks { get; set; }
        public string Q_Header { get; set; }
        public string Q_Answer { get; set; }
        public string ChoiceOne { get; set; }
        public string ChoiceTwo { get; set; }
        public string ChoiceThree { get; set; }
        public string ChoiceFour { get; set; }
        [ForeignKey("Exam")]
        public int Exam_Id { get; set; }
        public virtual Exam Exam { get; set; }


    }
    /*public class MultipleChooseQuestion:Question
    {
       
        public string ChoiceThree { get; set; }
        public string ChoiceFour { get; set; }
    }
    public class TrueOrFalseQuestion : Question
    {
         public TrueOrFalseQuestion()
        {
            ChoiceOne = "True";
            ChoiceTwo = "False";
        }
    }*/
    public enum QuestionType
    {
        MultipleChoose, TrueOrFalse
    }
}