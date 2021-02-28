using System.Collections.Generic;
using System.Linq;
using Crypto;
using System.Threading;
using System.Threading.Tasks;
using Coursework;

namespace ModeWork
{
    public class CBC : ICoder
    {
        private ICoderBlock _algorithm;
        private byte[] _c0;
        public FormFile form;

        public CBC(ICoderBlock algorithm, byte[] c0, FormFile form0)
        {
            _c0 = c0;
            _algorithm = algorithm;
            form = form0;
        }

        public async Task<byte[]> Encode(byte[] message)
        {
            var m = (byte[])message.Clone();
            var c = new List<byte>();

            var prev = _c0;
            for (int i = 0; i < message.Length; i += _algorithm.Size)
            {
                for (int j = 0; j < _algorithm.Size; j++)
                    m[i + j] ^= prev[j];

                await Task.Run(() => c.AddRange(_algorithm.EncodeBlock(message.Skip(i).Take(_algorithm.Size).ToArray())));
                prev = c.Skip(i).Take(_algorithm.Size).ToArray();
                form.progressBar.Value = (int)(i / (float)message.Length * 100);
            }

            return c.ToArray();
        }

        public async Task<byte[]> Decode(byte[] code)
        {
            var c = (byte[])code.Clone();
            var m = new List<byte>();

            var prev = _c0;
            for (int i = 0; i < code.Length; i += _algorithm.Size)
            {
                for (int j = 0; j < _algorithm.Size; j++)
                    c[i + j] ^= prev[j];
                form.progressBar.Value = (int)(i / (float)code.Length * 100);
                await Task.Run(() => m.AddRange(_algorithm.DecodeBlock(code.Skip(i).Take(_algorithm.Size).ToArray())));
                prev = m.Skip(i).Take(_algorithm.Size).ToArray();
            }

            return m.ToArray();
        }
    }
}
