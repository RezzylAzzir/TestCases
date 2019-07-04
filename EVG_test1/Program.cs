using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using asciidrw;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace EVG_test1
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter savefile = new BinaryFormatter();
            Characters chars;
            Queue<string> queuenames = new Queue<string>();
            string typer;
            int i = 0;
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.SetWindowSize(Console.LargestWindowWidth - 3, Console.LargestWindowHeight - 3);
            Asciidraw.drawpic("AGERESTRICT");
            try
            {
                AgeCheck p = new AgeCheck();
                p.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (AgeException ex)
            {
                Console.WriteLine("Error AgeException: " + ex.Message);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(0);
            }
            System.Console.Clear();


            Asciidraw.drawpic("intro");
            System.Console.ReadKey();
            System.Console.Clear();
            
            Console.WriteLine("Do you wanna load your progress(Y/N)");
            typer = Console.ReadLine();
            if (typer.CompareTo("Y") == 0)
            {
                Console.WriteLine("Type the name of save file:");
                typer = Console.ReadLine();
                using (FileStream fs = new FileStream(typer + ".sav", FileMode.Open))
                {
                    
                    
                    chars = (Characters)savefile.Deserialize(fs);
                    Console.WriteLine("Succesfull !");
                }
            }
            else
            {
                chars = new Characters();
                while (i < 4)
                {

                    Asciidraw.drawpic("newcharacter");
                    Console.WriteLine("Set your character name: ");

                    typer = Console.ReadLine();
                    if (typer.CompareTo("GodMode") == 0)
                    {
                        Console.WriteLine("Type correct password : ");
                        typer = Console.ReadLine();
                        if (typer.CompareTo("Murloc") != 0)
                        {
                            Console.WriteLine("Incorrect password");
                            continue;
                        }
                        for (i = 0; i < 4; i++)
                        {
                            chars[i] = new Character{ Name = typer};
                            chars[i].Name = "Godlike Creation";
                            chars[i].Class = "Warrior";
                            chars[i].str = 1500;
                            chars[i].agi = 8000;
                            chars[i].vit = 200000;
                            chars[i].phatk = 25000;
                            chars[i].def = 120000;
                            chars[i].wis = 50000;
                            chars[i].hp = chars[i].vit;
                            chars[i].mp = chars[i].wis;
                            chars[i].ep = chars[i].agi;
                        }
                        break;
                    }
                    else
                    {
                        chars[i] = new Character { Name = typer };
                    }

                    while (true)
                    {
                        System.Console.Clear();
                        Asciidraw.drawpic("Classes");
                        Console.WriteLine("Choose your character class: ");
                        typer = Console.ReadLine();
                        if (typer.CompareTo("Warrior") == 0)
                        {
                            chars[i].Class = typer;
                            System.Console.Clear();
                            Asciidraw.drawpic("Warriorpic");
                            while (true)
                            {
                                Console.WriteLine("Are you satisfied with this class? (Y/N) : ");
                                typer = Console.ReadLine();
                                if (typer.CompareTo("Y") == 0)
                                {
                                    break;
                                }
                                else if (typer.CompareTo("N") == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong character. Try again");
                                    continue;
                                }
                            }
                            if (typer.CompareTo("Y") == 0)
                            {
                                chars[i].str = 15;
                                chars[i].agi = 80;
                                chars[i].vit = 200;
                                chars[i].phatk = 25;
                                chars[i].def = 12;
                                chars[i].wis = 50;
                                chars[i].hp = chars[i].vit;
                                chars[i].mp = chars[i].wis;
                                chars[i].ep = chars[i].agi;
                                break;
                            }
                            else if (typer.CompareTo("N") == 0)
                            {
                                continue;
                            }
                            System.Console.ReadKey();
                        }
                        else if (typer.CompareTo("Wizard") == 0)
                        {

                            chars[i].Class = typer;
                            System.Console.Clear();
                            Asciidraw.drawpic("Wizardpic");
                            while (true)
                            {
                                Console.WriteLine("Are you satisfied with this class? (Y/N) : ");
                                typer = Console.ReadLine();
                                if (typer.CompareTo("Y") == 0)
                                {
                                    break;
                                }
                                else if (typer.CompareTo("N") == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong character. Try again");
                                    continue;
                                }
                            }
                            if (typer.CompareTo("Y") == 0)
                            {
                                chars[i].intl = 17;
                                chars[i].agi = 30;
                                chars[i].vit = 100;
                                chars[i].matk = 35;
                                chars[i].def = 4;
                                chars[i].wis = 200;
                                chars[i].hp = chars[i].vit;
                                chars[i].mp = chars[i].wis;
                                chars[i].ep = chars[i].agi;
                                break;
                            }
                            else if (typer.CompareTo("N") == 0)
                            {
                                continue;
                            }
                            System.Console.ReadKey();
                        }
                        else if (typer.CompareTo("Ranger") == 0)
                        {
                            chars[i].Class = typer;
                            System.Console.Clear();
                            Asciidraw.drawpic("Rangerpic");
                            while (true)
                            {
                                Console.WriteLine("Are you satisfied with this class? (Y/N) : ");
                                typer = Console.ReadLine();
                                if (typer.CompareTo("Y") == 0)
                                {
                                    break;
                                }
                                else if (typer.CompareTo("N") == 0)
                                {

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong character. Try again");
                                    continue;
                                }
                            }

                            if (typer.CompareTo("Y") == 0)
                            {
                                chars[i].str = 8;
                                chars[i].agi = 140;
                                chars[i].vit = 140;
                                chars[i].phatk = 30;
                                chars[i].def = 9;
                                chars[i].wis = 80;
                                chars[i].hp = chars[i].vit;
                                chars[i].mp = chars[i].wis;
                                chars[i].ep = chars[i].agi;
                                break;
                            }
                            else if (typer.CompareTo("N") == 0)
                            {
                                continue;
                            }
                            System.Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("There is no class with that name! Try type it again");
                        }
                    }
                    System.Console.Clear();
                    Console.WriteLine("Set your base characteristics");
                    chars[i].setstat(30);
                    System.Console.Clear();
                    i++;
                }
                System.Console.Clear();
               
                Console.WriteLine("Do you wanna save your characters?(Y/N)");
                typer = Console.ReadLine();
                if (typer.CompareTo("Y") == 0)
                {
                    Console.WriteLine("Type the name of save file:");
                    typer = Console.ReadLine();
                    using (FileStream fs = new FileStream(typer + ".sav", FileMode.Create))
                    {
                        savefile.Serialize(fs, chars);
                        Console.WriteLine("Succesfull save!");
                        
                    }
                }
                else
                {
                    Console.WriteLine("So, you like oldscholl hardcore. Not gonna stop you then.");
                }
            }
            Asciidraw.drawpic("Header");
            Console.WriteLine("Choose Your Reality: Hellheim or Alvheim: ");
            typer = Console.ReadLine();
            if (typer.CompareTo("Hellheim") == 0)
            {



                queuenames.Enqueue("GrimReaper");
                queuenames.Enqueue("Succubus");
                queuenames.Enqueue("Archlord");


            }
            else if (typer.CompareTo("Alvheim") == 0)
            {

                queuenames.Enqueue("Angel");
                queuenames.Enqueue("Unicorn");
                queuenames.Enqueue("CentaurQueen");

            }
            Console.WriteLine("Enjoy your endless journey!\n");
            i = 0;
            
            while (true)
            {
                typer = Console.ReadLine();
                if (typer.CompareTo("Characters") == 0)
                {
                    for (i = 0; i < 4; i++)
                    {
                        chars[i].showinfo();
                    }
                }
                else if (typer.CompareTo("Fight") == 0)
                {
                    Battle enemy = new Battle();

                    System.Console.Clear();
                    Asciidraw.drawpic("Header");
                    
                    enemy.Fight(chars, queuenames, chars.Battlestats);
                    for (int j = 0; j < 4; j++)
                    {
                        chars[j].hp = chars[j].vit;
                        chars[j].ep = chars[j].agi;
                    }
                    

                }
                else if (typer.CompareTo( "Battlestats") == 0)
                {
                    Character.ShowStats(chars.Battlestats);
                }
                else if (typer.CompareTo("Save")==0)
                {
                    Console.WriteLine("Type the name of save file:");
                    typer = Console.ReadLine();
                    using (FileStream fs = new FileStream(typer + ".sav", FileMode.Create))
                    {
                        savefile.Serialize(fs, chars);
                        Console.WriteLine("Succesfull save!");
                    }
                }
                else
                {
                    Console.WriteLine( "Incorrect input, please try again" );
                }


            }
        }
    }
}
