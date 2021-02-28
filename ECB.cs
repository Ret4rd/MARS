using Crypto;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Coursework;

namespace ModeWork
{
    public class ECB : ICoder
    {
        private ICoderBlock _algorithm;
        public FormFile form;

        public ECB() { }
        public ECB(ICoderBlock algorithm, FormFile form0)
        {
            _algorithm = algorithm;
            form = form0;
        }

        public async Task<byte[]> Encode(byte[] message)
        {
            var c = new List<byte>();

            for (int i = 0; i < message.Length; i += _algorithm.Size)
            {
                await Task.Run(() => c.AddRange(_algorithm.EncodeBlock(message.Skip(i).Take(_algorithm.Size).ToArray())));
                if(Thread.CurrentThread.ManagedThreadId == form.ThreadId)
                    form.progressBar.Value = (int)(i / (float)message.Length * 100);
            }
                

            return c.ToArray();
        }

        public async Task<byte[]> Decode(byte[] bloks)
        {
            var m = new List<byte>();

            for (int i = 0; i < bloks.Length; i += _algorithm.Size)
            {
                await Task.Run(() => m.AddRange(_algorithm.DecodeBlock(bloks.Skip(i).Take(_algorithm.Size).ToArray())));
                if (Thread.CurrentThread.ManagedThreadId == form.ThreadId)
                    form.progressBar.Value = (int)(i / (float)bloks.Length * 100);
            }
                

            return m.ToArray();
        }
    }
}
