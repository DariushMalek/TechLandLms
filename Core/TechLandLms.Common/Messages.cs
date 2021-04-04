using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Common
{
    public class Messages
    {
        public static string UserOrPassIsNotValid => "نام کاربری یا رمزعبور صحیح نمی باشد";
        public static string LoginIsDeactive => "در حال حاضر امکان ورود نمی باشد. لطفا در زمان دیگری مجدد تلاش نمایید";
        public static string ExistsUser => "نام کاربری تکراری می باشد";
        public static string DuplicateMobile => "شماره همراه تکراری می باشد";
        public static string DuplicateEmail => "ایمیل تکراری می باشد";
        public static string DuplicatePersonalCode => "کدملی تکراری می باشد";
    }
}
