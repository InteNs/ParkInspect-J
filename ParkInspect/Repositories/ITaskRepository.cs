using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskViewModel> GetAll();
        bool Create(TaskViewModel employee);
        bool Update(TaskViewModel employee);
    }
}
