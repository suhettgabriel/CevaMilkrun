using CevaMilkrun.Domain.Entities;

namespace CevaMilkrun.Domain.Interfaces
{
    public interface IMilkrunExternalService
    { 
        Task<MilkrunTrip?> GetTripDataByPhoneAsync(string phoneNumber);
    }
}