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
        // holds the list of GameNodes before they are linked up.
        LinkedList<GameNode> initializationList;

        // holds the list of actors (bots) that can display dialogue
        Actor[] actors;

        // an array of gameNode items
        GameNode[] gameNodes;

        // filepath to savegame data
        string saveURL;

        protected Game() { }
        public Game(string dataURL, string saveURL)
        {
            this.saveURL = saveURL;

            Initialize(dataURL);

            LoadSave(saveURL);

            foreach (GameNode node in currentNodes)
            {
                actors[node.Actor].Play(node, this);
                // play each
            }
        }

        public void ToggleNode(int id)
        {

        }

        public void ToggleActor(int id)
        {

        }

        // a list of nodes that are in play (live)

        LinkedList<GameNode> currentNodes;

        public void Parse(string text)
        {
            foreach (GameNode node in gameNodes)
            {
                foreach (CommandMap mapping in node.CommandList)
                {
                    if (mapping.Command.CompareTo(text.Trim().ToLower()) == 0)
                    {
                        actors[node.Actor].Process(mapping.Message, this);
                    }
                }
            }
        }














        //===================================================
        //      Initialization code
        //===================================================

        private void LoadSave(string saveURL)
        {
            // save the current nodes (ones that are live) by writing their IDs to a single line CSV file

            string data = "";

            try
            {
                using (StreamReader sr = new StreamReader(saveURL))
                {
                    data = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
            }

            if (data.CompareTo("") == 0)
            {
                // no save data, new game
                return;
            }
            else
            {
                // saved nodes are stored as a CSV
                string[] tempNodes = data.Split(',');

                for (int i = 0; i < tempNodes.Length; i++)
                {
                    currentNodes.AddLast(gameNodes[Int32.Parse(tempNodes[i])]);
                }
            }
        }

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

            gameNodes = new GameNode[initializationList.Count];

            for (int i = 0; i < initializationList.Count; i++)
            {
                gameNodes[i] = initializationList.ElementAt(i);
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
                {
                    string command = nodeData[i].Substring(0, nodeData[i].IndexOf("&&"));
                    string output = nodeData[i].Substring(nodeData[i].IndexOf("&&") + 2);
                    newNode.AddCommandMap(new CommandMap(command, output));
                }
            }

            initializationList.AddLast(newNode);
        }

        //start
    }
}
