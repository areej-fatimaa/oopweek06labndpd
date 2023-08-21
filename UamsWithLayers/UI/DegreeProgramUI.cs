using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UamsWithLayers.UI
{
    class DegreeProgramUI
    {
        public static BL.DegreeProgram TakeInputForDegree()
        {
            Console.WriteLine("Enter degree name:");
            string degName = Console.ReadLine();
            Console.WriteLine("Enter degree duration:");
            int degreeDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter seats for degree:");
            int degSeats = int.Parse(Console.ReadLine());

            BL.DegreeProgram program = new BL.DegreeProgram(degName, degreeDuration, degSeats);
            Console.WriteLine("How many subjects you want to enter");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
               BL. Subject s=SubjectUI.InputAddSubject();
                if(program.AddSubject(s))
                {
                    if(!(DL.SubjectDL.subjectList.Contains(s)))
                    {
                        DL.SubjectDL.AddSubjectIntoList(s);
                        DL.SubjectDL.StoreInFile("subject.txt", s);
                    }
                    Console.WriteLine("Subject added successfully");
                }
                else
                {
                    Console.WriteLine("Subject not added");
                    Console.WriteLine("20credit hour limit exceeded");
                    i--;
                }
            }
            return program;
        }
        public static void ViewProgram()
        {
            foreach(BL.DegreeProgram dp in DL.DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.Name);
            }
        }
    }
}
