using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReportGenerator
{
    public class Input : IData
    {
        public List<string> GetFile(string ordersFilePath)
        {
            List<string> lines = new List<string>();
            using var stream = File.OpenRead(ordersFilePath);
            using var reader = new StreamReader(stream);

            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                lines.Add(line);
            }

            return lines;
        }
    }
}
