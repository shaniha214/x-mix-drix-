using System;
using System.Windows.Forms;

namespace View
{
    public class UI
    {
        private readonly SettingsForm m_SettingsForm = new SettingsForm();
        private readonly BoardForm m_Board = new BoardForm();

        public SettingsForm SettingForm
        {
            get { return m_SettingsForm; }
        }

        public BoardForm BoardForm
        {
            get { return m_Board; }
        }

        public bool ExitOrContinue(string i_Message, string i_WinnerName)
        {
            string message = string.Empty;
            DialogResult result;

            if (i_Message == "A Win!")
            {
                message = string.Format(
                    @"The winner is {0}!
Would you like another round?",
                    i_WinnerName);
            }
            else
            {
                message = string.Format(@"Tie!
Would you like another round");
            }

            m_Board.Show();
            result = MessageBox.Show(new Form { TopMost = true }, message, i_Message, MessageBoxButtons.YesNo);

            return result == DialogResult.Yes;
        }
    }
}
