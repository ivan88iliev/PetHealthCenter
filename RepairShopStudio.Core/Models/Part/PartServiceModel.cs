using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Infrastructure.Data.Models;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(ServiceModelMain)]
    public class PartServiceModel : IPartModel
    {
        [Comment(ServiceModelId)]
        public int Id { get; set; }

        [Comment(ServiceModelName)]
        public string Name { get; set; } = null!;

        [Comment(ServiceModelImageUrl)]
        public string? ImageUrl { get; set; }

        [Comment(ServiceModelStock)]
        public int Stock { get; set; }

        [Comment(ServiceModelManufacturer)]
        public string Manufacturer { get; set; } = null!;

        [Comment(ServiceModelOriginalMpn)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(ServiceModelDescription)]
        public string? Description { get; set; }

        [Comment(ServiceModelPriceBuy)]
        public decimal PriceBuy { get; set; }

        [Comment(ServiceModelPriceSell)]
        public decimal PriceSell { get; set; }

        [Comment(ServiceModelVehicleComponent)]
        public string? VehicleComponent { get; set; }
    }
}
