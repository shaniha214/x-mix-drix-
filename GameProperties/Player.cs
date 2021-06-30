using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace GameProperties
{
    public class Player
    {
        private string m_Name;
        private int m_Score = 0;

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Score = 0;
        }

        public void Move(ref Point io_Pos, Board i_Board, char i_Sign)
        {
           i_Board.BoardGame[io_Pos.X, io_Pos.Y] = i_Sign;
        }
    }
}