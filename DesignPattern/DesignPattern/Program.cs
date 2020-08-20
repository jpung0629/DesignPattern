using System;
using System.ComponentModel;

namespace DesignPattern
{
    enum Gender
    {
        MAN,
        WOMAN
    }

    enum OS
    {
        WIN,
        MAC_OS
    }
    class Program
    {
        static void Main(string[] args)
        {
            testBuiler();
        }

        private static void testAbstractFactory()
        {
            OS os = OS.WIN; // 실제 업무에선 이렇게 예시로 넣지말고 진짜 OS를 가져와야 됨.
            IGUIFactory factory;
            switch(os)
            {
                case OS.WIN:
                    factory = new WinFactory();
                    break;
                case OS.MAC_OS:
                    factory = new MacOSFactory();
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            IButton button = factory.CreateButton();
            button.Paint();

        }
        private static void testBuiler()
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
