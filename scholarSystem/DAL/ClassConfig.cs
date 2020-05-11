using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using scholarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarSystem.DAL
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(k => k.GroupId);
            builder.Property(p => p.GroupId).ValueGeneratedOnAdd();
            builder.Property(p => p.GroupStudents).IsRequired();


            //RELATION 1:N
            //builder.HasMany(m => m.Students)
            //    .WithOne(o => o.Group)
            //    .HasForeignKey(f => f.GroupId);
        }
    }
    
    public class StudentConfig: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(k => k.StudentId);
            builder.Property(p => p.StudentId).ValueGeneratedOnAdd();
            builder.Property(p => p.StudentName).IsRequired().HasColumnType("Nvarchar(70)");
            builder.Property(p => p.StudentAverage).IsRequired();

            //RELATION N:1
            builder.HasOne(d => d.Group)
                .WithMany(c => c.Students)
                .HasForeignKey(f => f.GroupId);
        }
    }
}
