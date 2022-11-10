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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       

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

        
    }
}
