using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ParkInspectPortal.Models;

namespace ParkInspectPortal.Repositories
{
    public interface IInspectionRepo
    {
        List<InspectionViewModel> GetInspections();
        List<QuestionListViewModel> GetQuestionList(Guid guid);
    }
}
