using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeWork;

namespace Coursework
{
    class Mars : ICoderBlock
    {
        private uint[] _K = new uint[40];
        private uint[] _k = new uint[4];
        public int Size => 16;

        public Mars(uint[] k)
        {
            _k = k;
            _K = KeyExpansion(_k);
        }

        public byte[] DecodeBlock(byte[] message)
        {
            Block block = new Block(message, _K);
            block.DKeyOverlay();
            block.DForwardPass();
            block.DCrypto();
            block.DBackwardPass();
            block.DfinalKeying();
            return block.GetBytes();
        }

        public byte[] EncodeBlock(byte[] message)
        {
            Block block = new Block(message, _K);
            block.KeyOverlay();
            block.ForwardPass();
            block.Crypto();
            block.BackwardPass();
            block.finalKeying();
            return block.GetBytes();
        }

        //расширение ключа
        private uint[] KeyExpansion(uint[] _k)
        {
            uint[] T = new uint[15];
            for (int i = 0; i < _k.Length - 1; i++)
                T[i] = _k[i];
            T[_k.Length - 1] = (uint)_k.Length;
            for (int i = _k.Length; i < 15; i++)
                T[i] = 0;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 15; i++)
                {

                    var temp = T[Math.Abs(i - 7) % 15] ^ T[Math.Abs(i - 2) % 15];
                    Methods.MoveLeft(ref temp, 3);
                    temp ^= (uint)(4 * i + j);
                    T[i] ^= temp;
                }

                for (int k = 0; k < 4; k++)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        var temp = Methods.GetBites(T[Math.Abs(i - 1) % 15], 9);
                        if (temp < 256)
                            temp = Blocks.S0[temp];
                        else
                            temp = Blocks.S1[temp % 256];
                        var temp1 = T[i] + temp;
                        Methods.MoveLeft(ref temp1, 9);
                        T[i] = temp1;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    _K[10 * j + i] = T[(4 * i) % 15];
                }
            }

            var l = 5;

            while (l <= 35)
            {
                var jj = _K[l] & 3;
                var w = _K[l] | 3;
                var M = MakeMask(w);
                var p = Blocks.B[jj];
                Methods.MoveLeft(ref p, (int)Methods.GetBites(_K[l - 1], 5));
                _K[l] = w ^ (p & M);
                l += 2;
            }
            return _K;
        }

        private uint MakeMask(uint w)
        {
		    uint M = 0;
		    var ones = (1 << 10) - 1; 
            var d = 1;
		    while (d< 31 - 10){
			    var zerosOrOnes = (ones << d) & w;
			    if (zerosOrOnes == 0 || zerosOrOnes == (ones << d)){
				    ++d;
				    var dd = zerosOrOnes > 0;
				    while (d< 32 && ((1 << d) > 0) == dd){
					    M |= (uint)1 << d;
					    ++d;
				    }
				    --d;
				    M ^= (uint)1 << d;
			    }
			    ++d;
		    }
		    return M;
	    }

      

    }


}
