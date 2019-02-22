using LZ.Models.efdemo.Dto.Contracts;
using LZ.Models.efdemo.Entity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LZ.BusinessLayer.efdemo
{
    public interface IefdemoManager
    {
        Task AddNewUser(User userEntity);
        Task UpodateUser(User userEntity);
        Task<List<User>> GetUsers();
        Task DeleteUser(int userId);
    }
}
