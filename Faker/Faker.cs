using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Fakernamespace
{
    interface IFakeGenerator 
    {
        object Generate(); 
    }
    class FakeGenerator : IFakeGenerator
    {
        public virtual object Generate() 
        {
            object obj = 0;
            return obj;
        }
    }
    class IntFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return (int)12;
        }
    }
    public class Faker
    {
        Dictionary<Type, FakeGenerator> FakeGeneratorDictionary;
        public Faker() 
        {
            FakeGeneratorDictionary = new Dictionary<Type, FakeGenerator>();
            FakeGeneratorDictionary.Add(typeof(int), new IntFakeGenerator());
        }
        public T Create<T>()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var type = obj.GetType();
            FieldInfo[] myFields = type.GetFields();
            
            foreach (var item in myFields)
            {
                FakeGenerator generator = new FakeGenerator();
                FakeGeneratorDictionary.TryGetValue(item.FieldType, out generator);
                item.SetValue(obj, generator.Generate());
            }
            return obj;
        }
    }
}
