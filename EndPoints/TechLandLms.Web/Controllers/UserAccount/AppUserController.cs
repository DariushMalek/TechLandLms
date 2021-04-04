using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Model.Models;
using TechLandLms.Services.Global;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserController : BaseApiController<AppUser, AppUserDto, IAppUserService, LogInfo>
    {
        public AppUserController(IAppUserService appUserService)
        {
            _entityService = appUserService;
        }

        [AllowAnonymous]
        [HttpGet("GetCurrentUser")]
        public ActionResult<AppUserDto> GetCurrentUser()
        {
            var result = _entityService.GetCurrentUser();
            return Ok(result);
        }

        [HttpGet("GetUserProfileImage")]
        public async Task<IActionResult> GetUserProfileImage()
        {
            string currentUser = _entityService.GetCurrentUser().UserName;
            var userProfile = _entityService.GetUserProfileImage(currentUser);
            if (string.IsNullOrEmpty(userProfile))
            {
                return NoContent();
            }
            var profilePhoto = await DownloadFile(userProfile, ContentFileHelper.UserProfilePicture);
            return profilePhoto;
        }

        [HttpGet("GetUserImage/{UserId}")]
        public async Task<IActionResult> GetUserImage(int userId)
        {
            var userProfile = _entityService.GetUserImageById(userId);
            if (string.IsNullOrEmpty(userProfile))
            {
                return BadRequest("Image not found!");
            }
            var profilePhoto = await DownloadFile(userProfile, ContentFileHelper.UserProfilePicture);
            return profilePhoto;
        }

        [AllowAnonymous]
        [HttpPost("SignUpUser")]
        public IActionResult SignUpUser([FromBody] SignUpViewModel signUpModel)
        {
            var result = _entityService.SignUpUser(signUpModel);
            return ValidationResponse(result);
        }

        [AllowAnonymous]
        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword([FromBody] PasswordViewModel passwordModel)
        {
            var result = _entityService.ChangePassword(passwordModel);
            return ValidationResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("AddAppUser")]
        public IActionResult AddAppUser(AppUserDto model)
        {
            var appUser = _entityService.AddAppUser(model);
            return Ok(appUser);
        }

        [AllowAnonymous]
        [HttpPut("UpdateAppUser")]
        public IActionResult UpdateAppUser(AppUserDto model)
        {
            var result = _entityService.UpdateAppUser(model);
            return ValidationResponse(result);
        }

        [HttpPut("UploadUserImage/{id}")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public IActionResult UploadUserImage([FromRoute] int id, [FromForm] IFormFile file)
        {
            _entityService.UploadUserImage(file, id);
            return Ok();
        }


    }
}
