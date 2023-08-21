using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UamsWithLayers.UI
{
    class MenuUI
    {
        public static void Header()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                      UMAS                           ");
            Console.WriteLine("*****************************************************");
        }
        public static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static int Menu()
        {
            Console.WriteLine("1.Add student");
            Console.WriteLine("2.Add degree program");
            Console.WriteLine("3.Generate merit");
            Console.WriteLine("4.View registered students");
            Console.WriteLine("5.View students of specific program");
            Console.WriteLine("6.Register subjects for specific student");
            Console.WriteLine("7.Calculate fees for all registered students");
            Console.WriteLine("8.Exit");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
