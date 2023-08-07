using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.ProductComponent;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.ProductComponent;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(ProductComponentMain)]
    public class ProductComponent
    {
        [Key]
        [Comment(ProductComponentId)]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductComponentNameMaxLength)]
        [Comment(ProductComponentName)]
        public string Name { get; set; } = null!;

    }
}
