using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UamsWithLayers.UI
{
    class StudentUI
    {
        public static void PrintStudent()
        {
            foreach(BL.Student s in DL.StudentDL.studentList)
            {
                if(s.regDegree!=null)
                {
                    Console.WriteLine(s.Name+" got admission in"+s.regDegree.Name);
                }
                else
                {
                    Console.WriteLine(s.Name+" did not get admission");
                }
            }
        }
        public static void ViewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tECAT\tAge");
            foreach( BL.Student s in DL.StudentDL.studentList)
            {
                if(s.regDegree!=null)
                {
                    if(degName==s.regDegree.Name)
                    {
                        Console.WriteLine(s.Name+"\t"+s.FscMarks+"\t"+s.EcatMarks+"\t"+s.Age);
                    }
                }
            }
        }
        public static void ViewRegisteredStudent()
        {
            Console.WriteLine("Name\tFSC\tECAT\tAge");
            foreach (BL.Student s in DL.StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                        Console.WriteLine(s.Name + "\t" + s.FscMarks + "\t" + s.EcatMarks + "\t"+s.Age);
                }
            }
        }
        public static BL.Student InputAddStudent()
        {
            List<BL.DegreeProgram> preferences = new List<BL.DegreeProgram>();
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter FSC marks:");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ECAT marks:");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Available degree programs");
            UI.DegreeProgramUI.ViewProgram();
            Console.WriteLine("How many preferences you want to enter");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach(BL.DegreeProgram dp in DL.DegreeProgramDL.programList)
                {
                    if(degName==dp.Name&&!(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid degree name");
                }
            }
           BL. Student stu = new BL.Student(name, age, fscMarks, ecatMarks, preferences);
            return stu;
        }
        public static void CalculateFeeForAll()
        {
            foreach(BL.Student s in DL.StudentDL.studentList)
            {
                if(s.regDegree!=null)
                {
                    Console.WriteLine(s.Name+" has "+s.CalculateFee()+" Fees ");
                }
            }
        }
    }
}
