﻿
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
            this.button_findNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_find
            // 
            this.textBox_find.Location = new System.Drawing.Point(12, 58);
            this.textBox_find.Name = "textBox_find";
            this.textBox_find.Size = new System.Drawing.Size(334, 22);
            this.textBox_find.TabIndex = 1;
            // 
            // button_findNext
            // 
            this.button_findNext.Location = new System.Drawing.Point(370, 23);
            this.button_findNext.Name = "button_findNext";
            this.button_findNext.Size = new System.Drawing.Size(126, 33);
            this.button_findNext.TabIndex = 3;
            this.button_findNext.Text = "Find Next";
            this.button_findNext.UseVisualStyleBackColor = true;
            this.button_findNext.Click += new System.EventHandler(this.button_findNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Find row in Text:";
            // 
            // UploadFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_findNext);
            this.Controls.Add(this.textBox_find);
            this.Controls.Add(this.button1);
            this.Name = "UploadFindForm";
            this.Text = "Find in Text";
            this.Activated += new System.EventHandler(this.UploadFindForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadFindForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_find;
        private System.Windows.Forms.Button button_findNext;
        private System.Windows.Forms.Label label1;
    }
}