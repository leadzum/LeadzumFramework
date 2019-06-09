using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data
{
    public interface IEntityTypeConfigurationWithSeed<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        void Seed(EntityTypeBuilder<TEntity> builder);
    }
}
