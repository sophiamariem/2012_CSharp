using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankingAccountsTask
{

    class Program
    {
        static void Main(string[] args) //testing the program
        {
            //creating savings accounts and importing personal data
            SavingsAccount savings = new SavingsAccount("Sophia Mina", 119041868, "Grange Lane", 10000);
            SavingsAccount savings1 = new SavingsAccount("Emily James", 109040679, "Berry Lane", 20000);

            //importing data into saving accounts in order to view the results

            //importing data for first savings account
            savings.View();
            savings.Deposit(500, 0);
            savings.ViewDeposit();
            savings.Withdrawal(200, 0);
            savings.ViewWithdrawal();
            savings.Interest(0.5, 0);
            savings.ViewInterest();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //importing data for second savings account
            savings1.View();
            savings1.Deposit(300, 0);
            savings1.ViewDeposit();
            savings1.Withdrawal(5000000, 0);
            savings1.ViewWithdrawal();
            savings1.Interest(0.5, 0);
            savings1.ViewInterest();


            //creating current accounts and importing personal data
            CurrentAccount current = new CurrentAccount("Jane Smith", 875634375, "Grange Lane", 300000);
            CurrentAccount current1 = new CurrentAccount("Sarah Harper", 836492548, "Berry Lane", 700000);


            //importing data for first current account
            current.View();
            current.Deposit(2000, 0);
            current.ViewDeposit();
            current.Withdrawal(800, 0);
            current.ViewWithdrawal();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //importing data for second current account
            current1.View();
            current1.Deposit(900, 0);
            current1.ViewDeposit();
            current1.Withdrawal(427, 0);
            current1.ViewWithdrawal();

            //adding a read line so the program will not shut down immediately and the uer has time to view the results
            Console.ReadLine();

        }
    }
}

namespace BankingAccountsTask
{
    //implementing base class for account actions
    public abstract class BankAccounts
    {

        //declaring variables
        double bal; //balance
        double newbalance; //new balance after deposit and withdrawal
        double intert; //interest

        string uname; //account owner's name
        string uaddr; //account owner's address
        int acnum; //account owner's account number


        //class contructor to initialize class variables
        public BankAccounts(string name, int acNumber, string address, double balance)
        {
            this.uname = name;
            this.acnum = acNumber;
            this.uaddr = address;
            this.bal = balance;

        }


        //new balance method
        public double newbal
        {
            get { return newbalance; }
            set { newbalance = value; }
        }

        //name method
        public string name
        {
            get { return uname; }
            set { uname = value; }
        }

        //acount number method
        public int acNumber
        {
            get { return acnum; }
            set { acnum = value; }
        }

        //address method
        public string address
        {
            get { return uaddr; }
            set { uaddr = value; }
        }

        //adding name and balance to account owner
        public virtual void AccountOwner(string name, double balance)
        {
            this.uname = name;
            this.bal = balance;
        }


        //virtual method for deposit
        public virtual void Deposit(double newbal, double bal)
        {
            this.newbal = bal + newbal;
        }


        //virtual method for withdrawal
        public virtual void Withdrawal(double newbal, double bal)
        {
            this.newbal = bal - newbal;
        }

        //virtual method for interest
        public virtual void Interest(double inter, double bal)
        {
            inter = 0.5;
            this.intert = inter;
            this.newbal = ((bal * inter) + bal);

        }


        //welcoming output which displays acount owner's details
        public virtual void View()
        {
            Console.WriteLine("Hello {0} ! \n Your account number is: {1} \n Your current address is: {2}\n Your current balance is: £{3}\n\n", this.uname, this.acnum, this.uaddr, this.bal);
        }

        //output for deposit details
        public virtual void ViewDeposit()
        {
            Console.WriteLine("{0}. \n You have made a deposit of £{1}. Your current balance now is: £{2} \n\n", this.uname, this.newbal, (this.bal + this.newbal));
        }


        //output for withdrawal details
        public virtual void ViewWithdrawal()
        {
            Console.WriteLine("{0}. \n You have made a withdrawal of £{1}. Your current balance now is: £{2} \n\n", this.uname, this.newbal, (this.bal - this.newbal));
        }

        //output for interest
        public virtual void ViewInterest()
        {
            Console.WriteLine("{0}. \n You have {1}% of interest rate. Your current balance now is: £{2} \n\n", this.uname, this.intert, ((this.bal * this.intert) + this.bal));
        }

    }
}

namespace BankingAccountsTask
{

    //creating new derived class  for savings account by inheriting methods and properties from the bank account's class
    class SavingsAccount : BankAccounts
    {

        //construct for SavingsAccount class
        public SavingsAccount(string name, int acNumber, string address, double balance)
            : base(name, acNumber, address, balance)
        {
        }

        //deposit method for SavingsAccount class
        public void Deposit(double newbal, double balance)
        {
            this.newbal = balance + newbal; //calculation for adding deposit
        }


        //withdrawal method for SavingsAccount class
        public void Withdrawal(double newbal, double bal)
        {
            //calculation for subtracting withdrawal

            if (newbal > bal) //calculation so as to display message when savings account user attempts to withdraw more money than in bank account
            {
                Console.WriteLine("You cannot withdraw more money than your current balance.");
                Console.WriteLine();
                newbal = 0;
            }

        }

    }
}

namespace BankingAccountsTask
{

    //creating new derived class for current account by methods and properties inheriting from the bank account's class
    class CurrentAccount : BankAccounts
    {

        //constructor for CurrentAccount class
        public CurrentAccount(string name, int acNumber, string address, double balance)
            : base(name, acNumber, address, balance)
        { }


        //deposit method for CurrentAccount class
        public void Deposit(double newbal, double balance)
        {
            this.newbal = balance + newbal; //calculation for adding deposit
        }


        //withdrawal method for CurrentAccount class
        public void Withdrawal(double newbal, double bal) //calculation for subtracting withdrawal
        {

            if (this.newbal > bal) //calculation so as to display message when savings account makes an overdraft
            {
                Console.WriteLine("The overdraft comes with a flat charge of £5 each day.");
                Console.WriteLine();

            }
        }

    }

}




