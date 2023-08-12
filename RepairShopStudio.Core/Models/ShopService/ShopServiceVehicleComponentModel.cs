using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.ShopService;

namespace RepairShopStudio.Core.Models.ShopService
{
    [Comment(VehicleComponentViewModelMain)]
    public class ShopServiceVehicleComponentModel
    {
        [Comment(VehicleComponentViewModelId)]
        public int Id { get; set; }

        [Comment(VehicleComponentViewModelName)]
        public string Name { get; set; } = null!;
    }
}
