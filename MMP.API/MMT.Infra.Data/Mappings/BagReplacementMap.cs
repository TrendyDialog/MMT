using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Models;
using MMT.Infra.Data.Extensions;

namespace MMT.Infra.Data.Mappings
{
    public class BagReplacementMap : EntityTypeConfiguration<BagReplacement>
    {
        public override void Map(EntityTypeBuilder<BagReplacement> builder)
        {
            builder.ToTable("BagReplacement");
            builder.HasKey(t => t.Id);

            builder.Property(c => c.Id).HasColumnName("Id");
        }
    }
}
