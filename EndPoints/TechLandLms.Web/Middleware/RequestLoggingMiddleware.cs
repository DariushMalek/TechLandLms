using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandTools.Common.TechLandLog;

namespace TechLandLms.Web.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ITechLandLogger<LogInfo> _techLandLogger;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            //_techLandLogger = techLandLogger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if(context.Request?.Path.Value== "/api/userAccount/getByState")
                {
                    using (var reader = new StreamReader(context.Request.Body))
                    {
                        var body = reader.ReadToEndAsync();

                        // Do something
                    }
                }
                await _next(context);
            }
            catch(Exception e)
            {

            }
            finally
            {
                //_techLandLogger.LogInfo("OnRequest", "MiddleWare", "", null, $"Request {context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}");
            }
        }
    }
}
