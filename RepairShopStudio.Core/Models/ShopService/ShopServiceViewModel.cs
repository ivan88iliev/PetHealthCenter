using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.ShopService;

namespace RepairShopStudio.Core.Models.ShopService
{
    [Comment(ServiceViewModelmain)]
    public class ShopServiceViewModel : IServiceModel
    {
        [Comment(ServiceViewModelId)]
        public int Id { get; set; }

        [Comment(ServiceViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(ServiceViewModelDescription)]
        public string Description { get; set; } = null!;

        [Comment(ServiceViewModelPrice)]
        public decimal Price { get; set; }

        [Comment(ServiceViewModelVehicleComponentId)]
        [Display(Name = "Vehicle component")]
        public int VehicleComponentId { get; set; }

        [Comment(ServiceViewModelVehicleComponent)]
        public string VehicleComponent { get; set; } = null!;

        [Comment(ServiceViewModelVehicleComponents)]
        public IEnumerable<ShopServiceVehicleComponentModel> VehicleComponents { get; set; } 
            = new List<ShopServiceVehicleComponentModel>();
    }
}
