using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(ViewModelMain)]
    public class PartViewModel : IPartModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(ViewModelImageUrl)]
        public string? ImageUrl { get; set; }

        [Comment(ViewModelStock)]
        public int Stock { get; set; }

        [Comment(ViewModelManufacturer)]
        public string Manufacturer { get; set; } = null!;

        [Comment(ViewModelOriginalMpn)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(ViewModelDescription)]
        public string? Description { get; set; }

        [Comment(ViewModelPriceSell)]
        public decimal PriceSell { get; set; }

        [Comment(ViewModelPriceBuy)]
        public decimal PriceBuy { get; set; }

        [Comment(ViewModelVehicleComponentId)]
        [Display(Name = "Vehicle component")]
        public int VehicleComponentId { get; set; }

        [Comment(ViewModelVehicleComponent)]
        public string VehicleComponent { get; set; } = null!;

        [Comment(ViewModelVehicleComponents)]
        public IEnumerable<PartVehicleCopmonentModel> VehicleComponents { get; set; } = new List<PartVehicleCopmonentModel>();
    }
}
