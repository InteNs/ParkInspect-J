using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using MapControl;
using MapPoint = ParkInspect.Maps.MapPoint;

namespace ParkInspect.ViewModel
{
    public class MapViewModel : MainViewModel
    {
        // Collection of points within the map.
        public ObservableCollection<MapPoint> Points { get; set; }

        // Map Center
        public Location MapCenter { get; set; }

        // Location Services based on Google. Online use only.
        private GoogleLocationService Location { get; set; }

        // Data :D
        private List<CommissionViewModel> Commissions { get; set; }
        private List<InspectionViewModel> Inspections { get; set; }
        private List<EmployeeViewModel> Employees { get; set; }
        private List<CustomerViewModel> Customers { get; set; }

        public int ZoomLevel { get; set; }

        // Constructor
        public MapViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<InspectionViewModel> inspections, 
            IEnumerable<EmployeeViewModel> inspectors, IEnumerable<CustomerViewModel> customers)
        {
            // Set Location Translator and default address to Avans.
            Location = new GoogleLocationService();
            var avans = Location.GetLatLongFromAddress("5223 DE");
            MapCenter = new Location(avans.Latitude, avans.Longitude);
            ZoomLevel = 7;
            
            // Set Data Sources.
            Commissions = commissions.ToList();
            Inspections = inspections.ToList();
            Employees = inspectors.ToList();
            Customers = customers.ToList();
        }

        // Assigment per location
        // TODO: Remove plotted information before plotting new ones.
        public void AssigmentsPerLocation()
        {
            // if (Points.Count != 0) { Points.Clear(); };
            
        }

        // Inspections per locations
        public void InspectionsPerLocation()
        {
            //if (Points.Count < 1) { Points.Clear(); };

        }

        // Inspectors per location
        public void InspectorsPerLocation()
        {
            //if (Points.Count < 1) { Points.Clear(); };
            
        }

        // Customers per location
        public void CustomersPerLocation()
        {
            //if (Points.Count < 1) { Points.Clear(); };

        }
    }
}
