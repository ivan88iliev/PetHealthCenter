using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Statistics;

namespace RepairShopStudio.Core.Models.Statistics
{
    [Comment(ServiceViewModelMain)]
    public class StatisticsServiceModel
    {
        [Comment(ServiceViewModelTotalParts)]
        public int TotalParts { get; init; }

        [Comment(ServiceViewModelTotalServices)]
        public int TotalServices { get; init; }

        [Comment(ServiceViewModelTotalCustomers)]
        public int TotalCustomers { get; init; }

        [Comment(ServiceViewModelTotalOpeartingCards)]
        public int TotalOperatingCards { get; init; }
    }
}
