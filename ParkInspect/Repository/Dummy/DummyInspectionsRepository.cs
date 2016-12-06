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
                new InspectionViewModel { Name = "inspectie 1" },
                new InspectionViewModel { Name = "inspectie 2" },
                new InspectionViewModel { Name = "inspectie 3" },
                new InspectionViewModel { Name = "inspectie 4" },
                new InspectionViewModel { Name = "inspectie 5" }
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
