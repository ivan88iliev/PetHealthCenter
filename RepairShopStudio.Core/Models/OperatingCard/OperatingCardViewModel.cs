using Microsoft.EntityFrameworkCore;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.OperatingCard;

namespace RepairShopStudio.Core.Models.OperatingCard
{
    [Comment(ViewModelMain)]
    public class OperatingCardViewModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelPartName)]
        public string PartName { get; set; } = null!;

        [Comment(ViewModelServiceName)]
        public string ServiceName { get; set; } = null!;

        [Comment(ViewModelCustomerName)]
        public string CustomerName { get; set; } = null!;

        [Comment(ViewModelVehicleLicensePlate)]
        public string VehicleLicensePlate { get; set; } = null!;

        [Comment(ViewModelMechanicName)]
        public string MechanicName { get; set; } = null!;

        [Comment(ViewModelDocumentNumber)] 
        public string DocumentNumber { get; set; } = null!;

        [Comment(ViewModelIssueDate)] 
        public string IssueDate { get; set; } = null!;

        [Comment(ViewModelIsActive)]
        public bool IsActive { get; set; } = true;


    }
}
