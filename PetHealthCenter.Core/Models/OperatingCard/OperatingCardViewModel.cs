using Microsoft.EntityFrameworkCore;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.OperatingCard;

namespace PetHealthCenter.Core.Models.OperatingCard
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

        [Comment(ViewModelPetIdentificationNumber)]
        public string PetIdentificationNumber { get; set; } = null!;

        [Comment(ViewModelDoctorName)]
        public string DoctorName { get; set; } = null!;

        [Comment(ViewModelDocumentNumber)] 
        public string DocumentNumber { get; set; } = null!;

        [Comment(ViewModelIssueDate)] 
        public string IssueDate { get; set; } = null!;

        [Comment(ViewModelIsActive)]
        public bool IsActive { get; set; } = true;


    }
}
