
namespace TxtEditor
{
    partial class UploadFindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_find = new System.Windows.Forms.TextBox();
            this.button_find = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "close and return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_find
            // 
            this.textBox_find.Location = new System.Drawing.Point(12, 21);
            this.textBox_find.Name = "textBox_find";
            this.textBox_find.Size = new System.Drawing.Size(334, 22);
            this.textBox_find.TabIndex = 1;
            // 
            // button_find
            // 
            this.button_find.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_find.Location = new System.Drawing.Point(400, 12);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(75, 31);
            this.button_find.TabIndex = 2;
            this.button_find.Text = "Find";
            this.button_find.UseVisualStyleBackColor = true;
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // UploadFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 110);
            this.Controls.Add(this.button_find);
            this.Controls.Add(this.textBox_find);
            this.Controls.Add(this.button1);
            this.Name = "UploadFindForm";
            this.Text = "FindForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadFindForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_find;
        private System.Windows.Forms.Button button_find;
    }
}