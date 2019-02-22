using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LZ.DataLayer.efdemo.Context
{
    public class efdemoContextSql : efdemoContext
    {
        public efdemoContextSql(
            IConfiguration configuration) : base(configuration)
        {
            //bool isEnabled = false;
            //bool.TryParse(configuration["EntityFramework:Logging:logQueryEnabled"], out isEnabled);
            //if (isEnabled)
            //{
            //    this.LogSqlStats(configuration);
            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
}