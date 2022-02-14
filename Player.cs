using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Player
    {
        public int NumberOfShips { get; set; }
        public int NumberOfShipsLeft { get; set; }
        public int[,] XYShip { get; private set; }
        public string[,] XYBoard { get; set; }
        public int BoardLengthX { get; set; }
        public int BoardLengthY { get; set; }
        public string Name { get; private set; }
        public int PlayerNumber { get; private set; }
        private List<int> movesLogX;
        private List<int> movesLogY;
        public Player(string name, int playerNumber, int boardLengthX, int boardLengthY, int numberOfShips)
        {
            NumberOfShips = numberOfShips;
            NumberOfShipsLeft = numberOfShips;
            BoardLengthX = boardLengthX;
            BoardLengthY = boardLengthY;
            XYShip = new int[NumberOfShips, 2];
            XYBoard = new string[boardLengthX, boardLengthY];
            movesLogX = new List<int>();
            movesLogY = new List<int>();
            Name = name.ToUpper();
            PlayerNumber = playerNumber;
        }

        public void GetNewShips()
        {
            Random rand = new Random();
            for (int i = 0; i < NumberOfShips; i++)
            {
                XYShip[i, 0] = 0;
                XYShip[i, 1] = 0;
            }
            for (int i = 0; i < NumberOfShips; i++)
            {
                int x = rand.Next(BoardLengthX - 1);
                int y = rand.Next(BoardLengthY - 1);
                XYShip[i, 0] = x;
                XYShip[i, 1] = y;
            }
        }

        public bool ValidMove(int x, int y)
        {
            //Returns true if move has not been made yet
            bool validMove = true;
            for(int i = 0; i< movesLogX.Count; i++)
            {
                if(movesLogX[i] == x && movesLogY[i] == y)
                {
                    validMove = false;
                }
            }
            if (validMove)
            {
                movesLogX.Add(x);
                movesLogY.Add(y);
            }
            return validMove;
        }
    }
}
