using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities;
using TenderApp.Core.Utilities.Result;
using TenderApp.Core.Utilities.Security;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<Result> Add(User user);
        Task<DataResult<List<User>>> GetAll();
        Task<DataResult<User>> GetById(Guid id);
        Task<Result> Update(User user);
        Task<Result> DeleteById(Guid id);
        Task<DataResult<JwtToken>> Login(LoginDto loginDto);
        Task<DataResult<string>> Register(RegisterDto registerDto);
        Task<DataResult<User>>GetByMail(string mail);
       
    }
}
