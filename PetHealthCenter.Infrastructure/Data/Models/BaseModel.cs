using System.ComponentModel.DataAnnotations;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; } = null!;
    }
}
