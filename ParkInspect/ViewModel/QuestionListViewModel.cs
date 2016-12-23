using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewModel : MainViewModel
    {
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        public QuestionViewModel QuestionToAdd { get; set; }

        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public QuestionItemViewModel SelectedQuestionItem { get; set; }
        public ICommand RemoveQuestionCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
           QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
        }
    }
}
