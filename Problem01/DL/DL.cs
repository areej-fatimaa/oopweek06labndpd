using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Problem01
{
    class DL
    {
        public static List<CoffeShop> shops = new List<CoffeShop>();
        public static void StoreInFileItem(MenueItem menu)
        {
            string path = "D:\\oopweek06lab\\Problem01\\ItemList.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(menu.Name + "," + menu.Type+","+menu.Price);
            Console.ReadKey();
            file.Flush();
            file.Close();
        }
        public static void ReadItemsfromFile(CoffeShop shop)
        {
            string path = "D:\\oopweek06lab\\Problem01\\ItemList.txt";

            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Console.ReadKey();
                    string Name = record.Split(',')[0];
                    string type = record.Split(',')[1];
                    int price =int.Parse( record.Split(',')[2]);
                    MenueItem s1 = new MenueItem(Name,type,price);
                    shop.AddMeuItem(s1);
                }
                fileVariable.Close();
            }
        }
        public static string cheapestProduct(List<MenueItem> list)
        {
                MenueItem cheapestProduct = list.OrderBy(p=>p.Price).FirstOrDefault();
            return cheapestProduct.Name;
        }
          
    }
}
