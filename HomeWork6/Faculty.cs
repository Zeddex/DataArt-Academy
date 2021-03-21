using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HomeWork6
{
    public class Faculty
    {
        public void ShowFaculty()
        {
            using (AppContext context = new AppContext())
            {
                foreach (Group g in context.Groups.Include(g => g.Students))
                {
                    Console.WriteLine($"\nГруппа {g.Title}({g.Students.Count}):");
                    foreach (Student s in g.Students.OrderBy(s => s.LastName))
                    {
                        Console.WriteLine($"Студент: {s.LastName} {s.FirstName} {s.MiddleName}");
                    }
                }
            }
        }

        public void ShowGroups()
        {
            using (AppContext context = new AppContext())
            {
                var groups = context.Groups.Select(g => new
                {
                    groupTitle = g.Title,
                    groupId = g.Id
                });

                string groupsList = string.Empty;
                bool isFirst = true;

                foreach (var g in groups)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        groupsList += ", ";

                    groupsList += g.groupId + " - " + g.groupTitle;
                }

                Console.WriteLine(groupsList);
            }
        }

        public List<int> ShowStudents(int groupNum)
        {
            List<int> studentsNumbers = new();

            using (AppContext context = new AppContext())
            {
                var students = context.Students.Where(s => s.GroupId == groupNum);

                foreach (var student in students)
                {
                    Console.WriteLine(student.Id + " - " + student.LastName + " " + student.FirstName + " " +  student.MiddleName);
                    studentsNumbers.Add(student.Id);
                }
            }

            return studentsNumbers;
        }

        public void AddStudent()
        {
            int groupNum;
            string fName, lName, mName;

            Console.WriteLine("Выберите номер группы:");
            ShowGroups();

            groupNum = GetGroup();

            while (true)
            {
                Console.WriteLine("Введите фамилию студента:");
                lName = Console.ReadLine();
                if (lName != "")
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите имя студента:");
                fName = Console.ReadLine();
                if (fName != "")
                {
                    break;
                }
            }

            Console.WriteLine("Введите отчество студента:");
            mName = Console.ReadLine();

            using (AppContext context = new AppContext())
            {
                var student = new Student()
                {
                    LastName = lName,
                    FirstName = fName,
                    MiddleName = mName,
                    GroupId = groupNum
                };

                context.Students.Add(student);
                context.SaveChanges();
            }

            Console.Clear();
        }

        public void DeleteStudent()
        {
            bool inputResult;
            int groupNum, studentNum;
            List<int> studentsNumbers;

            Console.WriteLine("Выберите номер группы:");
            ShowGroups();

            groupNum = GetGroup();

            Console.WriteLine("Выберите номер студента:");
            studentsNumbers = ShowStudents(groupNum);

            do
            {
                inputResult = Int32.TryParse(Console.ReadLine(), out studentNum);
                if (!studentsNumbers.Contains(studentNum))
                {
                    inputResult = false;
                }

            } while (!inputResult);

            using (AppContext context = new AppContext())
            {
                var studToDelete = context.Students.FirstOrDefault(s => s.Id == studentNum);
                context.Students.Remove(studToDelete);
                context.SaveChanges();
            }

            Console.Clear();
        }

        public int GetGroup()
        {
            bool inputResult;
            int groupNum, groupsAmount;

            // get amount of groups
            using (AppContext context = new AppContext())
            {
                groupsAmount = context.Groups.Count();
            }

            // get group number and check the group exists
            do
            {
                inputResult = Int32.TryParse(Console.ReadLine(), out groupNum);
                if (groupNum > groupsAmount || groupNum <= 0)
                {
                    inputResult = false;
                }

            } while (!inputResult);

            return groupNum;
        }
    }
}
