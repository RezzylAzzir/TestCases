using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVG_test1
{
    [Serializable]
    public class CharacterMessages
    {
        public delegate void CustomEventHandler(object sender, CustomEventArgs e);
        public event CustomEventHandler RaiseCustomEvent;
        public CharacterMessages()
        {
            RaiseCustomEvent += EnemyMessaging;
        }

        public void Message(string Name,int HP)
        {
            OnRaiseCustomEvent(new CustomEventArgs(Name,HP));
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            CustomEventHandler handler = RaiseCustomEvent;
            if (handler != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Current monster hp is {0}", e.HP);
                Console.ResetColor();
                handler(this,e);
            }
        }
        public void EnemyMessaging(object sender, CustomEventArgs e)
        {
            
            Random rand = new Random();
            switch (rand.Next(1, 4))
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(e.Name + ": ARRRGH... NEED MORE POWWWERRRR....");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Name + ": RRRR, DAMN HUUUMANSSSS...");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Name + ": RAAAWRR, KILLLL, DESTRRRROYYY....");
                    Console.ResetColor();
                    break;
                default:
                    break;

            }
        }
    }

  

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string name, int hp)
        {
            HP = hp;
            Name = name;
        }
        private string name;
        private int hp;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
    }
}
