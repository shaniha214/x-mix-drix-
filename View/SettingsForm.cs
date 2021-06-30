using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class SettingsForm : Form
    {
        private bool m_ClosedByStart = false;
        private int m_BoardSize = 3;        // default size
        private string m_Player1Name = null;
        private string m_Playe2rName = "Computer";
        private int m_Rival;        // 1  is computer , 0 is player

        public SettingsForm()
        {
            Application.EnableVisualStyles();
            intalizeComponents();
        }

        public void PlayersSettings()
        {
            m_BoardSize = (int)m_NUDCols.Value;
            m_Player1Name = m_TextBoxPlayer1Name.Text;
            if (m_TextBoxPlayer2Name.Enabled)
            {
                m_Rival = 0;
            }
            else
            {
                m_Rival = 1;
            }

            if (m_TextBoxPlayer2Name.Enabled)
            {
                m_Playe2rName = m_TextBoxPlayer2Name.Text;
            }

        }

        public int Rival
        {
            get { return m_Rival; }
            set { m_Rival = value; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
        }

        public string Player2Name
        {
            get { return m_Playe2rName; }
        }

        public bool Start
        {
            get { return m_ClosedByStart; }
        }

        private void buttonClickedm(object sender, EventArgs e)
        {
            m_ClosedByStart = sender == m_ButtonStart;
            this.Close();
        }

        private void numericUdClickm(object sender, EventArgs e)
        {
            if ((sender as NumericUpDown).Name == "NUDRows")
            {
                m_NUDCols.Value = m_NUDRows.Value;
            }
            else
            {
                m_NUDRows.Value = m_NUDCols.Value;
            }

        }

        private void checkBoxClickedm(object sender, EventArgs e)
        {
            m_TextBoxPlayer2Name.Enabled = true;
        }

        public Button StartGame
        {
            get { return m_ButtonStart; }
        }
    }
}
