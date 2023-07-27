
namespace TxtEditor
{
    partial class UploadReplaceForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.replaceButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Replace with:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Find what:";
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(349, 122);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(86, 25);
            this.replaceButton.TabIndex = 12;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(349, 44);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(86, 27);
            this.findNextButton.TabIndex = 11;
            this.findNextButton.Text = "Find next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(47, 125);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(275, 22);
            this.replaceTextBox.TabIndex = 10;
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(47, 44);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(275, 22);
            this.findTextBox.TabIndex = 9;
            // 
            // UploadReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 179);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.findTextBox);
            this.Name = "UploadReplaceForm";
            this.Text = "ReplaceForm";
            this.Activated += new System.EventHandler(this.UploadReplaceForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.TextBox findTextBox;
    }
}