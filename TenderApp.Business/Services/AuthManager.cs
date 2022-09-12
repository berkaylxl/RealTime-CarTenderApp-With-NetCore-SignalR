using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities;
using TenderApp.Core.Utilities.Result;
using TenderApp.Core.Utilities.Security;
using TenderApp.DataAccess;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Business.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerDal _corporateCustomerDal;
        private readonly IIndividualCustomerDal _individualCustomerDal;

        public AuthManager( IMapper mapper, ICorporateCustomerDal corporateCustomerDal, IIndividualCustomerDal ındividualCustomerDal)
        {
            _mapper = mapper;
            _corporateCustomerDal = corporateCustomerDal;
            _individualCustomerDal = ındividualCustomerDal;
        }
        public async Task<User>GetByMail(string email)
        {
            var individualData= await _corporateCustomerDal.Get(u => u.Email == email);
            var corporateData= await _individualCustomerDal.Get(u=>u.Email == email);

            if (individualData!=null)
            {
                return individualData;
            }
            else
            {
                return corporateData;
            }
        }
        public async Task<DataResult<JwtToken>> Login(LoginDto loginDto)
        {
            var user = await GetByMail(loginDto.Email);
            if (user is null)
                return new DataResult<JwtToken>(Status.Error,null, "User not found");
            var password = Encrpt(loginDto.Password);
            if (user.Password != password)
                return new DataResult<JwtToken>(Status.Error, null, "Password is wrong");
            var claims = new Claim[]{
                new Claim(ClaimTypes.Role,user.Claim),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.SerialNumber,user.Id.ToString())
            };
            var token = JwtHelper.GenerateToken(claims);
            return new DataResult<JwtToken>(Status.Success,token,"Login is Successful");
        }
        public async Task<DataResult<List<string>>>IndividualRegister(IndividualRegisterDto individualRegisterDto)
        {
            var registerUser = _mapper.Map<IndividualCustomer>(individualRegisterDto);
            registerUser.Password = Encrpt(individualRegisterDto.Password);
            registerUser.Claim = "user";
            await _individualCustomerDal.Add(registerUser);
            return new DataResult<List<string>>(Status.Success,new List<string> {"Register is Successful"});
        }
        public async Task<DataResult<string>>CorporateRegister(CorporateRegisterDto corporateRegisterDto)
        {
            var registerUser = _mapper.Map<CorporateCustomer>(corporateRegisterDto);
            registerUser.Password = Encrpt(corporateRegisterDto.Password);
            registerUser.Claim = "user";
            await _corporateCustomerDal.Add(registerUser);
            return new DataResult<string>(Status.Success, "Register is Successful");
        }
        private static string Encrpt(string password)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }

        public async Task<Guid> GetIdByMail(string email)
        {
            
            var individualData = await _individualCustomerDal.Get(u => u.Email == email);
            var corporateData = await _corporateCustomerDal.Get(u => u.Email == email);

            if (individualData != null)
            {
                return individualData.Id;
            }
            else
            {
                return corporateData.Id;
            }
        }
        public async Task<string> GetMailById(Guid userId)
        {
            var individualData = await _individualCustomerDal.Get(u=>u.Id==userId);
            var corporateData = await _corporateCustomerDal.Get(u => u.Id == userId);

            if (individualData != null)
            {
                return individualData.Email;
            }
            else
            {
                return corporateData.Email;
            }
        }
    }
}
