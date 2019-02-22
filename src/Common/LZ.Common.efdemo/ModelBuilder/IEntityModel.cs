using Microsoft.EntityFrameworkCore;

namespace LZ.Common.efdemo
{
    public interface IEntityModel
    {
        void BuildModel(ModelBuilder modelBuilder);
    }
}
