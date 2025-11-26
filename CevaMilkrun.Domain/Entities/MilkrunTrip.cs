using CevaMilkrun.Domain.Common;

namespace CevaMilkrun.Domain.Entities
{
    public class MilkrunTrip : BaseEntity
    {
        public string DriverName { get; private set; }
        public string Plate { get; private set; }
        public string CurrentStatus { get; private set; }
        public DateTime StartDate { get; private set; }

        private readonly List<MilkrunStop> _stops = new();
        public IReadOnlyCollection<MilkrunStop> Stops => _stops.AsReadOnly();

        public MilkrunTrip(string driverName, string plate, string currentStatus, DateTime startDate)
        {
            DriverName = driverName;
            Plate = plate;
            CurrentStatus = currentStatus;
            StartDate = startDate;
        }

        public void AddStop(MilkrunStop stop)
        {
            _stops.Add(stop);
        }

        public void AddStops(IEnumerable<MilkrunStop> stops)
        {
            _stops.AddRange(stops);
        }
    }
}