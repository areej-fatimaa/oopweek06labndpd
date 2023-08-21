using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class CoffeShop
    {
        public string Name;
        public List<MenueItem> menulist = new List<MenueItem>();
        public List<string> orders = new List<string>();
        public int paybleamount = 0;
        public CoffeShop(string name)
        {
            this.Name = name;
        }
        public void AddMeuItem(MenueItem menu)
        {
            menulist.Add(menu);
        }
        public List<MenueItem>  ReturnMenuList()
        {
            return menulist;
        }
        public List<string> ReturnDrinkList()
        {
            List<string> drinks = new List<string>();
            foreach(MenueItem menu in menulist)
            {
                if(menu.Type=="drink")
                {
                    drinks.Add(menu.Name);
                }
            }
            return drinks;
        }
        public List<string> ReturnFoodList()
        {
            List<string> food = new List<string>();
            foreach (MenueItem menu in menulist)
            {
                if (menu.Type == "food")
                {
                    food.Add(menu.Name);
                }
            }
            return food;
        }
        public  bool AddOrder(string name)
        {
            foreach(MenueItem item in menulist)
            {
                if (item.Name == name)
                {
                    orders.Add(item.Name);
                    paybleamount = paybleamount + item.Price;
                    return true;
                }
            }
            return false;
        }
        public List<string> OrderList()
        {
            return orders;
        }
        public int Amount()
        {
            return paybleamount;
        }
    }
}
