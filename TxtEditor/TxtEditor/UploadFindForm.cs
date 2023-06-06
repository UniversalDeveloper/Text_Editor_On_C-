using System;
using System.Drawing;
using System.Windows.Forms;

namespace TxtEditor
{
    sealed partial class UploadFindForm : Form
    {
        private static UploadFindForm _instance;
        private static readonly object _lock = new object();
       public static string basicText;
        public MainForm f1;

        public string FindWords { get; private set; }
        private UploadFindForm()
        {
            InitializeComponent();
            f1 = new MainForm();
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


        /*  private void HashTextBox()
          {
              var splitRow = hashText.Split(MainForm.textFromTexBox);
              foreach (var item in splitRow)
              {
                  hashText.Add(item);

              }
          }*/

        private void button_find_Click(object sender, EventArgs e)
        {

            FindNext();

            /* replase selected words in tex box main
            basicText= MainForm.textFromTexBox;
            var str = textBox_find.Text;            
             string str2 = MainForm.textFromTexBox;
             if (str2.Contains(str))
             {
               
                 FindWords = str2.Replace( str," ##{" + str.ToUpper() + "}## ");
              
             }
             */
        }
        /// <summary>
        /// create worle find method for test tecst box
        /// </summary>
        // 66668
       
        private void FindNext(string inputStr) 
        {
            string[] words = textBox_find.Text.Split(' ', ',', '.', '-','\n', '\t');
            richTextBoxFind.SelectAll();
            richTextBoxFind.SelectionBackColor = Color.White;
            foreach (var word in words)
            {
                int startPosIndx = 0;
                while (startPosIndx<richTextBoxFind.TextLength)
                {
                    int wordStartIndex = richTextBoxFind.Find(word,startPosIndx,RichTextBoxFinds.None);
                    if (wordStartIndex!=-1)
                    {
                        richTextBoxFind.SelectionStart = wordStartIndex;
                        richTextBoxFind.SelectionLength = word.Length;
                        richTextBoxFind.SelectionBackColor = Color.Red;

                    }
                    else
                    {
                        break;
                    }
                    startPosIndx += wordStartIndex + word.Length;
                }
            }

            /* /////////////ddddddddddddddddddddddddddd work for serching one word
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
           
        }
        // ehen Find text changes,update MainForms finding var
        private void textBox_find_TextChanged(object sender, EventArgs e)
        {

            /*
            if (textBox_find.Text.Length>0)
            {
                MainForm.findString = textBox_find.Text;
                //Unselecte last find, but keep cursor at current location.
                f1.TextBoxWorkArea.Select(f1.TextBoxWorkArea.SelectionStart, 0);
            }
            else
            {
                MainForm.findString = string.Empty;
                button_findNext.Enabled = false;
            }*/
        }
    }
}
