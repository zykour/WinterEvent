using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace WinterEvent
{
    class Game
    {
        LinkedList<GameNode> initializationList;
        Array gameNodes;
        string saveURL;

        protected Game() { }
        public Game(string dataURL, string saveURL)
        {
            this.saveURL = saveURL;
        }

        LinkedList<GameNode> currentNodes;

        private void Initialize(string dataURL)
        {
            string data = "";

            try
            {
                using (StreamReader sr = new StreamReader(dataURL))
                {
                    data = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }

            int position = 0;

            while (position != -1)
            {
                position = data.IndexOf("~;");

                if (position != -1)
                {
                    string tempNode = data.Substring(0, position);
                    
                    if (data.Length > position + 2)
                    {
                        data = data.Substring(position + 2);
                    }

                    CreateNode(tempNode);
                }
            }
        }

        private void CreateNode(string tempNode)
        {
            string[] nodeData = tempNode.Split('~');
            GameNode newNode = new GameNode();
            newNode.ID = Int32.Parse(nodeData[0]);
            newNode.Actor = Int32.Parse(nodeData[1]);
            newNode.Message = nodeData[2];
            
            for (int i = 3; i < nodeData.Length; i++)
            {
                if (nodeData[i].IndexOf("&&") != -1)
                    string command = nodeData[i].Substring(0, )
                    string output = 
                    newNode.AddCommandMap(new CommandMap());
            }
        }

        //load game
        //link
        //start
    }
}
