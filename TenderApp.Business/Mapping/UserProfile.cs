using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,RegisterDto >().ReverseMap();
        }
    }
}
