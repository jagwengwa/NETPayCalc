using System;
using System.IO;
class dst_NETPayCalculator
{
    static void Main()
    {
        try
        {
            try
            {
                double basicPay, allowance, grossPay, netPay, paye, nssfEmployee, nssfEmployer, totalNSSF,
                    totalDeductions;
                string employeeName;
                string userChoice = string.Empty;

                Console.WriteLine("*** NET PAY CALCULATOR - UGX ***");
                Console.WriteLine(" ");

                do
                {
                    Console.WriteLine("What is your name?");
                    employeeName = Console.ReadLine();

                    Console.WriteLine("Hello {0}. What is your pay?", employeeName);
                    bool isBasicPayConversionSuccess = double.TryParse(Console.ReadLine(), out basicPay);

                    if (isBasicPayConversionSuccess)
                    {
                        Console.WriteLine("Your total allowance...");
                        bool isAllowanceConversionSuccess = double.TryParse(Console.ReadLine(), out allowance);

                        if (isAllowanceConversionSuccess)
                        {
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
                                paye = 0;

                            nssfEmployee = 0.05 * (grossPay);
                            nssfEmployer = 0.1 * (grossPay);
                            totalNSSF = nssfEmployee + nssfEmployer;
                            totalDeductions = paye + nssfEmployee;

                            netPay = grossPay - paye - nssfEmployee;

                            Console.WriteLine(" ");
                            Console.WriteLine("{0}, your gross pay = UGX {1}", employeeName, grossPay);
                            Console.WriteLine("PAYE = UGX {0}", paye);
                            Console.WriteLine("NSSF Contribution: Employee = UGX {0} and Employer = UGX {1}", nssfEmployee, nssfEmployer);
                            Console.WriteLine("Total NSSF Contribution = UGX {0}", totalNSSF);
                            Console.WriteLine("Employee total deductions = UGX {0}", totalDeductions);
                            Console.WriteLine(" ");
                            Console.WriteLine("Your NET pay is UGX {0}", netPay);

                            do
                            {
                                Console.WriteLine("Do you want to continue? Yes or No...");
                                userChoice = Console.ReadLine().ToUpper();

                                if (userChoice != "YES" && userChoice != "NO")
                                {
                                    Console.WriteLine("Invalid choice. Enter Yes or No");
                                }
                            } while (userChoice != "YES" && userChoice != "NO");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid value.");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid value.");

                    }
                } while (userChoice == "YES");
            }

            catch (Exception ex)
            {
                string filePath = @"C:\Users\OMONDI\Documents\GitHub\VSCode\Learning HUB\Log.txt";

                if (File.Exists(filePath))
                {
                    StreamWriter sw = new StreamWriter(filePath); //Writing the error log to a file
                    sw.Write(ex.GetType().FullName); //Telling the StreamWriter what to write
                    sw.WriteLine();
                    sw.Write(ex.Message);
                    sw.WriteLine();
                    sw.Write(ex.StackTrace);
                    Console.WriteLine("Please try again.");
                }
                else
                {
                    throw new FileNotFoundException(filePath + "not found, ex.");
                }
            }
        }

        catch (Exception except)
        {
            Console.WriteLine("Current exception = {0}", except.GetType().Name);
            if (except.InnerException != null)
            {
                Console.WriteLine("Inner exception = {0}", except.InnerException.GetType().Name);
            }
        }
    }

}
/*


finally
{
    if (streamReader != null)
    {
        streamReader.Close();
    }
}
*/
