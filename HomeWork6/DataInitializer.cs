using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HomeWork6
{
    class DataInitializer
    {
        public static void InitializeData()
        {
            using (AppContext context = new AppContext())
            {
                var groups = new List<Group>
                {
                    new Group {Title = "электродинамика"},
                    new Group {Title = "радиотехника"}
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

        public static void RecreateDB()
        {
            using (AppContext context = new AppContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
