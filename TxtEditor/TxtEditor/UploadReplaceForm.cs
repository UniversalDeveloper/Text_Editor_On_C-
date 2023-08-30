using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ReplaceInTextBox();


        }
        private void ReplaceInTextBox()
        {
            var str = findTextBox.Text;
            string str2 = replaceTextBox.Text;
            var strBaasic = MainForm.mainForm.textBoxWorkArea.Text;
            if (strBaasic.Contains(str))
            {
                MainForm.mainForm.textBoxWorkArea.Text = strBaasic.Replace(str, str2);

            }           
        }
        private void TranslatReplaceInTextBox() 
        {
            var findStr = findTextBox.Text;
            string raplaceStr = replaceTextBox.Text;
            var inputText = MainForm.mainForm.textBoxWorkArea.Text;            
            MainForm.mainForm.textBoxWorkArea.Text = Regex.Replace(inputText, findStr, findStr+ "(" + raplaceStr.ToUpper() + ")", RegexOptions.IgnoreCase);

            /*if (inputText.Contains(findStr))
            {
             MainForm.mainForm.textBoxWorkArea.Text = inputText.Replace(findStr, findStr + "(" + raplaceStr.ToUpper() + ") ");    //strBaasic.Replace(str, str2);
                //FindWords = str2.Replace(str, " ##{" + str.ToUpper() + "}## "); str2.Replace(str,str+"(" + str2.ToUpper() + ") ");  
            }*/
        }

        private void translationNextButton_Click(object sender, EventArgs e)
        {
            TranslatReplaceInTextBox();

        }
    }
}
