using AutoMapper;
using LZ.DataLayer.efdemo.Context;
using LZ.Models.efdemo.Entity.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZ.DataLayer.efdemo.Repository
{
    public class efdemoRepository : DbContext, IefdemoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IefdemoContext _dbContext;

        public efdemoRepository(
            IefdemoContext dbContext,
            IConfiguration configuration
        )
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task AddNewUser(UserEntity userEntity)
        {
            try
            {
                var guid = Guid.NewGuid().ToString();
                userEntity.FkUserContacttNavigation = new List<UserContactEntity>
                {
                    new UserContactEntity
                    {
                        Area = "test area",
                        City = "pune",
                        State = guid
                    }

                };
                userEntity.FkUserDetailsNavigation = new UserDetailsEntity
                {
                    Email ="testmail",
                    FirstName = guid

                };
                _dbContext.User.Add(userEntity);

                var isSaved = await _dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteUser(int userId)
        {
            try
            {
                var user = await GetUsers(userId);
                _dbContext.User.Remove(user);

                var isSaved = await _dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await _dbContext.User
                //.Include(e => e.FkUserContacttNavigation)
                //.Include(e => e.FkUserDetailsNavigation)
                .ToListAsync().ConfigureAwait(false);

            //return cartList.Select(e => CartEntityDomainMapper.ToDomain(e)).ToList();
        }

        public async Task<UserEntity> GetUsers(int userId)
        {
            return await _dbContext.User.Where(user => user.UserId == userId).FirstOrDefaultAsync()
                //.Include(e => e.FkUserContacttNavigation)
                //.Include(e => e.FkUserDetailsNavigation)
                .ConfigureAwait(false);
        }

        public async Task UpodateUser(UserEntity userEntity)
        {
            //var cart = await GetCartEntityById(cartDomain.CartId);

            //if (cart == null)
            //{
            //    return null;
            //}

            //var cartEntity = cartDomain.ToEntity();
            try
            {
                _dbContext.User.Update(userEntity);

                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
