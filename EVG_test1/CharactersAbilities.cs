using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVG_test1
{
    class CharactersAbilities
    {
        public static int Autoattack(int playerstr, int playerphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playerphatk + playerstr / 4) - 10) + ((playerphatk + playerstr / 4) + 11);
            Console.WriteLine("You attacked enemy with sword and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int RageSlash(int playerstr, int playerphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playerphatk + playerstr * 2) - 10) + ((playerphatk + playerstr * 2) + 11);
            Console.WriteLine("You gone berserk, slashing everything you see around you and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int EnergyRegeneration(int playeragi, int playerlvl)
        {
            int regeneratedenergy = 0;
            regeneratedenergy = playeragi / 10 + playerlvl * 7;
            Console.WriteLine("You calmly observe situation and regenerated " + regeneratedenergy + " energy!");
            return regeneratedenergy;
        }

        public static int ArcaneBolt(int playerintl, int playermatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playermatk + playerintl / 4) - 10) + ((playermatk + playerintl / 4) + 11);
            Console.WriteLine("You cast little energy bolt which dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int Fireball(int playerintl, int playermatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playermatk + playerintl * 2) - 10) + ((playermatk + playerintl * 2) + 11);
            Console.WriteLine("You cast a fireball and it dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int WizardHealthRegeneration(int playervit, int playerlvl)
        {
            int regeneratedhealth = 0;
            regeneratedhealth = playervit / 10 + playerlvl * 7;
            Console.WriteLine("You prayed gods for blessing and regenerated " + regeneratedhealth + " hp!");
            return regeneratedhealth;
        }
        public static int ManaRegeneration(int playerwis, int playerlvl)
        {
            int regeneratedmana = 0;
            regeneratedmana = playerwis / 10 + playerlvl * 7;
            Console.WriteLine("You call the ancient powers for help and regenerated " + regeneratedmana + " mana!");
            return regeneratedmana;
        }

        public static int AutoShoot(int playerstr, int playerphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playerphatk + playerstr / 4) - 10) + ((playerphatk + playerstr / 4) + 11);
            Console.WriteLine("You shooted enemy with arrow and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int PowerArrow(int playerstr, int playerphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((playerphatk + playerstr * 2) - 10) + ((playerphatk + playerstr * 2) + 11);
            Console.WriteLine("You shooted with arrow, enchanced with magic and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int RangerHealthRegeneration(int playervit, int playerlvl)
        {
            int regeneratedhealth = 0;
            regeneratedhealth = playervit / 10 + playerlvl * 7;
            Console.WriteLine("You call a nature for help and regenerated " + regeneratedhealth + " hp!");
            return regeneratedhealth;
        }

        public static int Bite(int enemystr, int enemyphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((enemyphatk + enemystr / 4) - 10) + ((enemyphatk + enemystr / 4) + 11);
            Console.WriteLine("Enemy attacked you with bite and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }
        public static int Fury(int enemystr, int enemyphatk)
        {
            Random rand = new Random();
            int dealtdamage = 0;
            dealtdamage = rand.Next((enemyphatk + enemystr * 2) - 10) + ((enemyphatk + enemystr * 2) + 11);
            Console.WriteLine("Enemy attacked you with fury and dealt " + dealtdamage + " damage!");
            return dealtdamage;
        }

        public static void WarriorShowSkillList()
        {
            Console.WriteLine("1. Autoattack");
            Console.WriteLine("2. Rage Slash");
            Console.WriteLine("3. Energy Regeneration");
        }
        public static void WizardShowSkillList()
        {
            Console.WriteLine("1. Arcane Bolt");
            Console.WriteLine("2. Fireball");
            Console.WriteLine("3. Health Regeneration");
            Console.WriteLine("4. Mana Regeneration");
        }
        public static void RangerShowSkillList()
        {
            Console.WriteLine("1. Auto Shooting");
            Console.WriteLine("2. Power Arrow");
            Console.WriteLine("3. Health Regeneration");
        }
    }
}
