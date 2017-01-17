using System.Data.Entity;
using System.Linq;
using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public QuestionType QuestionType { get; set; }



        public QuestionViewModel Update()
        {
            if (isActive)
            {
                var newQuestion = Create();
                newQuestion.Id++;
                return newQuestion;
            }
            else
            {
                return Create();
            }
        }

        public QuestionViewModel Create()
        {
            var newQuestion = new QuestionViewModel();
            newQuestion.Description = Description;
            newQuestion.Version = Version;
            newQuestion.QuestionType = QuestionType;
            newQuestion.isActive = true;
            return newQuestion;
        }

        public QuestionViewModel Duplicate()
        {
            var newQuestion = new QuestionViewModel();
            newQuestion.Description = Description;
            newQuestion.Version = 1;
            return newQuestion;
        }

    }
}