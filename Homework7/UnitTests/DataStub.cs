using ReportGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class DataStub : IData
    {
        private List<string> data = new List<string>();

        public DataStub(List<string> data)
        {
            this.data = data;
        }

        public List<string> GetFile(string ordersFilePath)
        {
            List<string> fileData = data;
            return fileData;
        }
    }
}
