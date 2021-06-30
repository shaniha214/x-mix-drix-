using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class FormFinishGame : Form
    {
        private Button m_ContinueBtn;
        private Button m_ExitBtn;
        private Label m_LabelFinishMesege;

        private void initializeComponent()
        {
            m_LabelFinishMesege = new Label();
            m_LabelFinishMesege.Top = 16;
            m_LabelFinishMesege.Left = 16;
            m_LabelFinishMesege.Width = 100;
            m_LabelFinishMesege.Size = new Size(100, 100);
            m_LabelFinishMesege.Width = 200;
            this.Controls.Add(m_LabelFinishMesege);

            m_ContinueBtn = new Button();
            m_ContinueBtn.Location = new System.Drawing.Point(40, 135);
            m_ContinueBtn.Name = "ContinueBtn";
            m_ContinueBtn.Size = new System.Drawing.Size(126, 47);
            m_ContinueBtn.TabIndex = 0;
            m_ContinueBtn.Text = "Yes";
            m_ContinueBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Controls.Add(m_ContinueBtn);

            m_ExitBtn = new Button();
            m_ExitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            m_ExitBtn.Location = new System.Drawing.Point(222, 135);
            m_ExitBtn.Name = "ExitBtn";
            m_ExitBtn.Size = new System.Drawing.Size(126, 47);
            m_ExitBtn.TabIndex = 1;
            m_ExitBtn.Text = "No";
            m_ExitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Controls.Add(m_ExitBtn);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 212);
            this.Controls.Add(m_ExitBtn);
            this.Controls.Add(m_ContinueBtn);
            this.Name = "ExitOrContinueForm";

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        }
    }
}