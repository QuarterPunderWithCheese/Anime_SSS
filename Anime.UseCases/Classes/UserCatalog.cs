using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using DomainModel.Entities;
using DomainServices.DTO;
using DomainServices.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace DomainServices.Classes
{
    public class UserCatalog: IUserCatalog
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _manager;
       

        public UserCatalog(AppDbContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
        }

       


        public User AddUserOrDefault(UserRegistrationDto dto)
        {
            if (IsUserEmailUnique(dto.Email))
            {
                if (_manager.FindByNameAsync(dto.Name).Result != null) return null;
                return CreateUser(dto).Result;
            }
            return null;
        }

        public bool TryEditUser(EditUserDto dto)
        {
            if (dto.Id == null) return false; 
            User user = GetUserByIdFromDb(dto.Id);

            if (user == null) return false;
            user.Avatar = dto.AvatarPath;
            if (TryEditUserInDb(user))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public GetUserByIdDto GetUserByIdOrDefault(GetUserByIdDto dto)
        {
            dto.user = GetUserByIdFromDb(dto.Id);
            return dto;
        }

        public void ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
        {
            User user = GetUserByIdFromDb(changeUserRoleDto.Id);
            var roles = _manager.GetRolesAsync(user);
            /// ????
        }

        public GetUserSubscriptionAnimeDto GetUserSubscriptionAnimeOrDefault(GetUserSubscriptionAnimeDto dto)
        {
            dto.Anime = ReturnAnimeByUser(GetUserByIdFromDb(dto.UserId));
            return dto;
        }

        private async Task<User> CreateUser(UserRegistrationDto dto)
        {
            
            var user = new User
            {
                UserName = dto.Name,
                Email = dto.Email,
                Avatar = "Default.png"
            };
            
            await _manager.CreateAsync(user, dto.Password);
            return _context.Users.FirstOrDefault(x => x.Email == dto.Email);
        }

        private User GetUserByIdFromDb(int Id)
        {
            return _context.Users
                .FirstOrDefault(x => x.Id == Id.ToString());
        }

        private bool TryEditUserInDb(User user)
        {
            User _user = GetUserByIdFromDb(Convert.ToInt32(user.Id));
            if (_user == null) return false;
            _user.UserName = user.UserName;
            if (user.Avatar != null) _user.Avatar = user.Avatar;
            _context.SaveChanges();
            return true;
        }

        private List<FollowedAnime> ReturnAnimeByUser(User user)
        {
            return _context.FollowedAnime.Where(x => x.User.Id == user.Id).ToList();
        }

        public bool TryChangeUserPassword(TryChangeUserPasswordDto dto)
        {
            
            return TryChangeUserPasswordInDb(dto.UserId, dto.OldPassword, dto.NewPassword).Result;
        }

        public User TryLogIn(TryLogInDto dto)
        {
            User user = new User();
            user = GetUserByEmail(dto.Email);
            if (_manager.CheckPasswordAsync(user, dto.Pass).Result == true)
            {
                
                return user;
            }
            else
            {
                return null;
            }
        }

        public User GetUserByNameOrDefault(string Name)
        {
            return _manager.FindByNameAsync(Name).Result;
        }
        private User GetUserByEmail(string Email)
        {
            return _context.Users.FirstOrDefault(x=>x.Email == Email);
        }

        public User GetUserByEmailOrDefault(string Email)
        {
            if (Email == "")
            {
                return null;
            }
            else
            {
                return GetUserByEmail(Email);
            }
        }

        private bool IsUserEmailUnique(string Email)
        {
            User user = _context.Users.FirstOrDefault(x=>x.Email == Email);
            return user == null;
        }
        
        private async Task<bool> TryChangeUserPasswordInDb(int Id, string OldPass, string NewPass)
        {
            var result = await _manager.ChangePasswordAsync(GetUserByIdFromDb(Id), OldPass, NewPass);
            
            return result.Succeeded;
        }
        
        
        
        
        
    }
}