using System.ComponentModel.DataAnnotations;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; } = null!;
    }
}
