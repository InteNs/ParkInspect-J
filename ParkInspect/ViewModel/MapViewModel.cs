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
        //Best veel switch/case en nesting hiero

        // Collection of points within the map.
        public ObservableCollection<MapPoint> Points { get; set; }

        // Map Center
        public Location MapCenter { get; set; }

        // Location Services based on Google. Online use only.
        private GoogleLocationService Location { get; }

        // Data :D
        private List<CommissionViewModel> Commissions { get; }
        private List<InspectionViewModel> Inspections { get; set; }
        private List<EmployeeViewModel> Employees { get; }
        private List<CustomerViewModel> Customers { get; }

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
            Plot(source);
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

            Plot(source);
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
                switch (regios.Key)
                {
                    case "Limburg":
                        var maastricht = Location.GetLatLongFromAddress("6211 KM");
                        var setMaastricht = new MapPoint
                        {
                            Description = "Limburg, " + description + " " + regios.Value,
                            Location = new Location(maastricht.Latitude, maastricht.Longitude)
                        };
                        Points.Add(setMaastricht);
                        break;
                    case "Utrecht":
                        var utrecht = Location.GetLatLongFromAddress("3511 CE");
                        var setUtrecht = new MapPoint
                        {
                            Description = "Utrecht, " + description + " " + regios.Value,
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
                            Description = "Brabant, " + description + " " + regios.Value,
                            Location = new Location(brabant.Latitude, brabant.Longitude)
                        };
                        Points.Add(setBrabant);
                        break;
                    case "Flevoland":
                        var lelystad = Location.GetLatLongFromAddress("8232 DL");
                        var setFlevoland = new MapPoint
                        {
                            Description = "Flevoland, " + description + " " + regios.Value,
                            Location = new Location(lelystad.Latitude, lelystad.Longitude)
                        };
                        Points.Add(setFlevoland);
                        break;
                    case "Groningen":
                        var groningen = Location.GetLatLongFromAddress("9726 AE");
                        var setGroningen = new MapPoint
                        {
                            Description = "Groningen, " + description + " " + regios.Value,
                            Location = new Location(groningen.Latitude, groningen.Longitude)
                        };
                        Points.Add(setGroningen);
                        break;
                    case "Zeeland":
                        var zeeland = Location.GetLatLongFromAddress("4337 LH");
                        var setZeeland = new MapPoint
                        {
                            Description = "Zeeland, " + description + " " + regios.Value,
                            Location = new Location(zeeland.Latitude, zeeland.Longitude)
                        };
                        Points.Add(setZeeland);
                        break;
                }
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
