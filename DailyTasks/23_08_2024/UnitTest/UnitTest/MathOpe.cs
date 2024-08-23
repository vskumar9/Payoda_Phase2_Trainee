using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class MathOpe
    {
        public int add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public int Pro(int x, int y)
        {
            return x * y;
        }
        public int Div(int x, int y)
        {
            return x / y;
        }
        public virtual bool CheckValues()
        {
            return false;
        }
    }
    public class Employee
    {
        string Name;
        int Age;
        public Employee(string nme, int age)
        {
            Name = nme;
            Age = age;
        }
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public int age
        {
            get
            {
                return Age;
            }
            set { Age = value; }
        }
    }
}
