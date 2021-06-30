using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    partial class BoardForm : Form
    {
        private const char k_FirstPlayerSign = 'X';
        private const char k_SecPlayerSign = 'O';
        private const char k_EmptyPointSign = '\0';
        private const int k_ButtonsHeightAndWidth = 55;
        public string m_BottomMessage = "Player {0}:{1}  computer:{2}";
        private int m_MatrixSize;
        public Button[,] m_Buttons;

        public event Action<Point> OnButtonClick;

        public int BoardSize
        {
            get { return m_MatrixSize; }
            set { m_MatrixSize = value; }
        }

        public BoardForm()
        {
            Application.EnableVisualStyles();
        }

        public void BoardBuilder()
        {
            InitializeComponent();
        }

        public void UpdateBottomLable(int i_Player1Scoe, int i_Player2Scoe, bool i_IsCompyterPlayer)
        {
            if (i_IsCompyterPlayer)
            {
                m_LabelBottomText.Text = string.Format(m_BottomMessage, i_Player1Scoe, 0, i_Player2Scoe);
            }
            else
            {
                m_LabelBottomText.Text = string.Format(m_BottomMessage, i_Player1Scoe, i_Player2Scoe, 0);
            }

        }

        private Point getPointFromButton(Button i_CurrentButton)
        {
            string[] coordinates = i_CurrentButton.Name.Split(',');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            return new Point(x, y);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Point coords = getPointFromButton(sender as Button);
            OnButtonClick(coords);
        }

        public void UpdateBoard(char[,] i_LogicMatrix)
        {
            updateMatrix(i_LogicMatrix);
        }

        private Button createButton(Point i_Indx)
        {
            Button button = new Button();

            button.Name = i_Indx.X.ToString() + "," + i_Indx.Y.ToString();
            button.Size = new System.Drawing.Size(k_ButtonsHeightAndWidth, k_ButtonsHeightAndWidth);

            return button;
        }

        public void OnUpdateCell(Point i_ToUpdate, char i_Sign)
        {
            int col = i_ToUpdate.X;
            int row = i_ToUpdate.Y;
            Button currentButton = m_Buttons[col, row];

            if (i_Sign == k_EmptyPointSign)
            {
                currentButton.Text = string.Empty;
                currentButton.BackgroundImage = null;
            }

            m_Buttons[col, row].Text = i_Sign.ToString();
            currentButton.Enabled = false;
        }

        private void updateMatrix(char[,] i_LogicMatrix)
        {
            Button currentButton;
            for (int i = 0; i < m_MatrixSize; i++)
            {
                for (int j = 0; j < m_MatrixSize; j++)
                {
                    currentButton = m_Buttons[i, j];
                    if (i_LogicMatrix[i, j] == k_EmptyPointSign)
                    {
                        currentButton.Text = k_EmptyPointSign.ToString();
                        currentButton.Enabled = true;
                    }
                    else
                    {
                        if (i_LogicMatrix[i, j] == k_FirstPlayerSign)
                        {
                            m_Buttons[i, j].Text = k_FirstPlayerSign.ToString();
                        }
                        else
                        {
                            m_Buttons[i, j].Text = k_SecPlayerSign.ToString();
                        }
                       
                        currentButton.Enabled = false;
                    }

                }

            }

        }

        private void BoardForm_Load(object sender, EventArgs e)
        {
        }
    }
}
