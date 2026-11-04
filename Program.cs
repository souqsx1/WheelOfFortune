using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WheelOfFortune
{
    public struct Contestant
    {
        public string firstName;
        public string lastName;
        public string hobby;
        public int score;
    }
    internal class Program
    {
        //menu options
        private static void Play(Contestant[] data)
        {
            Random rand = new Random();
            Console.WriteLine("Here are the finalists:");
            int[] playerNums = new int[10];
            int temp;
            int dupe;
            
            for (int i = 0; i < playerNums.Length; i++)
            {
                dupe = 0;
                temp = rand.Next(0, 23);
                while (dupe < i)
                {
                    if (playerNums[dupe] != temp)
                    {
                        dupe++;
                    }
                    else
                    {
                        temp = rand.Next(0, 23);
                        dupe = 0;
                    }
                }
                playerNums[i] = temp;
            }
            Console.WriteLine("  First Name\tLast Name\t\tInterest\t\tScore ");
            for (int i = 0; i < playerNums.Length; i++)
            {
                Console.WriteLine($"  {data[playerNums[i]].firstName, -16}{data[playerNums[i]].lastName,-24}{data[playerNums[i]].hobby,-16}\t{data[playerNums[i]].score,3}");
            }
            Console.ReadLine();
            Console.WriteLine("Todays contestant is...");
            Console.ReadLine();
        }
        static void Display(Contestant[] contestants)
        {
            Console.WriteLine("First Name\tLast Name\t\tInterest\t\tScore ");
            foreach (Contestant person in contestants)
            {
                Console.WriteLine($"{person.firstName,-16}{person.lastName,-24}{person.hobby,-16}\t{person.score,3}");
            }

            Console.ReadLine();
        }
        static void Task3()
        {
            Console.WriteLine("Task3 !!!");
            Console.ReadLine();
        }
        static void Task4()
        {
            Console.WriteLine("Task4 !!!");
            Console.ReadLine();
        }
        //
        static Contestant[] Read(Contestant[] data)
        {
            Random rand = new Random();
            StreamReader sr = new StreamReader("wheelOfFortune.txt");
            for (int i = 0; i < data.Length; i++)
            {
                data[i].firstName = sr.ReadLine();
                data[i].lastName = sr.ReadLine();
                data[i].hobby = sr.ReadLine();
                data[i].score = Convert.ToInt32(sr.ReadLine());
            }
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int pos = 0; pos < data.Length - 1; pos++)
                {
                    if (data[pos + 1].lastName.CompareTo(data[pos].lastName) < 0)
                    {
                        Contestant temp;
                        temp = data[pos + 1];
                        data[pos + 1] = data[pos];
                        data[pos] = temp;

                    }
                }
            }
            sr.Close();
            return data;
        }
        
        static void Main()
        {
            bool repeat = true;
            Contestant[] data = new Contestant[23];
            data = Read(data);

            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1: Play\n2: Show/Edit contestants\n3: Task3\n4: Task4\n0: Exit");
                int input;
                int.TryParse(Console.ReadLine(), out input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        Play(data);
                        break;

                    case 2:
                        Display(data);

                        break;

                    case 3:
                        Task3();
                        break;

                    case 4:
                        Task4();
                        break;

                    case 0:
                        Console.WriteLine("Exiting");
                        repeat = false;
                        break;

                }

            } while (repeat);
        }
    }
}
