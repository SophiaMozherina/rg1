using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuitarSchools
{
    class GuitarSchool
    {
        public string name;
        private List<Student> studentsList = new List<Student>();
        private List<Teacher> teachersList = new List<Teacher>();
        private int latestStudentId = 0;
        private int latestTeacherId = 0;
        public GuitarSchool(string name)
        {
            this.name = name;
        }
        public bool isStudentIdAvailable(int id)
        {
            foreach (Student student in this.studentsList)
            {
                if (id == student.id) return true;
            }
            return false;
        }
        public bool isStudentIdAvailable(List<int> idList)
        {
            bool isAllIdAvailable = true;

            foreach (int id in idList)
            {
                if (!this.isStudentIdAvailable(id)) isAllIdAvailable = false;
            }

            return isAllIdAvailable;
        }
        public bool isTeacherIdAvailable(int id)
        {
            foreach (Teacher teacher in this.teachersList)
            {
                if (id == teacher.id) return true;
            }
            return false;
        }
            public void AddStudent()
        {
            try
            {
                Console.WriteLine("Введите имя ученика");
                string name = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите пол ученика");
                string gender = Console.ReadLine();
                Console.WriteLine("Введите email ученика");
                string email = Console.ReadLine();
                bool f = EmailIs(email);
                if (f == false) { throw new Exception("Неправильно написана почта"); }
                Console.WriteLine("Введите на какой гитаре играет ученик");
                string guitarType = Console.ReadLine();
                Student student = new Student(this.latestStudentId, name, age, gender, email, guitarType);
                this.latestStudentId++;
                this.studentsList.Add(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
        public void AddTeacher()
        {
            
            Console.WriteLine("Введите имя преподавателя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст преподавателя");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол преподавателя");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите email преподавателя");
            string email = Console.ReadLine();
            Console.WriteLine("Какой тип гитары преподает?");
            string guitarType = Console.ReadLine();
            Teacher teacher = new Teacher(this.latestTeacherId, name, age, gender, email, guitarType);
            this.latestTeacherId++;
            this.teachersList.Add(teacher);
        }
        public void AddTeacher(List<int> idList)
        {

            Console.WriteLine("Введите имя преподавателя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст преподавателя");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол преподавателя");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите email преподавателя");
            string email = Console.ReadLine();
            Console.WriteLine("Какой тип гитары преподает?");
            string guitarType = Console.ReadLine();
            Teacher teacher = new Teacher(this.latestTeacherId, name, age, gender, email, guitarType);
            teacher.SetStudentsList(idList);
            this.latestTeacherId++;
            this.teachersList.Add(teacher);
        }
        public void PrintStudentInfo()
        {
            Console.WriteLine("Список студентов:");
            foreach (Student student in this.studentsList)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
        public void PrintPrepInfo()
            { 
            Console.WriteLine("Список преподавателей:");
            foreach (Teacher teacher in this.teachersList)
            {
                Console.WriteLine(teacher.GetInfo());
            }
            
        }
        public void DeleteStudent(int id)
        {
            if (id > this.latestStudentId || id < 0)
            {
                Console.WriteLine("Пользователь не найден");
                return;
            } 

            int index = -1;
            for (int i = 0; i < this.studentsList.Count; i++)
            {
                if (this.studentsList[i].id == id)
                {
                    index = i;
                    break;
                }
            }
            this.studentsList.RemoveAt(index);
            Console.WriteLine("Пользователь удален!");
        }
        public void DeleteTeacher(int id)
        {
            if (id > this.latestTeacherId || id < 0)
            {
                Console.WriteLine("Пользователь не найден");
                return;
            }

            int index = -1;
            for (int i = 0; i < this.teachersList.Count; i++)
            {
                if (this.teachersList[i].id == id)
                {
                    index = i;
                    break;
                }
            }

            this.teachersList.RemoveAt(index);
            Console.WriteLine("Пользователь удален!");
        }
        public Teacher GetTeacherByID(int id)
        {
            foreach (Teacher teacher in this.teachersList)
            {
                if (teacher.id == id) return teacher;
            }
            return null;
        }
        public Student GetStudentByID(int id)
        {
            foreach (Student student in this.studentsList)
            {
                if (student.id == id) return student;
            }
            return null;
        }
        public void PrintTeacherStudentsList(int id)
        {
            Teacher teacher = GetTeacherByID(id);
            if (teacher == null) 
            {
                Console.WriteLine("Пользователь не найден");
                return;
            }
            List<int> studentsList = teacher.GetStudentsList();
            if (studentsList == null || studentsList.Count == 0)
            {
                Console.WriteLine("Список студентов: нет студентов");
                return;
            }
            Console.WriteLine("Список студентов: " + String.Join(" ", studentsList));
        }
        public bool EmailIs(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            MatchCollection match = regex.Matches(email);
            int s = 0;
            bool j = true;
            if (match.Count == 0)
            {
                j = false;
            }
            return j;
        }
    }
}
