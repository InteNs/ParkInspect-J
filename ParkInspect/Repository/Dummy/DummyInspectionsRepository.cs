using System;
using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyInspectionsRepository : IInspectionsRepository
    {
        private readonly ObservableCollection<InspectionViewModel> _inspections;

        public DummyInspectionsRepository()
        {
            _inspections = new ObservableCollection<InspectionViewModel>
            {
                new InspectionViewModel { Id = 1, Name = "inspectie 1", StartTime = new DateTime(2016,12, 1, 13, 10, 0), EndTime = new DateTime(2016,12, 1, 16, 45, 0), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"}} },
                new InspectionViewModel { Id = 2, Name = "inspectie 2", StartTime = new DateTime(2016,10,18, 13, 10, 0), EndTime = new DateTime(2016,10,18, 16, 45, 0), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"} } },
                new InspectionViewModel { Id = 3, Name = "inspectie 3", StartTime = new DateTime(2016,9,26, 13, 10, 0), EndTime = new DateTime(2016,9, 26, 16, 45, 0), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"} } },
                new InspectionViewModel { Id = 4, Name = "inspectie 4", StartTime = new DateTime(2016,11,13, 13, 10, 0), EndTime = new DateTime(2016,11, 13, 16, 45, 0), CommissionViewModel = new CommissionViewModel {Id = 2 , Customer = new CustomerViewModel() {Id = 2, Name = "Pim Westervoort"}, Employee = new EmployeeViewModel() {Id = 2, Name = "Edward van Lieshout"} } },
                new InspectionViewModel { Id = 5, Name = "inspectie 5", StartTime = new DateTime(2016,8,6, 13, 10, 0), EndTime = new DateTime(2016,8, 6, 16, 45, 0), CommissionViewModel = new CommissionViewModel {Id = 2, Customer = new CustomerViewModel() {Id = 2, Name = "Pim Westervoort"}, Employee = new EmployeeViewModel() {Id = 2, Name = "Edward van Lieshout"} } },
                new InspectionViewModel { Id = 1, Name = "inspectie 6", StartTime = new DateTime(2016,12, 1, 17, 10, 0), EndTime = new DateTime(2016,12, 1, 20, 00, 0), CommissionViewModel = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 3, Name = "Piet"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"}} }
            };
        }
        public ObservableCollection<InspectionViewModel> GetAll() => _inspections;

        public bool Add(InspectionViewModel item)
        {
            _inspections.Add(item);
            return true;
        }

        public bool Delete(InspectionViewModel item) => _inspections.Remove(item);

        public bool Update(InspectionViewModel item)
        {
            var index = _inspections.IndexOf(item);
            if (index < 0) return false;
            _inspections.RemoveAt(index);
            _inspections.Insert(index, item);
            return true;
        }
    }
}
