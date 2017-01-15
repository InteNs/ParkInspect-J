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
        private int id;
        private string description;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
           QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
        }
    }
}
