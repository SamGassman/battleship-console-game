using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class PlayingBoard
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player EnemyPlayer { get; set; }
        
        public PlayingBoard(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            Player1.GetNewShips();
            Player2.GetNewShips();
            CurrentPlayer = Player1;
            EnemyPlayer = Player2;
            for(int i = 0; i<Player1.BoardLengthX; i++)
            {
                for(int j = 0; j <Player1.BoardLengthY; j++)
                {
                    Player1.XYBoard[i, j] = "[ ]";
                }
            }
            for (int i = 0; i < Player2.BoardLengthX; i++)
            {
                for (int j = 0; j < Player2.BoardLengthY; j++)
                {
                    Player2.XYBoard[i, j] = "[ ]";
                }
            }
        }
        public void DisplayBoard()
        {
            //player1 side

            for (int i = 0; i < Player1.BoardLengthY; i++)
            {
                if (i == 0)
                {
                    Console.Write("   ");
                    for (int j = 0; j < Player1.BoardLengthX; j++)
                    {
                        Console.Write($" {j + 1} ");
                    }
                    Console.WriteLine();
                }
                Console.Write($" {i + 1} ");
                for (int j = 0; j < Player1.BoardLengthX; j++)
                {
                    Console.Write(Player1.XYBoard[j, i]);
                }
                if (i == Player1.BoardLengthY / 2)
                {
                    string turn = CurrentPlayer == Player1 ? " <--" : "";
                    Console.Write($"    {Player1.Name}{turn}");
                }
                Console.WriteLine();
            }

            //Divider
            for (int i = 0; i <= Player1.BoardLengthX; i++)
            {
                Console.Write("===");
            }
            Console.WriteLine();

            //player2 side
            for (int i = Player2.BoardLengthY - 1; i >= 0; i--)
            {
                Console.Write($" {i + 1} ");
                for (int j = 0; j < Player2.BoardLengthX; j++)
                {
                    Console.Write(Player2.XYBoard[j, i]);
                }
                if (i == Player2.BoardLengthY / 2)
                {
                    string turn = CurrentPlayer == Player2 ? " <--" : "";
                    Console.Write($"    {Player2.Name}{turn}");
                }
                Console.WriteLine();
                if (i == 0)
                {
                    Console.Write("   ");
                    for (int j = 0; j < Player2.BoardLengthX; j++)
                    {
                        Console.Write($" {j + 1} ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public bool Bomb(Player enemyPlayer, int x, int y)
        {
            bool hitShip = false;
            for(int i = 0; i < enemyPlayer.NumberOfShips; i++)
            {
                if (enemyPlayer.XYShip[i, 0] == x && enemyPlayer.XYShip[i, 1] == y)
                {
                    hitShip = true;
                    enemyPlayer.XYBoard[x - 1, y - 1] = "[X]";
                    enemyPlayer.NumberOfShipsLeft--;
                }
            }
            if (!hitShip)
            {
                enemyPlayer.XYBoard[x - 1, y - 1] = "[o]";
            }
            
            return hitShip;
        }
        public void NextTurn()
        {
            Player hold = CurrentPlayer;
            CurrentPlayer = EnemyPlayer;
            EnemyPlayer = hold;
        }
        
    }
}
