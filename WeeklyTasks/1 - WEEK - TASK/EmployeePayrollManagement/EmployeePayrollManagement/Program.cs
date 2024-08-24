using EmployeePayrollManagement;

namespace EmployeePayrollManagement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int id, pf, wages, days;
            float salary;
            string type, name;
            Console.WriteLine("Enter the details");
            Console.WriteLine("Enter the type of Employee:");
            type = Console.ReadLine();
            

            if (type.ToLower().Equals("permanent"))
            {
                Console.WriteLine("Employee Id:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Employee Name:");
                name = Console.ReadLine();
                Console.WriteLine("Basic Salary:");
                salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("PF:");
                pf = Convert.ToInt32(Console.ReadLine());

                Employee Pemployee = new PermanentEmployee() { Id = id, Name = name, BasicSalary = salary, Pf = pf };
                Pemployee.Bonus = Pemployee.CalculateBonus(salary, pf);
                Pemployee.NetSalary = Pemployee.CalculateSalary(id, name, salary);

                Console.WriteLine();
                Console.WriteLine($"The details are:\n" +
                                  $"Employee Id: {Pemployee.Id}\n" +
                                  $"Employee Name: {Pemployee.Name}\n" +
                                  $"Basic Salary: {Pemployee.BasicSalary}\n" +
                                  $"PF: {((PermanentEmployee)Pemployee).Pf}\n" +
                                  $"Bouns: {Pemployee.Bonus}\n" +
                                  $"Net Salary: {Pemployee.NetSalary}");

            }
            else if (type.ToLower().Equals("temporary"))
            {
                Console.WriteLine("Employee Id:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Employee Name:");
                name = Console.ReadLine();
                Console.WriteLine("Daily Wages:");
                wages = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No.of days worked:");
                days = Convert.ToInt32(Console.ReadLine());

                Employee Temployee = new TemporaryEmployee() { Id = id, Name = name, DailyWages = wages, NoOfDays = days };
                Temployee.NetSalary = Temployee.CalculateSalary(id, name, wages);
                Temployee.Bonus = Temployee.CalculateBonus(0, 0);

                Console.WriteLine();
                Console.WriteLine($"The details are:\n" +
                                  $"Employee Id: {Temployee.Id}\n" +
                                  $"Employee Name: {Temployee.Name}\n" +
                                  $"Daily Wages: {((TemporaryEmployee)Temployee).DailyWages}\n" +
                                  $"No.of days worked: {((TemporaryEmployee)Temployee).NoOfDays}\n" +
                                  $"Bouns: {Temployee.Bonus}\n" +
                                  $"Net Salary: {Temployee.NetSalary}\n");
            }

        }
    }

}