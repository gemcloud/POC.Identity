﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC.Identity.Infrastructure.Entities;

namespace POC.Identity.Infrastructure.EntityConfigurations
{
    public class DashboardMenuConfiguration : IEntityTypeConfiguration<DashboardMenu>
    {
        public void Configure(EntityTypeBuilder<DashboardMenu> builder)
        {
            builder.ToTable("DashboardMenus");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnType("int");

            builder.Property(e => e.Icon).IsRequired().HasMaxLength(50);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(2500);

            builder.Property(e => e.ParentId).HasColumnType("int");   //.HasColumnName("parent_id")

            builder.Property(e => e.Url).HasColumnName("url").HasMaxLength(255);

            builder.Property(p => p.DateCreated).ValueGeneratedOnAdd();   // DateCreated value is automatically generated by the database.

        }
    }
}
