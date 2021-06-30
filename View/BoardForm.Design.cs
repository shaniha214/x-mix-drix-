using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class BoardForm : Form
    {
        private Label m_LabelBottomText;

        public void InitializeComponent()
        {
            m_Buttons = new Button[m_MatrixSize, m_MatrixSize];
            Point indexes;
            Button posButton;

            for (int i = 0; i < m_MatrixSize; i++)
            {
                for (int j = 0; j < m_MatrixSize; j++)
                {
                    indexes = new Point(i, j);
                    posButton = createButton(indexes);
                    posButton.Click += new EventHandler(buttonClick);
                    m_Buttons[i, j] = posButton;
                    m_Buttons[i, j].Top = 10 + (i * k_ButtonsHeightAndWidth);
                    m_Buttons[i, j].Left = 10 + (j * k_ButtonsHeightAndWidth);
                    m_Buttons[i, j].Text = k_EmptyPointSign.ToString();
                    this.Controls.Add(posButton);
                }

            }

            m_LabelBottomText = new Label();
            m_LabelBottomText.Top = m_MatrixSize * k_ButtonsHeightAndWidth + 3 * m_MatrixSize;
            m_LabelBottomText.Width = k_ButtonsHeightAndWidth * 7;
            m_LabelBottomText.Left = m_Buttons[(m_MatrixSize / 2) - 1, (m_MatrixSize / 2) - 1].Left;
            m_LabelBottomText.Text = "Player 0:0 Computer:0";
            this.Controls.Add(m_LabelBottomText);
            this.Size = new Size((m_MatrixSize + 1) * k_ButtonsHeightAndWidth -15, (m_MatrixSize + 1) * k_ButtonsHeightAndWidth + 39);
            this.Text = "Tic Tac Toe Misere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BoardForm_Load);
        }

    }
}
