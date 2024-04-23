using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public enum AccountType
    {
        Investment_Account,
        Savings_Account,
        Current_Account
    }
    internal class Bank_Account
    {
        private double balance;
        private AccountType type;
        public string name;
        private Guid Id;

        public Bank_Account(double balance, Guid Id, AccountType type, string name)
        {
            this.balance = balance;
            this .Id = Guid.NewGuid();
            this.type = type;
            this.name = name;
        }

        public virtual void deposit(double value)
        {
            this.balance+= value;
            Console.WriteLine("Deposit made succesfully. Actual balance:" +  this.balance);
        }

        public virtual void withdraw(double value)
        {
            if (value <= balance)
            {
                balance -= value;
                Console.WriteLine("Withdrawal made succesfully. Actual balance:" + this.balance);
            }
            else
            {
                Console.WriteLine("Insuficient funds.");
            }

        }

        


        class Investment_Account : Bank_Account
        {
            private int withdrawalDate;

            public Investment_Account(double balance, Guid Id, AccountType type, string name, int withdrawalDate)
                : base(balance,Id, type, name)
            {
                this.withdrawalDate = withdrawalDate;

                Console.WriteLine("Account created succesfully.");
                Console.WriteLine("Id" + this.Id);
                Console.WriteLine("Name: " + this.name);
                Console.WriteLine("Balance: " + this.balance);
                Console.WriteLine("Type: " + this.type);
                Console.WriteLine("Withdrawal date: " + this.withdrawalDate);
            }

            public override void withdraw(double value)
            {
                int dateNow = DateTime.Now.Day;

                if (dateNow == withdrawalDate)
                {
                    base.withdraw(value);
                }

                else
                {
                    Console.WriteLine("Withdrawal is not alloud until choose date.");
                }
                
            }

        }
        class Savings_Account : Bank_Account
        {
           public Savings_Account(double balance, Guid Id, AccountType type, string name)
                : base(balance, Id, type, name)
            {
                Console.WriteLine("Account created succesfully.");
                Console.WriteLine("Id" + this.Id);
                Console.WriteLine("Name: " + this.name);
                Console.WriteLine("Balance: " + this.balance);
                Console.WriteLine("Type: " + this.type);
            }

            public override void deposit(double value)
            {
                balance = (balance + value) * (1 + 0.5);

                Console.WriteLine("Deposit made succesfully. Actual balance:" + this.balance);
            }
        }
        class Current_Account : Bank_Account
        {
            private double specialLimit;

            public Current_Account(double balance, Guid Id, AccountType type, string name, double specialLimit)
                : base(balance, Id, type, name)
            {
                this.specialLimit = specialLimit;

                Console.WriteLine("Account created succesfully.");
                Console.WriteLine("Id" + this.Id);
                Console.WriteLine("Name: " + this.name);
                Console.WriteLine("Balance: " + this.balance);
                Console.WriteLine("Type: " + this.type);
                Console.WriteLine("Special Limit: " + this.specialLimit);
            }

            public override void withdraw(double value)
            {
                double dif = balance - value;

                if( dif <= 0)
                {
                    if(dif * -1 <= specialLimit)
                    {
                        balance = 0;
                        specialLimit -= dif * -1;
                        Console.WriteLine("Withdrawal made succesfully. Actual special limit balance:"
                            + this.specialLimit);
                    }

                    else
                    {
                        Console.WriteLine("Insuficient funds.");
                    }
                }

                else
                {
                    base.withdraw(value);
                }
            }

            

        }
    }
}
