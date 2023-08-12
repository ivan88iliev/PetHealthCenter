using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Part;

namespace PetHealthCenter.Core.Models.Part
{
    [Comment(ViewModelMain)]
    public class PartViewModel : IPartModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(ViewModelImageUrl)]
        public string? ImageUrl { get; set; }

        [Comment(ViewModelStock)]
        public int Stock { get; set; }

        [Comment(ViewModelManufacturer)]
        public string Manufacturer { get; set; } = null!;

        [Comment(ViewModelOriginalMpn)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(ViewModelDescription)]
        public string? Description { get; set; }

        [Comment(ViewModelPriceSell)]
        public decimal PriceSell { get; set; }

        [Comment(ViewModelPriceBuy)]
        public decimal PriceBuy { get; set; }

        [Comment(ViewModelProductComponentId)]
        [Display(Name = "Product component")]
        public int ProductComponentId { get; set; }

        [Comment(ViewModelProductComponent)]
        public string ProductComponent { get; set; } = null!;

        [Comment(ViewModelProductComponents)]
        public IEnumerable<PartProductComponentModel> ProductComponents { get; set; } = new List<PartProductComponentModel>();
    }
}
