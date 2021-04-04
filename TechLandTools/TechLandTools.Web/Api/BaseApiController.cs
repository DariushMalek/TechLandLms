using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using TechLandTools.Common;
using TechLandTools.Common.DtoBase;
using TechLandTools.Common.EntityBase;
using TechLandTools.Common.Helper;
using TechLandTools.Common.TechLandLog;

namespace TechLandTools.Web.Api
{
    public class BaseApiController<TEntity,TDto, TService, TLogger> : Controller
        where TEntity : BaseEntity, new()
        where TLogger : LogEntityBase, new()
        where TService: IServiceBase<TEntity, TLogger>
        where TDto : BaseDto, new()
    {
        public TService _entityService;
        //protected IMapper _mapper;
        //protected IHostingEnvironment _appEnvironment;

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            var entities = _entityService.GetEntityList();
            return Ok(entities);
        }
        
       // GET api/values
       [HttpGet("getEntityPropInfo")]
        public ActionResult GetEntityPropsInfo()
        {
            var entities = BaseDto.GetEntityPropsInfo<TDto>();
            return Ok(entities);
        }

        // GET api/values
        [HttpPost("getByState")]
        public ActionResult GetByState([FromBody]EntityState entityState)
        {
            var entities = _entityService.GetEntityListByState<TDto>(entityState);
            return Ok(entities);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var entity = _entityService.LoadEntity(id).Result;
            if (entity == null || entity.Id <= 0)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("GetDto/{id}")]
        public ActionResult GetDto(int id)
        {
            var entity =_entityService.LoadEntity<TDto>(id).Result;
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _entityService.DoSubmit(entity);
            if (result.State == ValidationResultState.IsValid) 
            { 
                return Created("Get", entity.Id);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity)
        {
            if (ModelState.IsValid)
            {
                var result = _entityService.DoSubmit(entity);
                if (result.State == ValidationResultState.IsValid)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("deleteItems")]
        public async Task<IActionResult> DeleteItems([FromBody] int[] ids)
        {
            await _entityService.DeleteEntitiesAsync(ids);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteEntity(id);
            return NoContent();
        }

        public async Task<IActionResult> DownloadFile(string fileName, string path = "wwwroot\\Resources")
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), path);

            path = Path.Combine(pathToSave, fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

       
        private static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out string contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public IActionResult ExceptionResult(string message, int? exceptionNo = null, string exceptionHint = null)
        {
             return BadRequest(new TechLandException { Message = message, ExceptionNo = exceptionNo,ExceptionHint=exceptionHint });
        }
        public IActionResult ExceptionResult(ValidationResult result)
        {
            return ExceptionResult(result.Exception.Message, result.Exception.ExceptionNo, result.Exception.ExceptionHint);
        }

        public IActionResult ValidationResponse(ValidationResult result)
        {
            if (result.IsOk())
            {
                return Ok();
            }
            else {
                return ExceptionResult(result);
            }
        }
    }
}