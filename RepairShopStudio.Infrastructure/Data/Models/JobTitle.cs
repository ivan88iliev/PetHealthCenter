using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.JobTitle;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.JobTitle;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(JobTitleMain)]
    public class JobTitle
    {
        [Key]
        [Comment(JobTitleId)]
        public int Id { get; set; }

        [Required]
        [StringLength(JobTitleNameMaxLength)]
        [Comment(JobTitleName)]
        public string Name { get; set; } = null!;
    }
}
