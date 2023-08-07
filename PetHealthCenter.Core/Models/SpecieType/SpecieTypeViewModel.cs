using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.SpecieType;

namespace PetHealthCenter.Core.Models.SpecieType
{
    [Comment(ViewModelMain)]
    public class SpecieTypeViewModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelName)]
        public string Name { get; set; } = null!;
    }
}
