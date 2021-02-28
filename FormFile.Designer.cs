namespace Coursework
{
    partial class FormFile
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelEncode = new System.Windows.Forms.Label();
            this.richTextBoxFile = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(34, 153);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(211, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(64, 64);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(42, 13);
            this.labelFile.TabIndex = 1;
            this.labelFile.Text = "Файл: ";
            // 
            // labelEncode
            // 
            this.labelEncode.AutoSize = true;
            this.labelEncode.Location = new System.Drawing.Point(106, 21);
            this.labelEncode.Name = "labelEncode";
            this.labelEncode.Size = new System.Drawing.Size(0, 13);
            this.labelEncode.TabIndex = 2;
            // 
            // richTextBoxFile
            // 
            this.richTextBoxFile.Location = new System.Drawing.Point(67, 80);
            this.richTextBoxFile.Name = "richTextBoxFile";
            this.richTextBoxFile.Size = new System.Drawing.Size(145, 44);
            this.richTextBoxFile.TabIndex = 3;
            this.richTextBoxFile.Text = "";
            // 
            // FormFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.richTextBoxFile);
            this.Controls.Add(this.labelEncode);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormFile";
            this.Text = "Шифрование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelEncode;
        private System.Windows.Forms.RichTextBox richTextBoxFile;
    }
}