using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.HealthService;

namespace PetHealthCenter.Core.Models.HealthService
{
    [Comment(ProductComponentViewModelMain)]
    public class HealthServiceProductComponentModel
    {
        [Comment(ProductComponentViewModelId)]
        public int Id { get; set; }

        [Comment(ProductComponentViewModelName)]
        public string Name { get; set; } = null!;
    }
}
