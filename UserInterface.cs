using System;
using System.Collections.Generic;

using System.Text;


namespace BattleShip
{
    public class UserInterface
    {
        public void Run()
        {
            MessageScreen("WELCOME TO BATTLESHIP");
            Console.WriteLine("***** BATTLESHIP *****");
            Console.Write("Enter Player 1 Name: ");
            string p1Name = Console.ReadLine();
            Console.Write("Enter Player 2 Name: ");
            string p2Name = Console.ReadLine();

            //Player(name, player#, board x length, board y length, number of ships)
            Player player1 = new Player(p1Name, 1, 9, 5, 5);
            Player player2 = new Player(p2Name, 2, 9, 5, 5);


            PlayingBoard board = new PlayingBoard(player1, player2);
            
            bool done = false;
            while (!done)
            {
                Console.Clear();
                board.DisplayBoard();
                Console.WriteLine();

                Console.WriteLine(board.CurrentPlayer.Name);
                int inputX;
                int inputY;
                bool bombed = true;
                bool valid = true;
                try
                {
                    Console.Write("Enter the X coordinate of your next move (0 to quit): ");
                    inputX = int.Parse(Console.ReadLine());
                    if (inputX == 0)
                    {
                        done = true;
                        continue;
                    }
                    Console.Write("Enter the Y coordinate of your next move: ");
                    inputY = int.Parse(Console.ReadLine());
                    
                    try
                    {
                        bombed = board.Bomb(board.EnemyPlayer, inputX, inputY);
                        valid = board.CurrentPlayer.ValidMove(inputX, inputY);
                        if (bombed && valid)
                        {
                            MessageScreen($"YOU HIT {board.EnemyPlayer.Name}'S SHIP!");
                        }
                        if (board.EnemyPlayer.NumberOfShipsLeft == 0)
                        {
                            MessageScreen($"{board.CurrentPlayer.Name} WINS!");
                            done = true;
                            continue;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a valid coordinate, try again.");
                    Delay(2, true);
                    continue;
                }
                if(!valid)
                {
                    Console.WriteLine("You already made that move, try again.");
                    Delay(2, true);
                    continue;
                }
                

                board.NextTurn();
            }
        }

        public void MessageScreen(string message)
        {
            int margin = 28 - message.Length;
            message = $" {message} ";
            Console.Clear();
            for(int i = 0; i<5; i++)
            {
                if(i == 2)
                {
                    for(int j = 0; j < margin/2; j++)
                    {
                        Console.Write("=");
                    }
                    Console.Write(message);
                    for (int j = 0; j < margin / 2; j++)
                    {
                        Console.Write("=");
                        
                    }
                    if (margin % 2 == 1)
                    {
                        Console.Write("=");
                    }
                }
                else
                {
                    for (int j = 0; j < 30; j++)
                    {
                        Console.Write("=");
                    }
                }
                
                Console.WriteLine();
            }
            Delay(3, true);
            Console.Clear();
        }
        public void Delay(int timeToWait, bool secondsNotMs)
        {
            if (secondsNotMs)
            {
                DateTime endTime = DateTime.Now.AddSeconds(timeToWait);
                int end = endTime.Second;
                while (DateTime.Now.Second != end) { }
            }
            else
            {
                DateTime endTime = DateTime.Now.AddMilliseconds(timeToWait);
                int end = endTime.Millisecond;
                while (DateTime.Now.Millisecond != end) { }
            }
        }
    }
}
