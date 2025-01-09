using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objects
{
    internal class Logs
    {

        private String _str;

        public Logs(String str)
        {
            this._str = str;
        }

        public void writeLogs()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string line;
            List<String> strings = new List<string>();
            if(File.Exists(Path.Combine(docPath, "logs.txt")))
            {
                using (StreamReader reader = new StreamReader(Path.Combine(docPath, "logs.txt")))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        strings.Add(line);
                    }
                }
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "logs.txt")))
            {
                strings.Add(this._str);
                foreach (string linee in strings)
                    outputFile.WriteLine(linee);
            }
        }
    }
}
