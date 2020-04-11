using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Models;
using MMT.Infra.Data.Extensions;

namespace MMT.Infra.Data.Mappings
{
    public class CellMap : EntityTypeConfiguration<Cell>
    {
        public override void Map(EntityTypeBuilder<Cell> builder)
        {
            builder.ToTable("Cell");
            builder.HasKey(t => t.Id);

            builder.Property(c => c.Id).HasColumnName("Id");
        }
    }
}
