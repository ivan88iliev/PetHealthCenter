using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Vehicle;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.Vehicle;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(VehicleMain)]
    public class Vehicle
    {
        [Key]
        [Comment(VehicleId)]
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleMakeMaxLength)]
        [Comment(VehicleMake)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(VehicleModelMaxLength)]
        [Comment(VehicleModel)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(LicensePlateMaxLength)]
        [Comment(VehicleLicensePlate)]
        public string LicensePLate { get; set; } = null!;

        [Required]
        [Comment(VehicleFirstRegistration)]
        public DateTime FIrstRegistration { get; set; }

        [Comment(VehicleEngineTypeId)]
        public int EngineTypeId { get; set; }

        [ForeignKey(nameof(EngineTypeId))]
        [Comment(VehicleEngineType)]
        public EngineType EngineType { get; set; } = null!;

        [Required]
        [Range(EngineMinPower, EngineMaxPower)]
        [Comment(VehiclePower)]
        public int Power { get; set; }

        [Required]
        [StringLength(VinNumberLength)]
        [Comment(VehicleVinNumber)]
        public string VinNumber { get; set; } = null!;

        [Comment(VehicleCustomerId)]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [Comment(VehicleCustomer)]
        public Customer? Customer { get; set; }

    }
}
