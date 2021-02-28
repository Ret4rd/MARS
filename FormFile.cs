using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class FormFile : System.Windows.Forms.Form
    {
        public int ThreadId;
        public string FileName;
        public bool Encode;
        public FormFile(string name, bool encode)
        {
            //int ThreadId;
            ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            InitializeComponent();
            //ThreadId = Thread;
            FileName = name;
            richTextBoxFile.Text = name;
            Encode = encode;
            if (encode)
                labelEncode.Text = "Шифрование";
            else
                labelEncode.Text = "Расшифровка";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
