using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    internal abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BasicSalary {  get; set; }
        public float Bonus { get; set; }
        public float NetSalary { get; set; }

        public abstract float CalculateSalary(int id, String name, float basicSalary);

        public abstract float CalculateBonus(float salary, int criteria);

    }
}
