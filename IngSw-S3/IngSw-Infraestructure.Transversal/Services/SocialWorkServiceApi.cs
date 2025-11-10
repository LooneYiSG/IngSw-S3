using IngSw_Domain.Interfaces;

namespace IngSw_Infraestructure.Transversal.Services;

public class SocialWorkServiceApi : ISocialWorkServiceApi
{
    public Task<bool> ExistingSocialWork(string socialWork)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAffiliated(string affiliateNumber)
    {
        throw new NotImplementedException();
    }
}
