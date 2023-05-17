//PROGRAM TO CALCULATE NET PAY

using System;

class NETPayCalculator
{
    static void Main()
    {
        double basicPay, allowance, grossPay, netPay, paye;
        double nssfEmployee, nssfEmployer, totalNSSF, totalDeductions;

        Console.WriteLine("NET PAY CALCULATOR.");
        Console.WriteLine(" ");

        Console.Write("Enter your Basic Pay: ");
        basicPay = float.Parse(Console.ReadLine());

        Console.Write("Enter Allowances: ");
        allowance = float.Parse(Console.ReadLine());

        grossPay = (basicPay + allowance);

        if (grossPay > 10000000)
        {
            paye = (0.3 * (grossPay - 410000) + 25000) + (0.1 * (grossPay - 10000000));
        }
        else if (grossPay > 410000 && grossPay <= 10000000)
        {
            paye = 0.3 * (grossPay - 410000) + 25000;
        }
        else if (grossPay >= 335001 && grossPay <= 410000)
        {
            paye = 0.2 * (grossPay - 335001);
        }
        else if (grossPay >= 235001 && grossPay <= 335000)
        {
            paye = 0.1 * (grossPay - 235001);
        }
        else
            paye = grossPay;

        nssfEmployee = 0.05 * (grossPay);
        nssfEmployer = 0.1 * (grossPay);
        totalNSSF = nssfEmployee + nssfEmployer;
        totalDeductions = paye + nssfEmployee;

        netPay = grossPay - paye - nssfEmployee;

        Console.WriteLine(" ");
        Console.WriteLine("Your Total deductions = UGX {0}. ", totalDeductions);
        Console.WriteLine("PAYE = UGX {0}. ", paye);
        Console.WriteLine("NSSF Contribution: Employee = UGX {0} : Employer = UGX {1}. ", nssfEmployee, nssfEmployer);
        Console.WriteLine("Total NSSF Contribution = UGX {0}. ", totalNSSF);
        Console.WriteLine(" ");
        Console.WriteLine("Your NET Pay is UGX {0}. ", netPay);
    }
}