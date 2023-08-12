using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class JobTItleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(CreateJobTItle());
        }

        private List<JobTitle> CreateJobTItle()
        {
            var jobTitles = new List<JobTitle>();

            var managerJobTitle = new JobTitle()
            {
                Id = 1,
                Name = "Manager"
            };

            jobTitles.Add(managerJobTitle);


            var mechanicJobTitle = new JobTitle()
            {
                Id = 2,
                Name = "Mechanic"
            };

            jobTitles.Add(mechanicJobTitle);


            var adviserJobTitle = new JobTitle()
            {
                Id = 3,
                Name = "Service adviser"
            };

            jobTitles.Add(adviserJobTitle);

            return jobTitles;
        }
    }
}
