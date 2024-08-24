using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    internal class TemporaryEmployee : Employee
    {
        public int DailyWages { get; set; }
        public int NoOfDays { get; set; }

        public override float CalculateBonus(float salary, int criteria)
        {
            float bonus = 0;
            if (DailyWages < 1000)
            {
                bonus = NetSalary * 0.15f;
            }
            else if (DailyWages >= 1000 && DailyWages < 1500)
            {
                bonus = NetSalary * 0.12f;
            }
            else if (DailyWages >= 1500 && DailyWages < 1750)
            {
                bonus = NetSalary * 0.11f;
            }
            else if (DailyWages >= 1750)
            {
                bonus = NetSalary * 0.08f;
            }
            return bonus;
        }

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            NetSalary = DailyWages * NoOfDays;
            return NetSalary;
        }
    }
}
