using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asciidrw;

namespace EVG_test1
{
    class Battle
    {
        public void Fight(Characters chars, Queue<string> names, Queue<string> Battlestats)
        {
            int en_turn = 1;
            int i = 0;
            Hostile hostile = new Hostile(chars[i].lvl, names,chars[i].msgs);
            System.Console.Clear();
            Asciidraw.drawpic("Header");
            if (hostile.Name.CompareTo("Succubus") == 0)
            {
                Asciidraw.drawpic("Succubus");
            }
            else if (hostile.Name.CompareTo("GrimReaper") == 0)
            {
                Asciidraw.drawpic("GrimReaper");
            }
            else if (hostile.Name.CompareTo("Archlord") == 0)
            {
                Asciidraw.drawpic("Archlord");
            }
            else if (hostile.Name.CompareTo("CentaurQueen") == 0)
            {
                Asciidraw.drawpic("CentaurQueen");
            }
            else if (hostile.Name.CompareTo("Unicorn") == 0)
            {
                Asciidraw.drawpic("Unicorn");
            }
            else
            {
                Asciidraw.drawpic("Angel");
            }
            Console.WriteLine(hostile.Name + " spotted");
            Console.WriteLine("Enemy level: " + hostile.lvl);

            hostile.showinfo();
            while (true)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (chars[i].hp < 1)
                    {
                        if (i == 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }

                    }
                    else
                    {
                        break;
                    }
                    if (j == 3)
                    {
                        Console.WriteLine("All Your Characters Died! Game Over!");
                        System.Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                
                if (chars[i].Class.CompareTo("Warrior") == 0)
                {
                    WarriorBattle(hostile, chars[i], en_turn,Battlestats, chars[i].msgs);
                }
                else if (chars[i].Class.CompareTo("Wizard") == 0)
                {
                    WizardBattle(hostile, chars[i], en_turn, Battlestats, chars[i].msgs);
                }
                else if (chars[i].Class.CompareTo("Ranger") == 0)
                {
                    RangerBattle(hostile, chars[i], en_turn, Battlestats, chars[i].msgs);

                }
                if (hostile.hp < 1)
                {
                    break;
                }
                if (i == 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }


        }

        public void WarriorBattle(Hostile hostile, Character character, int enemy_turn,Queue<string> Battlestats, CharacterMessages msgs)
        {
            
            string typech;
            int typen;
            Console.WriteLine("Type <<Skill_list>> to begin fight");
            while (true)
            {
                typech = Console.ReadLine();
                if (typech.CompareTo("Skill_list") == 0)
                {
                    System.Console.Clear();
                    Asciidraw.drawpic("Header");
                    if (hostile.Name.CompareTo("Succubus") == 0)
                    {
                        Asciidraw.drawpic("Succubus");
                    }
                    else if (hostile.Name.CompareTo("GrimReaper") == 0)
                    {
                        Asciidraw.drawpic("GrimReaper");
                    }
                    else if (hostile.Name.CompareTo("Archlord") == 0)
                    {
                        Asciidraw.drawpic("Archlord");
                    }
                    else if (hostile.Name.CompareTo("CentaurQueen") == 0)
                    {
                        Asciidraw.drawpic("CentaurQueen");
                    }
                    else if (hostile.Name.CompareTo("Unicorn") == 0)
                    {
                        Asciidraw.drawpic("Unicorn");
                    }
                    else
                    {
                        Asciidraw.drawpic("Angel");
                    }
                    CharactersAbilities.WarriorShowSkillList();
                    Console.WriteLine("Choose skill number:");
                    typen = Convert.ToInt32(Console.ReadLine());
                    switch (typen)
                    {
                        case 1:

                            hostile.hp = hostile.hp - CharactersAbilities.Autoattack(character.str, character.phatk);
                            break;
                        case 2:
                            if ((50 + 20 * character.lvl) < character.ep)
                            {
                                character.ep = character.ep - (50 + 20 * character.lvl);
                                hostile.hp = hostile.hp - CharactersAbilities.RageSlash(character.str, character.phatk);
                            }
                            else
                            {
                                Console.WriteLine("Not enough energy. Try to use another skill");
                                continue;
                            }

                            break;
                        case 3:

                            character.ep = character.ep + CharactersAbilities.EnergyRegeneration(character.agi, character.lvl);
                            if (character.ep > character.agi)
                            {
                                character.ep = character.agi;
                            }
                            break;
                        default:
                            break;
                    }
                    if(hostile.hp >(100*hostile.lvl) && hostile.hp < (200*hostile.lvl))
                    {
                        msgs.Message(hostile.Name, hostile.hp);
                    }

                }
                else
                {
                    Console.WriteLine("Incorrect text! Type Skill_list to choose skill: ");
                    continue;
                }
                if (character.hp < 1)
                {
                    Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    break;
                }
                else if (hostile.hp < 1)
                {
                    if (character.lvl == 10)
                    {
                        System.Console.Clear(); 
                        Asciidraw.drawpic("GoodGameOver");
                        Console.WriteLine("You defetead the most powerful enemy, and now Evergarden can finally be at peace! You have done an unbelievable job, and many centuries further your name will be in every single ballad!");
                        System.Console.ReadKey();
                        System.Console.ReadKey();
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Congratulations, you won!");
                    character.exp = character.exp + hostile.lvl * 5;
                    character.CheckLvlUp();
                    Console.WriteLine("You got " + (hostile.lvl * 5) + " exp points! " + (100 - character.exp) + " untill next lvl");
                    character.hp = character.vit;
                    character.ep = character.agi;
                    Battlestats.Enqueue(hostile.Name + " " + hostile.lvl);
                    break;
                }
                else
                {
                    if (enemy_turn == 3)
                    {
                        character.hp = character.hp - CharactersAbilities.Fury(hostile.str, hostile.phatk);
                        enemy_turn = 1;
                    }
                    else
                    {
                        character.hp = character.hp - CharactersAbilities.Bite(hostile.str, hostile.phatk);
                        enemy_turn++;
                    }
                    Console.WriteLine("You have" + character.hp + " hp.");
                    Console.WriteLine("Enemy has " + hostile.hp + " hp. Type Skill_list to attack againg.");
                    if (character.hp < 1)
                    {
                        Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    }
                    break;
                }
            }
        }

        public void WizardBattle(Hostile hostile, Character character, int enemy_turn, Queue<string> Battlestats, CharacterMessages msgs)
        {
            string typech;
            int typen;
            Console.WriteLine("Type <<Skill_list>> to begin fight");
            while (true)
            {
                typech = Console.ReadLine();
                if (typech.CompareTo("Skill_list") == 0)
                {
                    System.Console.Clear();
                    Asciidraw.drawpic("Header");
                    if (hostile.Name.CompareTo("Succubus") == 0)
                    {
                        Asciidraw.drawpic("Succubus");
                    }
                    else if (hostile.Name.CompareTo("GrimReaper") == 0)
                    {
                        Asciidraw.drawpic("GrimReaper");
                    }
                    else if (hostile.Name.CompareTo("Archlord") == 0)
                    {
                        Asciidraw.drawpic("Archlord");
                    }
                    else if (hostile.Name.CompareTo("CentaurQueen") == 0)
                    {
                        Asciidraw.drawpic("CentaurQueen");
                    }
                    else if (hostile.Name.CompareTo("Unicorn") == 0)
                    {
                        Asciidraw.drawpic("Unicorn");
                    }
                    else
                    {
                        Asciidraw.drawpic("Angel");
                    }
                    CharactersAbilities.WizardShowSkillList();
                    Console.WriteLine("Choose skill number:");
                    typen = Convert.ToInt32(Console.ReadLine());
                    switch (typen)
                    {
                        case 1:

                            hostile.hp = hostile.hp - CharactersAbilities.ArcaneBolt(character.intl, character.matk);
                            break;
                        case 2:
                            if ((80 + 20 * character.lvl) < character.mp)
                            {
                                hostile.hp = hostile.hp - CharactersAbilities.Fireball(character.intl, character.matk);
                                character.mp = character.mp - (80 + 20 * character.lvl);
                            }
                            else
                            {
                                Console.WriteLine("Not enough energy. Try to use another skill");
                                continue;
                            }

                            break;
                        case 3:

                            character.hp = character.hp + CharactersAbilities.WizardHealthRegeneration(character.vit, character.lvl);
                            if (character.hp > character.vit)
                            {
                                character.hp = character.vit;
                            }
                            break;
                        case 4:

                            character.mp = character.mp + CharactersAbilities.ManaRegeneration(character.wis, character.lvl);
                            if (character.mp > character.wis)
                            {
                                character.mp = character.wis;
                            }
                            break;
                        default:
                            break;
                    }
                    if (hostile.hp > (100 * hostile.lvl) && hostile.hp < (200 * hostile.lvl))
                    {
                        msgs.Message(hostile.Name, hostile.hp);
                    }

                }
                else
                {
                    Console.WriteLine("Incorrect text! Type Skill_list to choose skill: ");
                    continue;
                }
                if (character.hp < 1)
                {
                    Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    break;
                }
                else if (hostile.hp < 1)
                {
                    if (character.lvl == 10)
                    {
                        System.Console.Clear();
                        Asciidraw.drawpic("GoodGameOver");
                        Console.WriteLine("You defetead the most powerful enemy, and now Evergarden can finally be at peace! You have done an unbelievable job, and many centuries further your name will be in every single ballad!");
                        System.Console.ReadKey();
                        System.Console.ReadKey();
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Congratulations, you won!");
                    character.exp = character.exp + hostile.lvl * 5;
                    character.CheckLvlUp();
                    Console.WriteLine("You got " + (hostile.lvl * 5) + " exp points! " + (100 - character.exp) + " untill next lvl");
                    character.hp = character.vit;
                    character.ep = character.agi;
                    Battlestats.Enqueue(hostile.Name + " " + hostile.lvl);
                    break;
                }

                else
                {
                    if (enemy_turn == 3)
                    {
                        character.hp = character.hp - CharactersAbilities.Fury(hostile.str, hostile.phatk);
                        enemy_turn = 1;
                    }
                    else
                    {
                        character.hp = character.hp - CharactersAbilities.Bite(hostile.str, hostile.phatk);
                        enemy_turn++;
                    }
                    Console.WriteLine("You have" + character.hp + " hp.");
                    Console.WriteLine("Enemy has " + hostile.hp + " hp. Type Skill_list to attack againg.");
                    if (character.hp < 1)
                    {
                        Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    }
                    break;
                }
            }
        }

        public void RangerBattle(Hostile hostile, Character character, int enemy_turn, Queue<string> Battlestats, CharacterMessages msgs)
        {
            string typech;
            int typen;
            Console.WriteLine("Type <<Skill_list>> to begin fight");
            while (true)
            {
                typech = Console.ReadLine();
                if (typech.CompareTo("Skill_list") == 0)
                {
                    System.Console.Clear();
                    Asciidraw.drawpic("Header");
                    if (hostile.Name.CompareTo("Succubus") == 0)
                    {
                        Asciidraw.drawpic("Succubus");
                    }
                    else if (hostile.Name.CompareTo("GrimReaper") == 0)
                    {
                        Asciidraw.drawpic("GrimReaper");
                    }
                    else if (hostile.Name.CompareTo("Archlord") == 0)
                    {
                        Asciidraw.drawpic("Archlord");
                    }
                    else if (hostile.Name.CompareTo("CentaurQueen") == 0)
                    {
                        Asciidraw.drawpic("CentaurQueen");
                    }
                    else if (hostile.Name.CompareTo("Unicorn") == 0)
                    {
                        Asciidraw.drawpic("Unicorn");
                    }
                    else
                    {
                        Asciidraw.drawpic("Angel");
                    }
                    CharactersAbilities.RangerShowSkillList();
                    Console.WriteLine("Choose skill number:");
                    typen = Convert.ToInt32(Console.ReadLine());
                    switch (typen)
                    {
                        case 1:

                            hostile.hp = hostile.hp - CharactersAbilities.AutoShoot(character.str, character.phatk);
                            break;
                        case 2:
                            if ((70 + 20 * character.lvl) < character.ep)
                            {
                                character.ep = character.ep - (70 + 20 * character.lvl);
                                hostile.hp = hostile.hp - CharactersAbilities.PowerArrow(character.str, character.phatk);
                            }
                            else
                            {
                                Console.WriteLine( "Not enough energy. Try to use another skill" );
                                continue;
                            }

                            break;
                        case 3:

                            character.ep = character.ep + CharactersAbilities.RangerHealthRegeneration(character.agi, character.lvl);
                            if (character.ep > character.agi)
                            {
                                character.ep = character.agi;
                            }
                            break;
                        default:
                            break;
                    }
                    if (hostile.hp > (100 * hostile.lvl) && hostile.hp < (200 * hostile.lvl))
                    {
                        msgs.Message(hostile.Name,hostile.hp);
                    }

                }

                else
                {
                    Console.WriteLine("Incorrect text! Type Skill_list to choose skill: ");
                    continue;
                }
                if (character.hp < 1)
                {
                    Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    break;
                }
                else if (hostile.hp < 1)
                {
                    if (character.lvl == 10)
                    {
                        System.Console.Clear();
                        Asciidraw.drawpic("GoodGameOver");
                        Console.WriteLine("You defetead the most powerful enemy, and now Evergarden can finally be at peace! You have done an unbelievable job, and many centuries further your name will be in every single ballad!");
                        System.Console.ReadKey();
                        System.Console.ReadKey();
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Congratulations, you won!");
                    character.exp = character.exp + hostile.lvl * 5;
                    character.CheckLvlUp();
                    Console.WriteLine("You got " + (hostile.lvl * 5) + " exp points! " + (100 - character.exp) + " untill next lvl");
                    character.hp = character.vit;
                    character.ep = character.agi;
                    Battlestats.Enqueue(hostile.Name + " " + hostile.lvl);
                    break;
                }

                else
                {
                    if (enemy_turn == 3)
                    {
                        character.hp = character.hp - CharactersAbilities.Fury(hostile.str, hostile.phatk);
                        enemy_turn = 1;
                    }
                    else
                    {
                        character.hp = character.hp - CharactersAbilities.Bite(hostile.str, hostile.phatk);
                        enemy_turn++;
                    }
                    Console.WriteLine("You have" + character.hp + " hp.");
                    Console.WriteLine("Enemy has " + hostile.hp + " hp. Type Skill_list to attack againg.");
                    if (character.hp < 1)
                    {
                        Console.WriteLine("Character DIED!(will be revived at the end of the battle)");
                    }
                    break;
                }
            }
        }
        public Battle()
        {

        }
    }
}
