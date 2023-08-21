using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    public class MenueItem
    {
        public string Name;
        public string Type;
        public int Price;
        public MenueItem(string name,string type,int price)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
    }
}
