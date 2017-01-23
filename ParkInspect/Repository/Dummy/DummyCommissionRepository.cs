using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyCommissionRepository : ICommissionRepository
    {

        private readonly ObservableCollection<CommissionViewModel> _commissions;
        //Nooit gebruikt?
        private readonly List<LocationViewModel> _locations;

        public DummyCommissionRepository()
        {
            _locations = new List<LocationViewModel>();

            _commissions = new ObservableCollection<CommissionViewModel>
            {
                new CommissionViewModel
                {
                    Id = 1,
                    Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"},
                    Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"},
                    ZipCode = "8473LD",
                    StreetNumber = "47",
                    DateCreated = new DateTime(2016, 11, 17, 19, 57, 0),
                    Description = "description 1", Region = "Limburg", Status = "Nieuw"
                },
                new CommissionViewModel
                {
                    Id = 2,
                    Customer = new CustomerViewModel() {Id = 2, Name = "Pim Westervoort"},
                    Employee = new EmployeeViewModel() {Id = 2, Name = "Edward van Lieshout"},
                    ZipCode = "8473LD",
                    StreetNumber = "42",
                    DateCreated = new DateTime(2016, 11, 17, 19, 57, 0),
                    DateCompleted = new DateTime(2016, 11, 30),
                    Description = "description 2", Region = "Limburg", Status = "Klaar"
                }
            };
        }

        public ObservableCollection<string> GetStatuses() => new ObservableCollection<string> { "Nieuw", "Ingedeeld", "Bezig", "Klaar" };

        public ObservableCollection<CommissionViewModel> GetAll() => _commissions;

        public bool Add(CommissionViewModel item)
        {
            _commissions.Add(item);
            return true;
        }

        public bool Delete(CommissionViewModel item) => _commissions.Remove(item);

        public bool Update(CommissionViewModel item)
        {
            var index = _commissions.IndexOf(item);
            if (index < 0) return false;
            _commissions.RemoveAt(index);
            _commissions.Insert(index, item);
            return true;
        }
    }
}
