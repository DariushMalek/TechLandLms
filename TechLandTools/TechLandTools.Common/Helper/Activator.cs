using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.Helper
{
    public class ActivatorHelper
    {
        public static T GetInstanceOf<T>()
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            return instance;
        }
    }
}
