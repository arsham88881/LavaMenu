using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavaMenu.Application;

public class IdentityUserLoginsMap : IEntityTypeConfiguration<AppUserLogins>
{
    public void Configure(EntityTypeBuilder<AppUserLogins> builder)
    {
        
    }
}
