using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Dto.Models;
using TechLandLms.Model.Dto;
using TechLandLms.Model.Models;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.TechLandLog;
using TechLandTools.Common.Data;
using TechLandLms.Common;
using TechLandTools.Common.Helper;
using TechLandLms.Services.Global;

namespace TechLandLms.Services
{
    public class AppUserService : ServiceBase<AppUser, LogInfo>, IAppUserService
    {
        readonly IUserRoleService _userRoleService;
        public AppUserService(IAsyncRepository<AppUser> entityRepository, IUserRoleService userRoleService, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {
            _userRoleService = userRoleService;
        }

        #region Authentication
        public bool AuthenticateByUserName(string userName, string password)
        {
            return EntityRepository.AnyEntity(x => x.UserName == userName && x.Pass == password);
        }
        public bool AuthenticateByEmail(string email, string password)
        {
            return AnyEntity($"Email ='{email}' and Pass = '{password}'");
        }

        public bool AppLoginIsActive()
        {
            var appSetting = EntityRepository.GetByCriteria<AppSetting>(n => true).FirstOrDefault();
            return appSetting.LoginIsActive;
        }

        #endregion

        #region CheckDuplicated
        public bool MobileIsDuplicate(int id, string mobile)
        {
            return EntityRepository.AnyEntity(x => x.Id != id && x.Mobile == mobile);
        }

        public bool UserIsDuplicate(int id, string userName)
        {
            return EntityRepository.AnyEntity(x => x.Id != id && x.UserName == userName);
        }

        public bool EmailIsDuplicate(int id, string email)
        {
            return EntityRepository.AnyEntity(x => x.Id != id && x.Email == email);
        }

        public bool PersonalCodeIsDuplicate(int id, string personalCode)
        {
            return EntityRepository.AnyEntity(x => x.Id != id && x.PersonalCode == personalCode);
        }

        public override ValidationResult SubmitValidation(AppUser entity)
        {
            if (UserIsDuplicate(entity.Id, entity.UserName))
            {
                return new ValidationResult(Messages.ExistsUser, "UserIsDuplicate");
            }
            if (EmailIsDuplicate(entity.Id, entity.Email))
            {
                return new ValidationResult(Messages.DuplicateEmail, "EmailIsDuplicate");
            }
            if (MobileIsDuplicate(entity.Id, entity.Mobile))
            {
                return new ValidationResult(Messages.DuplicateMobile, "MobileIsDuplicate");
            }
            if (PersonalCodeIsDuplicate(entity.Id, entity.PersonalCode))
            {
                return new ValidationResult(Messages.DuplicatePersonalCode, "PersonalCodeIsDuplicate");
            }
            return new ValidationResult();
        }
        #endregion

        public AppUserDto GetUserByEmail(string email)
        {
            return GetEntity<AppUserDto>($"Email = '{email}'");
        }

        public AppUserDto GetUserByName(string userName)
        {
            return GetEntity<AppUserDto>($"UserName = '{userName}'");
        }

        public AppUserDto GetCurrentUser()
        {
            return GetUserByName(HttpContextAccessor.HttpContext.User.Identity.Name);
        }

        public string GetUserProfileImage(string userName = "")
        {
            var userProfileImg = EntityRepository
                .GetByCriteria(x => x.UserName == userName).FirstOrDefault();
            return userProfileImg?.UserImage;
        }
        
        public string GetUserImageById(int userId)
        {
            var userProfileImg = EntityRepository
                .GetByCriteria(x => x.Id == userId).FirstOrDefault();
            return userProfileImg?.UserImage;
        }

        public ValidationResult SignUpUser(SignUpViewModel signUpModel)
        {
            EntityRepository.BeginTransaction();
            ValidationResult submitResult = new ValidationResult();
            try
            {
                var user = Mapper.Map<AppUser>(signUpModel);
                submitResult = DoSubmit(user);
                if (submitResult.IsOk() && user.IsAdmin == null)
                {
                    submitResult = AddUserRole(user.Id, AppRoles.User);
                   
                }
                if (submitResult.IsOk())
                {
                    EntityRepository.CommitTransaction();
                }
                else
                {
                    EntityRepository.RollbackTransaction();
                }
            }catch(Exception e)
            {

            }
            return submitResult;
        }

        public ValidationResult ChangePassword(PasswordViewModel passwordModel)
        {
            ValidationResult validationResult = new ValidationResult();
            var userToChangePass = EntityRepository.GetByCriteria(u => u.UserName == GetCurrentUser().UserName && u.Pass == passwordModel.CurrentPassword).FirstOrDefault();
            if (userToChangePass != null)
            {
                userToChangePass.Pass = passwordModel.Pass;
                validationResult = DoSubmit(userToChangePass);
            }
            return validationResult;
        }

        private ValidationResult AddUserRole(int userId, string roleName)
        {
            var role = EntityRepository.GetByCriteria<Role>(x => x.RoleTitle == roleName).FirstOrDefault().Id;
            var userRole = new UserRole()
            {
                UserId = userId,
                RoleId = role
            };
            var submitResult = _userRoleService.DoSubmit(userRole);
            return submitResult;
        }

        public ValidationResult AddAppUser(AppUserDto model)
        {
            var appUser = Mapper.Map<AppUser>(model);
            var submitRes = DoSubmit(appUser);
            return submitRes;
        }

        public ValidationResult UpdateAppUser(AppUserDto model)
        {
            var appUser = Mapper.Map<AppUser>(model);
            appUser.UserImage = model.UserImage;
            var updateUser = DoSubmit(appUser);
            return updateUser;
        }

        public void UploadUserImage(IFormFile file, int id)
        {
            var filePath = FileHelper.SaveFile(file, ContentFileHelper.UserProfilePicture);
            var entity = EntityRepository.GetByIdAsync(id).Result;
            entity.UserImage = filePath;
            DoSubmit(entity);
        }

    }
}
