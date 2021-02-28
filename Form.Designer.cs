namespace Coursework
{
    partial class Form
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьКлючToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрузитьВекторИнциализацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.radioButtonECB = new System.Windows.Forms.RadioButton();
            this.radioButtonCBC = new System.Windows.Forms.RadioButton();
            this.radioButtonCFB = new System.Windows.Forms.RadioButton();
            this.radioButtonOFB = new System.Windows.Forms.RadioButton();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.buttonPassword = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxC0 = new System.Windows.Forms.TextBox();
            this.labelC0 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьКлючToolStripMenuItem,
            this.закрузитьВекторИнциализацииToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьКлючToolStripMenuItem
            // 
            this.загрузитьКлючToolStripMenuItem.Name = "загрузитьКлючToolStripMenuItem";
            this.загрузитьКлючToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.загрузитьКлючToolStripMenuItem.Text = "Загрузить ключ";
            this.загрузитьКлючToolStripMenuItem.Click += new System.EventHandler(this.загрузитьКлючToolStripMenuItem_Click);
            // 
            // закрузитьВекторИнциализацииToolStripMenuItem
            // 
            this.закрузитьВекторИнциализацииToolStripMenuItem.Name = "закрузитьВекторИнциализацииToolStripMenuItem";
            this.закрузитьВекторИнциализацииToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.закрузитьВекторИнциализацииToolStripMenuItem.Text = "Закрузить вектор инциализации";
            this.закрузитьВекторИнциализацииToolStripMenuItem.Click += new System.EventHandler(this.закрузитьВекторИнциализацииToolStripMenuItem_Click);
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(212, 146);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(93, 23);
            this.buttonEncode.TabIndex = 1;
            this.buttonEncode.Text = "Шифровать";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(37, 40);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(465, 20);
            this.textBoxKey.TabIndex = 2;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(212, 190);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(93, 23);
            this.buttonDecode.TabIndex = 3;
            this.buttonDecode.Text = "Расшифровать";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // radioButtonECB
            // 
            this.radioButtonECB.AutoSize = true;
            this.radioButtonECB.Location = new System.Drawing.Point(27, 34);
            this.radioButtonECB.Name = "radioButtonECB";
            this.radioButtonECB.Size = new System.Drawing.Size(46, 17);
            this.radioButtonECB.TabIndex = 4;
            this.radioButtonECB.TabStop = true;
            this.radioButtonECB.Text = "ECB";
            this.radioButtonECB.UseVisualStyleBackColor = true;
            // 
            // radioButtonCBC
            // 
            this.radioButtonCBC.AutoSize = true;
            this.radioButtonCBC.Location = new System.Drawing.Point(27, 58);
            this.radioButtonCBC.Name = "radioButtonCBC";
            this.radioButtonCBC.Size = new System.Drawing.Size(46, 17);
            this.radioButtonCBC.TabIndex = 5;
            this.radioButtonCBC.TabStop = true;
            this.radioButtonCBC.Text = "CBC";
            this.radioButtonCBC.UseVisualStyleBackColor = true;
            // 
            // radioButtonCFB
            // 
            this.radioButtonCFB.AutoSize = true;
            this.radioButtonCFB.Location = new System.Drawing.Point(27, 82);
            this.radioButtonCFB.Name = "radioButtonCFB";
            this.radioButtonCFB.Size = new System.Drawing.Size(45, 17);
            this.radioButtonCFB.TabIndex = 6;
            this.radioButtonCFB.TabStop = true;
            this.radioButtonCFB.Text = "CFB";
            this.radioButtonCFB.UseVisualStyleBackColor = true;
            // 
            // radioButtonOFB
            // 
            this.radioButtonOFB.AutoSize = true;
            this.radioButtonOFB.Location = new System.Drawing.Point(27, 106);
            this.radioButtonOFB.Name = "radioButtonOFB";
            this.radioButtonOFB.Size = new System.Drawing.Size(46, 17);
            this.radioButtonOFB.TabIndex = 7;
            this.radioButtonOFB.TabStop = true;
            this.radioButtonOFB.Text = "OFB";
            this.radioButtonOFB.UseVisualStyleBackColor = true;
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonCBC);
            this.groupBoxMode.Controls.Add(this.radioButtonOFB);
            this.groupBoxMode.Controls.Add(this.radioButtonECB);
            this.groupBoxMode.Controls.Add(this.radioButtonCFB);
            this.groupBoxMode.Location = new System.Drawing.Point(398, 125);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(104, 137);
            this.groupBoxMode.TabIndex = 8;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Режимы шифрования";
            // 
            // buttonPassword
            // 
            this.buttonPassword.BackgroundImage = global::Coursework.Properties.Resources.eye;
            this.buttonPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPassword.Location = new System.Drawing.Point(508, 56);
            this.buttonPassword.Name = "buttonPassword";
            this.buttonPassword.Size = new System.Drawing.Size(33, 32);
            this.buttonPassword.TabIndex = 9;
            this.buttonPassword.UseVisualStyleBackColor = true;
            this.buttonPassword.Click += new System.EventHandler(this.buttonPassword_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(34, 24);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(33, 13);
            this.labelKey.TabIndex = 10;
            this.labelKey.Text = "Ключ";
            // 
            // textBoxC0
            // 
            this.textBoxC0.Location = new System.Drawing.Point(37, 82);
            this.textBoxC0.Name = "textBoxC0";
            this.textBoxC0.Size = new System.Drawing.Size(465, 20);
            this.textBoxC0.TabIndex = 11;
            // 
            // labelC0
            // 
            this.labelC0.AutoSize = true;
            this.labelC0.Location = new System.Drawing.Point(34, 66);
            this.labelC0.Name = "labelC0";
            this.labelC0.Size = new System.Drawing.Size(124, 13);
            this.labelC0.TabIndex = 12;
            this.labelC0.Text = "Вектор инициализации";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 295);
            this.Controls.Add(this.labelC0);
            this.Controls.Add(this.textBoxC0);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.buttonPassword);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mars";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.RadioButton radioButtonECB;
        private System.Windows.Forms.RadioButton radioButtonCBC;
        private System.Windows.Forms.RadioButton radioButtonCFB;
        private System.Windows.Forms.RadioButton radioButtonOFB;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.Button buttonPassword;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьКлючToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрузитьВекторИнциализацииToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxC0;
        private System.Windows.Forms.Label labelC0;
    }
}

