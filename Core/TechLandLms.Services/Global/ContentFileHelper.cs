using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandLms.Services.Global
{
    public static class ContentFileHelper
    {
        public static string OnlineExamAttachFilePath
        {
            get
            {
                return "wwwroot\\Resources\\Content\\OnlineExamAttachFile";
            }
        }
        public static string EducationalUnitAttachFilePath
        {
            get
            {
                return "wwwroot\\Resources\\Content\\EducationalUnitContentFile";
            }
        }
        public static string SchoolLogo
        {
            get
            {
                return "wwwroot\\Resources\\Content\\SchoolLogo";
            }
        }

        public static string UserProfilePicture
        {
            get
            {
                return "wwwroot\\Resources\\Content\\UserProfilePicture";
            }
        }  
        public static string UserProfileFixedPhotos
        {
            get
            {
                return "wwwroot\\Resources\\Content\\UserProfilePicture\\FixedPhotos";
            }
        }

    }
}
