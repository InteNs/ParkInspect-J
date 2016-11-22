using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface IQuestionRepository
    {
        QuestionViewModel Find(int id);
        IEnumerable<QuestionViewModel> All();
        QuestionViewModel Create(QuestionViewModel question);
        QuestionViewModel Update(QuestionViewModel question);
    }
}
