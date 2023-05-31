namespace GuitarSchools
{
    abstract class People
    {
        protected string name;
        protected int age;
        protected string gender;
        protected string email;
        public readonly int id;
        protected string guitarType;
        public People(int id, string name, int age, string gender, string email, string guitarType)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.guitarType = guitarType;
        }
        public void SetName(string name) { this.name = name;}
        public void SetAge(int age) {  this.age = age;}
        public void SetGender(string gender) {  this.gender = gender;}
        public void SetEmail(string email) {  this.email = email;}
        public void SetGuitarType(string guitarType) { this.guitarType = guitarType; }
        public string GetName() { return this.name;}
        public int GetAge() { return this.age;}
        public string GetGender() { return this.gender;}
        public string GetEmail() { return this.email;}
    }
}
