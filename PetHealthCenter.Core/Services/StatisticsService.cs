using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.Statistics;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;
        public StatisticsService(Infrastructure.Data.ApplicationDbContext applicationDbContext, IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Get the count of all records for certain enteties
        /// </summary>
        /// <returns>Integers representing to count of the records</returns>
        public async Task<StatisticsServiceModel> Total()
        {
            int totalParts = await repo.AllReadonly<Part>()
                .CountAsync(p => p.IsActive);

            int totalServices = await repo.AllReadonly<HealthService>()
                .CountAsync(s => s.IsActive);

            int totalCustomers = await repo.AllReadonly<Customer>()
                .CountAsync();

            int totalOperatingCards = await repo.AllReadonly<OperatingCard>()
                .CountAsync();

            return new StatisticsServiceModel()
            {
                TotalParts = totalParts,
                TotalServices = totalServices,
                TotalCustomers = totalCustomers,
                TotalOperatingCards = totalOperatingCards
            };
        }
    }
}
