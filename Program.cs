using System;

class Status
{
    public void StatusState(Character character)
    {
        float equippedAttack = 0;
        float equippedDefense = 0;

        foreach (Item item in character.inventory)
        {
            if (item.IsEquipped)
            {
                if (item.Type == "공격력") equippedAttack += item.Value;
                if (item.Type == "방어력") equippedDefense += item.Value;
            }
        }

        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();
        Console.WriteLine($"[Lv. {character.level}]");
        Console.WriteLine($"{character.name} ({character.job})");
        Console.WriteLine($"공격력 : {character.attack}  (스텟:{character.attack - equippedAttack} + (무기:{equippedAttack})");
        Console.WriteLine($"방어력 : {character.defense}   (스텟:{character.defense - equippedDefense}  + (갑옷:{equippedDefense})");
        Console.WriteLine($"체  력 : {character.hp}");
        Console.WriteLine($"Gold   : {character.gold}G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
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

    public List<Item> inventory = new List<Item>();



    public Character()
    {
        level = 1;
        name = "곽철이";
        job = "꽉꽉도적";
        attack = 10;
        defense = 5;
        hp = 100;
        gold = 1500000000;
    }
}

class Item
{
    public string Name;
    public int Value;
    public string Type;
    public string Description;
    public int Price;
    public bool IsEquipped = false;
    public bool IsPurchased = false;
    public string Grade;
    public string Part;

    public Item(string grade, string name, int value, string type, string part, string description, int price)
    {
        Name = name;
        Value = value;
        Type = type;
        Description = description;
        Price = price;
        Grade = grade;
        Part = part;
    }

    public void PrintInfo()
    {
        string priceText;
        if (IsPurchased)
        {
            priceText = "구매완료";
        }
        else
        {
            priceText = $"{Price}G";
        }
        Console.WriteLine($"- {Grade}{Name}| {Type} +{Value,3} |{Part} | {Description} | {priceText}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character character = new Character();
        Status status = new Status();

        List<Item> itemList = new List<Item>()
        {
            new Item("[일반]", "수련자 갑옷    ", 5,  "방어력", " 갑옷",  "수련에 도움을 주는 갑옷입니다.                   ",1000),
            new Item("[일반]", "무쇠갑옷       ", 9,  "방어력", " 갑옷",  "무쇠로 만들어져 튼튼한 갑옷입니다.               ",2000),
            new Item("[고급]", "스파르타의 창  ", 7,  "공격력", " 무기",  "스파르타 전사들이 사용한 전설의 창입니다.        ",3500),
            new Item("[고급]", "스파르타의 갑옷", 15, "방어력", " 갑옷",  "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",3500),
            new Item("[일반]", "낡은 검        ", 2,  "공격력", " 무기",  "쉽게 볼 수 있는 낡은 검 입니다.                  ",600),
            new Item("[일반]", "청동 도끼      ", 5,  "공격력", " 무기",  "어디선가 사용됐던거 같은 도끼입니다.             ",1500),
            new Item("[에픽]", "진명황의 집판점", 777,"공격력", " 무기",  "던붕이들은 아는 그런 무기입니다.                 ",1000000),
            new Item("[에픽]", "진명황의 갑옷  ", 777,"방어력", " 갑옷",  "던붕이들은 아는 그런 무기입니다.                 ",1000000)
        };

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
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    bool inStatus = true;
                    while (inStatus)
                    {
                        status.StatusState(character);
                        string sub = Console.ReadLine();

                        if (sub == "0") inStatus = false;
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
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
                        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                        Console.WriteLine();
                        Console.WriteLine("[아이템 목록]");
                        if (character.inventory.Count == 0)
                        {
                            Console.WriteLine("보유한 아이템이 없습니다.");
                        }
                        else
                        {
                            for (int i = 0; i < character.inventory.Count; i++)
                            {
                                Item item = character.inventory[i];
                                string equippedMark = item.IsEquipped ? "[E]" : "   ";
                                Console.WriteLine($"- {equippedMark}{item.Name} | {item.Type} +{item.Value} | {item.Description}");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("1. 장착 관리");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        string equipInput = Console.ReadLine();

                        if (equipInput == "0") inInventory = false;
                        else if (equipInput == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("장착 가능한 아이템 목록");
                            Console.WriteLine();

                            for (int i = 0; i < character.inventory.Count; i++)
                            {
                                Item item = character.inventory[i];
                                string equippedMark = item.IsEquipped ? "[E]" : "   ";
                                Console.WriteLine($"{i + 1}. {equippedMark}{item.Name} | {item.Type} +{item.Value} | {item.Description}");
                            }

                            Console.WriteLine();
                            Console.WriteLine("장착할 아이템 번호를 입력해주세요 (1 ~ N, 0. 취소) >> ");
                            string numInput = Console.ReadLine();

                            if (int.TryParse(numInput, out int idx) && idx >= 1 && idx <= character.inventory.Count)
                            {
                                Item selectedItem = character.inventory[idx - 1];

                                foreach (Item item in character.inventory)
                                {
                                    if (item.Type == selectedItem.Type && item.IsEquipped)
                                    {
                                        if (item.Type == "공격력") character.attack -= item.Value;
                                        if (item.Type == "방어력") character.defense -= item.Value;
                                        item.IsEquipped = false;
                                    }
                                }

                                selectedItem.IsEquipped = true;
                                if (selectedItem.Type == "공격력") character.attack += selectedItem.Value;
                                if (selectedItem.Type == "방어력") character.defense += selectedItem.Value;

                                Console.WriteLine();
                                Console.WriteLine($"{selectedItem.Name.Trim()}을(를) 장착했습니다!");
                                Console.ReadKey();
                            }
                            else if (idx == 0)
                            {
                                
                            }
                            else
                            {
                                Console.WriteLine("잘못된 번호입니다.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
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
                        Console.WriteLine($"[보유 골드] {character.gold}G");
                        Console.WriteLine("                                     [아이템 목록]");

                        for (int i = 0; i < itemList.Count; i++)
                        {
                            Console.Write($"{i + 1}. ");
                            itemList[i].PrintInfo();
                        }

                        Console.WriteLine();
                        Console.WriteLine("1. 아이템 구매");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        string sub = Console.ReadLine();

                        if (sub == "0") inShop = false;
                        else if (sub == "1")
                        {
                            Console.Write("구매할 아이템 번호를 입력하세요 (0. 취소) >> ");
                            string buyInput = Console.ReadLine();

                            if (int.TryParse(buyInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= itemList.Count)
                            {
                                Item selectedItem = itemList[selectedIndex - 1];

                                if (selectedItem.Price == 0)
                                {
                                    Console.WriteLine("이 아이템은 구매할 수 없습니다.");
                                }
                                else if (selectedItem.IsPurchased)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                }
                                else if (character.gold >= selectedItem.Price)
                                {
                                    character.gold -= selectedItem.Price;
                                    selectedItem.IsPurchased = true;
                                    character.inventory.Add(selectedItem);
                                    Console.WriteLine($"{selectedItem.Name.Trim()}을(를) 구매했습니다!");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("소지금이 부족합니다.");
                                }
                            }
                            else if (selectedIndex == 0) { }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadKey();
                        }
                    }
                    break;

                case "4":
                    {
                        bool Dun = true;
                        while (Dun)
                        {
                            Console.Clear();
                            Console.WriteLine("던전입장");
                            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                            Console.WriteLine();
                            Console.WriteLine("1. 쉬운 던전     | 방어력 5이상 권장");
                            Console.WriteLine("2. 일반 던전     | 방어력 11이상 권장");
                            Console.WriteLine("3. 어려운 던전   | 방어력 17이상 권장");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            Console.Write(">> ");
                            string sub = Console.ReadLine();

                            if (sub == "0") Dun = false;
                            else if (sub == "1")
                            {

                            }
                            else if (sub == "2")
                            {

                            }
                            else if (sub == "3")
                            {

                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                    break;

                case "5":
                    {
                        bool rest = true;
                        while (rest)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("휴식하기");
                            Console.WriteLine($"500G를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.gold}G)");
                            Console.WriteLine();
                            Console.WriteLine("1. 휴식하기");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            Console.Write(">> ");

                            string sub = Console.ReadLine();

                            if (sub == "0")
                            {
                                rest = false;
                            }
                            else if (sub == "1")
                            {
                                if (character.gold >= 500)
                                {
                                    int temp_hp = 0;

                                    temp_hp = (100 - character.hp);
                                    character.hp += temp_hp;

                                    character.gold -= 500;
                                    Console.WriteLine();
                                    Console.WriteLine("휴식을 완료했습니다.");
                                    Console.WriteLine($"현재 체력은 {character.hp}입니다.");
                                    Console.WriteLine();
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Gold가 부족합니다.");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다");
                            }
                        }
                    }
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
