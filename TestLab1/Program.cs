using System;

namespace TestLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool GoOn = true;
            Account YourMainAccount = new Account(500, 4);
            Account YourBackupAccount = new Account(1000, 5);

            while (GoOn)
            {
                Console.WriteLine($"Du har {YourMainAccount.Balance}kr på huvudkontot och {YourBackupAccount.Balance}kr på ditt reservkonto");
                Console.WriteLine("1. Sätt in pengar");
                Console.WriteLine("2. Ta ut pengar");
                Console.WriteLine("3. För över pengar");
                int input = 0;
                try
                {
                    input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            double insattning = double.Parse(Console.ReadLine());
                            YourMainAccount.Deposit(insattning);
                            break;
                        case 2:
                            double uttag = double.Parse(Console.ReadLine());
                            YourMainAccount.Withdraw(uttag);
                            break;
                        case 3:
                            double overforing = double.Parse(Console.ReadLine());
                            YourMainAccount.Transfer(YourBackupAccount, overforing);
                            break;
                        default:
                            GoOn = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Skriv in en siffra");
                }
            }
        }
    }
}
