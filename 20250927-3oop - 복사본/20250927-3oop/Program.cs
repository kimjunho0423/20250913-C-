using _20250927_3oop;

namespace _20250927_3oop
{
    using System;
    using System.Collections.Generic;

    // ===============================
    // 열거형 (Enum)
    // ===============================
    enum GunType { Pistol, Rifle, Shotgun, Sniper }
    enum AmmoType { NineMM, FiveFiveSix, SevenSixTwo, Shell }

    // ===============================
    // 구조체 (Struct): 사거리 정보
    // ===============================
    struct Range
    {
        public int Min;
        public int Max;
        public Range(int min, int max)
        {
            Min = min; Max = max;
        }

        public override string ToString() => $"{Min}m ~ {Max}m";
    }

    // ===============================
    // 인터페이스 (Interface)
    // ===============================
    interface IShootable
    {
        void Shoot();
        void Reload(int ammo);
    }

    interface IAttachment
    {
        void AttachScope(string scopeName);
    }

    // ===============================
    // 추상 클래스 (Abstract Class)
    // ===============================
    abstract class Gun : IShootable
    {
        // ----- 필드 & 속성 -----
        private string model;              // 캡슐화
        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("모델명은 비어 있을 수 없습니다.");
                model = value;
            }
        }

        public GunType Type { get; protected set; }
        public AmmoType AmmoType { get; protected set; }
        public Range EffectiveRange { get; protected set; }
        public int MagazineCapacity { get; protected set; }
        public int CurrentAmmo { get; protected set; }

        // ----- 생성자 & 소멸자 -----
        public Gun(string model, GunType type, AmmoType ammoType, Range range, int capacity)
        {
            Model = model;
            Type = type;
            AmmoType = ammoType;
            EffectiveRange = range;
            MagazineCapacity = capacity;
            CurrentAmmo = capacity;
            Console.WriteLine($"[생성] {Model} ({Type}) - 탄창: {CurrentAmmo}/{MagazineCapacity}");
        }

        ~Gun()
        {
            Console.WriteLine($"[소멸] {Model}이(가) 장비 목록에서 제거됨.");
        }

        // ----- 메서드 -----
        public abstract void Shoot(); // 추상 메서드 → 자식 클래스가 구현

        public virtual void Reload(int ammo)
        {
            CurrentAmmo += ammo;
            if (CurrentAmmo > MagazineCapacity)
                CurrentAmmo = MagazineCapacity;

            Console.WriteLine($"{Model} → 재장전 완료: {CurrentAmmo}/{MagazineCapacity}");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"모델: {Model}, 타입: {Type}, 탄약: {AmmoType}, 사거리: {EffectiveRange}, 탄창: {CurrentAmmo}/{MagazineCapacity}");
        }
    }

    // ===============================
    // 구체 클래스 (Concrete Classes)
    // ===============================
    class Pistol : Gun
    {
        public Pistol(string model)
            : base(model, GunType.Pistol, AmmoType.NineMM, new Range(5, 50), 15) { }

        public override void Shoot()
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                Console.WriteLine($"{Model} → 빵! ({CurrentAmmo}발 남음)");
            }
            else
            {
                Console.WriteLine($"{Model} → 탄약 부족! 재장전이 필요합니다.");
            }
        }
    }

    class Rifle : Gun, IAttachment
    {
        public Rifle(string model)
            : base(model, GunType.Rifle, AmmoType.FiveFiveSix, new Range(20, 500), 30) { }

        public override void Shoot()
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                Console.WriteLine($"{Model} → 따다다! ({CurrentAmmo}발 남음)");
            }
            else
            {
                Console.WriteLine($"{Model} → 탄약 부족! 재장전이 필요합니다.");
            }
        }

        public void AttachScope(string scopeName)
        {
            Console.WriteLine($"{Model}에 '{scopeName}' 스코프를 장착했습니다.");
        }
    }

    class Shotgun : Gun
    {
        public Shotgun(string model)
            : base(model, GunType.Shotgun, AmmoType.Shell, new Range(2, 40), 8) { }

        public override void Shoot()
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                Console.WriteLine($"{Model} → 펑! ({CurrentAmmo}발 남음)");
            }
            else
            {
                Console.WriteLine($"{Model} → 탄약 부족! 재장전이 필요합니다.");
            }
        }
    }

    // ===============================
    // 이벤트: 탄약 부족 알림
    // ===============================
    class AmmoMonitor
    {
        public event Action<Gun> OnLowAmmo;

        public void CheckAmmo(Gun gun)
        {
            if (gun is null) return;
            if (gun.GetType() == typeof(Pistol) && gun.CurrentAmmo <= 3 ||
                gun.GetType() == typeof(Rifle) && gun.CurrentAmmo <= 5 ||
                gun.GetType() == typeof(Shotgun) && gun.CurrentAmmo <= 2)
            {
                OnLowAmmo?.Invoke(gun);
            }
        }
    }

    // ===============================
    // 프로그램 실행
    // ===============================
    class Program
    {
        static void Main()
        {
            try
            {
                // 총기 생성
                Gun pistol = new Pistol("Glock 19");
                Gun rifle = new Rifle("M4A1");
                Gun shotgun = new Shotgun("Remington 870");

                Console.WriteLine("\n=== 총기 정보 ===");
                pistol.ShowInfo();
                rifle.ShowInfo();
                shotgun.ShowInfo();

                // 부착물 장착
                Rifle r = rifle as Rifle;
                r?.AttachScope("ACOG 4x");

                // 사격 테스트
                Console.WriteLine("\n=== 사격 테스트 ===");
                for (int i = 0; i < 5; i++) pistol.Shoot();
                for (int i = 0; i < 28; i++) rifle.Shoot();
                for (int i = 0; i < 7; i++) shotgun.Shoot();

                // 탄약 부족 이벤트
                AmmoMonitor monitor = new AmmoMonitor();
                monitor.OnLowAmmo += (gun) => Console.WriteLine($"⚠ 경고: {gun.Model}의 탄약이 부족합니다!");

                Console.WriteLine("\n=== 탄약 부족 점검 ===");
                monitor.CheckAmmo(pistol);
                monitor.CheckAmmo(rifle);
                monitor.CheckAmmo(shotgun);

                // 재장전
                Console.WriteLine("\n=== 재장전 ===");
                pistol.Reload(10);
                rifle.Reload(15);
                shotgun.Reload(5);

                // 예외 처리 테스트
                Console.WriteLine("\n=== 예외 테스트 ===");
                pistol.Model = "";  // 잘못된 모델명 → ArgumentException 발생
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

//Gun → 추상 클래스 (모든 총의 공통 기능)

//Pistol, Rifle, Shotgun → Gun 상속

//Range 구조체 → 사거리 표현

//GunType, AmmoType 열거형 → 총기 및 탄약 분류

//Shoot(), Reload() → 메서드

//2. OOP 원리

//캡슐화: private string model + public string Model { get; set; }

//상속: 세부 총기 클래스들이 Gun을 상속

//다형성: Shoot() 메서드를 각 총기별로 다르게 구현

//추상화: Gun 클래스의 추상 메서드 Shoot()

//3. 고급 개념

//인터페이스: IShootable, IAttachment

//구조체: Range로 사거리 정보 관리

//열거형: 총기 종류와 탄약 종류 분류

//이벤트: AmmoMonitor → 탄약 부족 경고

//예외 처리: 빈 모델명 입력 시 ArgumentException