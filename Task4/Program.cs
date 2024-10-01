using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Score { get; set; }
        public Student(string name,string group,DateTime dateofbirth, decimal score)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
            Score = score;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\My\\ReposVS\\MainTask_8_6\\trash\\students.dat";
            
            DateTime date = DateTime.Now;


            File.SetAttributes(path, FileAttributes.Normal); //позволяет избежать исключения access to the path

            BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string studentsDirectory = Path.Combine(desktopPath, "Students");

            // Создаем директорию Students
            if (!Directory.Exists(studentsDirectory))
            {
                Directory.CreateDirectory(studentsDirectory);
            }


            Dictionary<string, List<Student>> studentsByGroup = new Dictionary<string, List<Student>>();    //словарь с ключом группы и списком студентов

            while (binaryReader.PeekChar() > -1) {
                string name = binaryReader.ReadString();
                string group = binaryReader.ReadString();
                long datelong = binaryReader.ReadInt64();
                DateTime dateTime = DateTime.FromBinary(datelong);               
                decimal score = binaryReader.ReadDecimal();
                Student student = new Student ( name, group, dateTime, score );

                if (!studentsByGroup.ContainsKey(group)) //проверяет наличие элемента с определенным ключом и возвращает true при его наличии в словаре
                {
                    studentsByGroup[group] = new List<Student>();
                }
                studentsByGroup[group].Add(student);

            }


            foreach (var group in studentsByGroup)      // перебор по группам
            {
                string groupFilePath = Path.Combine(studentsDirectory, $"{group.Key}.txt");

                using (StreamWriter writer = new StreamWriter(groupFilePath))
                {
                    foreach (var student in group.Value)        // перебор студентов
                    {
                        writer.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}, {student.Score}");
                    }
                }
            }

            Console.WriteLine("Загрузка завершена. Файлы с данными студентов созданы на рабочем столе.");


        }
    }
}
