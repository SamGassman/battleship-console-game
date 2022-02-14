using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Run();

            Console.ReadLine();
        }
    }
}
