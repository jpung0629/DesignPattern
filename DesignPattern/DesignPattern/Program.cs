using System;

namespace DesignPattern
{
    enum Gender
    {
        MAN,
        WOMAN
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentBuilder builder = new StudentBuilder();

            Student student1 = builder
                .setAge(12)
                .setName("풍중현")
                .setGender(Gender.MAN)
                .build();

            Student student2 = builder
                .setAge(21)
                .setName("국현")
                .setGender(Gender.MAN)
                .build();

            Console.WriteLine(student1);
            Console.WriteLine(student2);
        }
    }

    class Student
    {
        private string? name;
        private int? age;
        private Gender? gender;

        public Student(string? name, int? age, Gender? gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ToString()
        {
            return $"Student: {{name: {name}, age: {age}, gender: {gender}}}";
        }
    }

    class StudentBuilder
    {
        private string? name = null;
        private int? age = null;
        private Gender? gender = null;

        public StudentBuilder()
        { }

        public StudentBuilder setName(string name)
        {
            this.name = name;
            return this;
        }

        public StudentBuilder setAge(int age)
        {
            this.age = age;
            return this;
        }

        public StudentBuilder setGender(Gender gender)
        {
            this.gender = gender;
            return this;
        }

        public Student build()
        {
            return new Student(name, age, gender);
        }
    }
}
