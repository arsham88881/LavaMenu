using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavaMenu.Application;

public class IdentityRoleClaimsMap : IEntityTypeConfiguration<AppRoleClaims>
{
    public void Configure(EntityTypeBuilder<AppRoleClaims> builder)
    {
       
    }
}
