using InsuranceCalculationWorkwithPolymorphism;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Insurance Number: ");
        string insuNumber = Console.ReadLine();
        Console.WriteLine("Insurance Name: ");
        string insuName = Console.ReadLine();
        Console.WriteLine("Amount Covered :");
        double amountCovered = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Select\n1.Life Insurance\n2.Motor Insurance");
        int choice = Convert.ToInt32(Console.ReadLine());
        Program p = new Program();
        switch (choice)
        {
            case 1:
                Console.WriteLine("Policy Term :");
                int term = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Benefit Percent :");
                float  percent = Convert.ToSingle(Console.ReadLine());

                LifeInsurance lifeInsurance = new LifeInsurance()
                {
                    InsuranceNo = insuNumber,
                    InsuranceName = insuName,
                    AmountCovered = amountCovered,
                    PolicyTerm = term,
                    BenefitPercent = percent

                };

                Console.WriteLine($"Calculated Premium : {p.addPolicy((Insurance)lifeInsurance, choice)}");

                break;
            case 2:
                Console.WriteLine("Depreciation Percent :");
                float depPercent = Convert.ToSingle(Console.ReadLine());

                MotorInsurance motorInsurance = new MotorInsurance()
                {
                    InsuranceNo = insuNumber,
                    InsuranceName = insuName,
                    AmountCovered = amountCovered,
                    DepPercent = depPercent
                };

                Console.WriteLine($"Calculated Premium : {p.addPolicy((Insurance)motorInsurance, choice)}");

                break;
            default:
                Console.WriteLine("Invalid selection.");
                break;

        }
    }

    public double addPolicy(Insurance ins, int opt)
    {
        if(opt == 1)
        {
            return ((LifeInsurance)ins).calculatePremium();
        }
        else if(opt == 2)
        {
            return ((MotorInsurance)ins).calculatePremium();
        }
        return 0;

    }
}