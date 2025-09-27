using _20250927_2oop;
using System;
using System.Collections.Generic;
namespace _20250927_2oop
{

    // 열거형 (Enum): 운영체제
    enum OperatingSystemType { Android, iOS, HarmonyOS, Other }

    // 구조체 (Struct): 해상도
    struct Resolution
    {
        public int Width;
        public int Height;

        public Resolution(int width, int height)
        {
            Width = width; Height = height;
        }

        public override string ToString() => $"{Width}x{Height}";
    }

    // 인터페이스 (Interface)
    interface IChargeable
    {
        void Charge(int amount);      // 배터리 충전
    }

    interface IConnectable
    {
        void ConnectToWiFi(string ssid);
    }

    // 추상 클래스 (Abstract Class)
    abstract class Smartphone : IChargeable, IConnectable
    {
        // 필드 & 속성
        private string brand;                // 캡슐화
        public string Brand
        {
            get => brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("브랜드명은 비어 있을 수 없습니다.");
                brand = value;
            }
        }

        public string Model { get; protected set; }
        public OperatingSystemType OS { get; protected set; }
        public Resolution Screen { get; private set; }
        public int BatteryLevel { get; protected set; }    // 0~100%

        // 생성자 & 소멸자
        public Smartphone(string brand, string model, OperatingSystemType os, Resolution screen)
        {
            Brand = brand;
            Model = model;
            OS = os;
            Screen = screen;
            BatteryLevel = 100;   // 초기 배터리 100%
            Console.WriteLine($"[생성] {Brand} {Model} 스마트폰이 준비되었습니다. 배터리 {BatteryLevel}%");
        }

        ~Smartphone()
        {
            Console.WriteLine($"[소멸] {Brand} {Model} 스마트폰이 해제되었습니다.");
        }

        // 메서드
        public abstract void Boot();        // 추상화 → 각 기종마다 다르게 동작
        public abstract void UseApp(string appName);

        public void Charge(int amount)
        {
            BatteryLevel += amount;
            if (BatteryLevel > 100) BatteryLevel = 100;
            Console.WriteLine($"{Brand} {Model} → 배터리 충전됨: {BatteryLevel}%");
        }

        public void ConnectToWiFi(string ssid)
        {
            Console.WriteLine($"{Brand} {Model}이(가) Wi-Fi '{ssid}'에 연결되었습니다.");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"브랜드: {Brand}, 모델: {Model}, OS: {OS}, 화면: {Screen}, 배터리: {BatteryLevel}%");
        }
    }

    // 구체 클래스 (Concrete Classes)
    class AndroidPhone : Smartphone
    {
        public AndroidPhone(string brand, string model, Resolution screen)
            : base(brand, model, OperatingSystemType.Android, screen) { }

        public override void Boot()
        {
            Console.WriteLine($"{Brand} {Model}: 안드로이드 부팅 중... 구글 로고 표시!");
        }

        public override void UseApp(string appName)
        {
            BatteryLevel -= 10;
            if (BatteryLevel < 0) BatteryLevel = 0;
            Console.WriteLine($"{Brand} {Model}에서 '{appName}' 앱 실행 → 배터리: {BatteryLevel}%");
        }
    }

    class IPhone : Smartphone
    {
        public IPhone(string model, Resolution screen)
            : base("Apple", model, OperatingSystemType.iOS, screen) { }

        public override void Boot()
        {
            Console.WriteLine($"{Brand} {Model}: 애플 로고와 함께 부팅 중... 🍎");
        }

        public override void UseApp(string appName)
        {
            BatteryLevel -= 7;   // iOS는 효율적
            if (BatteryLevel < 0) BatteryLevel = 0;
            Console.WriteLine($"{Brand} {Model}에서 '{appName}' 앱 실행 → 배터리: {BatteryLevel}%");
        }
    }

    // 이벤트: 충전 알림
    class Charger
    {
        public event Action<Smartphone> OnCharge;

        public void StartCharging(Smartphone phone)
        {
            Console.WriteLine("\n충전기를 연결합니다...");
            OnCharge?.Invoke(phone);
        }
    }

    // 프로그램 실행
    class Program
    {
        static void Main()
        {
            try
            {
                // 스마트폰 생성
                Smartphone galaxy = new AndroidPhone("Samsung", "Galaxy S25", new Resolution(1440, 3088));
                Smartphone iphone = new IPhone("iPhone 17 Pro", new Resolution(1290, 2796));

                // 정보 출력
                Console.WriteLine("\n=== 스마트폰 정보 ===");
                galaxy.ShowInfo();
                iphone.ShowInfo();

                // 부팅 및 앱 사용
                Console.WriteLine("\n=== 부팅 및 앱 실행 ===");
                galaxy.Boot();
                iphone.Boot();

                galaxy.UseApp("YouTube");
                iphone.UseApp("Safari");

                galaxy.ConnectToWiFi("Home_WiFi");

                // 충전 이벤트
                Charger charger = new Charger();
                charger.OnCharge += (phone) => phone.Charge(30);  // 이벤트 등록

                Console.WriteLine("\n=== 충전 시작 ===");
                charger.StartCharging(galaxy);
                charger.StartCharging(iphone);

                // 예외 테스트: 잘못된 브랜드명 설정
                Console.WriteLine("\n=== 예외 테스트 ===");
                galaxy.Brand = "";  // ArgumentException 발생
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[오류] {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n프로그램 종료 전 리소스 정리 완료.");
            }
        }
    }
  }

//1.기본 OOP

//Smartphone → 추상 클래스 (휴대폰 공통 기능 정의)

//AndroidPhone, IPhone → Smartphone 상속

//Resolution(구조체) → 화면 해상도 표현

//OperatingSystemType(열거형) → 운영체제 종류

//Brand, Model, BatteryLevel 등 속성

//Boot(), UseApp(), Charge() 등 메서드

//2. OOP 4대 원리

//캡슐화: private string brand + public string Brand { get; set; }

//상속: AndroidPhone과 IPhone이 Smartphone을 상속

//다형성: UseApp() → 각 클래스에서 배터리 소모 방식 다르게 구현

//추상화: Smartphone의 abstract 메서드 Boot(), UseApp()

//3.고급 개념

//인터페이스: IChargeable, IConnectable

//구조체: Resolution

//열거형: OperatingSystemType

//이벤트: Charger.OnCharge → 충전 알림

//예외 처리: 빈 브랜드명 입력 시 ArgumentException