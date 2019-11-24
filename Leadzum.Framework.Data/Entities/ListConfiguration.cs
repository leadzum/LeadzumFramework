using Leadzum.Framework.DomainModel.Enumerations;
using Leadzum.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Leadzum.Framework.Data.Entities
{
    public partial class ListConfiguration : IEntityTypeConfigurationWithSeed<List>
    {
        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.Property(p => p.CreatedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.Property(p => p.LastModifiedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.HasOne(u => u.Parent).WithMany(l => l.Lists)
           .HasForeignKey(r => r.ParentId).OnDelete(DeleteBehavior.Restrict);

            Seed(builder);
        }

        public void Seed(EntityTypeBuilder<List> builder)
        {
            var orderIndex = 0;
            var entryId = 1;
            foreach (DateFormat data in Enum.GetValues(typeof(DateFormat)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(DateFormat).Name, Value = data.ToString("d"), Text = data.GetDescription(), SortOrder = orderIndex++ });
            }
            orderIndex = 0;
            foreach (LongTimeFormat data in Enum.GetValues(typeof(LongTimeFormat)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(LongTimeFormat).Name, Value = data.ToString("d"), Text = data.GetDescription(), SortOrder = orderIndex++ });
            }
            orderIndex = 0;
            foreach (ShortTimeFormat data in Enum.GetValues(typeof(ShortTimeFormat)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(ShortTimeFormat).Name, Value = data.ToString("d"), Text = data.GetDescription(), SortOrder = orderIndex++ });
            }
            orderIndex = 0;
            foreach (DataType data in Enum.GetValues(typeof(DataType)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(DataType).Name, Value = data.ToString("d"), Text = data.ToString("g"), SortOrder = orderIndex++ });
            }
            orderIndex = 0;
            foreach (LogCategory data in Enum.GetValues(typeof(LogCategory)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(LogCategory).Name, Value = data.ToString("d"), Text = data.GetDescription(), SortOrder = orderIndex++ });
            }

            orderIndex = 0;
            foreach (UserCategory data in Enum.GetValues(typeof(UserCategory)))
            {
                builder.HasData(new List() { EntryId = entryId++, ListName = typeof(LogCategory).Name, Value = data.ToString("d"), Text = data.GetDescription(), SortOrder = orderIndex++ });
            }
        }
    }
}
