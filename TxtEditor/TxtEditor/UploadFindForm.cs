using System;
using System.Windows.Forms;

namespace TxtEditor
{
    sealed partial class UploadFindForm : Form
    {// public static UploadFindForm findForm;
        private static UploadFindForm _instance;
        private static readonly object _lock = new object();
      //  public static HashTextFromTextBox hashText;
      public string FindWords { get; private set; }
        private UploadFindForm()
        {
            InitializeComponent();
          //  hashText = new HashTextFromTextBox(10);
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
            var str = textBox_find.Text;            
            string str2 = MainForm.textFromTexBox;
            if (str2.Contains(str))
            {
                FindWords = str2.Replace( str,str.ToUpper());
            }

        }
    }
}
