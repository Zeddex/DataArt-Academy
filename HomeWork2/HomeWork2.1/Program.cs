using System;
using System.Collections.Generic;
using System.IO;
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

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < person.Count; i++)
            {
                StringBuilder sb = new StringBuilder("<a href=\"mailto:[email_address]\">[name]</a> |");
                sb.Replace("[email_address]", person[i].Email);
                sb.Replace("[name]", person[i].Name);
                result.AppendLine(sb.ToString());
            }

            // remove 2 last characters
            if (result.Length != 0)
            {
                result.Remove(result.Length - 4, 4);
            }

            // filtration
            result.Replace("<script>", "&lt;script&gt;");
            result.Replace("</script>", "&lt;/script&gt;");

            using (StreamWriter sw = new StreamWriter("index.html"))
            {
                sw.WriteLine("<body>");
                sw.WriteLine(result.ToString());
                sw.WriteLine("</body>");
            }
        }
    }
}
