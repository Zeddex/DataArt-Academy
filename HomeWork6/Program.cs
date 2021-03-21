using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace HomeWork6
{
    #region Homework6
    // При запуске выводятся списки студентов по группам: на первой строке выводится название группы и в скобках количество студентов в группе,
    // далее на каждой строке по одному студенту текущей группы(ФИО). Студенты отсортированы по фамилиям. Затем таким же образом выводятся следующие группы.
    // Выводится вопрос, какое действие нужно совершить: 
    // Вариант «1 – добавить студента» запускает цепочку последовательных вопросов, после каждого из которых пользователь должен ввести ответ:
    // Выберете номер группы: (далее следует вывод всех групп через запятую в формате <номер> - <название>)
    // Введите ФИО студента – строковый ввод
    // Вариант «2 - удалить студента», вопросы:
    // Выберете номер группы: (список групп)
    // Выберите номер студента: (далее следует вывод всех студентов группы по одному на строке в формате<номер> - <ФИО>)
    // После получения ответов производится запись в базу данных и возврат к пункту 1.
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var faculty = new Faculty();

            DataInitializer.RecreateDB();
            DataInitializer.InitializeData();
            Debug.WriteLine("Database initialization successful");

            faculty.ShowFaculty();

            while (true)
            {
                int mode;
                bool inputResult;

                Console.WriteLine("\nВыберите действие: ");
                Console.WriteLine("1 – добавить студента");
                Console.WriteLine("2 - удалить студента");

                do
                {
                    inputResult = Int32.TryParse(Console.ReadLine(), out mode);
                } while (!inputResult);

                switch (mode)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Добавление студента");
                        faculty.AddStudent();
                        faculty.ShowFaculty();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Удаление студента");
                        faculty.DeleteStudent();
                        faculty.ShowFaculty();
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
