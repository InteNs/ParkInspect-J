using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface IQuestionListRepository
    {
        IEnumerable<QuestionListViewModel> All();
        QuestionListViewModel Create(QuestionListViewModel questionList);
        QuestionListViewModel Update(QuestionListViewModel questionList);
        bool AddItem(QuestionListViewModel list, QuestionItemViewModel item);
        bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item);

    }
}
