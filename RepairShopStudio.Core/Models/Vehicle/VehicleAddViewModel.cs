using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Vehicle;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Vehicle;
using static RepairShopStudio.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.Vehicle
{
    [Comment(AddViewModelMain)]
    public class VehicleAddViewModel
    {
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength, ErrorMessage = VehicleMakeLength)]
        [Comment(AddViewModelMake)]
        public string? Make { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength, ErrorMessage = VehicleModelLength)]
        [Comment(AddViewModelModel)]
        public string? Model { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(LicensePlateMaxLength, MinimumLength = LicensePlateMinLength, ErrorMessage = VehicleLicensePlateNumberLength)]
        [Comment(AddViewModelLicensePLate)]
        public string? LicensePLate { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelFIrstRegistration)]
        public DateTime FIrstRegistration { get; set; }

        [Comment(AddViewModelEngineTypeId)]
        public int EngineTypeId { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(EngineMinPower, EngineMaxPower, ErrorMessage = VehiclePowerRange)]
        [Comment(AddViewModelPower)]
        public int Power { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(VinNumberLength, MinimumLength =VinNumberLength, ErrorMessage = VehicleVINRange)]
        [Comment(AddViewModelVinNumber)]
        public string? VinNumber { get; set; }

        [Comment(AddViewModelEngineTypes)]
        public ICollection<Infrastructure.Data.Models.EngineType> EngineTypes { get; set; }
            = new List<Infrastructure.Data.Models.EngineType>();

    }
}
