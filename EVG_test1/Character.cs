using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asciidrw;
using System.Globalization;

namespace EVG_test1
{
    [Serializable]
    public class Character
    {
        public CharacterMessages msgs;

        private int Typen;
        public string Name { get; set; }

        public int typen
        {
            get { return Typen; }
            set { this.Typen = value >= 0 ? value : 0; }
        }
        public Character()
        {

            lvl = 1;
            str = 1;
            intl = 1;
            agi = 30;
            phatk = 1;
            matk = 1;
            def = 1;
            vit = 100;
            wis = 50;
            hp = vit;
            gold = 0;
            exp = 0;
            msgs = new CharacterMessages();
            msgs.RaiseCustomEvent += Messaging;
        }

        private void Messaging(object sender, CustomEventArgs e)
        {
            Random rand = new Random();
            switch (rand.Next(1, 4))
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Name + ": Haha, get this, damn piece of monster trash!");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Name + ": And you call it a strength? Patethic!");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Name + ": Soooo boring... Just die already.");
                    Console.ResetColor();
                    break;
                default:
                    break;

            }
        }



        public void setstat(int count)
        {


            string typech;
            while (true)
            {

                System.Console.Clear();
                Asciidraw.drawpic("SetStat");
                if (count < 1)
                {
                    Console.WriteLine("You have 0 characteristics points");
                    System.Console.ReadKey();

                    break;
                }
                Console.WriteLine("You have " + count + " characteristics points\n");
                Console.WriteLine("Type stat to increase (Strength, Intelligence, Agility, Wisdom, Vitality. Each 1 point spent on Agi/Wis/Vit increasing stat by 5) :");
                typech = Console.ReadLine();
                if (typech.CompareTo("Strength") == 0)
                {
                    Console.WriteLine("Type requiered amount: ");
                    typen = Convert.ToInt32(Console.ReadLine());
                    if (typen > count)
                    {
                        Console.WriteLine("Not enough points. Try again");
                        continue;
                    }
                    str = str + typen;
                    count = count - typen;
                    continue;
                }
                else if (typech.CompareTo("Intelligence") == 0)
                {
                    Console.WriteLine("Type requiered amount: ");
                    typen = Convert.ToInt32(Console.ReadLine());
                    if (typen > count)
                    {
                        Console.WriteLine("Not enough points. Try again");
                        continue;
                    }
                    intl = intl + typen;
                    count = count - typen;
                    continue;
                }
                else if (typech.CompareTo("Agility") == 0)
                {
                    Console.WriteLine("Type requiered amount: ");
                    typen = Convert.ToInt32(Console.ReadLine());
                    if (typen > count)
                    {
                        Console.WriteLine("Not enough points. Try again");
                        continue;
                    }
                    agi = agi + typen * 5;
                    ep = agi;
                    count = count - typen;
                    continue;
                }
                else if (typech.CompareTo("Wisdom") == 0)
                {
                    Console.WriteLine("Type requiered amount: ");
                    typen = Convert.ToInt32(Console.ReadLine());
                    if (typen > count)
                    {
                        Console.WriteLine("Not enough points. Try again");
                        continue;
                    }
                    wis = wis + typen * 5;
                    mp = wis;
                    count = count - typen;
                    continue;
                }
                else if (typech.CompareTo("Vitality") == 0)
                {
                    Console.WriteLine("Type requiered amount: ");
                    typen = Convert.ToInt32(Console.ReadLine());
                    if (typen > count)
                    {
                        Console.WriteLine("Not enough points. Try again");
                        continue;
                    }
                    vit = vit + typen * 5;
                    hp = vit;
                    count = count - typen;
                    continue;
                }
                else
                {
                    Console.WriteLine("Incorrect characteristic. Try again");
                }

            }
        }
        public int str;
        public int lvl;
        public int intl;
        public int agi;
        public int ep;
        public int vit;
        public int hp;
        public int matk;
        public int phatk;
        public int def;
        public int wis;
        public int mp;
        public int gold;
        public int exp;
        public string Class;
        public void showinfo()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Class: " + Class);
            Console.WriteLine("Strength: " + str);
            Console.WriteLine("Intelligence: " + intl);
            Console.WriteLine("Agility: " + agi);
            Console.WriteLine("Phisical Attack: " + phatk);
            Console.WriteLine("Magic Attack: " + matk);
            Console.WriteLine("Defence: " + def);
            Console.WriteLine("Vitality: " + vit);
            Console.WriteLine("Wisdom: " + wis);
            Console.WriteLine("Exp: " + exp);
            Console.WriteLine("Gold coins: " + gold);
        }
        public void CheckLvlUp()
        {
            if (exp > 99)
            {
                lvl++;
                setstat(10);
                exp = exp - 100;
            }
            else
            {
                return;
            }
        }

        public static void ShowStats(IEnumerable<string> myCollection)
        {
            foreach (string str in myCollection)
                Console.WriteLine("    {0}", str);
        }
    }
    [Serializable]
    public class Characters
    {

        public Queue<string> Battlestats;
        Character[] data;
        public Characters()
        {
            Battlestats = new Queue<string>(10);
            data = new Character[4];
        }
        public Character this[int index]
        {
            get
            {
                return data[index];

            }
            set
            {
                data[index] = value;
            }
        }


    }
    public class Hostile : Character
    {
        public Hostile(int enemy_lvl, Queue<string> names, CharacterMessages msgs)
        {

            Random rand = new Random();
            lvl = enemy_lvl;
            if (lvl > 4 && lvl < 10)
            {
                if (names.Peek().CompareTo("GrimReaper") == 0)
                {
                    names.Dequeue();
                }
                if (names.Peek().CompareTo("Angel") == 0)
                {
                    names.Dequeue();
                }
                lvl = lvl + rand.Next(1, 3);
            }
            if (lvl == 10)
            {
                if (names.Peek().CompareTo("Succubus") == 0)
                {
                    names.Dequeue();
                }
                if (names.Peek().CompareTo("Unicorn") == 0)
                {
                    names.Dequeue();
                }
                lvl = lvl + rand.Next(2, 6);
            }
            Name = names.Peek();
            Class = "Monster";
            str = 15 + (4 * lvl);
            intl = 17 + (4 * lvl);
            agi = 140 + (70 * lvl);
            phatk = 30 + (8 * lvl);
            matk = 35 + (8 * lvl);
            def = 12 + (4 * lvl);
            vit = 100 + (80 * lvl);
            hp = vit;
            wis = 200 + (70 * lvl);
            gold = rand.Next(1, 21);
            exp = 0;
        }
    }
    class AgeException : Exception
    {
        public AgeException(string message)
            : base(message)
        { }
    }
    public class AgeCheck
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    throw new AgeException("Users under 18 y.o. restricted from playing this game");
                }

                else
                {
                    age = value;
                }
            }

        }
    }
}