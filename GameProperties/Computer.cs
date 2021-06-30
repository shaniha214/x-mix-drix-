using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace GameProperties
{
    public class Computer
    {
        private int m_Score = 0;

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public void Move(ref Point io_Pos, Board i_Board, int i_RivalSign)
        {
            bool unValidPossion = true;
            Random rand = new Random();

            while (unValidPossion)
            {
                io_Pos.X = rand.Next(i_Board.m_WidthOfBoard);
                io_Pos.Y = rand.Next(i_Board.m_WidthOfBoard);
                unValidPossion = i_Board.PossiblePossionChecker(ref io_Pos);
                if (!unValidPossion)
                {
                    i_Board.BoardGame[io_Pos.X, io_Pos.Y] = i_Board.m_SignO;
                }

            }

        }
    }
}