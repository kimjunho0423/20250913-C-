using System.ComponentModel;

namespace operator_ex_
{
    internal class Program
    { 
        static void Main(string[] args)
            {
            Console.WriteLine("C# 연산자 예제");

            // 연산자 기초
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
            Console.WriteLine("\n[연산자 예시]");
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"덧셈: a + b = {a + b}");
            Console.WriteLine($"뺄셈: a - b = {a - b}");
            Console.WriteLine($"곱셈: a * b = {a * b}");
            Console.WriteLine($"나눗셈: a / b = {a / b}");
            Console.WriteLine($"나머지: a % b = {a % b}");

            // 연산자 예시
            string c = "\n치킨";
            Console.WriteLine(c);
            Console.WriteLine("\n갯수 입력:");
            int chicken = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int f, g;
            f = chicken / e;
            g = chicken % e;
            Console.WriteLine("나눈 후 몫은 얼마야? " + f + "개\n");
            Console.WriteLine("나눈 후 나머지는 얼마야? " + g + "개\n");

            //관계 연산자
            int h = 3, i = 6, j = 9;
            Console.WriteLine("h가 i보다 크다 {0}", h > i);
            Console.WriteLine("h가 i보다 같거나 크다 {0}", h >= i);
            Console.WriteLine("j에서 6을 빼면 h와 같다 {0}", j - 6 == h);
            Console.WriteLine("j에서 6을 빼면 h와 같지않다 {0}", j - 6 != h);
            Console.WriteLine("j에서 6을 빼면 i와 같다 {0}", j - 6 == i);
            Console.WriteLine("j에서 6을 빼면 i와 같지않다 {0}", j - 6 != i);
            Console.WriteLine("\n프로그램 종료!");
        }
      }
    }