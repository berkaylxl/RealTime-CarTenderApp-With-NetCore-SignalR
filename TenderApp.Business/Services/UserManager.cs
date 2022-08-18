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
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Business.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public async Task<Result> DeleteById(Guid id)
        {
            var user = await _userDal.Get(u => u.Id == id);
            if (user is null)
                return new Result(Status.Error, "Cannot delete user > (User Not Found)");
            await _userDal.Delete(user);
            return new Result(Status.Success,"User was Deleted");
        }

        public async Task<DataResult<List<User>>> GetAll()
        {
            var data = await _userDal.GetAll();
            return new DataResult<List<User>>(Status.Success,data,"User was Listed");

        }
        public async Task<DataResult<User>> GetById(Guid id)
        {
            var data = await _userDal.Get(u => u.Id == id);
            if (data is null)
                return new DataResult<User>(Status.Error, data,"User Not Found");
            return new DataResult<User>(Status.Success, data);

        }
        public async Task<DataResult<User>> GetByMail(string mail)
        {
            var data = await _userDal.Get(u => u.Email == mail);
            if (data is null)
                return new DataResult<User>(Status.Error, data, "User Not Found");
            return new DataResult<User>(data);
        }
        public async Task<Result> Update(User user)
        {
            await _userDal.Update(user);
            return new Result(Status.Success,"User was Updated");
        }
        public async Task<Result> Add(User user)
        {
            await _userDal.Add(user);
            return new Result(Status.Success, "User was Added");
        }

        // --------------------------------------------------------------------LOGIN REGISTER

        public async Task<DataResult<JwtToken>> Login(LoginDto loginDto)
        {
            var user = await GetByMail(loginDto.Email);
            if (user is null)
                return new DataResult<JwtToken>(Status.Error,null, "User not found");
            var password = Encrpt(loginDto.Password);
            if (user.Data.Password != password)
                return new DataResult<JwtToken>(Status.Error, null, "Password is wrong");

            var claims = new Claim[]{

                new Claim(ClaimTypes.Role,user.Data.Claim),
                new Claim(ClaimTypes.Email,user.Data.Email),
                new Claim(ClaimTypes.GivenName,user.Data.FirstName),
                new Claim(ClaimTypes.Surname,user.Data.LastName)
            };
            var token = JwtHelper.GenerateToken(claims);
            return new DataResult<JwtToken>(Status.Success,token,"Login is Successful");
        }
        public async Task<DataResult<string>> Register(RegisterDto registerDto)
        {

            var registerUser = _mapper.Map<User>(registerDto);
            registerUser.Password = Encrpt(registerDto.Password);
            registerUser.Claim = "user";
            await _userDal.Add(registerUser); 
            return new DataResult<string>(Status.Success,"Register is Succussful");
        }

        private static string Encrpt(string password)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }


    }
}
