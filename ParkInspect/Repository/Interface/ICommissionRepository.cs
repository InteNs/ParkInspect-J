﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ICommissionRepository : IBaseRepository<CommissionViewModel>
    {
        void CreateLocation(LocationViewModel location);


        IEnumerable<string> GetRegions();
        IEnumerable<CustomerViewModel> GetCustomers();
        IEnumerable<LocationViewModel> GetLocationViewModels();

    }
}
