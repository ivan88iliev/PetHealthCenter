using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.JobTitle;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.JobTitle;

namespace PetHealthCenter.Infrastructure.Data.Models
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
