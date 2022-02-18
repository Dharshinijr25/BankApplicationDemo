using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplicationDemo
{
    public class AmountExceedException : Exception
    {
        public AmountExceedException() : base()
        {
            Console.WriteLine("Amount Limit Has Exceeded");
        }
    }
    class Emplyee
    {
        public String EmpId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string AccountType
        {
            get; set;
        }
        public int Amount
        {
            get; set;
        }

        public int AmtEnable
        {
            get; set;
        }
        public int AmtTrans
        {
            get; set;
        }
    }
    class DelegateClass
    {
        public void SavingAMT()
        {
            Console.WriteLine("Your AMT Option of Savings Account has been Enabled\n Note : 500 Rs will be deduct if your Daily 3 Transaction limit Exceeds ");
        }
        public void CurrentAMT()
        {
            Console.WriteLine("Your AMT Option of Current Account has been Enabled \n Note : 500 Rs will be deduct if your Daily 3 Transaction limit Exceeds ");
        }
        public void ChildCareAMT()
        {
            Console.WriteLine("Your AMT Option of ChildCare Account has been Enabled \n Note : 500 Rs will be deduct if your Daily 3 Transaction limit Exceeds ");
        }
        public int Amount(int AvailBal, int TransCount)
        {
            int Val = 0;

            return Val;

        }
    }
    class Program
    {
        public delegate void AMTDeletegate();
        static void Main(string[] args)
        {
            int choice, amount;
            int n = 0;
            Emplyee emp = new Emplyee();
            DelegateClass dc = new DelegateClass();
            List<Emplyee> em = new List<Emplyee>();

            AMTDeletegate ad = new AMTDeletegate(dc.SavingAMT);
            string filepath = @"D:\\First.txt";
            try
            {
                if (!File.Exists(filepath))
                    {
                    File.Create(filepath);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                    Console.WriteLine("Welcome Axis Bank");
        CreateAccount:
            while (n == 0)
            {
                Console.WriteLine("Please select the below option to Open the A/C");
                Console.WriteLine(" 1. Savings A/C \n 2. Current A/C \n 3. ChildCare A/C ");
                Console.WriteLine("-------------------------------------------------");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        emp = new Emplyee();
                        emp.AccountType = "Savings A/C";
                        Console.WriteLine("Your Savings A/C has been Created Suceessfully");
                        Console.WriteLine("Daily Limit for the Saving A/C is 100000");
                        Console.WriteLine("Enter Emplyee Details :");
                        Console.WriteLine("Emp Id:");
                        emp.EmpId = Console.ReadLine();
                        Console.WriteLine("Emp Name:");
                        emp.Name = Console.ReadLine();
                        Console.WriteLine("Emp Address:");
                        emp.Address = Console.ReadLine();
                        Console.WriteLine("Enter the Amount to Deposite");
                        amount = Convert.ToInt32(Console.ReadLine());
                        if (amount > 100000)
                        {
                            emp.Amount = 0;
                            throw new AmountExceedException();
                            //Console.WriteLine("Amount Exceeded");
                        }
                        else
                        {
                            emp.Amount = amount;
                            Console.WriteLine(amount + " has deposited\n");

                        }
                        Console.WriteLine("Press 1 for Enable the ATM option");
                        int Option = Convert.ToInt32(Console.ReadLine());
                        if (Option == 1)
                        {
                            ad = new AMTDeletegate(dc.SavingAMT);
                            ad();

                        }


                        break;
                    case 2:
                        emp = new Emplyee();
                        emp.AccountType = "Current A/C";
                        Console.WriteLine("You have Sucessfully Created the Current A/C");
                        Console.WriteLine("Daily Limit for the Saving A/c is 200000");
                        Console.WriteLine("Enter Emplyee Details :");
                        Console.WriteLine("Emp Id:");
                        
                        emp.EmpId = Console.ReadLine();
                        Console.WriteLine("Emp Name:");
                        emp.Name = Console.ReadLine();
                        Console.WriteLine("Emp Address:");
                        emp.Address = Console.ReadLine();
                        Console.WriteLine("Please Enter the Deposite Amount");
                        amount = Convert.ToInt32(Console.ReadLine());
                        if (amount > 200000)
                        {
                            emp.Amount = 0;
                            //throw new AmountExceedException();
                            Console.WriteLine("Amount Exceeded");
                        }
                        else
                        {
                            emp.Amount = amount;
                            Console.WriteLine(amount + " has deposited\n");
                            Console.WriteLine("Press 1 for Enable the ATM option");
                            Option = Convert.ToInt32(Console.ReadLine());
                            if (Option == 1)
                            {
                                ad += new AMTDeletegate(dc.CurrentAMT);
                                ad();
                            }
                        }
                        break;
                    case 3:
                        emp = new Emplyee();
                        emp.AccountType = "Child Care A/C";
                        Console.WriteLine("You have Sucessfully Created the Savings A/C");
                        Console.WriteLine("Daily Limit for the Saving A/c is 50000 ");
                        Console.WriteLine("Enter Emplyee Details :");
                        Console.WriteLine("Emp Id:");
                        
                        emp.EmpId = Console.ReadLine();
                        Console.WriteLine("Emp Name:");
                        emp.Name = Console.ReadLine();
                        Console.WriteLine("Emp Address:");
                        emp.Address = Console.ReadLine();
                        Console.WriteLine("Please Enter the Deposite Amount");
                        amount = Convert.ToInt32(Console.ReadLine());
                        if (amount > 50000)
                        {
                            emp.Amount = 0;
                            throw new AmountExceedException();
                            //Console.WriteLine("Amount Exceeded");
                        }
                        else
                        {
                            emp.Amount = amount;
                            Console.WriteLine(amount + " has deposited\n");
                            Console.WriteLine("Press 1 for Enable the ATM option");
                            Option = Convert.ToInt32(Console.ReadLine());
                            if (Option == 1)
                            {
                                ad += new AMTDeletegate(dc.ChildCareAMT);
                                ad();
                            }
                        }
                        break;
                    default:
                        emp.AccountType = "NA";
                        emp.Amount = -1;
                        Console.WriteLine("you have not select the A/C");
                        break;
                }
                if (choice >= 1 && choice <= 3)
                {
                    em.Add(emp);
                }

                //Console.WriteLine("Do You want to Store the this Emplyee Details? Press 1");
                //int Save = Convert.ToInt32(Console.ReadLine());
                if (choice>=1 && choice<=3)
                {
                    try
                    {

                        using (StreamWriter sw = File.AppendText(filepath))
                        {
                            sw.WriteLine(Environment.NewLine + emp.EmpId + "\t" + emp.Name + "\t" + emp.Address + "\t" + emp.AccountType + "\t" + emp.Amount + "\n");
                            sw.Close();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (choice >= 1 && choice <= 3)
                {
                    Console.WriteLine("\nEmpId \t Name \t\t Address \t AccountType \t Amount");
                    foreach (Emplyee e in em)
                    {
                        Console.WriteLine(e.EmpId + "\t" + e.Name + "\t" + e.Address + "\t" + e.AccountType + "\t" + e.Amount + "\n");
                    }
                }
                Console.WriteLine("Do you want to create new Account? Press 1");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    n = 0;
                    goto CreateAccount;

                }
                else
                {
                    n = 1;
                }

                Console.ReadKey();
            }



        }
    }
}
