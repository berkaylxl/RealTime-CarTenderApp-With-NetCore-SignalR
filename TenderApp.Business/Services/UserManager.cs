using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Services
{
    public class UserManager : IUserService
    {
         private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task DeleteById(Guid id)
        {
            var user = await _userDal.Get(u => u.Id == id);
            await _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }
        public async Task<User> GetById(Guid id)
        {
            return await _userDal.Get(u=>u.Id==id);
        }

        public async Task<User> GetByMail(string mail)
        {
            return await _userDal.Get(u => u.Email == mail);
        }
        public async Task Update(User user)
        {
            await _userDal.Update(user);
        }
        public async Task Add(User user)
        {
            await _userDal.Add(user);
        }

        // --------------------------------------------------------------------LOGIN REGISTER

        public async Task<JwtToken> Login(LoginDto loginDto)
        {
            var user = await GetByMail(loginDto.Email);
            if (user is null)
                throw new Exception("user not found");
            var password = Encrpt(loginDto.Password);
            if (user.Password != password)
                throw new Exception("password is wrong");

            var claims = new Claim[]{

                new Claim(ClaimTypes.Role,user.Claim),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Surname,user.LastName)
            };
            var token=JwtHelper.GenerateToken(claims);
            return token;
        }
        public async Task Register(RegisterDto registerDto)
        {







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
