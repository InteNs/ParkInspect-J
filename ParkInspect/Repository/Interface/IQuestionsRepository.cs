using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repository.Interface
{
    public interface IQuestionsRepository : IBaseRepository<QuestionItemViewModel>
    {
        ObservableCollection<string> GetFunctions();
    }
}
