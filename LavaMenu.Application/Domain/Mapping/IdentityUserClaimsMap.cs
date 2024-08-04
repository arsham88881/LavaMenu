using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavaMenu.Application;

public class IdentityUserClaimsMap : IEntityTypeConfiguration<AppUserClaims>
{
    public void Configure(EntityTypeBuilder<AppUserClaims> builder)
    {
    }
}
