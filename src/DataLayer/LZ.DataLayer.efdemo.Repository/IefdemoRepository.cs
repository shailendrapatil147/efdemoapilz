using LZ.Models.efdemo.Entity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LZ.DataLayer.efdemo.Repository
{
    public interface IefdemoRepository
    {
        Task AddNewUser(UserEntity userEntity);
        Task UpodateUser(UserEntity userEntity);
        Task<List<UserEntity>> GetUsers();
        Task<UserEntity> GetUsers(int userId);
        Task DeleteUser(int userId);
    }
}
