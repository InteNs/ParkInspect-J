using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public QuestionType QuestionType { get; set; }

        public QuestionViewModel Update()
        {
            if (!IsActive) return Create();
            var newQuestion = Create();
            newQuestion.Id++;
            return newQuestion;
        }

        public QuestionViewModel Create()
        {
            var newQuestion = new QuestionViewModel
            {
                Description = Description,
                Version = Version,
                QuestionType = QuestionType,
                IsActive = true
            };
            return newQuestion;
        }

        public QuestionViewModel Duplicate()
        {
            var newQuestion = new QuestionViewModel
            {
                Description = Description,
                Version = 1
            };
            return newQuestion;
        }
    }
}