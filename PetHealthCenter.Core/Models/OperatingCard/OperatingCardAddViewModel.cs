using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Customer;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.OperatingCard;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Models.OperatingCard
{
    [Comment(AddViewModelMain)]
    public class OperatingCardAddViewModel
    {
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelCustomerId)]
        public int CustomerId { get; set; }

        [Comment(AddViewModelCustomerName)]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength, ErrorMessage = CustomerNameLength)]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelPetId)]
        public int PetId { get; set; }

        [Comment(AddViewModelPets)]
        public IEnumerable<Infrastructure.Data.Models.Pet> Pets { get; set; } 
            = new List<Infrastructure.Data.Models.Pet>();

        [Comment(AddViewModelApplicationUserId)]
        public string? ApplicationUserId { get; set; }

        [Comment(AddViewModelApplicationUsers)]
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } 
            = new List<ApplicationUser>();

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelPartId)]
        public int PartId { get; set; }

        [Comment(AddViewModelParts)]
        public IEnumerable<Infrastructure.Data.Models.Part> Parts { get; set; } 
            = new List<Infrastructure.Data.Models.Part>();

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelServiceId)]
        public int ServiceId { get; set; }

        [Comment(AddViewModelHealthServices)]
        public IEnumerable<Infrastructure.Data.Models.HealthService> HealthServices { get; set; } 
            = new List<Infrastructure.Data.Models.HealthService>();

        [Comment(AddViewModelIssueDate)]
        public DateTime? IssueDate { get; set; }

        [Comment(AddViewModelIsActive)]
        public bool IsActive { get; set; } = true;

        public string? DocumentNumber { get; set; }
    }
}
