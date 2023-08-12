using RepairShopStudio.Core.Models.Statistics;

namespace RepairShopStudio.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
