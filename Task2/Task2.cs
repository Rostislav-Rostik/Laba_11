using System.Diagnostics.Metrics;

internal class Task2
{
    public delegate void Reaction();

    public class King 
    {
        public string name;
        public event Reaction action;

        public King (string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public void GetReaction()
        {
            Console.WriteLine($"King {name} is under attack!");
        }
    }

    public class Footman
    {
        private string name;

        public Footman(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }


        public void GetReaction()
        {
            Console.WriteLine($"Footman {name} is panicking!");
        }
    }

    public class Royal_Guard 
    {
        private string name;

        public Royal_Guard(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public void GetReaction()
        {
            Console.WriteLine($"Royal Guard {name} is defending!");
        }
    }

    static void Main()
    {
        var temp = Console.ReadLine().Split();
        King king = new King(temp[0]);
        
        List<Royal_Guard> royal_Guards = new List<Royal_Guard>();
        List<Footman> footman = new List<Footman>();

        temp = Console.ReadLine().Split();

        foreach (string item in temp)
        {
            Royal_Guard temp_item = new Royal_Guard(item);
            royal_Guards.Add(temp_item);

        }

        temp = Console.ReadLine().Split();

        foreach (string item in temp)
        {
            Footman temp_item = new Footman(item);
            footman.Add(temp_item);
        }

        while (true)
        {
            temp = Console.ReadLine().Split();
            if (temp[0] == "END" || temp[0] == "End")
            {
                break;
            }
            else if (temp[0] == "attack")
            {
                king.GetReaction();
                foreach (Royal_Guard temp_item in royal_Guards)
                {
                    temp_item.GetReaction();
                }
                foreach (Footman temp_item in footman)
                {
                    temp_item.GetReaction();
                }
            }
            else if (temp[0] == "kill")
            {

                for (int i = 0; i != royal_Guards.Count; i++)
                {
                    if (royal_Guards[i].Name == temp[1])
                    {
                        royal_Guards.RemoveAt(i);
                    }
                }
                for (int i = 0; i != footman.Count; i++)
                {
                    if (footman[i].Name == temp[1])
                    {
                        footman.RemoveAt(i);
                    }
                }
            }
            
        }
    }
}