using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC.Identity.Infrastructure.Entities;

namespace POC.Identity.Infrastructure.EntityConfigurations
{
    public class LinkRolesMenuConfiguration : IEntityTypeConfiguration<LinkRolesMenu>
    {
        public void Configure(EntityTypeBuilder<LinkRolesMenu> builder)
        {
            builder.ToTable("LinkRolesMenus");

            builder.HasIndex(e => e.MenuId);

            builder.HasIndex(e => e.AppRoleId);

            builder.Property(e => e.Id).HasColumnType("int");

            builder.Property(e => e.MenuId).HasColumnType("int");

            builder.Property(e => e.AppRoleId).HasMaxLength(450);

            builder.HasOne(d => d.Menu)
                .WithMany(p => p.LinkRolesMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("link_roles_menus_ibfk_1");

            builder.HasOne(d => d.AppRole)
                .WithMany(p => p.LinkRolesMenus)
                .HasForeignKey(d => d.AppRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("link_roles_menus_ibfk_2");
        }
    }
}
