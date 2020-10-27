using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Fakernamespace
{
    
    public class Faker
    {
        Dictionary<Type, FakeGenerator> FakeGeneratorDictionary;
        public Faker() 
        {
            FakeGeneratorDictionary = new Dictionary<Type, FakeGenerator>();
            FakeGeneratorDictionary.Add(typeof(int), new IntFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(long), new LongFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(string), new StringFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(double), new DoubleFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(float), new FloatFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(DateTime), new DateTimeFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(List<int>), new ArrIntFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(List<string>), new ArrStringFakeGenerator());
            FakeGeneratorDictionary.Add(typeof(List<double>), new ArrDoubleFakeGenerator());
        }
        public T Create<T>()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var type = obj.GetType();
            FieldInfo[] myFields = type.GetFields();
            foreach (var item in myFields)
            {
                if (FakeGeneratorDictionary.TryGetValue(item.FieldType, out var generator))
                    item.SetValue(obj, generator.Generate());
                else 
                {
                    item.SetValue(obj, null);
                }
            }
            return obj;
        }
    }
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
    class LongFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return (long)12;
        }
    }
    class StringFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return "string";
        }
    }
    class FloatFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return (float)23.1;
        }
    }
    class DateTimeFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return DateTime.Now;
        }
    }
    class DoubleFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return (double)000.1;
        }
    }
    class ArrIntFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6 };
        }
    }
    class ArrDoubleFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return new List<double> {1.0, 2.0, 3.0, 4.0, 5.0, 6.0};
        }
    }
    class ArrStringFakeGenerator : FakeGenerator
    {
        public override object Generate()
        {
            return new List<string> { "1","2" ,"3","4","5","6"};
        }
    }
}
