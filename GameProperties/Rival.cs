using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace GameProperties
{
    public class Rival
    {
        public Computer m_Computer;
        public Player m_Player;
        private int m_RivalSign;

        public Rival(string i_Name, int i_RivalSign)
        {
            AlocatePlayers(i_Name, i_RivalSign);
        }

        public int RivalSign
        {
            get { return m_RivalSign; }
            set { m_RivalSign = value; }
        }

        public int Score()
        {
            int score;  //// how?
            if (m_RivalSign != 0)
            {
                score = m_Computer.Score;
            }
            else
            {
                score = m_Player.Score;
            }

            return score;
        }

        public void AlocatePlayers(string i_Name, int i_RivalSign)
        {
            m_RivalSign = i_RivalSign;
            if (m_RivalSign != 0)
            {
                m_Computer = new Computer();
            }
            else
            {
                m_Player = new Player(i_Name);
            }

        }

        public void RivalMove(ref Point io_Pos, Board i_Board)
        {
            if (m_RivalSign != 0)
            {
                m_Computer.Move(ref io_Pos, i_Board, i_Board.m_SignO);
            }
            else
            {
                m_Player.Move(ref io_Pos, i_Board, i_Board.m_SignO);
            }

        }

        public string Name()
        {
            string name;

            if (m_RivalSign != 0)
            {
                name = "Computer";
            }
            else
            {
                name = m_Player.Name;
            }

            return name;
        }

        public void Win()
        {
            if (m_RivalSign == 0)
            {
                m_Player.Score++;
            }
            else
            {
                m_Computer.Score++;
            }

        }
    }
}
