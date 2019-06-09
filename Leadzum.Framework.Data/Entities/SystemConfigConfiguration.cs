using Leadzum.Framework.DomainModel.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Leadzum.Framework.Data.Entities
{
    public partial class SystemConfigConfiguration : IEntityTypeConfigurationWithSeed<SystemConfig>
    {
        public void Configure(EntityTypeBuilder<SystemConfig> builder)
        {
            builder.HasIndex(p => p.ConfigName).IsUnique();
            builder.Property(p => p.LastModifiedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<SystemConfig> builder)
        {
            var entryId = 1;

            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_GENERAL", ConfigName = "DateFormat", DataType = (int)DataType.Text, Length = 15, DefaultValue = "dd-MMM-yyyy", ConfigValue = "dd-MMM-yyyy", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_GENERAL", ConfigName = "ShortTimeFormat", DataType = (int)DataType.Text, Length = 15, DefaultValue = "HH:mm", ConfigValue = "HH:mm", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_GENERAL", ConfigName = "LongTimeFormat", DataType = (int)DataType.Text, Length = 15, DefaultValue = "HH:mm:ss", ConfigValue = "HH:mm:ss", ViewOrder = 0, IsVisible = true });

            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "Server", DataType = (int)DataType.Text, Length = 30, DefaultValue = "", ConfigValue = "", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "Port", DataType = (int)DataType.Integer, Length = 0, DefaultValue = "25", ConfigValue = "25", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "RequireAuthentication", DataType = (int)DataType.Boolean, Length = 0, DefaultValue = "False", ConfigValue = "False", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "UserName", DataType = (int)DataType.Text, Length = 30, DefaultValue = "", ConfigValue = "", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "Password", DataType = (int)DataType.Text, Length = 30, DefaultValue = "", ConfigValue = "", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "EnableSSL", DataType = (int)DataType.Text, Length = 0, DefaultValue = "False", ConfigValue = "False", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "MailFrom", DataType = (int)DataType.Text, Length = 30, DefaultValue = "", ConfigValue = "", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "DisplayName", DataType = (int)DataType.Text, Length = 30, DefaultValue = "", ConfigValue = "", ViewOrder = 0, IsVisible = true });
            builder.HasData(new SystemConfig { ConfigId = entryId++, ConfigCategory = "SYS_SMTP", ConfigName = "Activated", DataType = (int)DataType.Boolean, Length = 0, DefaultValue = "False", ConfigValue = "False", ViewOrder = 0, IsVisible = true });
        }
    }
}
