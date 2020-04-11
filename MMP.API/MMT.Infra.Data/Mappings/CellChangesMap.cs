using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Models;
using MMT.Infra.Data.Extensions;

namespace MMT.Infra.Data.Mappings
{
    public class CellChangesMap : EntityTypeConfiguration<CellChanges>
    {
        public override void Map(EntityTypeBuilder<CellChanges> builder)
        {
            builder.ToTable("CellChanges");
            builder.HasKey(t => t.Id);

            builder.Property(c => c.Id).HasColumnName("Id");
        }
    }
}
