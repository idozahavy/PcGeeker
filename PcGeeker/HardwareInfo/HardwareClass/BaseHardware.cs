using System.Collections.Generic;
using System.Reflection;

namespace HardwareInfo.HardwareClass
{
    public abstract class BaseHardware
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
                else if(prop.PropertyType == typeof(List<T>))
                {
                    List<T> ls = prop.GetValue(this) as List<T>;
                    foreach(T obj in ls)
                    {
                        func.Invoke(this, prop, obj);
                    }
                }
            }
        }
    }
}