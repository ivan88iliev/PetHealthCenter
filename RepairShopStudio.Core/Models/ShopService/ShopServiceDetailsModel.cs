using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.ShopService;

namespace RepairShopStudio.Core.Models.ShopService
{
    [Comment(DetailsViewModelMain)]
    public class ShopServiceDetailsModel : IServiceModel
    {
        [Comment(DetailsViewModelId)]
        public int Id { get; set; }

        [Comment(DetailsViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(DetailsViewModelDescription)]
        public string Description { get; set; } = null!;

        [Comment(DetailsViewModelPrice)]
        public decimal Price { get; set; }

        [Comment(DetailsViewModelVehicleComponent)]
        public string VehicleComponent { get; set; } = null!;
    }
}
