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
        public void AssigmentsPerLocation(DateTime? StartDate, DateTime? EndDate, EmployeeViewModel SelectedInspector = null)
        {
            // if (Points.Count != 0) { Points.Clear(); };
            
        }

        // Inspections per locations
        public void InspectionsPerLocation(DateTime? StartDate, DateTime? EndDate, QuestionItemViewModel SelectedQuestion, string SelectedAnswer)
        {
            //if (Points.Count < 1) { Points.Clear(); };

        }

        // Inspectors per location
        public void InspectorsPerLocation()
        {
            //if (Points.Count < 1) { Points.Clear(); };
            
        }

        // Customers per location
        // TODO: Per Regio
        public void CustomersPerLocation()
        {
            //if (Points.Count < 1) { Points.Clear(); };
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (var customer in Customers)
            {
                var latLong = Location.GetLatLongFromAddress(customer.ZipCode);
                var region = Location.GetRegionFromLatLong(latLong.Latitude, latLong.Longitude);
                if (counter.ContainsKey(Location.GetRegionFromLatLong(latLong.Latitude, latLong.Longitude).Name))
                {
                    counter[Location.GetRegionFromLatLong(latLong.Latitude, latLong.Longitude).Name]++;
                }
                else
                {
                    counter.Add(Location.GetRegionFromLatLong(latLong.Latitude, latLong.Longitude).Name, 1);
                }
            }

            foreach (var regios in counter)
            {
                Console.Out.NewLine = regios.Key;
            }
        }
    }
}
