using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using View;
using GameProperties;

namespace Controller
{
    internal class Controller
    {
        private readonly Game m_Game;
        private bool m_GameRunning;
        private readonly UI m_UI;

        public Controller()
        {
            m_UI = new UI();
            m_Game = new Game();
            m_GameRunning = true;
        }

        public void GameLoop()
        {
            int[] points = new int[] { 0, 0 };

            m_UI.SettingForm.ShowDialog();
            initalizeGame();
            startGame();
            while (m_GameRunning)
            {
                if (m_UI.BoardForm.ShowDialog() == DialogResult.Cancel)
                {
                    break;
                }

                exitOrContinueExecute(points);
                m_Game.IntalizeGame();
                m_UI.BoardForm.UpdateBoard(m_Game.m_Board.BoardGame);
                m_UI.BoardForm.Hide();
            }

        }

        private void exitOrContinueExecute(int[] i_Points)
        {
            if (m_Game.IsTie())
            {
                m_GameRunning = m_UI.ExitOrContinue("A Tie!", "none");
            }
            else
            {
                m_GameRunning = m_UI.ExitOrContinue("A Win!", m_Game.CurrentWiner());
            }
 
            m_UI.BoardForm.UpdateBottomLable(m_Game.m_YourPlayer.Score, m_Game.m_RivalPlayer.Score(), m_Game.IsComputerPlaying());
        }

        public void SetGame()
        {
            m_UI.SettingForm.PlayersSettings();
            m_Game.Rival = m_UI.SettingForm.Rival;
            m_UI.BoardForm.BoardSize = m_UI.SettingForm.BoardSize;
            m_UI.BoardForm.InitializeComponent();
        }

        private void startGame()
        {
            m_Game.Start(m_UI.SettingForm.Player1Name, m_UI.SettingForm.Player2Name, m_UI.SettingForm.BoardSize, m_UI.SettingForm.Rival);
        }

        private void initalizeGame()
        {
            m_UI.BoardForm.OnButtonClick += HandelButtonClicked;
            SetGame();
        }

        public void HandelButtonClicked(Point i_ClickedBtn)
        {
            m_Game.PlaceMarker(ref i_ClickedBtn);
            if (m_Game.CheckFinish(i_ClickedBtn))
            {
                m_UI.BoardForm.UpdateBoard(m_Game.m_Board.BoardGame);
                m_UI.BoardForm.DialogResult = DialogResult.Abort;

                return;
            }

            if (m_Game.TryUpdateLogicMatrix(i_ClickedBtn))
            {
                if (m_Game.CheckFinish(i_ClickedBtn))
                {
                    m_UI.BoardForm.DialogResult = DialogResult.Abort;
                }
            }

            m_UI.BoardForm.UpdateBoard(m_Game.m_Board.BoardGame);
        }
    }
}
