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

        
        //File New option.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:Code File New option.
            MessageBox.Show("Code File New option");

        }


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
