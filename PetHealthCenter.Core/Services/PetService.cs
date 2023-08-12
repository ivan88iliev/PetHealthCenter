using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Core.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository repo;

        public PetService(
Infrastructure.Data.ApplicationDbContext applicationDbContext, IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> ExistsAsync(string identificationNumber)
        {
            return await repo.AllReadonly<Pet>()
               .AnyAsync(h => h.IdentificationNUmber == identificationNumber);
        }
    }
}
