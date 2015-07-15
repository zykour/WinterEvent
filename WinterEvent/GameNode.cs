using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterEvent
{
    class GameNode
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int actor;
        public int Actor
        {
            get { return actor; }
            set { actor = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

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