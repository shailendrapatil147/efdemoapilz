using AutoMapper;
using LZ.Common.Logging;
using LZ.DataLayer.efdemo.Repository;
using LZ.Mappers.efdemo.EntityToDomain;
using LZ.Models.efdemo.Dto.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LZ.BusinessLayer.efdemo
{
    public class efdemoManager : IefdemoManager
    {
        private readonly IefdemoRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public efdemoManager(
            IefdemoRepository repository,
            IConfiguration configuration,
            IMapper mapper
        )
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task AddNewUser(User user)
        {
            try
            {
                await _repository.AddNewUser(user.ToEntity()).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteUser(int userId)
        {
            try
            {
                await _repository.DeleteUser(userId).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var result = await _repository.GetUsers().ConfigureAwait(false);
                return result.ToDomain();

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task UpodateUser(User user)
        {
            try
            {
                await _repository.UpodateUser(user.ToEntity()).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
