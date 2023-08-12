using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Custommer;

namespace PetHealthCenter.Core.Models.CustomerModels
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

        [Comment(ViewModelPetId)]
        public int PetId { get; set; }

        [Comment(ViewModelPets)]
        public ICollection<Infrastructure.Data.Models.Pet> Pets { get; set; } 
            = new List<Infrastructure.Data.Models.Pet>();
    }
}
