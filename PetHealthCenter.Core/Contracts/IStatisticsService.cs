using PetHealthCenter.Core.Models.Statistics;

namespace PetHealthCenter.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
