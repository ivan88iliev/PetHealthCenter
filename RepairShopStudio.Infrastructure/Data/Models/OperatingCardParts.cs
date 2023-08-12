using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.OperatingCardParts;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(OperatingCardPartsMain)]
    public class OperatingCardParts
    {
        [Required]
        public int OperatingCardId { get; set; }

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part? Part { get; set; }
    }
}
