using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework10.Models;

namespace Homework10.Models
{
    public static class CollegeData
    {
        public static void Initialize(CollegeContext context)
        {
            if (!context.Students.Any() && !context.Groups.Any())
            {
                
                var groups = new List<Group>
                {
                    new Group { Title = "Радиофизика" },
                    new Group { Title = "Микроэлектроника" },
                    new Group { Title = "Общая физика" },
                    new Group { Title = "Электродинамика"},
                    new Group { Title = "Радиотехника"}
                };
                context.Groups.AddRange(groups);
                context.SaveChanges();

                var groupsList = context.Groups.ToList();
                var students = new List<Student>
                {
                    new Student {FirstName = $"Артём", MiddleName = $"Дмитриевич", LastName = $"Худяков", Group = groupsList[0]},
                    new Student {FirstName = $"Малика", MiddleName = $"Никитична", LastName = $"Семёнова", Group = groupsList[0]},
                    new Student {FirstName = $"Айлин", MiddleName = $"Дмитриевна", LastName = $"Бородина", Group = groupsList[1]},
                    new Student {FirstName = $"Степан", MiddleName = $"Степанович", LastName = $"Дмитриев", Group = groupsList[1]},
                    new Student {FirstName = $"Никита", MiddleName = $"Максимович", LastName = $"Козлов", Group = groupsList[1]},
                    new Student {FirstName = $"София", MiddleName = $"Евгеньевна", LastName = $"Панова", Group = groupsList[2]},
                    new Student {FirstName = $"Михаил", MiddleName = $"Львович", LastName = $"Пирогов", Group = groupsList[2]},
                    new Student {FirstName = $"Алиса", MiddleName = $"Мироновна", LastName = $"Смирнова", Group = groupsList[2]},
                    new Student {FirstName = $"Давид", MiddleName = $"Михайлович", LastName = $"Иванов", Group = groupsList[3]},
                    new Student {FirstName = $"Семён", MiddleName = $"Иванович", LastName = $"Зыков", Group = groupsList[3]},
                    new Student {FirstName = $"Александра", MiddleName = $"Артёмовна", LastName = $"Осипова", Group = groupsList[3]},
                    new Student {FirstName = $"Ариана", MiddleName = $"Арсентьевна", LastName = $"Соловьева", Group = groupsList[3]},
                    new Student {FirstName = $"Каролина", MiddleName = $"Данииловна", LastName = $"Фадеева", Group = groupsList[4]},
                    new Student {FirstName = $"Андрей", MiddleName = $"Михайлович", LastName = $"Куликов", Group = groupsList[4]},
                    new Student {FirstName = $"Кристина", MiddleName = $"Викторовна", LastName = $"Никитина", Group = groupsList[4]}
                };
                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
