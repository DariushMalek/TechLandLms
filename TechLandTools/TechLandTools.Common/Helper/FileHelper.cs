using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace TechLandTools.Common.Helper
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile file, string path= "wwwroot\\Resources")
        {
            try
            {
                var folderName = path;
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var myUniqueFileName = string.Format(@"{0}" + Path.GetExtension(file.FileName), Guid.NewGuid());
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, myUniqueFileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return myUniqueFileName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return  $"Internal server error: {ex}";
            }
        }
    }
}
