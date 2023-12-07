using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_rykhlov
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = GetStudents();

            // 1) Отсортировать объекты массива в порядке возрастания даты рождения
            var sortByBirthDate = from student in students 
                                  orderby student.Birthdate
                                  select student;

            // 2) Выбрать все элементы, возраст которых больше или равен 25
            var ageAbove25 = from student in students 
                             where student.Age >= 25
                             select student;

            // 3) Выбрать первый элемент, имя которого начинается на «А»
            var startWithA = (from student in students
                             where student.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                             select student).FirstOrDefault();

            // 4) Выбрать минимальный четный ID объекта
            var minId = (from student in students 
                             where student.ID % 2 == 0
                             select student.ID).Min();

            // 5) Выбрать объект с самым длинным именем
            var longestName = from student in students
                                    where student.Name.Length == (from s in students 
                                                                  orderby s.Name.Length descending
                                                                  select s.Name.Length).FirstOrDefault()
                                    select student;

            // 6) Вывести список ID объектов, отсортированный по возрастанию
            var sortIds = from student in students
                            orderby student.ID
                            select student.ID;

            Console.WriteLine("1) Отсортированные по дате рождения:");
            foreach (var student in sortByBirthDate)
                Console.WriteLine(student.Name + " " + student.Birthdate);

            Console.WriteLine("\n2) Возраст старше или равен 25:");
            foreach (var student in ageAbove25)
                Console.WriteLine(student.Name);

            Console.WriteLine("\n3) Первое имя, начинающееся на 'A':");
            Console.WriteLine(startWithA?.Name);

            Console.WriteLine("\n4) Минимальный четный ID:");
            Console.WriteLine(minId);

            Console.WriteLine("\n5) Студент(ы) с самым длинным именем:");
            foreach (var longest in longestName)
                Console.WriteLine(longest.Name);

            Console.WriteLine("\n6) Отсортированный список ID:");
            foreach (var id in sortIds)
                Console.WriteLine(id);
        }

        private static Student[] GetStudents() 
        {
            return new Student[] // создание массива объектов Student
            {
                new Student { ID = 1, Name = "Kirill", Age = 19, Birthdate = new DateTime(2004, 1, 4) },
                new Student { ID = 3, Name = "Dick", Age = 18, Birthdate = new DateTime(2005, 8, 10) },
                new Student { ID = 7, Name = "Travis", Age = 29, Birthdate = new DateTime(1995, 6, 18) },
                new Student { ID = 8, Name = "John", Age = 21, Birthdate = new DateTime(2002, 2, 1) },
                new Student { ID = 2, Name = "Bob", Age = 32, Birthdate = new DateTime(1991, 5, 20) },
                new Student { ID = 9, Name = "Dmitry", Age = 19, Birthdate = new DateTime(2004, 1, 1) },
                new Student { ID = 4, Name = "Artem", Age = 19, Birthdate = new DateTime(2004, 11, 12) },
                new Student { ID = 5, Name = "Max", Age = 20, Birthdate = new DateTime(2005, 10, 20) },
                new Student { ID = 6, Name = "Zane", Age = 24, Birthdate = new DateTime(1999, 4, 30) },
                new Student { ID = 10, Name = "Ahmat", Age = 25, Birthdate = new DateTime(1998, 6, 30) }
            };
        }
    }
}