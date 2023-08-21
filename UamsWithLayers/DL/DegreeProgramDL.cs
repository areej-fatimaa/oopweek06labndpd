using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UamsWithLayers.DL
{
    class DegreeProgramDL
    {
        public static List<BL.DegreeProgram> programList = new List<BL.DegreeProgram>();
        public static void AddIntoDegreeList(BL.DegreeProgram dp)
        {
            programList.Add(dp);
        }
        public static BL.DegreeProgram isDegreeExists(string degreeName)
        {
            foreach(BL.DegreeProgram dp in programList)
            {
                if(dp.Name==degreeName)
                {
                    return dp;
                }
            }
            return null;
        }
        public static void StoreIntoFile(string path,BL.DegreeProgram dp)
        {
            StreamWriter f = new StreamWriter(path,true);
            string SubjectNames = "";
            for(int i=0;i<dp.subjects.Count-1;i++)
            {
                SubjectNames = SubjectNames + dp.subjects[i].subType + ";";
            }
            f.WriteLine(dp.Name + "," + dp.Duration + "," + dp.Seats + "," + SubjectNames);
            f.Flush();
            f.Close();
        }
        public static bool ReadFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while((record=f.ReadLine())!=null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degName = splittedRecord[0];
                    int duration =int.Parse( splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] recordForSubjects = splittedRecord[3].Split(';');
                    BL.DegreeProgram dp = new BL.DegreeProgram(degName, duration, seats);
                    for(int x=0;x<recordForSubjects.Length;x++)
                    {
                        BL.Subject s = SubjectDL.IsSubjectExists(recordForSubjects[x]);
                        if(s!=null)
                        {
                            dp.AddSubject(s);
                        }
                    }
                    AddIntoDegreeList(dp);
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
