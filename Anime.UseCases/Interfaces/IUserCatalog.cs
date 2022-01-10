using System.Collections.Generic;
using DomainModel.Entities;
using DomainServices.DTO;

namespace DomainServices
{
    public interface IUserCatalog
    {
        User AddUserOrDefault(UserRegistrationDto dto);
        bool TryEditUser(EditUserDto dto);
        GetUserByIdDto GetUserByIdOrDefault(GetUserByIdDto dto);
        void ChangeUserRole(ChangeUserRoleDto dto);
        GetUserSubscriptionAnimeDto GetUserSubscriptionAnimeOrDefault(GetUserSubscriptionAnimeDto dto);
        bool TryChangeUserPassword(TryChangeUserPasswordDto dto);
        User TryLogIn(TryLogInDto dto);
        User GetUserByNameOrDefault(string Name);
        User GetUserByEmailOrDefault(string Email);

 
    }
}