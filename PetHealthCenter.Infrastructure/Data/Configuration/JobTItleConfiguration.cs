using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Infrastructure.Data.Configuration
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


            var doctorJobTitle = new JobTitle()
            {
                Id = 2,
                Name = "Doctor"
            };

            jobTitles.Add(doctorJobTitle);


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
