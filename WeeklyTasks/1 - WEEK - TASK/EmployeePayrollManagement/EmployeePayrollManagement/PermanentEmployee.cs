using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    internal class PermanentEmployee : Employee
    {
        public int Pf {  get; set; }

        public override float CalculateBonus(float salary, int criteria)
        {
            float bonus = 0;
            if (Pf < 1000)
            {
                bonus = salary * 0.10f;
            }
            else if (Pf >= 1000 && Pf < 1500)
            {
                bonus = salary * 0.115f;
            }
            else if (Pf >= 1500 && Pf < 1800)
            {
                bonus = salary * 0.12f;
            }
            else if (Pf >= 1800)
            {
                bonus = salary * 0.15f;
            }
            return bonus;
        }

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            return basicSalary - Pf;
        }
    }
}
