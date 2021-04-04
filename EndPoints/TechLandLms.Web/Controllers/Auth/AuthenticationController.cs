using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Common;
using TechLandLms.Core.Entities;
using TechLandLms.Model;
using TechLandLms.Model.Dto;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.DtoBase;
using TechLandTools.Common.Secutirty;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseApiController<AppUser, BaseDto, IAppUserService, LogInfo>
    {
        readonly AppSettingModel _appSetting;
        public AuthenticationController(IAppUserService appUserService, IOptions<AppSettingModel> appSetting)
        {
            _entityService = appUserService;
            _appSetting = appSetting.Value;
        }

        [AllowAnonymous]
        [HttpPost("SignInByEmail")]
        public IActionResult SignInByEmail([FromBody] SignInModel signInModel)
        {
            var model = new AuthInfoModel
            {
                Email = signInModel.Email,
                Password = signInModel.Password
            };
            var loginInfoIsValid = _entityService.AuthenticateByEmail(model.Email, model.Password);

            if (!loginInfoIsValid)
            {
                _entityService.TechLandLogger.LogError("", "", $"Login Faild; User: {model.UserName} ; Password: {model.Password}", "Login");

                return ExceptionResult(Messages.UserOrPassIsNotValid);
            }
            var userInfo = _entityService.GetUserByEmail(model.Email);

            if (!_entityService.AppLoginIsActive() && !userInfo.IsAdmin.Value)
            {
                return ExceptionResult( Messages.LoginIsDeactive);
            }
            var expiresIn = DateTime.UtcNow.AddHours(4);
            model.UserId = userInfo.Id;
            model.Email = userInfo.Email;
            model.UserName = userInfo.UserName;
            model.FirstName = userInfo.FirstName;
            model.LastName = userInfo.LastName;
            model.IsAdmin = userInfo.IsAdmin;
            model.UserRole = "Admin";//userInfo.IsAdmin.Value ? "Admin" : userInfo.UserRoleList.FirstOrDefault().RoleEntity.RoleTitle;
            model.AccessToken = JwtHelper.GenerateJSONWebToken(model, _appSetting.Secret, expiresIn);
            model.ExpiresIn = expiresIn;
            model.UserId = userInfo.Id;
            return Ok(model);

        }
    }
}
