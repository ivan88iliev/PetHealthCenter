using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ShopService;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.ShopService;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(ShopServiceMain)]
    public class ShopService
    {
        [Key]
        [Comment(ShopServiceId)]
        public int Id { get; set; }

        [Required]
        [StringLength(RepairServiceNameMaxLength)]
        [Comment(ShopServiceName)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(RepairServiceDescriptionMaxLength)]
        [Comment(ShopServiceDescription)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment(ShopServicePrice)]
        [Range(typeof(decimal), ShopServicePriceMinValue, ShopServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Comment(ShopServiceVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [ForeignKey(nameof(VehicleComponentId))]
        [Comment(ShopServiceVehicleComponent)]
        public VehicleComponent VehicleComponent { get; set; } = null!;

        [Required]
        [Comment(ShopServiceParts)]
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        [Comment(ShopServiceIsActive)]
        public bool IsActive { get; set; } = true;

    }
}