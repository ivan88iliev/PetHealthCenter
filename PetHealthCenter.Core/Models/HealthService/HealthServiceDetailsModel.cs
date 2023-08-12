using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.HealthService;

namespace PetHealthCenter.Core.Models.HealthService
{
    [Comment(DetailsViewModelMain)]
    public class HealthServiceDetailsModel : IServiceModel
    {
        [Comment(DetailsViewModelId)]
        public int Id { get; set; }

        [Comment(DetailsViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(DetailsViewModelDescription)]
        public string Description { get; set; } = null!;

        [Comment(DetailsViewModelPrice)]
        public decimal Price { get; set; }

        [Comment(DetailsViewModelProductComponent)]
        public string ProductComponent { get; set; } = null!;
    }
}
