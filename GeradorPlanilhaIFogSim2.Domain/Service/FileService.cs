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
                list.AddRange(Directory.GetFiles(path));
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            return list;
        }
    }
}
