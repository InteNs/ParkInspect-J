using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    class DummyTaskRepository : ITaskRepository
    {
        public IEnumerable<TaskViewModel> GetAll()
        {
            return new List<TaskViewModel>()
            {
                new TaskViewModel() {Id = 1, Description = "VoorbeeldOpdracht" },
                new TaskViewModel() {Id = 2 ,Description = "Opdracht Avans" },
                new TaskViewModel() {Id = 3, Description = "Opdracht gemeente 's Hertogenbosch" }
            };
        }

        public bool Create(TaskViewModel employee)
        {
            return true;
        }

        public bool Update(TaskViewModel employee)
        {
            return true;
        }
    }
}
