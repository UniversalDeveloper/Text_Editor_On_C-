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
using System.Reflection;

namespace TxtEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region Declear class veriable
        private string _workingFilePath = string.Empty;
        public string appTitle = ((AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;//gives the value of the Title

        private string _workingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// create path from root to folder MyDocuments automatecli for
                                                                                                       // different platforms whith out manual descrabing full path
        private const string FILE_FILTER = "Plain Text(*.txt)|*.txt|" +
                                           "Log Files(*.log)|*.log|" +
                                            "All Files(*.*)|*.*";

        #endregion

        #region File Menu

        #region File New option
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var switcherSavingOper = SaveChanges();
            if (switcherSavingOper == true)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            TextBoxWorkArea.Clear();
            TextBoxWorkArea.Modified = false;
            TextBoxWorkArea.Focus();


        }
        #endregion
        #region File Save
        #region File Save option

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if there is a valid file name, save file(workingFilePath not empty).Otherwise follow SAVE AS logic
            if (_workingFilePath != string.Empty & _workingFilePath.EndsWith(".txt") | _workingFilePath.EndsWith(".log"))
            {
                SaveFile();
            }
            else {
                saveAsToolStripMenuItem_Click(sender, e);// call method SAVE AS
            }
           
        }
        #endregion
        #region File Save as option
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {//Use the SAVE FILE DIALOG (from tool box)to get file path and name,then save file
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            { 
                Filter = FILE_FILTER,
                DefaultExt= "txt"

            };
            if (_workingFilePath == string.Empty)
            {
                saveFileDialog.FileName = "Document.txt";
                saveFileDialog.InitialDirectory = _workingPath;
            }
            else 
            {
                saveFileDialog.FileName = Path.GetFileName(_workingFilePath);
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(_workingFilePath);
            }
            if (saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                _workingFilePath = saveFileDialog.FileName;
                SaveFile();
            }

        }
        #endregion
        #endregion
        public void SaveFile() { }
        #region File Open

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var switcherSavingOper = SaveChanges();
            if (switcherSavingOper == true)
            {
                saveToolStripMenuItem_Click(sender, e);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = FILE_FILTER,
                DefaultExt = "txt",
                FileName = string.Empty,
                InitialDirectory = _workingPath

            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _workingFilePath = openFileDialog.FileName;// if we choose document we take full path
                GetFile();

            }
        }


        #endregion
        #endregion
        private void GetFile()
        {
            try
            {
                TextBoxWorkArea.Text = File.ReadAllText(_workingPath);//we read all text from file and then clouse file stream
                TextBoxWorkArea.Modified = false;
                TextBoxWorkArea.Focus();// return worke cursor in worke area

                _workingFilePath = Path.GetFullPath(_workingPath);//it return full cross-platform manner path of open file object
                this.Text = this.Text + "-" + Path.GetFullPath(_workingFilePath);// change title of window form
            }
            catch (IOException ex)
            {
                MessageBox.Show("File IO Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("File Permission Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was problem the file selected", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }   
        }
        public bool SaveChanges()
        {
            if (TextBoxWorkArea.Modified == true)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    return true;
            }
            return false;
        }






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
            string appTitle = ((AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
        }

       
    }
}
