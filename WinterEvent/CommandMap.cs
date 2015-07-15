using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterEvent
{
    class CommandMap
    {
        private string command;
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public CommandMap(string command, string message)
        {
            this.command = command;
            this.message = message;
        }
    }
}
