using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GoogleMaps.LocationServices;
using MapControl;
using MapPoint = ParkInspect.Maps.MapPoint;

namespace ParkInspect.ViewModel
{
    public class MapViewModel : MainViewModel
    {
        // Location Services based on Google. Online use only.
        private GoogleLocationService Location { get; }

        // Data :D
        private List<CommissionViewModel> Commissions { get; }
        private List<InspectionViewModel> Inspections { get; set; }
        private List<EmployeeViewModel> Employees { get; }
        private List<CustomerViewModel> Customers { get; }
<<<<<<< HEAD
        private int Limit { get; set; }

=======
        // Collection of points within the map.
        public ObservableCollection<MapPoint> Points { get; set; }
        // Map Center
        public Location MapCenter { get; set; }
>>>>>>> development
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
            Limit = 50;
        }

        #region filters

        // Assigment per location
        public void AssigmentsPerLocation(DateTime? startDate, DateTime? endDate, EmployeeViewModel selectedInspector = null)
        {
            if (Points.Count < 1) { Points.Clear(); }
            var source = new List<CommissionViewModel>();
            source.AddRange(Commissions.AsEnumerable());
            if (startDate != null)
            {
                source.RemoveAll(o => o.DateCreated >= startDate.Value);
                if (endDate != null)
                {
                    source.RemoveAll(o => o.DateCreated <= endDate.Value);
                }
            }
            if (selectedInspector != null)
            {
                source.RemoveAll(o => o.Employee.Id != selectedInspector.Id);
            }

            Plot(source.Count > Limit ? source.GetRange(source.Count - Limit, Limit) : source);
        }

        // Inspections per locations
        public void InspectionsPerLocation(DateTime? startDate, DateTime? endDate, QuestionItemViewModel selectedQuestion, string selectedAnswer)
        {
            if (Points.Count < 1) { Points.Clear(); }

            var source = new List<CommissionViewModel>();

            source.AddRange(Commissions.AsEnumerable());

            if (startDate != null)
            {
                source.RemoveAll(o => o.DateCreated >= startDate.Value);
                if (endDate != null)
                {
                    source.RemoveAll(o => o.DateCreated <= endDate.Value);
                }
            }

            if (selectedQuestion != null)
            {
                source.RemoveAll(o => o.Id != selectedQuestion.QuestionList.Inspection.CommissionViewModel.Id && selectedQuestion.Answer == selectedAnswer);
            }

            Plot(source.Count > Limit ? source.GetRange(source.Count - Limit, Limit) : source);
        }

        // Inspectors per location
        public void InspectorsPerLocation()
        {
            if (Points.Count < 1) { Points.Clear(); }
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

            SetPerRegion(counter, "inspecteurs :");
        }

        // Customers per location
        public void CustomersPerLocation()
        {
            if (Points.Count < 1) { Points.Clear(); }
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
            SetPerRegion(counter, "klanten :");
        }
        #endregion

        #region helpers
        public void SetPerRegion(Dictionary<string, int> dictionary, string description)
        {
            foreach (var regios in dictionary)
            {
                var region = "";
                var loc = Location.GetLatLongFromAddress("3511 CE");
                switch (regios.Key)
                {
                    case "Limburg":
                        loc = Location.GetLatLongFromAddress("6211 KM");
                        region = "Limburg";
                        break;
                    case "Utrecht":
                        loc = Location.GetLatLongFromAddress("3511 CE");
                        MapCenter = new Location {Latitude = loc.Latitude, Longitude = loc.Longitude};
                        region = "Utrecht";
                        break;
                    case "Noord-Brabant":
                        loc = Location.GetLatLongFromAddress("5211 AZ");
                        region = "Brabant";
                        break;
                    case "Flevoland":
                        loc = Location.GetLatLongFromAddress("8232 DL");
                        region = "Flevoland";
                        break;
                    case "Groningen":
                        loc = Location.GetLatLongFromAddress("9726 AE");
                        region = "Groningen";
                        break;
                    case "Zeeland":
                        loc = Location.GetLatLongFromAddress("4337 LH");
                        region = "Zeeland";
                        break;
                    case "Noord-Holland":
                        loc = Location.GetLatLongFromAddress("1012 AB");
                        region = "Noord-Holland";
                        break;
                    case "Zuid-Holland":
                        loc = Location.GetLatLongFromAddress("2515 XP");
                        region = "Zuid-Holland";
                        break;
                    case "Gelderland":
                        loc = Location.GetLatLongFromAddress("6811 KM");
                        region = "Gelderland";
                        break;
                    case "Overijssel":
                        loc = Location.GetLatLongFromAddress("8011 MC");
                        region = "Overijssel";
                        break;
                    case "Drenthe":
                        loc = Location.GetLatLongFromAddress("9401 KD");
                        region = "Drenthe";
                        break;
                    case "Friesland":
                        loc = Location.GetLatLongFromAddress("8911 AC");
                        region = "Friesland";
                        break;
                }
                var setPointer = new MapPoint
                {
                    Description = region + ", " + description + " " + regios.Value,
                    Location = new Location(loc.Latitude, loc.Longitude)
                };
                Points.Add(setPointer);
            }
        }

        public void Plot(List<CommissionViewModel> source)
        {
            foreach (var item in source)
            {
                var loc = Location.GetLatLongFromAddress(item.ZipCode);
                if (loc != null)
                {
                    var setPoint = new MapPoint
                    {
                        Description = item.Customer.Name,
                        Location = new Location(loc.Latitude, loc.Longitude)
                    };
                    Points.Add(setPoint);
                }
            }
        }
        #endregion
    }
}
