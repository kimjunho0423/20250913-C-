using System;
using System.Text;
namespace position_number_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== 진법 계산기 (고정 메뉴: 2~9진법, 10진법, 16진법) ===");
                Console.WriteLine("1. 2진법");
                Console.WriteLine("2. 3진법");
                Console.WriteLine("3. 4진법");
                Console.WriteLine("4. 5진법");
                Console.WriteLine("5. 6진법");
                Console.WriteLine("6. 7진법");
                Console.WriteLine("7. 8진법");
                Console.WriteLine("8. 9진법");
                Console.WriteLine("9. 10진법");
                Console.WriteLine("10. 16진법");
                Console.WriteLine("0. 종료");
                Console.Write("선택: ");
                string sel = Console.ReadLine()?.Trim();

                if (sel == "0") { Console.WriteLine("프로그램 종료!"); break; }

                int numberBase;
                switch (sel)
                {
                    case "1": numberBase = 2; break;
                    case "2": numberBase = 3; break;
                    case "3": numberBase = 4; break;
                    case "4": numberBase = 5; break;
                    case "5": numberBase = 6; break;
                    case "6": numberBase = 7; break;
                    case "7": numberBase = 8; break;
                    case "8": numberBase = 9; break;
                    case "9": numberBase = 10; break;
                    case "10": numberBase = 16; break;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        continue;
                }

                RunCalculator(numberBase);
            }
        }

        static void RunCalculator(int numberBase)
        {
            Console.WriteLine($"\n[{numberBase}진법 계산기] (정수 연산, 음수 허용)");

            Console.Write($"첫 번째 숫자 입력 ({BaseDigitsInfo(numberBase)}): ");
            string s1 = Console.ReadLine()?.Trim();
            if (!TryParseToLong(s1, numberBase, out long n1))
            {
                Console.WriteLine("첫 번째 숫자 형식이 잘못되었습니다.");
                return;
            }

            Console.Write("연산자 입력 (+, -, *, /): ");
            string op = Console.ReadLine()?.Trim();
            if (op != "+" && op != "-" && op != "*" && op != "/")
            {
                Console.WriteLine("지원하지 않는 연산자입니다.");
                return;
            }

            Console.Write($"두 번째 숫자 입력 ({BaseDigitsInfo(numberBase)}): ");
            string s2 = Console.ReadLine()?.Trim();
            if (!TryParseToLong(s2, numberBase, out long n2))
            {
                Console.WriteLine("두 번째 숫자 형식이 잘못되었습니다.");
                return;
            }

            long res = 0;
            bool valid = true;
            switch (op)
            {
                case "+": res = n1 + n2; break;
                case "-": res = n1 - n2; break;
                case "*": res = n1 * n2; break;
                case "/":
                    if (n2 == 0) { Console.WriteLine("0으로 나눌 수 없습니다."); valid = false; }
                    else res = n1 / n2; // 정수 나눗셈
                    break;
            }

            if (valid)
            {
                Console.WriteLine("\n[결과]");
                Console.WriteLine($"10진수: {res}");
                Console.WriteLine($"{numberBase}진수: {ToBaseString(res, numberBase)}");
            }
        }

        // 입력 문자열(s)을 fromBase 진법으로 파싱해서 long 결과를 반환 (성공 여부)
        static bool TryParseToLong(string s, int fromBase, out long value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim();
            int idx = 0;
            bool negative = false;
            if (s[0] == '+' || s[0] == '-')
            {
                negative = s[0] == '-';
                idx = 1;
                if (s.Length == 1) return false;
            }

            long v = 0;
            try
            {
                for (int i = idx; i < s.Length; i++)
                {
                    char c = s[i];
                    int digit;
                    if (c >= '0' && c <= '9') digit = c - '0';
                    else if (c >= 'A' && c <= 'Z') digit = c - 'A' + 10;
                    else if (c >= 'a' && c <= 'z') digit = c - 'a' + 10;
                    else return false;

                    if (digit < 0 || digit >= fromBase) return false;
                    checked { v = v * fromBase + digit; }
                }
            }
            catch (OverflowException)
            {
                return false;
            }

            value = negative ? -v : v;
            return true;
        }

        // long 값을 toBase 진법 문자열로 변환
        static string ToBaseString(long value, int toBase)
        {
            if (toBase < 2 || toBase > 36) throw new ArgumentOutOfRangeException(nameof(toBase));
            if (value == 0) return "0";

            bool negative = value < 0;
            // long.MinValue 처리: -(value+1) 은 안전, +1로 보정
            ulong u;
            if (negative)
            {
                u = (ulong)(-(value + 1)) + 1UL;
            }
            else
            {
                u = (ulong)value;
            }

            StringBuilder sb = new StringBuilder();
            while (u > 0)
            {
                int rem = (int)(u % (ulong)toBase);
                char c = rem < 10 ? (char)('0' + rem) : (char)('A' + (rem - 10));
                sb.Insert(0, c);
                u /= (ulong)toBase;
            }

            if (negative) sb.Insert(0, '-');
            return sb.ToString();
        }

        static string BaseDigitsInfo(int b)
        {
            if (b <= 10) return $"0..{b - 1}";
            else return $"0..9, A..{(char)('A' + b - 11)}";
        }

    }
}