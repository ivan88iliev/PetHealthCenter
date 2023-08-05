using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.JobTitle;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Possible job titles")]
    public class JobTitle
    {
        [Key]
        [Comment("Id of the job title")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(JobTitleNameMaxLength)]
        [Comment("Job title")]
        public string Name { get; set; } = null!;
    }
}
