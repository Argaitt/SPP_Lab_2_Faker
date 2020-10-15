using Fakernamespace;
using System;

namespace CPP_Lab_2_Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Foo foo = faker.Create<Foo>();
            
        }
    }
    class Foo 
    {
        public int test1;
        public string test2;
        public long test3;
    }
}
