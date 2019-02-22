using AutoMapper;
using LZ.BusinessLayer.efdemo;
using LZ.Common.Controllers;
using LZ.Common.efdemo.Constants;
using LZ.Models.efdemo.Dto.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LZ.Controllers.efdemo
{
    /// <summary>
    /// 
    /// </summary>
    public class efdemoController : BaseController
    {
        private IefdemoManager _efdemoManager;
        //private IAuthorizationService _authorizationService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="efdemoManager"></param>
        /// <param name="configuration"></param>
        public efdemoController(
            IefdemoManager efdemoManager,
            IConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
            _efdemoManager = efdemoManager;
        }

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/getusers")]
        public async Task<IActionResult> GetUsers()
        {  
           return CreateResponse(HttpStatusCode.OK, await  _efdemoManager.GetUsers().ConfigureAwait(false));
        }

        [HttpPost]
        [Route("/updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] User request)
        {
            try
            {
                await _efdemoManager.AddNewUser(request).ConfigureAwait(false);
                request.Password = "test123";

                await _efdemoManager.UpodateUser(request).ConfigureAwait(false);
                return CreateResponse(HttpStatusCode.OK, new
                    {
                        Success = true,
                        MessageDetails = "Create and update user successed",
                    });
            }
            catch (Exception ex)
            {
                return CreateResponse(
                   HttpStatusCode.InternalServerError,
                   Common.Error.ApiErrorProvider.GetErrorResponse(
                       ApiErrorCodes.InternalServiceError,
                       ex.Message));
            }
        }

        [HttpDelete]
        [Route("/deleteuser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int userId)
        {
            try
            {
                await _efdemoManager.DeleteUser(userId).ConfigureAwait(false);
                
                return CreateResponse(HttpStatusCode.OK, new
                {
                    Success = true,
                    MessageDetails = "delete user successed",
                });
            }
            catch (Exception ex)
            {
                return CreateResponse(
                   HttpStatusCode.InternalServerError,
                   Common.Error.ApiErrorProvider.GetErrorResponse(
                       ApiErrorCodes.InternalServiceError,
                       ex.Message));
            }
        }
    }
}
