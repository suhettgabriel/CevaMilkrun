using Refit;

namespace CevaMilkrun.Infrastructure.ExternalServices.Refit
{
    public interface ICevaMilkrunApi
    {
        [Post("/Servicos/SincronizarService.svc/Sincronizar")]
        Task<string> GetRawMilkrunDataAsync([Header("fone")] string phoneNumber, [Header("Cookie")] string cookie);
    }
}