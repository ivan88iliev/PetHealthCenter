using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Models.Part
{
    public class PartsFilterQueryModel
    {
        public int TotalPartsCount { get; set; }

        public IEnumerable<PartServiceModel> Parts { get; set; } = new List<PartServiceModel>();
    }
}
