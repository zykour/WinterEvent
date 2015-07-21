using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterEvent
{
    class Actor
    {
        private bool active;

        public Actor() 
        {
            active = false;
        }

        public void Play(GameNode node, Game game)
        {
            if (node.Message.Contains("&&"))
            {
                string[] delimiter = new string[] { "&&" };

                string[] messages = node.Message.Trim().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < messages.Length; i++)
                {
                    string tempText = messages[i].Trim();

                    if (tempText.Contains("%%"))
                    {
                        tempText = tempText.Remove(0, 2);
                        game.ToggleActor(Int32.Parse(tempText));
                    }
                    else if (tempText.Contains("##"))
                    {
                        tempText = tempText.Remove(0, 2);
                        game.ToggleNode(Int32.Parse(tempText));
                    }
                }
            }
        }

        public void Process(string text, Game game)
        {

        }

        public bool IsActive()
        {
            return active;
        }

    }
}
