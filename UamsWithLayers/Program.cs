
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UamsWithLayers
{
    class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            if(DL.SubjectDL.ReadFromFile(subjectPath))
            {
                Console.WriteLine("Subject data loaded successfully");
            }
            if(DL.DegreeProgramDL.ReadFromFile(degreePath))
            {
                Console.WriteLine("Degreeprogram data loaded successfully");
            }
            if(DL.StudentDL.ReadFromFile(studentPath))
            {
                Console.WriteLine("Student data loaded successfully");
            }
            int option = 0;
            while(option!=8)
            {
                option =UI.MenuUI.Menu();
                 UI.MenuUI.ClearScreen();
                if (option == 1)
                {
                    if (DL.DegreeProgramDL.programList.Count > 0)
                    {
                        BL.Student s = UI.StudentUI.InputAddStudent();
                        DL.StudentDL.AddIntoStudentList(s);
                        DL.StudentDL.StoreIntoFile(studentPath, s);
                    }
                }
                else if (option == 2)
                {
                    BL.DegreeProgram d = UI.DegreeProgramUI.TakeInputForDegree();
                    DL.DegreeProgramDL.AddIntoDegreeList(d);
                    DL.DegreeProgramDL.StoreIntoFile(degreePath, d);
                }
                else if (option == 3)
                {
                    List<BL.Student> sortedList = new List<BL.Student>();
                    sortedList = DL.StudentDL.SortStudentByMerit();
                    DL.StudentDL.GiveAdmission(sortedList);
                    UI.StudentUI.PrintStudent();
                }
                else if (option == 4)
                {
                    UI.StudentUI.ViewRegisteredStudent();
                }
                else if (option == 5)
                {
                    Console.WriteLine("Enter degree name");
                    string degreeName = Console.ReadLine();
                    UI.StudentUI.ViewStudentInDegree(degreeName);
                }
                else if (option == 6)
                {
                    Console.WriteLine("Enter student name");
                    string name = Console.ReadLine();
                    BL.Student s = DL.StudentDL.StudentPresent(name);
                    if (s != null)
                    {
                        UI.SubjectUI.ViewSubject(s);
                        UI.SubjectUI.RegisterSubject(s);
                    }
                }
                else if (option == 7)
                {
                    UI.StudentUI.CalculateFeeForAll();
                }
                    UI.MenuUI.ClearScreen();
                }
            }
        }
    }
