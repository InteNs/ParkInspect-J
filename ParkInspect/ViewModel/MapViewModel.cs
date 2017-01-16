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
            Points = new ObservableCollection<MapPoint>();
            
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
            if (Points.Count < 1) { Points.Clear(); }

        }

        // Inspections per locations
        public void InspectionsPerLocation(DateTime? StartDate, DateTime? EndDate, QuestionItemViewModel SelectedQuestion, string SelectedAnswer)
        {
            if (Points.Count < 1) { Points.Clear(); }

        }

        // Inspectors per location
        public void InspectorsPerLocation()
        {
            if (Points.Count < 1) { Points.Clear(); };
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (var customer in Employees)
            {
                if (counter.ContainsKey(customer.Region))
                {
                    counter[customer.Region]++;
                }
                else
                {
                    counter.Add(customer.Region, 1);
                }
            }

            foreach (var regios in counter)
            {
                switch (regios.Key)
                {
                    case "Limburg":
                        // De beste
                        var maastricht = Location.GetLatLongFromAddress("6211 KM");
                        var setMaastricht = new MapPoint
                        {
                            Description = "Limburg, werknemers : " + regios.Value,
                            Location = new Location(maastricht.Latitude, maastricht.Longitude)
                        };
                        Points.Add(setMaastricht);
                        break;
                    case "Utrecht":
                        var utrecht = Location.GetLatLongFromAddress("3511 CE");
                        var setUtrecht = new MapPoint
                        {
                            Description = "Utrecht, werknemers : " + regios.Value,
                            Location = new Location(utrecht.Latitude, utrecht.Longitude)
                        };
                        Points.Add(setUtrecht);
                        MapCenter.Latitude = utrecht.Latitude;
                        MapCenter.Longitude = utrecht.Longitude;
                        break;
                    case "Brabant":
                        var brabant = Location.GetLatLongFromAddress("5211 AZ");
                        var setBrabant = new MapPoint
                        {
                            Description = "Brabant, werknemers : " + regios.Value,
                            Location = new Location(brabant.Latitude, brabant.Longitude)
                        };
                        Points.Add(setBrabant);
                        break;
                    case "Flevoland":
                        var lelystad = Location.GetLatLongFromAddress("8232 DL");
                        var setFlevoland = new MapPoint
                        {
                            Description = "Flevoland, werknemers : " + regios.Value,
                            Location = new Location(lelystad.Latitude, lelystad.Longitude)
                        };
                        Points.Add(setFlevoland);
                        break;
                    case "Groningen":
                        var groningen = Location.GetLatLongFromAddress("9726 AE");
                        var setGroningen = new MapPoint
                        {
                            Description = "Groningen, werknemers : " + regios.Value,
                            Location = new Location(groningen.Latitude, groningen.Longitude)
                        };
                        Points.Add(setGroningen);
                        break;
                    case "Zeeland":
                        var zeeland = Location.GetLatLongFromAddress("4337 LH");
                        var setZeeland = new MapPoint
                        {
                            Description = "Zeeland, werknemers : " + regios.Value,
                            Location = new Location(zeeland.Latitude, zeeland.Longitude)
                        };
                        Points.Add(setZeeland);
                        break;
                }
            }

            ZoomLevel = 8;
        }

        // Customers per location
        public void CustomersPerLocation()
        {
            if (Points.Count < 1) { Points.Clear(); };
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (var customer in Customers)
            {
                if (counter.ContainsKey(customer.Region))
                {
                    counter[customer.Region]++;
                }
                else
                {
                    counter.Add(customer.Region, 1);
                }
            }

            foreach (var regios in counter)
            {
                switch (regios.Key)
                {
                    case "Limburg":
                        // De beste
                        var maastricht = Location.GetLatLongFromAddress("6211 KM");
                        var setMaastricht = new MapPoint
                        {
                            Description = "Limburg, klanten : " + regios.Value,
                            Location = new Location(maastricht.Latitude, maastricht.Longitude)
                        };
                        Points.Add(setMaastricht);
                        break;
                    case "Utrecht":
                        var utrecht = Location.GetLatLongFromAddress("3511 CE");
                        var setUtrecht = new MapPoint
                        {
                            Description = "Utrecht, klanten : " + regios.Value,
                            Location = new Location(utrecht.Latitude, utrecht.Longitude)
                        };
                        Points.Add(setUtrecht);
                        MapCenter.Latitude = utrecht.Latitude;
                        MapCenter.Longitude = utrecht.Longitude;
                        break;
                    case "Brabant":
                        var brabant = Location.GetLatLongFromAddress("5211 AZ");
                        var setBrabant = new MapPoint
                        {
                            Description = "Brabant, klanten : " + regios.Value,
                            Location = new Location(brabant.Latitude, brabant.Longitude)
                        };
                        Points.Add(setBrabant);
                        break;
                    case "Flevoland":
                        var lelystad = Location.GetLatLongFromAddress("8232 DL");
                        var setFlevoland = new MapPoint
                        {
                            Description = "Flevoland, klanten : " + regios.Value,
                            Location = new Location(lelystad.Latitude, lelystad.Longitude)
                        };
                        Points.Add(setFlevoland);
                        break;
                    case "Groningen":
                        var groningen = Location.GetLatLongFromAddress("9726 AE");
                        var setGroningen = new MapPoint
                        {
                            Description = "Groningen, klanten : " + regios.Value,
                            Location = new Location(groningen.Latitude, groningen.Longitude)
                        };
                        Points.Add(setGroningen);
                        break;
                    case "Zeeland":
                        var zeeland = Location.GetLatLongFromAddress("4337 LH");
                        var setZeeland = new MapPoint
                        {
                            Description = "Zeeland, klanten : " + regios.Value,
                            Location = new Location(zeeland.Latitude, zeeland.Longitude)
                        };
                        Points.Add(setZeeland);
                        break;
                }
            }

            ZoomLevel = 8;
        }
    }
}
