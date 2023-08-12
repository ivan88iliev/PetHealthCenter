using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Part;

namespace PetHealthCenter.Core.Models.Part
{
    [Comment(DetailsModelMain)]
    public class PartDetailsModel : PartServiceModel
    {
        [Comment(DetailsModelIdProductComponent)]
        public string ProductComponent { get; set; } = null!;
    }
}
