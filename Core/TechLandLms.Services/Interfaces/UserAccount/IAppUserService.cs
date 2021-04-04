using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Model.Models;
using TechLandTools.Common;

namespace TechLandLms.Services.Interfaces
{
    public interface IAppUserService : IServiceBase<AppUser, LogInfo>
    {
        bool AuthenticateByUserName(string userName, string password);
        bool AuthenticateByEmail(string email, string password);
        bool AppLoginIsActive();
        AppUserDto GetUserByEmail(string email);
        AppUserDto GetUserByName(string userName);
        AppUserDto GetCurrentUser();
        string GetUserProfileImage(string userName = "");
        ValidationResult SignUpUser(SignUpViewModel signUpModel);
        ValidationResult AddAppUser(AppUserDto model);
        ValidationResult UpdateAppUser(AppUserDto model);
        void UploadUserImage(IFormFile file, int id);
        string GetUserImageById(int userId);
        ValidationResult ChangePassword(PasswordViewModel passwordModel);
    }
}
