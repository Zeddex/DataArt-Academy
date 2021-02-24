using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Text;

namespace HomeWork2._1
{
    #region HW 2.1
    // Часть 1. 
    // Дан список людей, для каждого из который известно имя и адрес электронной почты.
    // Необходимо сформировать строку с HTML разметкой, которая выведет этот список в виде ссылок вида:
    // <a href = "mailto:[email_address]" >[name] </ a >
    // где[email_address] - это адрес электронной почты, а[name] - имя человека.
    // Формирование указанной строки должно осуществляться с использованием класса StringBuilder. 
    // Сформированная строка должна записываться в файл "index.html".
    //
    // Часть 2.
    // Измените вашу программу так, чтобы она могла корректно обрабатывать имена и адреса вида "Maxim<script>alert('Name!')</script>"
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>
            {
                new Person { Name = "John Doe", Email = "johndoe@gmail.com"},
                new Person { Name = "Vardenis Pavardenis", Email = "vpavardenis@gmail.com"},
                new Person { Name = "Jean Dupont", Email = "jeandupont@gmail.com"},
                new Person { Name = "John Smith", Email = "johnsmith@gmail.com"},
                new Person { Name = "Hong Gildong", Email = "hgildong@gmail.com"},
                new Person { Name = "Maxim<script>alert('Name!')</script>", Email = "injection@gmail.com"}
            };

            string result = DataProcessing.GenerateBody(person);

            Output.SaveFile(DataProcessing.Encode(result));
        }
    }

    class Output
    {
        public static void SaveFile (string data)
        {
            using (StreamWriter sw = new StreamWriter("index.html"))
            {
                sw.WriteLine("<body>");
                sw.WriteLine(data);
                sw.WriteLine("</body>");
            }
        }
    }

    class DataProcessing
    {
        /// <summary>
        /// Generate body of HTML document
        /// </summary>
        /// <param name="dataList">User's list</param>
        /// <returns></returns>
        public static string GenerateBody(List<Person> dataList)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < dataList.Count; i++)
            {
                if (i != dataList.Count - 1)
                {
                    result.AppendLine($"<a href=\"mailto:{dataList[i].Email}\">{dataList[i].Name}</a> |");
                }
                else
                {
                    result.AppendLine($"<a href=\"mailto:{dataList[i].Email}\">{dataList[i].Name}</a>");
                }
            }

            // filtration
            //result.Replace("<script>", "&lt;script&gt;");
            //result.Replace("</script>", "&lt;/script&gt;");

            return result.ToString();
        }

        public static string Encode(string data)
        {
            string encodedData = HttpUtility.HtmlEncode(data);
            return encodedData;
        }
    }
}
