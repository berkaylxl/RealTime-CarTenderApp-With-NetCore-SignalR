using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Services.Abstract
{
    public interface IUserService
    {
        Task Add(User user);
        List<User> GetAll();
        Task<User> GetById(Guid id);
        Task Update(User user);
        Task DeleteById(Guid id);
        Task<JwtToken> Login(LoginDto loginDto);
        Task<string> Register(RegisterDto registerDto);
        Task<User>GetByMail(string mail);
       
    }
}
