using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace TxtEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region Declear class veriable
        //  public string appTitle = MainForm.Application.Info.Title;
        private string _workingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// create path from root to folder MyDocuments automatecli for
                                                                                                       // different platforms whith out manual descrabing full path
       // private const string FILE_FILTER = "Plain Text(*.txt)|*.txt|" & "Plain text(*.txt)|*.txt|"

        #endregion

        #region File Menu

        #region File New option
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
              var switcherSavingOper= SaveChanges();
            if (switcherSavingOper==true)
            {
                saveToolStripMenuItem_Click( sender, e);
            }
            TextBoxWorkArea.Clear();
            TextBoxWorkArea.Modified = false;
            TextBoxWorkArea.Focus();


        }
        #endregion

        #region File Save option

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:Code File Save option.
            MessageBox.Show("Code File Save option");
        }

        public bool SaveChanges()
        {
            if (TextBoxWorkArea.Modified== true)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)                
                    return  true;                
            }
            return false;
        }
        #endregion

        #region File open

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion








        private void formatToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxWorkArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              string path = ".";

        string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// create path from root to folder MyDocuments automatecli for different platforms whith out manual descrabing full path
        //OpenFileDialog op = new OpenFileDialog();
        // op.ShowDialog() ;//= System.Windows.Forms.DialogResult.OK;

    }
    }
}
