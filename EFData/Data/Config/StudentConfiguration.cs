using CoreData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.GPA).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(p => p.Age).IsRequired();
			builder.Property(p => p.Major).IsRequired();
			builder.Property(p => p.ContactInfo).IsRequired();
        }
	}
}
