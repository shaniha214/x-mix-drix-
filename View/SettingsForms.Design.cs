using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace View
{
    public partial class SettingsForm : Form
    {
        private Label m_LabelPlayers;
        private Label m_LabelPlayer1;
        private Label m_LabelPlayer2;
        private Label m_LabelBoardSize;
        private Label m_LabelRows;
        private Label m_LabelCols;
        private TextBox m_TextBoxPlayer1Name;
        private TextBox m_TextBoxPlayer2Name;
        private Button m_ButtonStart;
        private NumericUpDown m_NUDRows;
        private NumericUpDown m_NUDCols;
        private CheckBox m_CheckBoxPlayer2;

        private void intalizeComponents()
        {
            m_LabelPlayers = new Label();
            m_LabelPlayers.Text = "Players:";
            m_LabelPlayers.Top = 16;
            m_LabelPlayers.Left = 16;
            this.Controls.Add(m_LabelPlayers);

            m_LabelPlayer1 = new Label();
            m_LabelPlayer1.Text = "Player 1:";
            m_LabelPlayer1.Top = m_LabelPlayers.Bottom + 10;
            m_LabelPlayer1.Left = m_LabelPlayers.Left + 8;
            this.Controls.Add(m_LabelPlayer1);

            m_TextBoxPlayer1Name = new TextBox();
            m_TextBoxPlayer1Name.Left = m_LabelPlayer1.Right + 8;
            m_TextBoxPlayer1Name.Top = m_LabelPlayer1.Top + m_LabelPlayer1.Height / 2 - m_TextBoxPlayer1Name.Height / 2;
            this.Controls.Add(m_TextBoxPlayer1Name);

            m_LabelPlayer2 = new Label();
            m_LabelPlayer2.Text = "Player 2:";
            m_LabelPlayer2.Top = m_LabelPlayer1.Bottom + 8;
            m_LabelPlayer2.Left = m_LabelPlayer1.Left + 14;
            m_LabelPlayer2.Width = 50;
            this.Controls.Add(m_LabelPlayer2);

            m_CheckBoxPlayer2 = new CheckBox();
            m_CheckBoxPlayer2.Left = m_LabelPlayer1.Left - 1;
            m_CheckBoxPlayer2.Top = m_LabelPlayer2.Top - 4;
            m_CheckBoxPlayer2.Checked = false;
            m_CheckBoxPlayer2.Click += new EventHandler(checkBoxClickedm);
            this.Controls.Add(m_CheckBoxPlayer2);

            m_TextBoxPlayer2Name = new TextBox();
            m_TextBoxPlayer2Name.Left = m_TextBoxPlayer1Name.Left;
            m_TextBoxPlayer2Name.Top = m_LabelPlayer2.Top + m_LabelPlayer2.Height / 2 - m_TextBoxPlayer2Name.Height / 2;
            m_TextBoxPlayer2Name.Enabled = false;
            m_TextBoxPlayer2Name.Text = "Computer";
            this.Controls.Add(m_TextBoxPlayer2Name);

            m_LabelBoardSize = new Label();
            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Top = m_LabelPlayer2.Bottom + 16;
            m_LabelBoardSize.Left = m_LabelPlayers.Left;
            this.Controls.Add(m_LabelBoardSize);

            m_LabelRows = new Label();
            m_LabelRows.Text = "Rows:";
            m_LabelRows.Top = m_LabelBoardSize.Bottom + 4;
            m_LabelRows.Left = m_LabelBoardSize.Left + 10;
            m_LabelRows.Width = 50;
            this.Controls.Add(m_LabelRows);

            m_NUDRows = new NumericUpDown();
            m_NUDRows.Top = m_LabelBoardSize.Bottom + 4;
            m_NUDRows.Left = m_LabelRows.Right;
            m_NUDRows.Size = new System.Drawing.Size(40, 30);
            m_NUDRows.Minimum = 3;
            m_NUDRows.Maximum = 9;
            m_NUDRows.Click += new EventHandler(numericUdClickm);
            m_NUDRows.Name = "NUDRows";
            this.Controls.Add(m_NUDRows);

            m_LabelCols = new Label();
            m_LabelCols.Text = "Cols:";
            m_LabelCols.Top = m_LabelRows.Top;
            m_LabelCols.Left = m_NUDRows.Right + 20;
            m_LabelCols.Width = 50;
            this.Controls.Add(m_LabelCols);

            m_NUDCols = new NumericUpDown();
            m_NUDCols.Top = m_NUDRows.Top;
            m_NUDCols.Left = m_LabelCols.Right - 2;
            m_NUDCols.Size = new System.Drawing.Size(40, 30);
            m_NUDCols.Minimum = 3;
            m_NUDCols.Maximum = 9;
            m_NUDCols.Click += new EventHandler(numericUdClickm);
            m_NUDCols.Name = "NUDCols";
            this.Controls.Add(m_NUDCols);

            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.Top = m_LabelRows.Bottom + 16;
            m_ButtonStart.Left = m_LabelBoardSize.Left;
            m_ButtonStart.Click += new EventHandler(buttonClickedm);
            m_ButtonStart.Size = new Size(250, 30);
            this.Controls.Add(m_ButtonStart);

            this.Text = "Game Settings";
            this.Size = new Size(300, 300);
        }
    }
}