using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterEvent
{
    class GameNode
    {

        // id of the node
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // integer ID of the actor (bot), each node pertains exactly to one bot
        private int actor;
        public int Actor
        {
            get { return actor; }
            set { actor = value; }
        }

        // the 'message', generally a string message to be displayed by the bot, but it can also be an encoded action for the bot to perform instead
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        // list of inputs/outputs while this node is live, i.e. you might be able to ask the bot for help via a "!help" command and the bot will output a help menu
        LinkedList<CommandMap> commandList;
        public LinkedList<CommandMap> CommandList
        {
            get { return commandList; }
        }

        public GameNode() 
        {
            commandList = new LinkedList<CommandMap>();
        }

        public void AddCommandMap(CommandMap commandMap)
        {
            commandList.AddFirst(commandMap);
        }
    }
}