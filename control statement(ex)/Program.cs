using System;

namespace control_statement_ex_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# 제어문");

            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
            // 제어문 기초
            Console.WriteLine("\n[제어문 예시]");
            if (a > b)
            {
                Console.WriteLine("a는 b보다 큽니다.");
            }
            else if (a == b)
            {
                Console.WriteLine("a와 b는 같습니다.");
            }
            else
            {
                Console.WriteLine("a는 b보다 작습니다.");
            }

            Console.WriteLine("for문: 1부터 5까지 출력");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("while문: 5부터 1까지 출력");
            int k = 5;
            while (k > 0)
            {
                Console.Write(k + " ");
                k--;
            }
            Console.WriteLine();

            // 제어문 예시
            for (int i = 0; i <= 32; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine("신라면");
                        break;
                    case 2:
                        Console.WriteLine("진라면");
                        break;
                    case 3:
                        Console.WriteLine("오징어짬뽕");
                        break;
                    case 4:
                        Console.WriteLine("안성탕면");
                        break;
                    case 5:
                        Console.WriteLine("참깨라면");
                        break;
                    case 6:
                        Console.WriteLine("틈새라면");
                        break;
                    case 7:
                        Console.WriteLine("진짬뽕");
                        break;
                    case 8:
                        Console.WriteLine("진짜장");
                        break;
                    case 9:
                        Console.WriteLine("짜짜로니");
                        break;
                    case 10:
                        Console.WriteLine("삼양라면");
                        break;
                    case 11:
                        Console.WriteLine("김치라면");
                        break;
                    case 12:
                        Console.WriteLine("짜장면(팔도)");
                        break;
                    case 13:
                        Console.WriteLine("생생우동");
                        break;
                    case 14:
                        Console.WriteLine("짜파게티");
                        break;
                    case 15:
                        Console.WriteLine("짜왕");
                        break;
                    case 16:
                        Console.WriteLine("불짬뽕");
                        break;
                    case 17:
                        Console.WriteLine("무파마");
                        break;
                    case 18:
                        Console.WriteLine("스낵면");
                        break;
                    case 19:
                        Console.WriteLine("오동통면");
                        break;
                    case 20:
                        Console.WriteLine("너구리");
                        break;
                    case 21:
                        Console.WriteLine("사리곰탕");
                        break;
                    case 22:
                        Console.WriteLine("꼬꼬면");
                        break;
                    case 23:
                        Console.WriteLine("도시락(라면)");
                        break;
                    case 24:
                        Console.WriteLine("배홍동");
                        break;
                    case 25:
                        Console.WriteLine("스파게티(농심)");
                        break;
                    case 26:
                        Console.WriteLine("새우탕");
                        break;
                    case 27:
                        Console.WriteLine("튀김 우동");
                        break;
                    case 28:
                        Console.WriteLine("하모니");
                        break;
                    case 29:
                        Console.WriteLine("양념치킨라면");
                        break;
                    case 30:
                        Console.WriteLine("불닭볶음면");
                        break;
                    default:
                        Console.WriteLine("라면의 종류");
                        break;
                }
            }

        }
    }
}