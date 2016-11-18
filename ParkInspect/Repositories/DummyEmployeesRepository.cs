﻿using Data;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public class DummyEmployeesRepository : IEmployeeRepository
    {

        private EmployeesViewModel _evm;

        public bool Create(EmployeeViewModel employee)
        {
            return true;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return new List<EmployeeViewModel>
            {
                new EmployeeViewModel(1, "Pim Westervoort", "Brabant", "Inspecteur"),
                new EmployeeViewModel(2, "Edward van Lieshout", "Brabant", "Inspecteur"),
                new EmployeeViewModel(3, "Mark Havekes", "Utrecht", "Inspecteur"),
                new EmployeeViewModel(4, "Pim Pam Pet", "Limburg", "Inspecteur"),
                new EmployeeViewModel(5, "Mathijs van Bree", "Limburg", "Directeur")
            };
        }

        public bool Update(EmployeeViewModel employee)
        {
            return true;
        }

        public IEnumerable<string> GetRegions()
        {
            return new List<string>
            {
                "Limburg",
                "Utrecht",
                "Brabant"
            };
        }

        public IEnumerable<string> GetFunctions()
        {
            return new List<string>
            {
                "Directeur",
                "Inspecteur",
                "Manager"
            };
        }
    }
}
