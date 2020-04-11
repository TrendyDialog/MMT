using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Models;
using MMT.Infra.Data.Extensions;

namespace MMT.Infra.Data.Mappings
{
    public class DamageTypeMap : EntityTypeConfiguration<DamageType>
    {
        public override void Map(EntityTypeBuilder<DamageType> builder)
        {
            builder.ToTable("DamageType");
            builder.HasKey(t => t.Id);

            builder.Property(c => c.Id).HasColumnName("Id");
        }
    }
}
