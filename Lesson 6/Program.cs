using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Cart
    {
        public string BankName { get; set; }
        public string PAN { get; set; }//16
        public string PIN { get; set; }//4
        public string CVC { get; set; }//3
        public string Expire_date { get; set; }//etibarliliq muddeti
        public decimal Balance { get; set; }
        public string History { get; set; }

        public Cart(string BankName,string Pan,string Pin,string CVC,string Expire_date,decimal Balance)
        {
            this.BankName = BankName;
            this.PAN = Pan;
            this.PIN = Pin;
            this.CVC = CVC;
            this.Expire_date = Expire_date;
            this.Balance = Balance;
            Start_work();
        }
        public void Add_cart()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write(" Bankname daxil edin : ");
            string new_bankname = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" Balansi daxil edin : ");
            string new_Pan = Console.ReadLine();

        }
        public override string ToString()
        {
            return $@" Bankname : {this.BankName}
 PAN : {this.PAN}
 PIN : {this.PIN}
 CVC : {this.CVC}
 Expire Date : {this.Expire_date} 
 Balance : {this.Balance}";
        }

        public void Start_work()
        {
            string new_str = $"{DateTime.Now} Tarixinde kart istifadeye acildi .       ";
            History += new_str;
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Cart user_Card;

        public User(string new_name,string new_Surname,Cart new_card)
        {
            this.Name = new_name;
            this.Surname = new_Surname;
            this.user_Card = new_card;
        }
        public override string ToString()
        {
            return $@" Name : {this.Name}
 Surname : {Surname}
 {user_Card.ToString()}";
        }

    }

    class Data_Base
    {
        public User[] user_massiv =new User[1000];
        public int Users_count=0;
        public void Add_User(User new_user)
        {
            user_massiv[Users_count++] = new_user;
        }
        public void Show_all()
        {
            for (int i = 0; i < Users_count; i++)
            {
                Console.WriteLine(user_massiv[i].ToString());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        
    }
    class ATM
    {
        Data_Base data_Base = new Data_Base();
        public void Start()
        {

            Cart cart_1 = new Cart("TimaBank", "0000000000000001", "0001", "001", "25/05/2025", 10000);
            User user_1 = new User("Teymur", "Novruzov", cart_1);

            Cart cart_2 = new Cart("TimaBank", "0000000000000002", "0002", "002", "25/05/2025", 10000);
            User user_2 = new User("Tural", "Novruzov", cart_2);

            Cart cart_3 = new Cart("TimaBank", "0000000000000003", "0003", "003", "25/05/2025", 10000);
            User user_3 = new User("Telman", "Novruzzade", cart_3);

            Cart cart_4 = new Cart("TimaBank", "0000000000000004", "0004", "004", "25/05/2025", 10000);
            User user_4 = new User("Tehmasib", "Novruzlu", cart_4);

            Cart cart_5 = new Cart("TimaBank", "0000000000000005", "0005", "005", "25/05/2025", 10000);
            User user_5 = new User("Elmira", "Hesenova", cart_5);

            data_Base.Add_User(user_1);
            data_Base.Add_User(user_2);
            data_Base.Add_User(user_3);
            data_Base.Add_User(user_4);
            data_Base.Add_User(user_5);
 
            Step_one();
        }

        public void Step_one()
        {
            
            Console.WindowHeight = 25;
            Console.WindowWidth = 67;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($@"                    TIMA BANK-a XOŞ GELMİŞSİNİZ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($@"     PIN daxil edin : ");
            string first_step_pin = Console.ReadLine();
            for (int i = 0; i < data_Base.Users_count; i++)
            {
                if (data_Base.user_massiv[i].user_Card.PIN == first_step_pin)
                {
                    data_Base.user_massiv[i].user_Card.History += $@"
{DateTime.Now} Tarixinde karta daxil olundu";
                    Step_second(data_Base.user_massiv[i]);
                }
            }
            wrong_PIN_ex ex = new wrong_PIN_ex();
            Console.WriteLine(ex.Message);
            Thread.Sleep(2000);
            Step_one();
        }
        public void Step_second(User second_step_user)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  [ 0 ] Geriye");
            Console.WriteLine();
            Console.WriteLine("  [ 1 ] Balans");
            Console.WriteLine();
            Console.WriteLine("  [ 2 ] Negd pul");
            Console.WriteLine();
            Console.WriteLine("  [ 3 ] Kartdan karta kocurme");
            Console.WriteLine();
            Console.WriteLine("  [ 4 ] Tarixce");
            Console.WriteLine();
            Console.Write(" Daxil edin : ");
            string second_step_choice = Console.ReadLine();
            if (second_step_choice == "0")
            {
                Step_one();
            }
            else if (second_step_choice == "1")
            {
                Step_third_Balance(second_step_user);
            }
            else if (second_step_choice == "2")
            {
                Step_fourth_Money(second_step_user);
            }
            else if (second_step_choice == "3")
            {
                Transfer_kart_money_1(second_step_user);
            }
            else if (second_step_choice == "4")
            {
                finish_funk(second_step_user);
            }
            else
            {
                second_step_choice = string.Empty;
                seconWrongChoice ex = new seconWrongChoice();
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                Step_second(second_step_user);
            }
        }
        public void finish_funk(User second_step_user)
        {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine( second_step_user.user_Card.History );
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" [ 0 ] Geriye ");
                Console.WriteLine();
                Console.Write(" -->");
                string choice_ = Console.ReadLine();
                if (choice_ == "0")
                {
                    Step_second(second_step_user);
                }
                else
                {
                    wrong_balance_choice ex = new wrong_balance_choice();
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    finish_funk(second_step_user);

                }
        }
        public void Transfer_kart_money_1(User user)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Kocurme etmek istediyiniz kartin CVC -sini daxil edin");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" --> ");
            string transfer_str_check = Console.ReadLine();
            for (int i = 0; i < data_Base.Users_count; i++)
            {
                if (data_Base.user_massiv[i].user_Card.CVC ==transfer_str_check )
                {
                    Transfer_kart_money_2(user,data_Base.user_massiv[i]);
                }
            }
            wrong_balance_choice ex = new wrong_balance_choice();
            Console.WriteLine(ex.Message);
            Thread.Sleep(2000);
            Transfer_kart_money_1(user);
        }
        public void Transfer_kart_money_2(User user,User user2)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Kocurmek istediyiniz mebleqi daxil edin ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" --> ");
            string money_str = Console.ReadLine();
            int money_int = 0;
            bool check=int.TryParse(money_str,out money_int);
            if (money_int > user.user_Card.Balance)
            {
                notHaveMonetInACArd ex_1 = new notHaveMonetInACArd();
                Console.WriteLine(ex_1.Message);
                Thread.Sleep(2000);
                Transfer_kart_money_2(user,user2);
            }
            else if (check == false)
            {
                wrong_balance_choice ex_2 = new wrong_balance_choice();
                Console.WriteLine(ex_2.Message);
                Thread.Sleep(2000);
                Transfer_kart_money_2(user,user2);
            }
            else
            {
                user.user_Card.Balance -= money_int;
                user2.user_Card.Balance += money_int;
                user.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan {user2.user_Card.CVC} -CVC li karta {money_int}m kocuruldu";
                user2.user_Card.History += $@"
{DateTime.Now} Tarixinde {user.user_Card.CVC} -CVC li kartdan bu karta {money_int}m kocuruldu";
                Finish();
            }
            Step_second(user);
        }
        public void Step_third_Balance(User third_step_user)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($@"     Balansiniz : {third_step_user.user_Card.Balance}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     [ 0 ] Geriye ");
            Console.WriteLine();
            Console.Write("     Seciminizi daxil edin : ");
            string balance_choice_third = Console.ReadLine();
            if (balance_choice_third == "0")
            {
                Step_second(third_step_user);
            }
            else
            {
                wrong_balance_choice ex3 = new wrong_balance_choice();
                Console.WriteLine(ex3.Message);
                Thread.Sleep(2000);
                Step_third_Balance(third_step_user);
            }
        }
        public void Step_fourth_Money(User step_four_money)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($@" [1]  10m ");
            Console.WriteLine($@" [2]  20m ");
            Console.WriteLine($@" [3]  50m ");
            Console.WriteLine($@" [4]  100m ");
            Console.WriteLine($@" [5]  Diger ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" Seciminizi daxil edin : ");
            string fourth_step_choice = Console.ReadLine();
            if (fourth_step_choice == "1")
            {
                step_four_money.user_Card.Balance -= 10;
                step_four_money.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan 10m cixarildi";
                Finish();
            }
            else if (fourth_step_choice == "2")
            {
                step_four_money.user_Card.Balance -= 20;
                step_four_money.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan 20m cixarildi";
                Finish();
            } 
            else if (fourth_step_choice == "3")
            {
                step_four_money.user_Card.Balance -= 50;
                step_four_money.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan 50m cixarildi";
                Finish();
            } 
            else if (fourth_step_choice == "4")
            {
                step_four_money.user_Card.Balance -= 100;
                step_four_money.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan 100m cixarildi";
                Finish();
            } 
            else if (fourth_step_choice == "5")
            {
                Try_balance(step_four_money);
            }
            else
            {
                wrong_balance_choice ex = new wrong_balance_choice();
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                Step_fourth_Money(step_four_money);
            }
            Step_second(step_four_money);
        }
        public void Try_balance(User user)
        {
            wrong_balance_choice wrong_choice = new wrong_balance_choice();
            notHaveMonetInACArd not_money_ex = new notHaveMonetInACArd();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Sizin Balansiniz : "+user.user_Card.Balance);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($@" Meblegi daxil edin : ");
            string try_balance_str = Console.ReadLine();
            int new_money=0;
            bool check_int = int.TryParse(try_balance_str, out new_money);
            if (check_int == false)
            {
                Console.WriteLine(wrong_choice.Message);
                Thread.Sleep(2000);
                Try_balance(user);
            }
            else if (new_money > user.user_Card.Balance)
            {
                Console.WriteLine(not_money_ex.Message);
                Thread.Sleep(2000);
                Try_balance(user);
            }
            else
            {
                user.user_Card.Balance -= new_money;
                user.user_Card.History += $@"
{DateTime.Now} Tarixinde kartdan {new_money}m cixarildi";
                Finish();
            }
            Step_second(user);
        }
        public void Finish()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Emeliyyat ugurla basa catdi , TESEKKURLER ");
            Thread.Sleep(2000);
        }
    } 

    class notHaveMonetInACArd : Exception
    {
        public notHaveMonetInACArd() : base(string.Format($@"     
     
     Daxil etdiyiniz mebleq balansda yoxdur ")) { }
    }

    class wrong_balance_choice : Exception
    {
        public wrong_balance_choice() : base(string.Format($@"     
     
     Yalnis Secim ")) { }
    }

    class wrong_PIN_ex : Exception
    {
        public wrong_PIN_ex() : base(string.Format($@"     

     Yalnis PIN "))
        {

        }
        public wrong_PIN_ex(string PIN):base(string.Format($@"     

      Yalnis PIN ({0})",PIN))
        {

        }
    }

    class seconWrongChoice : Exception
    {
        public seconWrongChoice() : base(string.Format($@"     
     
     Yalnis secim ")) { }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.Start();
        }
    }
}
