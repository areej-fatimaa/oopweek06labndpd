using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UamsWithLayers.UI
{
    class SubjectUI
    {
        public static BL.Subject InputAddSubject()
        {
            Console.WriteLine("Enter subject code:");
            string subCode = Console.ReadLine();
            Console.WriteLine("Enter subject type:");
            string subType = Console.ReadLine();
            Console.WriteLine("Subject credit hours:");
            int creditHour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter subject fee:");
            int subFee = int.Parse(Console.ReadLine());
            BL.Subject sub = new BL.Subject(subCode, subType, creditHour, subFee);
            return sub;
        }
        public static void ViewSubject(BL.Student s)
        {
            if(s.regDegree!=null)
            {
                Console.WriteLine("Sub code\t Sub type");
                foreach(BL.Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.subCode+"\t"+sub.subType);
                }
            }
        }
        public static void RegisterSubject(BL.Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register");
            int count = int.Parse(Console.ReadLine());
            for(int i=0;i<count;i++)
            {
                Console.WriteLine("Enter subject code");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(BL.Subject sub in s.regDegree.subjects)
                {
                    if(code==sub.subCode&&!(s.regSubject.Contains(sub)))
                    {
                        if(s.RegStudentSubject(sub))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A student cannot have more than 9 CH");
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Invalid course");
                    i--;
                }
            }
        }
    }
}
