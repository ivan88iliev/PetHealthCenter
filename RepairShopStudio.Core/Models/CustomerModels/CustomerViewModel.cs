using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Custommer;

namespace RepairShopStudio.Core.Models.CustomerModels
{
    public class CustomerViewModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(ViewModelPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Comment(ViewModelEmail)]
        public string Email { get; set; } = null!;

        [Comment(ViewModelIsCorporate)]
        public bool IsCorporate { get; set; }

        [Comment(ViewModelUic)]
        public string Uic { get; set; } = null!;

        [Comment(ViewModelAddress)]
        public string? Address { get; set; }

        [Comment(ViewModelResponsiblePerson)]
        public string ResponsiblePerson { get; set; } = null!;

        [Comment(ViewModelVehicleId)]
        public int VehicleId { get; set; }

        [Comment(ViewModelVehicles)]
        public ICollection<Infrastructure.Data.Models.Vehicle> Vehicles { get; set; } 
            = new List<Infrastructure.Data.Models.Vehicle>();
    }
}
