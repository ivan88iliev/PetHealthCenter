using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHealthCenter.Core.Contracts
{
    public interface IPetService
    {
        Task<bool> ExistsAsync(string identificationNumber);
    }
}
