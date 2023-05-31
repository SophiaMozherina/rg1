using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarSchools
{
    class Teacher : People
    {
        private List<int> studentsList;

        public Teacher(int id, string name, int age, string gender, string email, string guitarType) : base(id, name, age, gender, email, guitarType)
        {
            studentsList = new List<int>();
        }
        public void AddStudent(int studentId)
        {
            studentsList.Add(studentId);
        }
        public void SetStudentsList(List<int> studentsList )
        {
            this.studentsList = studentsList;
        }
        public string GetInfo()
        {
            return $"id: {id}, name: {name}, age: {age}, gender: {gender}, email: {email}, guitarType: {guitarType}";
        }
        public List<int> GetStudentsList() 
        {
            return studentsList;
        }
    }
}
