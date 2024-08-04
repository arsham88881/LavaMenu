using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavaMenu.Application;

public class IdentityUserRoleMap : IEntityTypeConfiguration<AppUserRoles>
{
    public void Configure(EntityTypeBuilder<AppUserRoles> builder)
    {
        throw new NotImplementedException(
    }
}
