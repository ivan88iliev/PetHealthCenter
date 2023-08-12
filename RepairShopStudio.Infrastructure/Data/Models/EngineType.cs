using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.EngineType;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.EngineType;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(EngyneTypeMain)]
    public class EngineType
    {
        [Key]
        [Comment(EngyneTypeId)]
        public int Id { get; set; }

        [Required]
        [StringLength(EngineTypeNameMaxLength)]
        [Comment(EngyneTypeName)]
        public string Name { get; set; } = null!;

    }
}
