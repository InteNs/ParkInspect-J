﻿using System;
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
                new InspectionViewModel { Id = 1, Name = "inspectie 1", StartTime = new DateTime(2016,12,1), cvm = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"}} },
                new InspectionViewModel { Id = 2, Name = "inspectie 2", StartTime = new DateTime(2016,10,18), cvm = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"} } },
                new InspectionViewModel { Id = 3, Name = "inspectie 3", StartTime = new DateTime(2016,9,26), cvm = new CommissionViewModel {Id = 1, Customer = new CustomerViewModel() {Id = 1, Name = "Mark Havekes"}, Employee = new EmployeeViewModel() {Id = 1, Name = "Pim Westervoort"} } },
                new InspectionViewModel { Id = 4, Name = "inspectie 4", StartTime = new DateTime(2016,11,13), cvm = new CommissionViewModel {Id = 2 , Customer = new CustomerViewModel() {Id = 2, Name = "Pim Westervoort"}, Employee = new EmployeeViewModel() {Id = 2, Name = "Edward van Lieshout"} } },
                new InspectionViewModel { Id = 5, Name = "inspectie 5", StartTime = new DateTime(2016,8,6), cvm = new CommissionViewModel {Id = 2, Customer = new CustomerViewModel() {Id = 2, Name = "Pim Westervoort"}, Employee = new EmployeeViewModel() {Id = 2, Name = "Edward van Lieshout"} } }
            };
        }
        public ObservableCollection<InspectionViewModel> GetAll()
        {
            return _inspections;
        }

        public bool Add(InspectionViewModel item)
        {
            _inspections.Add(item);
            return true;
        }

        public bool Delete(InspectionViewModel item)
        {
            return _inspections.Remove(item);
        }

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
