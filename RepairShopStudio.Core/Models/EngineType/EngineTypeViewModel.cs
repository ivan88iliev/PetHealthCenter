using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.EngineType;

namespace RepairShopStudio.Core.Models.EngineType
{
    [Comment(ViewModelMain)]
    public class EngineTypeViewModel
    {
        [Comment(ViewModelId)]
        public int Id { get; set; }

        [Comment(ViewModelName)]
        public string Name { get; set; } = null!;
    }
}
