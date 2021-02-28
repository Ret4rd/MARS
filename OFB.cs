using System.Collections.Generic;
using System.Linq;
using Crypto;
using System.Threading;
using System.Threading.Tasks;
using Coursework;

namespace ModeWork
{
    public class OFB : ICoder
    {
        private ICoderBlock _algorithm;
        private byte[] _c0;
        public FormFile form;

        public OFB(ICoderBlock algorithm, byte[] c0, FormFile form0)
        {
            _c0 = c0;
            _algorithm = algorithm;
            form = form0;
        }

        public async Task<byte[]> Encode(byte[] message)
        {

            var m = (byte[])message.Clone();
            var c = new List<byte>();

            byte[] prev = _c0;

            for (int i = 0; i < message.Length; i += _algorithm.Size)
            {
                await Task.Run(() => c.AddRange(_algorithm.EncodeBlock(prev)));
                prev = c.Skip(i).Take(_algorithm.Size).ToArray();
                for (int j = 0; j < _algorithm.Size; j++)
                    c[i + j] ^= m[i + j];
                form.progressBar.Value = (int)(i / (float)message.Length * 100);
            }

            return c.ToArray();
        }

        public async Task<byte[]> Decode(byte[] code)
        {
            var m = (byte[])code.Clone();
            var c = new List<byte>();

            byte[] prev = _c0;

            for (int i = 0; i < code.Length; i += _algorithm.Size)
            {
                await Task.Run(() => c.AddRange(_algorithm.EncodeBlock(prev)));
                prev = c.Skip(i).Take(_algorithm.Size).ToArray();
                for (int j = 0; j < _algorithm.Size; j++)
                    c[i + j] ^= m[i + j];
                form.progressBar.Value = (int)(i / (float)code.Length * 100);
            }

            return c.ToArray();
        }
    }
}
