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

        private void button_findNext_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            DialogResult dialog = new DialogResult();
            int start1 = 0;
            int end1 = MainForm.mainForm.textBoxWorkArea.Text.LastIndexOf(textBox_find.Text);

           var basicText = MainForm.textFromTexBox;//////////
             var CopybasicText = MainForm.textFromTexBox;
            string str2 = MainForm.textFromTexBox;
            var str = textBox_find.Text;

            while (start1 < end1)
            {

                start1 = basicText.IndexOf(textBox_find.Text, start1) + 1; // start1 = MainForm.mainForm.textBoxWorkArea.Text.IndexOf(textBox_find.Text, start1) + 1;
                MainForm.mainForm.textBoxWorkArea.SelectionStart = start1;

                if (start1 == -1)
                {//create dialog if we want to continue search we select founde word then ask to contunue serch

                    break;
                }
                else
                {
                    MainForm.mainForm.textBoxWorkArea.Select(start1 - 1,+ textBox_find.Text.Length);
                    MainForm.mainForm.textBoxWorkArea.Focus();

                   MainForm.mainForm.textBoxWorkArea.ScrollToCaret();
                    MainForm.mainForm.Show();

                   MainForm.mainForm.textBoxWorkArea.Text = basicText.Replace(str, " ##{" + str.ToUpper() + "}## ");/////
                    dialog = MessageBox.Show("Do you want to continue search?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dialog == DialogResult.Yes & start1 != 0)
                    {
                        continue;// contunue of search
                    }
                    else if(dialog == DialogResult.No)
                    {
                        break;
                    }
                }
            }
            dialog = MessageBox.Show("No more words to search");
            MainForm.mainForm.textBoxWorkArea.Text = basicText;
        }

       
        private void UploadFindForm_Activated(object sender, EventArgs e)
        {
            if (MainForm.findString != string.Empty)
            {
                textBox_find.Text = MainForm.findString;
            }

        }
    }
    
}
