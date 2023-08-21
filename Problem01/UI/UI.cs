using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    public class UI
    {
        public static void WelcomeScreen(string name)
        {
            Console.WriteLine("Welcome to"+name+" Coffee Shop");
        }
        public static int Options()
        {
            int choice = 0;
            Console.WriteLine("1.Add a menu item");
            Console.WriteLine("2.Cheapest item in the menu");
            Console.WriteLine("3.View the drinks menu");
            Console.WriteLine("4.View the food's menu");
            Console.WriteLine("5.Add order");
            Console.WriteLine("6.Fulfill order");
            Console.WriteLine("7.View the order's list");
            Console.WriteLine("8.Total payable amount");
            Console.WriteLine("9.Exit");
            Console.WriteLine("Enter your choice:");
            try
            {
               choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input");
            }
            return choice;
        }
        public static MenueItem AddItemMenu()
        {
            int price=0;
            Console.WriteLine("Enter name of item");
            string name = Console.ReadLine();
            Console.WriteLine("Enter type of product");
            string type = Console.ReadLine();
            Console.WriteLine("Enter price of product");
            try
            {
                price = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid price");
            }
            MenueItem menu = new MenueItem(name, type, price);
            return menu;
        }
        public static void ViewCheapestProduct(string cheapestProduct)
        {
            Console.WriteLine(cheapestProduct);
        }
        public static void ViewList(List<string> list)
        {
            foreach(string str in list)
            {
                Console.WriteLine(str);
            }
        }
        public static string AddOrderinput()
        {
            Console.WriteLine("Enter the name of produt");
            string name = Console.ReadLine();
            return name;
        }
        public static void FulFillOrder(string x)
        {
            if(x!=null)
            {
                Console.WriteLine(x+ " is ready");
            }
            else
                Console.WriteLine("All orders have been fulfilled!");
        }
        public static void ListOrders(List<string>list)
        {
            for(int i=0;i<list.Count;i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        public static void PaybleAmount(int amount)
        {
            if (amount > 0)

            {
                Console.WriteLine("Payble amount is" + amount);
            }
            else
            {
                Console.WriteLine("No orders taken");
            }
        }
    }
}
