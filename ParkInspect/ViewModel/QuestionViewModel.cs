using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }

    }
}