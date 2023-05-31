using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http.Headers;

namespace GuitarSchools
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            GuitarSchool school = new GuitarSchool("Добро пожаловать в гитарную школу!");
            int id;
            bool q = false;

            while (!q)
            {
                Console.WriteLine("Введите команду:");
                Console.WriteLine("1. Добавить пользователя");
                Console.WriteLine("2. Изменить информацию о пользователе");
                Console.WriteLine("3. Удалить пользователя");
                Console.WriteLine("4. Вывести информацию");

                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Какого пользователя добавить?");
                        Console.WriteLine("1. Ученик");
                        Console.WriteLine("2. Преподаватель");
                        string a = Console.ReadLine();

                        switch (a)
                        {
                            case "1":
                                school.AddStudent();
                                break;
                            case "2":
                                Console.WriteLine("1. Ввести преподавателя со списком учеников");
                                Console.WriteLine("2. Ввести преподавателя без списка учеников");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        List<int> idList = GetIntListFromString("Введите список ID");
                                        if (!school.isStudentIdAvailable(idList)) 
                                        {
                                            Console.WriteLine("Студент не найден");
                                            break;
                                        }
                                        school.AddTeacher(idList);
                                        break;
                                    case "2":
                                        school.AddTeacher();
                                        break;
                                    default:
                                        Console.WriteLine("Такого нет");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("У кого изменить информацию?");
                        Console.WriteLine("1. Ученик");
                        Console.WriteLine("2. Преподаватель");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Введите ID");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (!school.isStudentIdAvailable(id))
                                {
                                    Console.WriteLine("Такого студента нет");
                                    break;
                                }
                                UpdateStudentInfo(school.GetStudentByID(id));
                                break;
                            case "2":
                                Console.WriteLine("Введите ID");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (!school.isTeacherIdAvailable(id))
                                {
                                    Console.WriteLine("Такого студента нет");
                                    break;
                                }
                                UpdateTeacherInfo(school.GetTeacherByID(id));
                                break;
                            default:
                                Console.WriteLine("Такого пользователя нет");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("У кого удалить информацию?");
                        Console.WriteLine("1. Ученик");
                        Console.WriteLine("2. Преподаватель");
                        string h = Console.ReadLine();
                        switch (h)
                        {
                            case "1":
                                Console.WriteLine("Введите ID");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (school.isStudentIdAvailable(id))
                                {
                                    school.DeleteStudent(id);
                                }
                                else
                                {
                                    Console.WriteLine("Ученик с заданным id не найден");
                                }
                                break;
                            case "2":
                                Console.WriteLine("Введите ID");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (school.isTeacherIdAvailable(id))
                                {
                                    school.DeleteTeacher(id);
                                }
                                else
                                {
                                    Console.WriteLine("Преподаватель с заданным id не найден");
                                }
                                break;
                            default:
                                Console.WriteLine("Такого типа нет");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("О ком вывести информацию?");
                        Console.WriteLine("1. Об учениках");
                        Console.WriteLine("2. О преподавателях");
                        Console.WriteLine("3. Обо всех");
                        Console.WriteLine("4. Вывести список учеников у преподавателя с ID:");
                        string b = Console.ReadLine();
                        switch (b)
                        {
                            case "1":
                                school.PrintStudentInfo();
                                break;
                            case "2":
                                school.PrintPrepInfo();
                                break;
                            case "3":
                                school.PrintStudentInfo();
                                school.PrintPrepInfo();
                                break;
                            case "4":
                                Console.WriteLine("Введите ID");
                                id = Convert.ToInt32(Console.ReadLine());
                                school.PrintTeacherStudentsList(id);
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует");
                        break;
                }
            }
        }
        catch (FormatException)
            {
                Console.WriteLine("Неверный ввод данных");
            }
            catch (Exception e)
            {
                Console.WriteLine("Кажется, что-то пошло не так...");
                Console.WriteLine(e.Message);
            }
        }
        static List<int> GetIntListFromString(string a) 
        {
            Console.WriteLine(a);
            string[] b = Console.ReadLine().Split(' ');
            return GetIntListFromString(b);
        }
        static List<int> GetIntListFromString(string[] c)
        {
            List<int> ids = new List<int>();

            foreach (string num in c)
            {
                ids.Add(Convert.ToInt32(num));
            }
            return ids;
        }
        static void UpdateStudentInfo(Student student)
        {
            Console.WriteLine("Выберите параметр, который надо изменить");
            Console.WriteLine("1. Имя");
            Console.WriteLine("2. Возраст");
            Console.WriteLine("3. Пол");
            Console.WriteLine("4. Почта");
            Console.WriteLine("5. Тип гитары");
            string parameter = Console.ReadLine();
            Console.WriteLine("Введите новое значение");
            string value = Console.ReadLine();
            switch (parameter)
            {
                case "1":
                    student.SetName(value);
                    break;
                case "2":
                    student.SetAge(Convert.ToInt32(value));
                    break;
                case "3":
                    student.SetGender(value);
                    break;
                case "4":
                    student.SetEmail(value);
                    break;
                case "5":
                    student.SetGuitarType(value);
                    break;
                default:
                    Console.WriteLine("Такого параметра нет");
                    break;
            }
        }
            static void UpdateTeacherInfo(Teacher teacher) //сдвинуть
            {
                Console.WriteLine("Выберите параметр, который надо изменить");
                Console.WriteLine("1. Имя");
                Console.WriteLine("2. Возраст");
                Console.WriteLine("3. Пол");
                Console.WriteLine("4. Почта");
                Console.WriteLine("5. Тип гитары");
                Console.WriteLine("6. Список студентов");
                string parameter = Console.ReadLine();
                Console.WriteLine("Введите новое значение");
                string value = Console.ReadLine();
                switch (parameter)
                {
                    case "1":
                        teacher.SetName(value);
                        break;
                    case "2":
                        teacher.SetAge(Convert.ToInt32(value));
                        break;
                    case "3":
                        teacher.SetGender(value);
                        break;
                    case "4":
                        teacher.SetEmail(value);
                        break;
                case "5":
                    teacher.SetGuitarType(value);
                    break;
                case "6":
                        teacher.SetStudentsList(GetIntListFromString(value.Split(" ")));
                        break;
                    default:
                        Console.WriteLine("Такого параметра нет");
                        break;
                }
            }
        }
    }
