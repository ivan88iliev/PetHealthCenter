using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Part;

namespace PetHealthCenter.Core.Models.Part
{
    [Comment(ProductComponentModelMain)]
    public class PartProductComponentModel
    {
        [Comment(ProductComponentModelId)]
        public int Id { get; set; }

        [Comment(ProductComponentModelName)]
        public string Name { get; set; } = null!;
    }

}
