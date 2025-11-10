namespace IngSw_Domain.Interfaces;

public interface ISocialWorkServiceApi
{
    Task<bool> ExistingSocialWork(string socialWork);

    Task<bool> IsAffiliated(string affiliateNumber);
}
