using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewModel : MainViewModel
    {
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
           QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
        }
    }
}
