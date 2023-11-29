using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pro_events.Application.DTO.Users;
using pro_events.Application.IServices;
using pro_events.Domain.Identity;
using pro_events.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace pro_events.Application.ServicesRepository
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersistence _userPersistence;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserPersistence userPersistence) 
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
            this._userPersistence = userPersistence;
        }
        public async Task<SignInResult> CheckUserPassword(UserSaveDto userDto, string password)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(e => e.UserName == userDto.UserName);
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch(Exception ex) 
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }

        public async Task<UserSaveDto> CreateUser(UserSaveDto newUserDto)
        {
            try
            {
                var user = _mapper.Map<User>(newUserDto);
                if (user == null) throw new Exception("Can not map user data sent.");
                // preenche todos os dados do user ao passar por parâmetro
                var result = await _userManager.CreateAsync(user, newUserDto.Password);
                if (result.Succeeded)
                {
                    var response = _mapper.Map<UserSaveDto>(user);
                    await _userPersistence.SaveChangesAsync();
                    return response;
                }
                var msg = "";
                foreach (var item in result.Errors)
                    msg = "[" + msg + item.Description + "]";
                
                throw new Exception($"Errors ocurred while creating. {msg}");
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }

        public async Task<UserSaveDto> GetUserByUserName(string userName)
        {
            try
            {
                var user = await _userPersistence.GetUserByUserNameAsync(userName.ToLower());
                if (user == null) throw new Exception("User was not found.");
                var rs = _mapper.Map<UserSaveDto>(user);
                return rs;
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }

        public async Task<UserSaveDto> UpdateUser(UserSaveDto userDto)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == userDto.UserName.ToLower());
                if (user == null) throw new Exception("User not found");

                var mappedUser = _mapper.Map(userDto, user);
                
                
                var token = await _userManager.GeneratePasswordResetTokenAsync(mappedUser);
                var result = await _userManager.ResetPasswordAsync(mappedUser, token, userDto.Password);

                if (result.Succeeded)
                {
                    _userPersistence.Update(mappedUser);
                    if (await _userPersistence.SaveChangesAsync())
                    {
                        return _mapper.Map<UserSaveDto>(mappedUser);
                    }
                }
                throw new Exception("Error while updating user");
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(x => x.UserName == userName);
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }
    }
}
