using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionItemViewModel : MainViewModel
    {
        public QuestionItemViewModel()
        {

        }
        
        public QuestionViewModel Question { get; set; }
        public string Answer { get; set; }

        public int QuestionId => Question.Id;
        public int QuestionVersion => Question.Version;
        public string QuestionDescription => Question.Description;
        public QuestionType QuestionType => Question.QuestionType;

    }
}
