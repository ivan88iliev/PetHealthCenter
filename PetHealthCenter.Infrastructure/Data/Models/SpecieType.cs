using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.SpecieType;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.SpecieType;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(EngyneTypeMain)]
    public class SpecieType
    {
        [Key]
        [Comment(EngyneTypeId)]
        public int Id { get; set; }

        [Required]
        [StringLength(SpecieTypeNameMaxLength)]
        [Comment(EngyneTypeName)]
        public string Name { get; set; } = null!;

    }
}
