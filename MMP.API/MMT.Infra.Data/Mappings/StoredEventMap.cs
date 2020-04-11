using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Core.Events;
using MMT.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MMT.Infra.Data.Mappings
{
    public class StoredEventMap : EntityTypeConfiguration<StoredEvent>
    {
        public override void Map(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("StoredEvent");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.AggregateId)
                .HasColumnName("AggregateId");

            builder.Property(c => c.Data)
                .HasColumnName("Data");

            builder.Property(c => c.User)
                .HasColumnName("User");

            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action");
        }
    }
}
