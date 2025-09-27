using _20250927_1oop;
using System;
using System.Security.Claims;
using System.Xml.Linq;
namespace _20250927_1oop
{
    // 클래스(Class), 객체(Object), 인스턴스(Instance)
    class Animal
    {
        // 필드(Field)
        private string name;       // private 필드 (캡슐화)
        private int age;

        // 속성(Property)
        public string Name         // public 속성 (외부 접근 허용)
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // 생성자(Constructor)
        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine($"{name}이(가) 태어났습니다!");
        }

        // 메서드(Method)
        public virtual void Speak()     // 가상 메서드 (다형성)
        {
            Console.WriteLine($"{name}이(가) 소리를 냅니다!");
        }

        // 소멸자(Destructor)
        ~Animal()
        {
            Console.WriteLine($"{name}이(가) 사라졌습니다...");
        }
    }
    // 상속(Inheritance)
    class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age) { }

        // 다형성(Polymorphism): 메서드 재정의
        public override void Speak()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다!");
        }
    }

    // 추상화(Abstraction)
    abstract class Vehicle      // 추상 클래스
    {
        public abstract void Drive();   // 추상 메서드: 자식이 반드시 구현
    }

    // 인터페이스(Interface)
    interface IFlyable
    {
        void Fly();   // 메서드 시그니처만 제공
    }

    class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("자동차가 도로 위를 달립니다!");
        }
    }

    class Airplane : Vehicle, IFlyable
    {
        public override void Drive()
        {
            Console.WriteLine("비행기가 활주로를 달립니다!");
        }

        public void Fly()
        {
            Console.WriteLine("비행기가 하늘로 날아갑니다!");
        }
    }

    // 구조체(Struct)
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x; Y = y;
        }

        public void Print()
        {
            Console.WriteLine($"좌표: ({X}, {Y})");
        }
    }

    // 열거형(Enum)
    enum Day
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    // 프로그램 실행
    class Program
    {
        static void Main()
        {
            // 객체(Object) 생성
            Animal a1 = new Animal("동물", 3);   // Animal 인스턴스
            Dog d1 = new Dog("바둑이", 2);       // Dog 인스턴스

            a1.Speak();    // 동물 소리
            d1.Speak();    // 멍멍 짖음 (다형성)

            // 추상 클래스 & 인터페이스
            Car car = new Car();
            car.Drive();

            Airplane plane = new Airplane();
            plane.Drive();
            plane.Fly();

            // 구조체
            Point p = new Point(10, 20);
            p.Print();

            // 열거형
            Day today = Day.Friday;
            Console.WriteLine($"오늘은 {today}입니다.");
        }
    }

}

//클래스(Class): Animal, Dog, Car, Airplane

//객체(Object) & 인스턴스(Instance): new 키워드로 만든 a1, d1 등

//생성자(Constructor): Animal(...)

//소멸자(Destructor): ~Animal()

//속성(Property): Name, Age

//필드(Field): private string name

//메서드(Method): Speak(), Drive(), Fly()

//캡슐화(Encapsulation): private 필드 + public 속성

//상속(Inheritance): Dog: Animal

//다형성(Polymorphism): override Speak()

//추상화(Abstraction): abstract class Vehicle

//인터페이스(Interface): IFlyable

//구조체(Struct): Point

//열거형(Enum): Day