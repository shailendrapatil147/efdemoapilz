using AutoMapper;
using LZ.Common.Logging;
using LZ.Common.Logging.Serilog;
using LZ.DataLayer.efdemo.Context;
using LZ.Mappers.efdemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.LZ.efdemo
{
    public class TestBase
    {
        protected IConfiguration _configuration;
        //protected ILoggingService _loggingService;
        protected DirectoryInfo directoryInfo;
        protected IMapper mapper;
        public TestBase()
        {
            directoryInfo =
                Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.Parent;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(directoryInfo.FullName + "\\SearchService")
                .AddJsonFile("appsettings.predev.json")
                .Build();

           // _loggingService = new SerilogLoggingService(_configuration);
            mapper = new efdemoMapper().Mapper;
        }
    }
}
