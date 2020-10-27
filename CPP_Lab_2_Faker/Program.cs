using Fakernamespace;
using System;
using System.Collections.Generic;

namespace CPP_Lab_2_Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Foo foo = faker.Create<Foo>();
            Bar bar = faker.Create<Bar>();
            
        }
    }
    class Foo 
    {
        public int test1;
        public string test2;
        public long test3;
        public float test4;
        public string test5;
        public DateTime test6;
        public List<int> test7;
        public List<string> test8;
        public double test9;
        public List<double> test10;
        public Bar bar;
    }
    class Bar
    {
        public int test1;
        public string test2;
        public long test3;
        public float test4;
        public string test5;
        public DateTime test6;
        public List<int> test7;
        public List<string> test8;
        public double test9;
        public List<double> test10;
        public Foo foo;
    }
}
