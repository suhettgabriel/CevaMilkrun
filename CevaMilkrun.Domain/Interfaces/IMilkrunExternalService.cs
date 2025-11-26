namespace CevaMilkrun.Domain.Interfaces
{
    public interface IMilkrunExternalService
    {
        Task<string> GetRawJsonAsync(string phoneNumber);
    }
}