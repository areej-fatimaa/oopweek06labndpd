using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UamsWithLayers.DL
{
    public class SubjectDL
    {
        public static List<BL.Subject> subjectList=new List<BL.Subject>();
        public static void AddSubjectIntoList(BL.Subject s)
        {
            subjectList.Add(s);
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
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int ch = int.Parse(splittedRecord[2]);
                    int subFees =int.Parse( splittedRecord[3]);
                    BL.Subject s = new BL.Subject(code, type, ch, subFees);
                    AddSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void StoreInFile(string path,BL.Subject s)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(s.subCode + "," + s.subType + "," + s.CreditHours,s.Fees);
            Console.ReadKey();
            file.Flush();
            file.Close();
        }
        public static BL.Subject IsSubjectExists(string type)
        {
           foreach(BL.Subject s in subjectList)
            {
                if(s.subType==type)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
