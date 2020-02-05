using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            IMoneyOperationHandler verifyHandler = new VerifyAccountHandler();
            IMoneyOperationHandler checkHandler = new CheckMoneyHandler();
            IMoneyOperationHandler loggerHandler = new MoneyOperationLoggerHandler();
            IMoneyOperationHandler recieveHandler = new RecieveMoneyHandler();

            verifyHandler.Next = checkHandler;
            checkHandler.Next = loggerHandler;
            loggerHandler.Next = recieveHandler;

            string cardNumber;
            int pin;
            decimal money;

            Console.WriteLine("Enter card number: ");
            cardNumber = Console.ReadLine();
            Console.WriteLine("Enter pin: ");
            pin = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount: ");
            money = decimal.Parse(Console.ReadLine());

            verifyHandler.Handle(cardNumber, pin, money);
        }
    }

    interface IMoneyOperationHandler
    {
        IMoneyOperationHandler Next { get; set; }
        void Handle(string cardNumber, int pin, decimal money);
    }

    class VerifyAccountHandler : IMoneyOperationHandler
    {
        public IMoneyOperationHandler Next { get; set; }

        public void Handle(string cardNumber, int pin, decimal money)
        {
            if (AccountDatabase.Accounts.Any(x => x.CardNumber == cardNumber && x.Pin == pin))
                Next.Handle(cardNumber, pin, money);
            else
                Console.WriteLine("Error! Invalid account!");
        }
    }

    class CheckMoneyHandler : IMoneyOperationHandler
    {
        public IMoneyOperationHandler Next { get; set; }

        public void Handle(string cardNumber, int pin, decimal money)
        {
            var account = AccountDatabase.Accounts.FirstOrDefault(x => x.CardNumber == cardNumber && x.Pin == pin);
            if (account.Money >= money)
                Next.Handle(cardNumber, pin, money);
            else
                Console.WriteLine("Error! Not enough money!");
        }
    }

    class MoneyOperationLoggerHandler : IMoneyOperationHandler
    {
        public IMoneyOperationHandler Next { get; set; }

        public void Handle(string cardNumber, int pin, decimal money)
        {
            Console.WriteLine($"[{DateTime.Now}] - Card number {cardNumber} - {money}");
            Next.Handle(cardNumber, pin, money);
        }
    }

    class RecieveMoneyHandler : IMoneyOperationHandler
    {
        public IMoneyOperationHandler Next { get; set; }

        public void Handle(string cardNumber, int pin, decimal money)
        {
            var account = AccountDatabase.Accounts.FirstOrDefault(x => x.CardNumber == cardNumber && x.Pin == pin);
            account.Money -= money;
        }
    }

    class Account
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public decimal Money { get; set; }
    }

    static class AccountDatabase
    {
        public static List<Account> Accounts;

        static AccountDatabase()
        {
            Accounts = new List<Account>
            {
                new Account { FullName = "Gleb Skripnikov", CardNumber = "1111", Pin = 1111, Money = 1000 },
                new Account { FullName = "Test Test", CardNumber = "2222", Pin = 2222, Money = 2000 }
            };
        }
    }
}
