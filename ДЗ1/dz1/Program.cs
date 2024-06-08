using System;
using System.Runtime.InteropServices;

namespace dz1
{
    interface INotifyer
    {
        void Notify(decimal balance);
    }

    class SMSLowBalanceNotyfyer : INotifyer
    {
        private string _phone;
        private decimal _lowBalanceValue;
        public SMSLowBalanceNotyfyer(string phone, decimal lowBalanceValue)
        {
            _phone = phone;
            _lowBalanceValue = lowBalanceValue;
        }
        public void Notify(decimal balance)
        {
            if (balance < _lowBalanceValue) Console.WriteLine($"На номер {_phone} отправлено СМС с текстом: \"Ваш баланс составляет {balance}\"");
        }
    }

    class EMailBalanceChangedNotifyer : INotifyer
    {
        private string _email;

        public EMailBalanceChangedNotifyer(string email)
        {
            _email = email;
        }
        public void Notify(decimal balance)
        {
            Console.WriteLine($"На email \"{_email}\" отправлено письмо с текстом: \"Ваш баланс составляет: {balance}.\"");
        }
    }

    class Account
    {
        private decimal _balance;
        private List<INotifyer> _notifyers = new();

        public Account()
        {
            _balance = 0;
        }

        public Account(decimal balance)
        {
            _balance = balance;
        }

        public void AddNotifyer(INotifyer notifyer)
        {
            _notifyers.Add(notifyer);      
        }

        public void Notification()
        {
            foreach (INotifyer notifyer in _notifyers) notifyer.Notify(_balance);
        }
   
        public void ChangeBalance(decimal balance)
        {
            _balance = balance;
        }
        public decimal Balance()
        {
            return _balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        Account account = new(100); //создание банковского аккаунта с балансом 100 рублей//

        while (true)
            {
                Console.Clear();
                Console.WriteLine("\t== Терминал управления аккаунтом ==\n");            
                Console.WriteLine("1 - Подключить уведомления.");
                Console.WriteLine("2 - Отправить уведомления.");
                Console.WriteLine("3 - Поменять баланс.");
                Console.WriteLine("4 - Вывести баланс на экран.");
                Console.WriteLine("5 - Выход");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите номер телефона: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Введите баланс счета, при котором на телефон по СМС будет приходить уведомление: ");
                        decimal lowBalance = decimal.Parse(Console.ReadLine());
                        account.AddNotifyer(new SMSLowBalanceNotyfyer(number, lowBalance));
                        Console.WriteLine("Введите email: ");
                        string email = Console.ReadLine();  
                        account.AddNotifyer(new EMailBalanceChangedNotifyer(email));
                        break;
                    case 2:
                        Console.Clear();
                        account.Notification();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите новый баланс:");
                        decimal newBalance = decimal.Parse(Console.ReadLine());
                        account.ChangeBalance(newBalance);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"На счету: {account.Balance()} ");
                        Console.ReadLine();
                        break;
                    case 5:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введено неправильное значение. Повторите.");                        
                        break;
                };
            }
        }
    }
}