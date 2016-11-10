using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{

    public class EmployeeViewModel
    {
        //written for tests
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string Function { get; set; }

        public EmployeeViewModel(int id, string name, string region, string function)
        {
            Id = id;
            Name = name;
            Region = region;
            Function = function;
        }

        public EmployeeViewModel()
        {

        }

    }
}
