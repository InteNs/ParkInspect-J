using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }


        public QuestionViewModel Update()
        {
            return null;
        }
        public QuestionViewModel Duplicate()
        {
            return null;
        }
        public void Reload()
        {

        }
        public void Create()
        {

        }
        public void Disable()
        {

        }
    }
}