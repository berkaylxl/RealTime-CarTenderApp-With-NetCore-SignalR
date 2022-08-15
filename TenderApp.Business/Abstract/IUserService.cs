using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Abstract
{
    public interface IUserService
    {
        Task Add(User user);
        Task Delete(Guid id);
        Task Update(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<string> Login(LoginDto loginDto);
        Task<User> GetByMail(string mail);
    }
}
