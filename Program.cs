using System;

class Status
{
    public void StatusState(Character character)
    {
        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv. {character.level}");
        Console.WriteLine($"{character.name} ({character.job})");
        Console.WriteLine($"공격력 : {character.attack}");
        Console.WriteLine($"방어력 : {character.defense}");
        Console.WriteLine($"체  력 : {character.hp}");
        Console.WriteLine($"Gold  : {character.gold}G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.Write(">> ");
    }
}
class Character
{
    public int level;
    public string name;
    public string job;
    public float attack;
    public float defense;
    public int hp;
    public int gold;

    public Character()
    {
        level = 1;
        name = "Eat-Dong";
        job = "전사";
        attack = 10;
        defense = 5;
        hp = 100;
        gold = 1500;
    }
}

class Item
{
    public string Name;
    public int Value;
    public string Type;
    public string Description;
    public int Price;
    public int Index;
    
    public Item(string name, int value, string type, string description, int price)
    {
        Name = name;
        Value = value;
        Type = type;
        Description = description;
        Price = price;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Character character = new Character();
        Status status = new Status();

        List<Item> itemList = new List<Item>();

        itemList.Add(new Item("수련자 갑옷", 5, "Armor", "수련에 도움을 주는 갑옷입니다.",1000));
        itemList.Add(new Item("무쇠갑옷", 9, "Armor", "무쇠로 만들어져 튼튼한 갑옷입니다.",0));
        itemList.Add(new Item("스파르타 창", 7, "Weapon", "스파르타 전사들이 사용한 전설의 창입니다.",0));

        bool GameManager = true;

        while (GameManager)
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 >> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    bool inStatus = true;
                    while (inStatus)
                    {
                        status.StatusState(character);
                        string sub = Console.ReadLine();

                        if (sub == "0")
                            inStatus = false;
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("계속하려면 아무 키나 누르세요...");
                            Console.ReadKey();
                        }
                    }
                    break;

                case "2":
                    bool inInventory = true;
                    while (inInventory)
                    {
                        Console.Clear();
                        Console.WriteLine("인벤토리");
                        Console.WriteLine("아이템 목록이 표시됩니다. (아직 구현되지 않음)");
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.Write(">> ");
                        string sub = Console.ReadLine();

                        if (sub == "0")
                            inInventory = false;
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("계속하려면 아무 키나 누르세요...");
                            Console.ReadKey();
                        }
                    }
                    break;

                case "3":
                    bool inShop = true;
                    while (inShop)
                    {
                        Console.Clear();
                        Console.WriteLine("상점");
                        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                        Console.WriteLine();
                        Console.WriteLine("[보유 골드]");
                        Console.WriteLine($"{character.gold}");
                        Console.WriteLine();
                        Console.WriteLine("[아이템 목록]");

                        Console.WriteLine("0. 나가기");
                        Console.Write(">> ");
                        string sub = Console.ReadLine();

                        if (sub == "0")
                            inShop = false;
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("계속하려면 아무 키나 누르세요...");
                            Console.ReadKey();
                        }
                    }
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Console.WriteLine("계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("게임을 종료합니다. 안녕히 가세요!");
    }
}
