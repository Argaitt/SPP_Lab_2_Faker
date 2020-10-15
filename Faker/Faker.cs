using System;
using System.Dynamic;
using System.Reflection;

namespace Fakernamespace
{
    public class Faker
    {
        public T Create<T>()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var type = obj.GetType();
            FieldInfo[] myFields = type.GetFields();
            
            foreach (var item in myFields)
            {
                item.SetValue(obj, 1);
            }
            return obj;
        }
    }
}
