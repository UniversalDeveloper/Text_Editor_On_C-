using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace TxtEditor
{
    public partial class MainForm : Form
    {
        //public static HashTextFromTextBox hashText;
        public static string textFromTexBox;
        public  TextBox textBoxWorkArea;
        public static MainForm mainForm;
        public static string findString = string.Empty;
       
        public MainForm()
        { 
            InitializeComponent();
            mainForm = this;
            textBoxWorkArea = TextBoxWorkArea;
            // hashText = new HashTextFromTextBox(1000);
          //  textFromTexBox = "";
            undoToolStripMenuItem.Enabled = _undoList.Count > 0;//we can use Undo comand becouse TextBox area is empty



        }

        #region Declear class veriable


        private static string bufferSringOfTextBox = string.Empty;
        #region For File New, Open File,SaveChanges method ,ReturnSwitcherVarToBegin,Exit File,MainForm_FormClosing event
        private bool _switcherYesNo;
        private bool _switcherCancel;
        #endregion

        #region For Path of Text Editor
        private string _workingFilePath = string.Empty;
        //private string appTitle = ((AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;//gives the value of the Title

        private string _workingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// create path from root to folder MyDocuments automatecli for
                                                                                                       // different platforms whith out manual descrabing full path
        private const string FILE_FILTER = "Plain Text(*.txt)|*.txt|" +
                                           "Log Files(*.log)|*.log|" +
                                            "All Files(*.*)|*.*";
        #endregion

        #region For Saving functio 
        private bool switcherCancelSaving;// if we change mind of saving file and creating new with out of loss data
        #endregion

        #region For Undo function
        private Stack<string> _undoList = new Stack<string>();
        private bool isOpenFile = false;
        #endregion
        #endregion

        #region File Menu

        #region File New option
        //// is tested already
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxWorkArea.Text))// text box area not ampty
            {
                SaveChanges();

                var savingOper = _switcherYesNo;
                if (savingOper == true)
                {
                    //clean old path 
                    _workingFilePath = string.Empty;

                    saveToolStripMenuItem_Click(sender, e);
                    var cancelSave = switcherCancelSaving;
                    if (cancelSave == false)// if we want to continue of saving file with chenges befor creating new file
                    {
                        CleanTextBoxAr();
                    }
                    else if (cancelSave == true)// if we do not to continue saving file, with returing in file with out changes and opening new file
                    {
                        return;
                    }
                }
                else if (savingOper == false && _switcherCancel == false)
                {
                    CleanTextBoxAr();
                }
                else // button clear
                {
                    return;
                }
            }
            else
            {
                //clean old path 
                _workingFilePath = string.Empty;
            }

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
            else
            {
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
                DefaultExt = "txt"

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

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _workingFilePath = saveFileDialog.FileName;
                SaveFile();
            }
            else
            {
                switcherCancelSaving = true;
                return;// if we presed cancel we needed to go back with any changes of old documents
            }

        }
        #endregion
        #endregion

        #region File Open (Tested++)

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TextBoxWorkArea.Text))
            {
                SaveChanges();
                var switcherSavingOper = _switcherYesNo;
                if (switcherSavingOper == true)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                else if (_switcherCancel == true)
                {
                    return;
                }
                var cancelSave = switcherCancelSaving;
                if (cancelSave == true)// if we want to continue of saving file with chenges befor creating new file
                {
                    return;
                }
                OpenFile();
            }
            else
            {
                OpenFile();
            }
            ReturnSwitcherVarToBegin();
        }


        #endregion
        #endregion
        #region Edit Menu
        #region Copy/Cut/Delete/Undo/Past/Select all/Date time
        private void TimeDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            TextBoxWorkArea.SelectedText = current.ToString("M/d/yyyy");
            TextBoxWorkArea.Modified = true;

        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxWorkArea.Text))
            {
                TextBoxWorkArea.SelectAll();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextBoxWorkArea.SelectedText != "")
            {
                PutTextInBufArea();
                TextBoxWorkArea.Text = DeleteSelectedText();
                cutToolStripMenuItem.Enabled = false;
                cutToolStripButton.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                copyToolStripButton.Enabled = false;
                pasteToolStripButton.Enabled = true;
            }
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextBoxWorkArea.SelectedText != "")
            {
                PutTextInBufArea();
                copyToolStripButton.Enabled = false;
                copyToolStripButton.Enabled = false;
            }


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TextBoxWorkArea.SelectedText != "")
            {
                TextBoxWorkArea.Clear();
            }
            deleteToolStripMenuItem.Enabled = false;
        }

        #region Undo

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_undoList.Count == 2 & isOpenFile == true)
            {
                UnDoOpenFile();
            }
            else
            {
                UnDoCleatTetxEreaWithOutOpenFile();
            }
        }

        private void UnDoOpenFile()
        {
            _undoList.Pop();
            TextBoxWorkArea.Text = _undoList.Peek();
            undoToolStripMenuItem.Enabled = false;
        }
        private void UnDoCleatTetxEreaWithOutOpenFile()
        {
            if (_undoList.Count != 0)
            {
                _undoList.Pop();
                if (_undoList.Count == 0)
                {
                    TextBoxWorkArea.Clear();
                }
                else
                {
                    TextBoxWorkArea.Text = _undoList.Peek();
                }
            }
            undoToolStripMenuItem.Enabled = _undoList.Count > 0;//we can use Undo comand antil Stack has got elements working with

        }

        private void RecodEdit()
        {
            _undoList.Push(TextBoxWorkArea.Text);// added recod about changes in text box
            if (isOpenFile == true & _undoList.Count == 1)
            {
                undoToolStripMenuItem.Enabled = false;// agreed that we can use undo from menu strip
            }
            else
            {
                undoToolStripMenuItem.Enabled = true;
            }

        }
        #endregion


        #endregion

        #endregion
        #region Font
        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialogWorke.ShowColor = true;
            fontDialogWorke.ShowApply = true;
            fontDialogWorke.Font = TextBoxWorkArea.Font;
            fontDialogWorke.Color = TextBoxWorkArea.ForeColor;
            if (fontDialogWorke.ShowDialog() == DialogResult.OK)
            {
                TextBoxWorkArea.Font = fontDialogWorke.Font;
                TextBoxWorkArea.ForeColor = fontDialogWorke.Color;
            }
        }

        private void fontDialogWorke_Apply(object sender, EventArgs e)
        {
            TextBoxWorkArea.Font = fontDialogWorke.Font;
            TextBoxWorkArea.ForeColor = fontDialogWorke.Color;
        }
        #endregion
        #region Help
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm a = new AboutBoxForm();
            a.ShowDialog();
        }
        #endregion

        #region Aditional methodth for correct work File Menu components
        private void CleanTextBoxAr()
        {
            TextBoxWorkArea.Clear();
            TextBoxWorkArea.Modified = false;
            TextBoxWorkArea.Focus();
            _workingFilePath = string.Empty;
            if (_workingFilePath == "")
            {
                _workingFilePath = "C:\\Users\\пк\\Documents";
                this.Text = Path.GetFullPath(_workingFilePath);

            }
            else
            {
                this.Text = Path.GetFullPath(_workingFilePath);
            }


        }
        private void OpenFile()
        {
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

                #region Use UnDo
                isOpenFile = true;
                _undoList.Clear();
                RecodEdit();
                #endregion

            }
        }
        private void GetFile()
        {
            try
            {
                TextBoxWorkArea.Text = File.ReadAllText(_workingFilePath);//we read all text from file and then clouse file stream
                TextBoxWorkArea.Modified = false;
                TextBoxWorkArea.Focus();// return worke cursor in worke area

                _workingPath = Path.GetFullPath(_workingFilePath);//it return full cross-platform manner path of open file object
                this.Text = Path.GetFullPath(_workingFilePath);// change title of window form

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
        public void SaveFile()
        {
            try
            {
                File.WriteAllText(_workingFilePath, TextBoxWorkArea.Text);
                TextBoxWorkArea.Modified = false;
                TextBoxWorkArea.Focus();
                this.Text = Path.GetFullPath(_workingFilePath);
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
        private void ConfirmSavingInf()
        {
            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.No:
                    _switcherYesNo = false;
                    break;
                case DialogResult.Yes:
                    _switcherYesNo = true;
                    break;
                case DialogResult.Cancel:
                    _switcherCancel = true;
                    break;

            }
        }
        public void SaveChanges()
        {
            ReturnSwitcherVarToBegin();

            if (TextBoxWorkArea.Modified == true || !string.IsNullOrEmpty(TextBoxWorkArea.Text))//we cheack if text area was modifided or some file without changes was open before
            {
                ConfirmSavingInf();
            }
        }
        private string DeleteSelectedText()
        {
            int a = TextBoxWorkArea.SelectionLength;
            return TextBoxWorkArea.Text.Remove(TextBoxWorkArea.SelectionStart, a);
        }
        private void VisualOfCutPastCopy()
        {
            if (TextBoxWorkArea.SelectedText != "")
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            if (bufferSringOfTextBox == null || bufferSringOfTextBox == string.Empty)
            {
                pasteToolStripMenuItem.Enabled = false;
            }
            else { pasteToolStripMenuItem.Enabled = true; }
        }
        private void PutTextInBufArea()
        {
            bufferSringOfTextBox = TextBoxWorkArea.SelectedText;

        }
        private void ReturnSwitcherVarToBegin()
        {
            switcherCancelSaving = false;
            _switcherCancel = false;
            _switcherYesNo = false;
        }
        private void CloseTextFilde(object sender, EventArgs e)
        {
            if (TextBoxWorkArea.Modified == true || !string.IsNullOrEmpty(TextBoxWorkArea.Text))
            {
                ConfirmSavingInf();
                if (_switcherYesNo == true)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    bufferSringOfTextBox = string.Empty;
                    System.Windows.Forms.Application.ExitThread();
                }

            }
            bufferSringOfTextBox = string.Empty;
            System.Windows.Forms.Application.ExitThread();
        }
        private void TextBoxWorkArea_TextChanged(object sender, EventArgs e)
        {

            if (TextBoxWorkArea.Modified)
            {
                textFromTexBox = TextBoxWorkArea.Text;
                RecodEdit();
            }

        }

        #endregion

        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(TextBoxWorkArea.Text))
            {
                textFromTexBox = TextBoxWorkArea.Text;
                selectAllToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem.Enabled = true;

            }
            VisualOfCutPastCopy();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string appTitle = ((AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
        }
        #region Exit File
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTextFilde(sender, e);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseTextFilde(sender, e);
        }







        #endregion



        private void TextBoxWorkArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (TextBoxWorkArea.SelectedText != "")
            {
                cutToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }


        private void TextBoxWorkArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                cutToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
            }

        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (bufferSringOfTextBox != null || bufferSringOfTextBox != string.Empty)
            {
                TextBoxWorkArea.Text += bufferSringOfTextBox;
            }
        }
        #region Find position
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            textFromTexBox = TextBoxWorkArea.Text;             
        UploadFindForm uploadFind =  UploadFindForm.GetInstance();          
          
             uploadFind.Show();

           
        }



        #endregion

        private void findNextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UploadFindForm uploadFind = UploadFindForm.GetInstance();
            textFromTexBox = TextBoxWorkArea.Text;
            uploadFind.Show();

        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UploadReplaceForm uploadReplace = UploadReplaceForm.GetInstance();
            uploadReplace.Show();
            
        }
        
        
        #region File Print Option     
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: print functionality

            printDialog1.PrinterSettings = printDocument1.PrinterSettings;
            printDialog1.Document = printDocument1;

            printDialog1.AllowSomePages = true;
            printDialog1.PrinterSettings.MinimumPage = 1;
            printDialog1.PrinterSettings.MaximumPage = 9999;
            printDialog1.PrinterSettings.FromPage = 1;
            printDialog1.PrinterSettings.ToPage = 9999;

            if (DialogResult.OK == printDialog1.ShowDialog())
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;


                try
                {
                    printDocument1.Print();
                }
                catch (InvalidPrinterException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Printing File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
        }
        #endregion
    }
}
