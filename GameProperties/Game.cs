using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace GameProperties
{
    public class Game
    {
        public Player m_YourPlayer;
        public Rival m_RivalPlayer;
        public Board m_Board;
        public int m_MovesCounter = 0;
        private int m_RivalSign;

        public int Rival
        {
            get { return m_RivalSign; }
            set { m_RivalSign = value; }
        }

        public bool IsTie()
        {
            return m_MovesCounter == m_Board.m_SumOfCells;
        }

        public bool IsComputerPlaying()
        {
            return m_RivalSign == 1;
        }

        public void Start(string i_Name1, string i_Name2, int i_Size, int i_RivalSign)
        {
            AlocatePlayers(i_Name1, i_Name2, i_RivalSign);
            AlocateBoard(i_Size);
        }

        public int GetMyPlayerScore()
        {
            return m_YourPlayer.Score;
        }

        public void IntalizeGame()
        {
            m_Board.ClearBoard();
            m_MovesCounter = 0;
        }

        public string CurrentWiner()
        {
            if (m_MovesCounter % 2 == 0)
            {
                return m_YourPlayer.Name;
            }
            else
            {
                return m_RivalPlayer.Name();
            }
        }

        public int GetRivalPlayerScore()
        {
            return m_RivalPlayer.Score();
        }

        public void AlocatePlayers(string i_Name1, string i_Name2, int i_RivalSign)
        {
            m_YourPlayer = new Player(i_Name1);
            m_RivalPlayer = new Rival(i_Name2, i_RivalSign);
        }

        public void AlocateBoard(int i_Size)
        {
            m_Board = new Board(i_Size);
        }

        public bool CheckFinish(Point i_Pos)
        {
            return m_MovesCounter == m_Board.m_SumOfCells || CheckWin(i_Pos);
        }

        public bool CheckWin(Point i_Pos)
        {
            bool row = false;
            bool column = false;
            bool diagnose = false;

            row = checkRow(i_Pos);
            column = checkColumn(i_Pos);
            if (i_Pos.X == i_Pos.Y || Math.Abs(i_Pos.X - i_Pos.Y) == m_Board.m_WidthOfBoard - 1 || i_Pos.X + i_Pos.Y == m_Board.m_WidthOfBoard)
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

        private bool checkRow(Point i_Pos)
        {
            bool winRow = true;
            int index;

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[i_Pos.X, index] != m_Board.BoardGame[i_Pos.X, index + 1])
                {
                    winRow = false;
                }
            }

            return winRow;
        }

        private bool checkColumn(Point i_Pos)
        {
            bool winColumn = true;
            int index;

            for (index = 0; index < m_Board.m_WidthOfBoard - 1; index++)
            {
                if (m_Board.BoardGame[index, i_Pos.Y] != m_Board.BoardGame[index + 1, i_Pos.Y])
                {
                    winColumn = false;
                }

            }

            return winColumn;
        }

        public bool TryUpdateLogicMatrix(Point i_ChoosenPoint)
        {
            Point pos = new Point(0,0);

            if (1 == m_RivalSign)
            {
                m_RivalPlayer.m_Computer.Move(ref pos, m_Board, m_Board.m_SignO);
                m_MovesCounter++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlaceMarker(ref Point io_Pos)
        {
            if (0 == m_MovesCounter % 2)
            {
                m_YourPlayer.Move(ref io_Pos, m_Board, m_Board.m_SignX);
            }
            else if (0 != m_MovesCounter % 2&& 0 == Rival)
            {
               m_RivalPlayer.RivalMove(ref io_Pos, m_Board);
            }

            m_MovesCounter++;
        }

        private bool checkDiagnose(Point i_Pos)
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