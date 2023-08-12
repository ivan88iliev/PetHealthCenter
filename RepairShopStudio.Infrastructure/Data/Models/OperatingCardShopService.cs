using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.OperatingCardShopService;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(OperatingCardShopServiceMain)]
    public class OperatingCardShopService
    {
        [Required]
        public int OperatingCardId { get; set; }

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public int ShopServiceId { get; set; }

        [ForeignKey(nameof(ShopServiceId))]
        public ShopService? ShopService { get; set; }
    }
}
