using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavaMenu.Application;

public class IdentityUserTokenMap : IEntityTypeConfiguration<AppUserTokens>
{
    public void Configure(EntityTypeBuilder<AppUserTokens> builder)
    {
        throw new NotImplementedException();
    }
}
