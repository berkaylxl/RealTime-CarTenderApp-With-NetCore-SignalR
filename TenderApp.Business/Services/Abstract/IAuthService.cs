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
    public interface IAuthService
    {
        Task<DataResult<JwtToken>> Login(LoginDto loginDto);
        Task<DataResult<string>> IndividualRegister(IndividualRegisterDto individualRegisterDto);
        Task<DataResult<string>> CorporateRegister(CorporateRegisterDto corporateRegisterDto);
        Task<Guid> GetIdByMail(string email);
       
    }
}
