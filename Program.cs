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
    public double attack;
    public int defense;
    public int hp;
    public float gold;
    public int exp;

    public List<Item> inventory = new List<Item>();



    public Character()
    {
        level = 1;
        name = "곽철이";
        job = "도적";
        attack = 10;
        defense = 5;
        hp = 1000;
        gold = 1500;
        exp = 0;
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

    struct ClearMoney
{
    public int Money;

    public ClearMoney(int money)
    {
        Money = money;
    }
    public static ClearMoney Easy = new ClearMoney(1000);
    public static ClearMoney Normal = new ClearMoney(1700);
    public static ClearMoney Hard = new ClearMoney(2500);
}

class Program
{
    static void Main(string[] args)
    {
        Character character = new Character();
        Status status = new Status();

        
        ClearMoney Easy = new ClearMoney(1000);
        ClearMoney Normal = new ClearMoney(1700);
        ClearMoney Hard = new ClearMoney(2500);



        List<Item> itemList = new List<Item>()
        {
            new Item("[일반]", "수련자 갑옷    ", 5,  "방어력", " 갑옷",  "수련에 도움을 주는 갑옷입니다.                   ",1000),
            new Item("[일반]", "무쇠갑옷       ", 9,  "방어력", " 갑옷",  "무쇠로 만들어져 튼튼한 갑옷입니다.               ",2000),
            new Item("[고급]", "스파르타의 창  ", 7,  "공격력", " 무기",  "스파르타 전사들이 사용한 전설의 창입니다.        ",3500),
            new Item("[고급]", "스파르타의 갑옷", 15, "방어력", " 갑옷",  "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",3500),
            new Item("[일반]", "낡은 검        ", 2,  "공격력", " 무기",  "쉽게 볼 수 있는 낡은 검 입니다.                  ",600),
            new Item("[일반]", "청동 도끼      ", 5,  "공격력", " 무기",  "어디선가 사용됐던거 같은 도끼입니다.             ",1500),
            new Item("[에픽]", "진명황의 집판검", 777,"공격력", " 무기",  "한때 리니지에서 엄청난 무기입니다                ",1000000),
            new Item("[에픽]", "진명황의 갑옷  ", 777,"방어력", " 갑옷",  "진명황의 집판검과 세트효과를 제공합니다.         ",1000000)
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
                            int Easy_Defense = 5;
                            int Normal_Defense = 11;
                            int Hard_Defense = 17;
                            int temp_exp = 0;

                            Console.Clear();
                            Console.WriteLine("던전입장");
                            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                            Console.WriteLine();
                            Console.WriteLine($"1. 쉬운 던전     | 방어력 {Easy_Defense}이상 권장");
                            Console.WriteLine($"2. 일반 던전     | 방어력 {Normal_Defense}이상 권장");
                            Console.WriteLine($"3. 어려운 던전   | 방어력 {Hard_Defense}이상 권장");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            Console.Write(">> ");
                            string sub = Console.ReadLine();

                         
                            if (sub == "0") Dun = false;
                            else if (sub == "1")
                            {
                                if (character.hp < 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("체력이 없습니다. 휴식하세요");
                                    Console.ReadKey();
                                    Dun = false;
                                }

                                if (character.defense >= Easy_Defense)
                                {
                                    Console.Clear();
                                    Console.Write("던전 소탕중");
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                    }
                                    Console.WriteLine();
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.WriteLine("던전 클리어!");
                                    Console.ReadKey();

                                    Random rand=new Random();
                                    int number = rand.Next(20,35);

                                    int temp_Defense = 0;
                                    int temp_attack = 0;

                                    temp_Defense = character.defense - Easy_Defense;

                                    int temp_hp = character.hp;
                                    character.hp = (character.hp - number - temp_Defense);

                                    if (character.hp < 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("던전 공략 중 HP가 모자라서 실패ㅜㅜ");
                                        Console.WriteLine("체력이 없습니다. 휴식하세요");
                                        Console.ReadKey();
                                        Dun = false;
                                    }

                                    else
                                    {
                                        character.exp += 1;

                                        Console.WriteLine($"잔여 HP는 {temp_hp}-({number - temp_Defense})={character.hp}입니다.");
                                        Console.ReadKey();
                                        Console.WriteLine();

                                        Random m_rand = new Random();
                                        float M_number = m_rand.Next((int)character.attack, (int)character.attack * 2);

                                        Console.WriteLine($"던전 클리어 보상은 {Easy.Money}+보너스({M_number})%적용 = {Easy.Money + ((Easy.Money * (M_number / 100)))}G입니다");
                                        character.gold += Easy.Money + ((Easy.Money * (M_number / 100)));
                                        Console.WriteLine($"");
                                        Console.WriteLine();
                                        Console.WriteLine($"현재 플레이어 골드는 {character.gold}G입니다");
                                        Console.ReadKey();

                                        if(character.level==1)
                                        {
                                            if(character.exp == 1)
                                            {
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.Clear ();
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();
                                            }
                                        }
                                        if (character.level == 2)
                                        {
                                            if (character.exp == 2)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 3)
                                        {
                                            if (character.exp == 3)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 4)
                                        {
                                            if (character.exp == 4)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                                if (character.level == 5)
                                                {
                                                    character.job = "꽉꽉"+character.job;

                                                    Console.Clear();
                                                    Console.WriteLine("오잉?");

                                                    for (int i = 0; i < 3; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write(".");
                                                    }
                                                    Console.WriteLine("내 몸에서 무슨 일이 일어나는거지?");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();

                                                    Console.WriteLine("으아아아아아아악");
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("안");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("돼");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("!");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    Console.WriteLine($"축하합니다. 당신은 레벨{character.level}달성으로 [{character.job}]으로 전직하였습니다.");
                                                    Console.WriteLine("전직 보너스");
                                                    Console.WriteLine($"공격력 + {10} = {character.attack += 10}");
                                                    Console.WriteLine($"방어력 + {10} = {character.defense += 10}");
                                                    Console.WriteLine($"체력 + {10} = {character.hp += 10}");
                                                    Console.ReadKey();
                                                    Console.Clear();

                                                    Console.WriteLine($"[Lv. {character.level}]");
                                                    Console.WriteLine($"{character.name} ({character.job})");
                                                    Console.WriteLine($"공격력 : {character.attack}");
                                                    Console.WriteLine($"방어력 : {character.defense}");
                                                    Console.WriteLine($"체  력 : {character.hp}");
                                                    Console.WriteLine($"Gold   : {character.gold}G");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Random rand = new Random();
                                    int R_number = rand.Next(1, 11);

                                    if(R_number == 1)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");
                                        Console.ReadKey();
                                        character.hp = character.hp / 2;
                                    }
                                    else if (R_number == 3)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");
                                        Console.ReadKey();
                                        character.hp = character.hp / 2;
                                    }
                                    else if (R_number == 5)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");
                                        Console.ReadKey();
                                        character.hp = character.hp / 2;
                                    }
                                    else if (R_number == 7)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");
                                        Console.ReadKey();
                                        character.hp = character.hp / 2;
                                    }
                                }
                            }
                            else if (sub == "2")
                            {
                                if (character.hp < 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("체력이 없습니다. 휴식하세요");
                                    Console.ReadKey();
                                    Dun = false;
                                }

                                if (character.defense >= Normal_Defense)
                                {
                                    Console.Clear();
                                    Console.Write("던전 소탕중");
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                    }
                                    Console.WriteLine();
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.WriteLine("던전 클리어!");
                                    Console.ReadKey();

                                    Random rand = new Random();
                                    int number = rand.Next(20, 35);

                                    int temp_Defense = 0;
                                    int temp_attack = 0;

                                    temp_Defense = character.defense - Normal_Defense;

                                    int temp_hp = character.hp;
                                    character.hp = (character.hp - number - temp_Defense);

                                    if (character.hp < 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("던전 공략 중 HP가 모자라서 실패ㅜㅜ");
                                        Console.WriteLine("체력이 없습니다. 휴식하세요");
                                        Console.ReadKey();
                                        Dun = false;
                                    }

                                    else
                                    {
                                        character.exp += 1;

                                        Console.WriteLine($"잔여 HP는 {temp_hp}-({number - temp_Defense})={character.hp}입니다.");
                                        Console.ReadKey();
                                        Console.WriteLine();

                                        Random m_rand = new Random();
                                        float M_number = m_rand.Next((int)character.attack, (int)character.attack * 2);

                                        Console.WriteLine($"던전 클리어 보상은 {Normal.Money}+보너스({M_number})%적용 = {Normal.Money + ((Normal.Money * (M_number / 100)))}G입니다");
                                        character.gold += Normal.Money + ((Normal.Money * (M_number / 100)));
                                        Console.WriteLine($"");
                                        Console.WriteLine();
                                        Console.WriteLine($"현재 플레이어 골드는 {character.gold}G입니다");
                                        Console.ReadKey();

                                        if (character.level == 1)
                                        {
                                            if (character.exp == 1)
                                            {
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();
                                            }
                                        }
                                        if (character.level == 2)
                                        {
                                            if (character.exp == 2)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 3)
                                        {
                                            if (character.exp == 3)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 4)
                                        {
                                            if (character.exp == 4)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                                if (character.level == 5)
                                                {
                                                    character.job = "꽉꽉"+character.job;

                                                    Console.Clear();
                                                    Console.WriteLine("오잉?");

                                                    for (int i = 0; i < 3; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write(".");
                                                    }
                                                    Console.WriteLine("내 몸에서 무슨 일이 일어나는거지?");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();

                                                    Console.WriteLine("으아아아아아아악");
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("안");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("돼");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("!");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    Console.WriteLine($"축하합니다. 당신은 레벨{character.level}달성으로 [{character.job}]으로 전직하였습니다.");
                                                    Console.WriteLine("전직 보너스");
                                                    Console.WriteLine($"공격력 + {10} = {character.attack += 10}");
                                                    Console.WriteLine($"방어력 + {10} = {character.defense += 10}");
                                                    Console.WriteLine($"체력 + {10} = {character.hp += 10}");
                                                    Console.ReadKey();
                                                    Console.Clear();

                                                    Console.WriteLine($"[Lv. {character.level}]");
                                                    Console.WriteLine($"{character.name} ({character.job})");
                                                    Console.WriteLine($"공격력 : {character.attack}");
                                                    Console.WriteLine($"방어력 : {character.defense}");
                                                    Console.WriteLine($"체  력 : {character.hp}");
                                                    Console.WriteLine($"Gold   : {character.gold}G");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Random rand = new Random();
                                    int R_number = rand.Next(1, 11);

                                    if (R_number == 1)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");
                                        
                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 3)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 5)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 7)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        Console.WriteLine("던전 공략은 실패했지만 운좋게 체력이 달지않았습니다");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else if (sub == "3")
                            {
                                if (character.hp < 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("체력이 없습니다. 휴식하세요");
                                    Console.ReadKey();
                                    Dun = false;
                                }

                                if (character.defense >= Hard_Defense)
                                {
                                    Console.Clear();
                                    Console.Write("던전 소탕중");
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                    }
                                    Console.WriteLine();
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.WriteLine("던전 클리어!");
                                    Console.ReadKey();

                                    Random rand = new Random();
                                    int number = rand.Next(20, 35);

                                    int temp_Defense = 0;
                                    int temp_attack = 0;

                                    temp_Defense = character.defense - Hard_Defense;

                                    int temp_hp = character.hp;
                                    character.hp = (character.hp - number - temp_Defense);

                                    if (character.hp < 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("던전 공략 중 HP가 모자라서 실패ㅜㅜ");
                                        Console.WriteLine("체력이 없습니다. 휴식하세요");
                                        Console.ReadKey();
                                        Dun = false;
                                    }

                                    else
                                    {
                                        character.exp += 1;

                                        Console.WriteLine($"잔여 HP는 {temp_hp}-({number - temp_Defense})={character.hp}입니다.");
                                        Console.ReadKey();
                                        Console.WriteLine();

                                        Random m_rand = new Random();
                                        float M_number = m_rand.Next((int)character.attack, (int)character.attack * 2);

                                        Console.WriteLine($"던전 클리어 보상은 {Easy.Money}+보너스({M_number})%적용 = {Hard.Money + ((Hard.Money * (M_number / 100)))}G입니다");
                                        character.gold += Hard.Money + ((Hard.Money * (M_number / 100)));
                                        Console.WriteLine($"");
                                        Console.WriteLine();
                                        Console.WriteLine($"현재 플레이어 골드는 {character.gold}G입니다");
                                        Console.ReadKey();

                                        if (character.level == 1)
                                        {
                                            if (character.exp == 1)
                                            {
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();
                                            }
                                        }
                                        if (character.level == 2)
                                        {
                                            if (character.exp == 2)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 3)
                                        {
                                            if (character.exp == 3)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                            }
                                        }
                                        if (character.level == 4)
                                        {
                                            if (character.exp == 4)
                                            {
                                                Console.Clear();
                                                character.defense += 1;
                                                character.attack += 0.5;
                                                character.exp = 0;
                                                character.level += 1;
                                                Console.WriteLine();
                                                Console.WriteLine("축하합니다 레벨업입니다.");
                                                Console.WriteLine("빠바바바바밤.");
                                                Console.WriteLine($"당신의 레벨은{character.level}가 되었습니다.");
                                                Console.ReadKey();

                                                if (character.level == 5)
                                                {
                                                    character.job += "꽉꽉";

                                                    Console.Clear();
                                                    Console.WriteLine("오잉?");

                                                    for (int i = 0; i < 3; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write(".");
                                                    }
                                                    Console.WriteLine("내 몸에서 무슨 일이 일어나는거지?");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();

                                                    Console.WriteLine("으아아아아아아악");
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("안");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("돼");
                                                    }
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Thread.Sleep(500);
                                                        Console.Write("!");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    Console.WriteLine($"축하합니다. 당신은 레벨{character.level}달성으로 [{character.job}]으로 전직하였습니다.");
                                                    Console.WriteLine("전직 보너스");
                                                    Console.WriteLine($"공격력 + {10} = {character.attack += 10}");
                                                    Console.WriteLine($"방어력 + {10} = {character.defense += 10}");
                                                    Console.WriteLine($"체력 + {10} = {character.hp += 10}");
                                                    Console.ReadKey();
                                                    Console.Clear();

                                                    Console.WriteLine($"[Lv. {character.level}]");
                                                    Console.WriteLine($"{character.name} ({character.job})");
                                                    Console.WriteLine($"공격력 : {character.attack}");
                                                    Console.WriteLine($"방어력 : {character.defense}");
                                                    Console.WriteLine($"체  력 : {character.hp}");
                                                    Console.WriteLine($"Gold   : {character.gold}G");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Random rand = new Random();
                                    int R_number = rand.Next(1, 11);

                                    if (R_number == 1)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 3)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 5)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else if (R_number == 7)
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        character.hp = character.hp / 2;
                                        Console.WriteLine($"던전 공략 실패로 체력이 50% 감소하여 {character.hp}이 되었습니다.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.Write("던전 소탕중");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Thread.Sleep(500);
                                            Console.Write(".");
                                        }
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        Console.WriteLine("던전 실패!");

                                        Console.WriteLine("던전 공략은 실패했지만 운좋게 체력이 달지않았습니다");
                                        Console.ReadKey();
                                    }
                                }
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
