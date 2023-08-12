using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.OperatingCardHealthService;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(OperatingCardHealthServiceMain)]
    public class OperatingCardHealthService
    {
        [Required]
        public int OperatingCardId { get; set; }

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public int HealthServiceId { get; set; }

        [ForeignKey(nameof(HealthServiceId))]
        public HealthService? HealthService { get; set; }
    }
}
