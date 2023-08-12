using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;

        public VehicleService(
Infrastructure.Data.ApplicationDbContext applicationDbContext, IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> ExistsAsync(string licensePlate)
        {
            return await repo.AllReadonly<Vehicle>()
               .AnyAsync(h => h.LicensePLate == licensePlate);
        }
    }
}
