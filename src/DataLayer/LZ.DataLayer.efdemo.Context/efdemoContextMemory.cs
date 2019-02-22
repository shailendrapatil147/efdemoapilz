using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LZ.DataLayer.efdemo.Context
{
    public class efdemoContextMemory : efdemoContext
    {
        public efdemoContextMemory(
            IConfiguration configuration) : base(
            configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("InMemoryDbName");
        }
    }
}