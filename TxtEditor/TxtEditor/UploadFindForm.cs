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
            textBox_find.Clear();
            this.Hide();

        }


        private void button_find_Click(object sender, EventArgs e)
        {           
            Find(textBox_find.Text,richTextBoxFind);
        }
        
        private void Find(string inputStr,RichTextBox workAr) 
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
        {  /*/////////////ddddddddddddddddddddddddddd work for serching one word
             int start =0;
             int end = richTextBoxFind.Text.LastIndexOf(textBox_find.Text);
             richTextBoxFind.SelectAll();
             richTextBoxFind.SelectionBackColor = Color.White;
             while (start<end)
             {
                 richTextBoxFind.Find(textBox_find.Text,start,RichTextBoxFinds.None);
                 richTextBoxFind.SelectionBackColor = Color.Red;
                 start = richTextBoxFind.Text.IndexOf(textBox_find.Text,start)+1;
             }
            ///ddddddddddddddddddddddddddddddddddddddddd
            */
            // MainForm.f1.t1.Text = "Helo word";
            DialogResult dialog = new DialogResult();
            int start = 0;
            int end = MainForm.f1.t1.Text.LastIndexOf(textBox_find.Text);
            while (start<end)
            {
               
                start = MainForm.f1.t1.Text.IndexOf(textBox_find.Text, start) + 1;
                 MainForm.f1.t1.SelectionStart = start;

               // dialog = MessageBox.Show("Do you want to continue search?", "Confirmation", MessageBoxButtons.OKCancel);
                if (start==-1)
                {//create dialog if we want to continue search we select founde word then ask to contunue serch
                    
                    break;
                }
                else
                { MainForm.f1.t1.Select(start - 1, textBox_find.Text.Length);
                    MainForm.f1.t1.Focus();
                    MainForm.f1.t1.ScrollToCaret();
                    MainForm.f1.Show();
                    dialog= MessageBox.Show("Do you want to continue search?", "Confirmation", MessageBoxButtons.OK);

                    if (dialog == DialogResult.OK&start!=0)
                    {
                        continue;// contunue of search
                    }
                   
                }
                

            }
dialog = MessageBox.Show("Does not exist?");
        }
    }
}
