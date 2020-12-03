using HotelTDD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.Profile)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
