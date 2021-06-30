using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace GameProperties
{
    public class Board
    {
        public char m_SignO = 'O';
        public char m_SignX = 'X';
        public int m_SumOfCells;
        public int m_WidthOfBoard;
        private char[,] m_BoardGame;

        public Board(int i_BoardWidth)
        {
            BuildBoard(i_BoardWidth);
        }

        public char[,] BoardGame
        {
            get { return m_BoardGame; }
        }

        public void BuildBoard(int i_BoardWidth)
        {
            m_WidthOfBoard = i_BoardWidth;
            m_SumOfCells = m_WidthOfBoard * m_WidthOfBoard;
            m_BoardGame = new char[m_WidthOfBoard, m_WidthOfBoard];
        }

        public void ClearBoard()
        {
            Array.Clear(BoardGame, 0, BoardGame.Length);
        }

        public bool PossiblePossionChecker(ref Point io_Pos)
        {
            return io_Pos.X < 0 || io_Pos.X >= m_WidthOfBoard
                       || io_Pos.Y < 0 || io_Pos.Y >= m_WidthOfBoard
                       || BoardGame[io_Pos.X, io_Pos.Y] == 'X'
                       || BoardGame[io_Pos.X, io_Pos.Y] == 'O';
        }
    }
}