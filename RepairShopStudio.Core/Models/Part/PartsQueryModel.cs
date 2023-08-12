using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.Part
{
    public class PartsQueryModel
    {
        public const int PartsPerPage = 3;
        
        public string? SearchTerm { get; set; }

        public PartSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPartsCount { get; set; }

        public IEnumerable<PartServiceModel> Parts { get; set; } = Enumerable.Empty<PartServiceModel>();

        public string? Manufacturer { get; set; }
        public IEnumerable<string> Manufacturers { get; set; } = Enumerable.Empty<string>();

        public string? VehicleComponent { get; set; }
        public IEnumerable<string> VehicleComponents { get; set; } = Enumerable.Empty<string>();
    }
}
