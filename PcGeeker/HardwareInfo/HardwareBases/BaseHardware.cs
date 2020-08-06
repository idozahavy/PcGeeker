using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.HardwareBases
{
    public class BaseHardware
    {
        public delegate void WhereTypeFunc<T>(object sender, PropertyInfo property, T value);
        public void Where<T>(WhereTypeFunc<T> func)
        {
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(T))
                {
                    func.Invoke(this, prop, (T)prop.GetValue(this));
                }
            }
        }
    }
    
}
