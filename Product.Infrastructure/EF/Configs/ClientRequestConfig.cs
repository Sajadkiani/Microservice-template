using Product.Infrastructure.EF.Idempotency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Infrastructure.EF.Configs;

public class ClientRequestConfig : IEntityTypeConfiguration<ClientRequest>
{
    public void Configure(EntityTypeBuilder<ClientRequest> builder)
    {
        builder.ToTable("ClientRequests").HasKey(item => item.Id);
    }
}