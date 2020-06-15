using System.ComponentModel.DataAnnotations;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int Min_Age = 12;
        private const int Max_Age = 90;
        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        [MyRequired]
        public string Name { get; set; }
        [MyRange(Min_Age,Max_Age)]
        public int Age { get; set; }
    }
}
