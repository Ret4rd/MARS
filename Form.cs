using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ModeWork;
using Crypto;
using System.Threading;


namespace Coursework
{
    public partial class Form : System.Windows.Forms.Form
    {
        const int blockSize = 16;
        const int blockKeySize = 56;
        const int subblockSize = 4;

        public byte[] text;
        public byte[] byteKey;
        public byte[] bytec0;

        //public int mainThread;
        //ECB trees = new ECB();
        public Form()
        {
            InitializeComponent();
            radioButtonECB.Checked = true;
            //mainThread = mainThreadId;
        }

        private async void buttonEncode_Click(object sender, EventArgs e)
        {
            if ((textBoxKey.Text == "" && byteKey == null) ||
                (textBoxC0.Text == "" && bytec0 == null && !radioButtonECB.Checked))
            {
                MessageBox.Show("Не введены данные");
                return;
            }
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filePath = openFileDialog.FileName;
            Task read = Task.Run(() =>
            {
                try
                {
                    text = File.ReadAllBytes(filePath);
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });
            read.Wait();
            
            if (text == null)
            {
                MessageBox.Show("Нет текста");
                return;
            }
                
            ICoder modeWork = null;
            if(byteKey == null)
                byteKey = Encoding.Default.GetBytes(textBoxKey.Text);

            var addByte = new List<byte>();
            for (int i = byteKey.Length; i < blockKeySize; i++)
                addByte.Add(byteKey[i % byteKey.Length]);
            byteKey = byteKey.Concat(addByte.ToArray()).ToArray();

            
            if (!radioButtonECB.Checked)
            {
                if (bytec0 == null)
                    bytec0 = Encoding.Default.GetBytes(textBoxC0.Text);
                addByte = new List<byte>();
                for (int i = bytec0.Length; i < blockSize; i++)
                    addByte.Add(bytec0[i % bytec0.Length]);
                bytec0 = bytec0.Concat(addByte.ToArray()).ToArray();
            }
            
            if (text.Length % blockSize != 0)
            {
                addByte = new List<byte>();
                for (int i = 0; i < blockSize - text.Length % blockSize; i++)
                    addByte.Add(0);

                text = text.Concat(addByte.ToArray()).ToArray();
            }
            uint[] T = new uint[14];
            
            for (int i = 0; i < byteKey.Length; i += subblockSize)
            {
                T[i / subblockSize] = BitConverter.ToUInt32(byteKey.Skip(i).Take(subblockSize).ToArray(), 0);
            }

            var fileName = Path.GetFileName(openFileDialog.FileName);
            FormFile wind = new FormFile(fileName, true);
            var mars = new Mars(T);
            if (radioButtonECB.Checked)
                modeWork = new ECB(mars, wind);
            else if (radioButtonCBC.Checked)
                modeWork = new CBC(mars, bytec0, wind);
            else if (radioButtonCFB.Checked)
                modeWork = new CFB(mars, bytec0, wind);
            else if (radioButtonOFB.Checked)
                modeWork = new OFB(mars, bytec0, wind);

            wind.Show();
            byte[] result = new byte[] { };
            if (radioButtonECB.Checked)
            {
                int processorCount = 2;
                Task<byte[]>[] allTasks = new Task<byte[]>[processorCount];

                for (int i = 0; i < processorCount; i++)
                {
                    int indexI = i; // т.к. значение i может поменяться при EndInvoke
                    allTasks[indexI] = Task.Run(() => modeWork.Encode(text.Skip(text.Length / processorCount * i).Take(text.Length / processorCount).ToArray()));
                    Thread.Sleep(100);
                }

                await Task.WhenAll(allTasks);
                for (int i = 0; i < processorCount; i++)
                {
                    result = result.Concat(allTasks[i].Result).ToArray();
                }
            }
            else
                result = await modeWork.Encode(text);
            wind.progressBar.Value = 100;
            
            using (var fs = System.IO.File.Create(Application.StartupPath + "\\(MARS)" + fileName))
            {
                await fs.WriteAsync(result, 0, result.Count());
                fs.Flush();
            }
        }

        private async void buttonDecode_Click(object sender, EventArgs e)
        {
            if ((textBoxKey.Text == "" && byteKey == null) ||
                (textBoxC0.Text == "" && bytec0 == null && !radioButtonECB.Checked))
            {
                MessageBox.Show("Не введены данные");
                return;
            }
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filePath = openFileDialog.FileName;
            Task read = Task.Run(() =>
            {
                try
                {
                    text = File.ReadAllBytes(filePath);
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });
            read.Wait();
            if (text == null)
            {
                MessageBox.Show("Нет текста");
                return;
            }
            ICoder modeWork = null;
            if(byteKey == null)
                byteKey = Encoding.Default.GetBytes(textBoxKey.Text);

            var addByte = new List<byte>();
            for (int i = byteKey.Length; i < blockKeySize; i++)
                addByte.Add(byteKey[i % byteKey.Length]);
            byteKey = byteKey.Concat(addByte.ToArray()).ToArray();

            
            if (!radioButtonECB.Checked)
            {
                if (bytec0 == null)
                    bytec0 = Encoding.Default.GetBytes(textBoxC0.Text);
                addByte = new List<byte>();
                for (int i = bytec0.Length; i < blockSize; i++)
                    addByte.Add(bytec0[i % bytec0.Length]);
                bytec0 = bytec0.Concat(addByte.ToArray()).ToArray();
            }

            if (text.Length % blockSize != 0)
            {
                addByte = new List<byte>();
                for (int i = 0; i < blockSize - text.Length % blockSize; i++)
                    addByte.Add(0);

                text = text.Concat(addByte.ToArray()).ToArray();
            }
            uint[] T = new uint[14];

            for (int i = 0; i < byteKey.Length; i += subblockSize)
            {
                T[i / subblockSize] = BitConverter.ToUInt32(byteKey.Skip(i).Take(subblockSize).ToArray(), 0);
            }

            var fileName = Path.GetFileName(openFileDialog.FileName);
            FormFile wind = new FormFile(fileName, false);

            var mars = new Mars(T);
            if (radioButtonECB.Checked)
                modeWork = new ECB(mars, wind);
            else if (radioButtonCBC.Checked)
                modeWork = new CBC(mars, bytec0, wind);
            else if (radioButtonCFB.Checked)
                modeWork = new CFB(mars, bytec0, wind);
            else if (radioButtonOFB.Checked)
                modeWork = new OFB(mars, bytec0, wind);
            wind.Show();
            byte[] result = new byte[] { };
            if (radioButtonECB.Checked)
            {
                int processorCount = 2;
                Task<byte[]>[] allTasks = new Task<byte[]>[processorCount];

                for (int i = 0; i < processorCount; i++)
                {
                    int indexI = i; // т.к. значение i может поменяться при EndInvoke

                    allTasks[indexI] = Task.Run(() => modeWork.Decode(text.Skip(text.Length / processorCount * i).Take(text.Length / processorCount).ToArray()));
                    Thread.Sleep(100);
                }

                await Task.WhenAll(allTasks);
                for (int i = 0; i < processorCount; i++)
                {
                    result = result.Concat(allTasks[i].Result).ToArray();
                }
            }
            else
                result = await modeWork.Decode(text);
            wind.progressBar.Value = 100;
            using (var fs = System.IO.File.Create(Application.StartupPath + "\\(MARS)" + fileName))
            {
                await fs.WriteAsync(result, 0, result.Count());
                fs.Flush();
            }
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            textBoxKey.UseSystemPasswordChar = !textBoxKey.UseSystemPasswordChar;
            textBoxC0.UseSystemPasswordChar = !textBoxC0.UseSystemPasswordChar;
        }

        private void загрузитьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filePath = openFileDialog.FileName;
            byteKey = new byte[blockKeySize];
            try
            {
                using (var stream = File.OpenRead(filePath))
                {
                    stream.ReadAsync(byteKey, 0, blockKeySize);
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            
        }

        private void закрузитьВекторИнциализацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filePath = openFileDialog.FileName;
            bytec0 = new byte[blockSize];
            try
            {
                using (var stream = File.OpenRead(filePath))
                {
                    stream.ReadAsync(bytec0, 0, blockSize);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
