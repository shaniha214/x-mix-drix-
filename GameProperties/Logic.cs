using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProperties
{
    class Logic
    {
        public Player m_YourPlayer;
        public Rival m_RivalPlayer;
        public Board m_Board = new Board();
        public int m_MovesCounter = 0;

        public void AlocatePlayers(string i_Name)
        {
            m_YourPlayer = new Player(i_Name);
            m_RivalPlayer = new Rival();
        }

        public bool CheckWin(Possition i_Pos)
        {
            bool row = false;
            bool column = false;
            bool diagnose = false;

            row = checkRow(i_Pos);
            column = checkColumn(i_Pos);

            if (i_Pos.RowIndex == i_Pos.ColIndex || Math.Abs(i_Pos.RowIndex - i_Pos.ColIndex) == m_Board.m_WidthOfBoard - 1 || i_Pos.RowIndex + i_Pos.ColIndex == m_Board.m_WidthOfBoard)
            {
                diagnose = checkDiagnose(i_Pos);
            }

            if (row || column || diagnose)
            {
                if (m_MovesCounter % 2 == 0)
                {
                    m_YourPlayer.Score++;
                }
                else
                {
                    m_RivalPlayer.Win();
                }
            }

            return row || column || diagnose;
        }

        private bool checkRow(Possition i_Pos)
        {
            bool winRow = true;
            int index;

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[i_Pos.RowIndex, index] != m_Board.BoardGame[i_Pos.RowIndex, index + 1])
                {
                    winRow = false;
                }
            }

            return winRow;
        }

        private bool checkColumn(Possition i_Pos)
        {
            bool winColumn = true;
            int index;

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[index, i_Pos.ColIndex] != m_Board.BoardGame[index + 1, i_Pos.ColIndex])
                {
                    winColumn = false;
                }
            }

            return winColumn;
        }

        private bool checkDiagnose(Possition i_Pos)
        {
            bool winFirstdiagnose = true;
            bool winSecondDiagnose = true;
            int index;

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[index, index] != m_Board.BoardGame[index + 1, index + 1]
                    || (m_Board.BoardGame[index, index] != m_Board.m_SignX
                    && m_Board.BoardGame[index, index] != m_Board.m_SignO))
                {
                    winFirstdiagnose = false;
                }
            }

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[index, m_Board.m_WidthOfBoard - index - 1] != m_Board.BoardGame[index + 1, m_Board.m_WidthOfBoard - index - 2]
                    || (m_Board.BoardGame[index, m_Board.m_WidthOfBoard - index - 1] != m_Board.m_SignX
                    && m_Board.BoardGame[index, m_Board.m_WidthOfBoard - index - 1] != m_Board.m_SignO))
                {
                    winSecondDiagnose = false;
                }
            }

            return winFirstdiagnose || winSecondDiagnose;
        }
    }
}