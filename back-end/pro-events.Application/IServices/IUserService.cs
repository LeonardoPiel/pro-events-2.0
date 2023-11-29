using Microsoft.AspNetCore.Identity;
using pro_events.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.IServices
{
    public interface IUserService
    {
        Task<bool> UserExists(string userName);
        Task<UserSaveDto> GetUserByUserName(string userName);
        Task<SignInResult> CheckUserPassword(UserSaveDto userDto, string password);
        Task<UserSaveDto> CreateUser(UserSaveDto newUserDto);
        Task<UserSaveDto> UpdateUser(UserSaveDto userDto);
    }
}
