using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeShop shop = new CoffeShop("Tesha's");
            DL.ReadItemsfromFile(shop);
            UI.WelcomeScreen(shop.Name);
            Console.ReadKey();
            int choice = 0;
            while(choice!=9)
            {
                Console.Clear();
                choice = UI.Options();
                if (choice == 1)
                {
                    MenueItem menu = UI.AddItemMenu();
                    shop.AddMeuItem(menu);
                    DL.StoreInFileItem(menu);
                }
                else if (choice == 2)
                {
                    List<MenueItem> list = shop.ReturnMenuList();
                    string cheapestproduct = DL.cheapestProduct(list);
                    UI.ViewCheapestProduct(cheapestproduct);
                }
                else if (choice == 3)
                {
                    List<string> list = shop.ReturnDrinkList();
                    UI.ViewList(list);

                }
                else if (choice == 4)
                {
                    List<string> list = shop.ReturnFoodList();
                    UI.ViewList(list);
                }
                else if (choice == 5)
                {
                    string name = UI.AddOrderinput();
                    bool isTrue = shop.AddOrder(name);
                    if (isTrue)
                    {
                        Console.WriteLine("Order added");
                    }
                    else
                    {
                        Console.WriteLine("this item is currently unAvailable!");
                    }
                }
                else if (choice == 6)
                {
                    List<string> order = shop.OrderList();
                    if (order.Count > 0)
                    {
                        for (int x = 0; x < order.Count; x++)
                        {
                            UI.FulFillOrder(order[x]);
                            //Console.WriteLine(order[x] + " is ready");
                        }
                    }
                    //else
                    //    Console.WriteLine("All orders have been fulfilled!");
                }
                else if(choice==7)
                {
                    List<string> order = shop.OrderList();
                    UI.ListOrders(order);
                }
                else if(choice==8)
                {
                    int amount = shop.Amount();
                    UI.PaybleAmount(amount);
                }
                Console.ReadKey();
            }
        }
    }
}
