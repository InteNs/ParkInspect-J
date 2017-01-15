using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }
        private QuestionListViewModel _selectedQuestionList;

        public QuestionListViewModel SelectedQuestionList
        {
            get { return _selectedQuestionList; }
            set
            {
                _selectedQuestionList = value;
                RaisePropertyChanged();
            }
        }

        public QuestionListsviewModel(IQuestionListRepository repo, IRouterService router) : base(router)
        {
            QuestionLists = repo.GetAll();
            SelectedQuestionList = QuestionLists[0];
            
        }
    }
}
