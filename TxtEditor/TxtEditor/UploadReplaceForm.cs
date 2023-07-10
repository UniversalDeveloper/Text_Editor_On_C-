using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TxtEditor
{
    sealed partial class UploadReplaceForm : Form
    {
        public UploadReplaceForm()
        {
            InitializeComponent();
        }

        private static UploadReplaceForm _instance;
        private static readonly object _lock = new object();


        public static UploadReplaceForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UploadReplaceForm();
                    }
                }
            }
            return _instance;
        }
        // retrieve last findString value
        private void UploadReplaceForm_Activated(object sender, EventArgs e)
        {
            if (MainForm.findString != string.Empty)
            {
                findTextBox.Text = MainForm.findString;
            }

        }

        private void Search()
        {
        }
        //replace text
        private void replaceButton_Click(object sender, EventArgs e)
        {
            while (MainForm.mainForm.textBoxWorkArea.Text.Length != 0)
            {
                if (MainForm.mainForm.textBoxWorkArea.SelectedText != string.Empty)
                {
                    MainForm.mainForm.textBoxWorkArea.SelectedText = replaceTextBox.Text;
                    MainForm.mainForm.textBoxWorkArea.Modified = true;
                    MainForm.mainForm.textBoxWorkArea.ScrollToCaret();
                    MainForm.mainForm.textBoxWorkArea.Focus();

                }
            }
            findNextButton_Click(sender, e);

        }

        private void findNextButton_Click(object sender, EventArgs e)
        {
            FindText();
        }
        private void FindText()
        {

            int startPos = 0;
            int foundPos = MainForm.mainForm.textBoxWorkArea.Text.LastIndexOf(findTextBox.Text);
            DialogResult dialog = new DialogResult();
            while (startPos < foundPos)
            {

                startPos = MainForm.mainForm.textBoxWorkArea.Text.IndexOf(findTextBox.Text, startPos) + 1;
              
                if (startPos == -1)
                {
dialog = MessageBox.Show("00000h?", "Confirmation", MessageBoxButtons.OK);
                    break;
                }
                else {
                  
                    MainForm.mainForm.textBoxWorkArea.Select(startPos - 1, findTextBox.Text.Length);
                    MainForm.mainForm.textBoxWorkArea.Focus();
                    MainForm.mainForm.textBoxWorkArea.ScrollToCaret();
                    
                }

               
            }
            dialog = MessageBox.Show("00000h?", "Confirmation", MessageBoxButtons.OK);

        }
    }
}
