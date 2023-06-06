using System;
using System.Drawing;
using System.Windows.Forms;

namespace TxtEditor
{
    sealed partial class UploadFindForm : Form
    {
        private static UploadFindForm _instance;
        private static readonly object _lock = new object();
      



        public string FindWords { get; private set; }
        private UploadFindForm()
        {
            InitializeComponent();
            richTextBoxFind.Text = MainForm.textFromTexBox;
            

        }

        public static UploadFindForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UploadFindForm();
                    }
                }
            }
            return _instance;
        }



        private void UploadFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancel the closing event from the closing the for
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // FindWords = basicText;
            textBox_find.Clear();
            this.Hide();

        }


        private void button_find_Click(object sender, EventArgs e)
        {
           
            FindNext(textBox_find.Text,richTextBoxFind);

        }
        
        private void FindNext(string inputStr,RichTextBox workAr) 
        {
            string[] words = inputStr.Split(' ', ',', '.', '-','\n', '\t');
            workAr.SelectAll();
            workAr.SelectionBackColor = Color.White;
            foreach (var word in words)
            {
                int startPosIndx = 0;
                while (startPosIndx< workAr.TextLength)
                {
                    int wordStartIndex = workAr.Find(word,startPosIndx,RichTextBoxFinds.None);
                    if (wordStartIndex!=-1)
                    {
                        workAr.SelectionStart = wordStartIndex;
                        workAr.SelectionLength = word.Length;
                        workAr.SelectionBackColor = Color.Red;

                    }
                    else
                    {
                        break;
                    }
                    startPosIndx += wordStartIndex + word.Length;
                }
            }

        }
      
        private void button_findNext_Click(object sender, EventArgs e)
        {

        }
    }
}
