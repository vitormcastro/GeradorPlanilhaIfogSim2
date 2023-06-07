using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorPlanilhaIFogSim2.Domain.Service
{
    public class FileService
    {
        public static List<string> ListFolder(string path)
        {
            List<string> list = new List<string>();
            if(Directory.Exists(path))
            {
                list.AddRange(GetFileNameWithoutExtension(Directory.GetFiles(path)));
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            return list;
        }
        
        private static string[] GetFileNameWithoutExtension(string[] files)
        {
            for(int f  = 0; f < files.Length; f++)
            {
                files[f] = Path.GetFileNameWithoutExtension(files[f]);
            }

            return files;
        }

        public static void WriteCSV(string nameFile, string[] lines)
        {
            string path = Path.Combine(Constants.SheetsPath,nameFile+".csv");
            if(File.Exists(path)) 
            {
                File.AppendAllLines(path, new string[] { lines[1] });
            }
            else
            {
                File.WriteAllLines(path, lines);
            }
        }
    }
}
