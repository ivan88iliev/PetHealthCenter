using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(VehicleCopmonentModelMain)]
    public class PartVehicleCopmonentModel
    {
        [Comment(VehicleCopmonentModelId)]
        public int Id { get; set; }

        [Comment(VehicleCopmonentModelName)]
        public string Name { get; set; } = null!;
    }

}
