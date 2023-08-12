using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.VehicleComponent;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.VehicleComponent;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(VehicleComponentMain)]
    public class VehicleComponent
    {
        [Key]
        [Comment(VehicleComponentId)]
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleComponentNameMaxLength)]
        [Comment(VehicleComponentName)]
        public string Name { get; set; } = null!;

    }
}
