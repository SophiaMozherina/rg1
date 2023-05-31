using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarSchools
{
    class Student : People
    {

        public string guitarType;

        public Student(int id, string name, int age, string gender, string email, string guitarType) : base(id, name, age, gender, email, guitarType)
        {
            
            this.guitarType = guitarType;
        }
        public string GetInfo()
        {
            return $"id: {id}, name: {name}, gender:{gender}, email:{email}, guitarType:{guitarType}";
        }
    }
}
