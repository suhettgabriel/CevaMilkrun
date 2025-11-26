using CevaMilkrun.Domain.Common;

namespace CevaMilkrun.Domain.Entities
{
    public class MilkrunStop : BaseEntity
    {
        public string LocationName { get; private set; }
        public string Address { get; private set; }
        public string Type { get; private set; }
        public DateTime EstimatedArrival { get; private set; }
        public DateTime? ActualArrival { get; private set; }
        public string Status { get; private set; }

        public MilkrunStop(string locationName, string address, string type, DateTime estimatedArrival, string status)
        {
            LocationName = locationName;
            Address = address;
            Type = type;
            EstimatedArrival = estimatedArrival;
            Status = status;
        }

        public void SetActualArrival(DateTime arrival)
        {
            ActualArrival = arrival;
        }
    }
}