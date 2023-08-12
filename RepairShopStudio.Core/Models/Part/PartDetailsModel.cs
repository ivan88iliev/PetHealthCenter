using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(DetailsModelMain)]
    public class PartDetailsModel : PartServiceModel
    {
        [Comment(DetailsModelIdVehicleComponent)]
        public string VehicleComponent { get; set; } = null!;
    }
}
