using efdemoService;
using LZ.BusinessLayer.efdemo;
using LZ.Controllers.efdemo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NSubstitute;
using System;
using System.IO;
using System.Net.Http;

namespace Test.LZ.efdemo
{
    public class ControllerTestBase : TestBase
    {
        protected HttpContext _httpContextDefault = new DefaultHttpContext();
        protected IAuthorizationService _authorizationService;
        protected IefdemoManager _efdemoManager;
        private efdemoController _controller;

        public ControllerTestBase() : base()
        {
            _authorizationService = Substitute.For<IAuthorizationService>();
            _efdemoManager = Substitute.For<IefdemoManager>();

            //_controller = new efdemoController(_efdemoManager, _authorizationService,
            //    _configuration, _loggingService, mapper);
        }
    }
}