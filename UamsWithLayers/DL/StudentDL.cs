using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UamsWithLayers.DL
{
    class StudentDL
    {
        public static List<BL.Student> studentList = new List<BL.Student>();
        public static void AddIntoStudentList(BL.Student s)
        {
            studentList.Add(s);
        }
        public static BL.Student StudentPresent(string name)
        {
            foreach(BL.Student s in studentList)
            {
                if(name==s.Name&& s.regDegree!=null)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<BL.Student> SortStudentByMerit()
        {
            List<BL.Student> sortedList = new List<BL.Student>();
            foreach (BL.Student stu in studentList)
            {
                stu.CalculateMerit();
            }
            sortedList = studentList.OrderByDescending(s => s.merit).ToList();
            return sortedList;
        }
        public static void GiveAdmission(List<BL.Student> sortedList)
        {
            foreach (BL.Student stu in sortedList)
            {
                foreach (BL.DegreeProgram deg in stu.preference)
                {
                    if (deg.Seats > 0 && stu.regDegree == null)
                    {
                        stu.regDegree = deg;
                        deg.Seats--;
                        break;
                    }
                }

            }
        }
        public static void StoreIntoFile(string path, BL.Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for (int i = 0; i < s.preference.Count-1; i++)
            {
                degreeNames=degreeNames+s.preference[i]+ ";";
            }
            f.WriteLine(s.Name + "," + s.Age + "," + s.FscMarks + "," + s.EcatMarks+","+degreeNames);
            f.Flush();
            f.Close();
        }
        public static bool ReadFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string Name = splittedRecord[0];
                    string age = splittedRecord[1];
                    int fscMarks = int.Parse(splittedRecord[2]);
                    int ecatMarks = int.Parse(splittedRecord[3]);
                    string[] prefrence = splittedRecord[4].Split(';');
                    List<BL.DegreeProgram> prefrences = new List<BL.DegreeProgram>();
                    for (int x = 0; x < prefrence.Length; x++)
                    {
                        BL.DegreeProgram d = DL.DegreeProgramDL.isDegreeExists(prefrence[x]);
                        if (d != null)
                        {
                            if(!(prefrences.Contains(d)))
                            {
                                prefrences.Add(d);
                            }
                        }
                    }
                    BL.Student s = new BL.Student(Name, age, fscMarks, ecatMarks, prefrences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
