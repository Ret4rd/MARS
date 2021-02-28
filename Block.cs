using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Block
    {
        private uint[] _D = new uint[4];
        private uint[] _K = new uint[40];

        //деление на 4 сабблока
        public Block(byte[] block, uint[] K)
        {
            for (int i = 0; i < block.Length; i += 4)
            {
                _D[i / 4] = BitConverter.ToUInt32(block.Skip(i).Take(4).ToArray(), 0);
            }
            _K = K;
        }

        //1 этап: наложение ключа
        public void KeyOverlay()
        {
            for(int i = 0; i < 4; i++)
            {
                _D[i] += _K[i];
            }
        }
        //Этап 2: прямое перемешивание
        public void ForwardPass()
        {
            for (int i = 0; i < 8; ++i)
            {
                // обращаемся к 4-ем S-блокам
                _D[1] ^= Blocks.S0[Methods.GetByte(_D[0], 0)];
                _D[1] += Blocks.S1[Methods.GetByte(_D[0], 1)];
                _D[2] += Blocks.S0[Methods.GetByte(_D[0], 2)];
                _D[3] ^= Blocks.S1[Methods.GetByte(_D[0], 3)];

                Methods.MoveRight(ref _D[0], 24);

                // также проделаем дополнительные операции смешивания
                if (i == 0 || i == 4)
                    _D[0] += _D[3];
                if (i == 1 || i == 5)
                    _D[0] += _D[1];
                var temp = _D[0];
                _D[0] = _D[1];
                _D[1] = _D[2];
                _D[2] = _D[3];
                _D[3] = temp;
            }  
        }
        //функция E
        public uint[] E(uint D, uint K1, uint K2)
        {
            var M = D;
            M += K1;
            //var R = D;
            //R = Methods.MoveLeft(R, 13);
            Methods.MoveLeft(ref D, 13);
            var R = D * K2;
            var i = Methods.GetBites(M, 9);
            uint L = 0;
            if (i < 256)
                L = Blocks.S0[i];
            else
                L = Blocks.S1[i % 256];
            Methods.MoveLeft(ref R, 5);
            var r = Methods.GetBites(R, 5);
            Methods.MoveLeft(ref M, (int)r);
            L ^= R;
            Methods.MoveLeft(ref R, 5);
            L ^= R;
            r = Methods.GetBites(R, 5);
            Methods.MoveLeft(ref L, (int)r);
            return new uint[] { L, M, R };
        }
        //Этап 3, 4: криптопреобразование 
        public void Crypto()
        {
            for (int i = 0; i < 16; ++i)
            {
                var Out = E(_D[0], _K[2 * i + 4], _K[2 * i + 5]);
                Methods.MoveLeft(ref _D[0], 13);
                _D[2] += Out[1];

                if (i < 8)
                {
                    _D[1] += Out[0];
                    _D[3] ^= Out[2];
                }
                else
                {
                    _D[3] += Out[0];
                    _D[1] ^= Out[2];
                }
                var temp = _D[0];
                _D[0] = _D[1];
                _D[1] = _D[2];
                _D[2] = _D[3];
                _D[3] = temp;
            }
        }
        //Этап 5: обратное перемешивание
        public void BackwardPass()
        {
            for (int i = 0; i < 8; ++i)
            {
                // также проделаем дополнительные операции смешивания
                if (i == 2 || i == 6)
                    _D[0] -= _D[3];
                else if (i == 3 || i == 7)
                    _D[0] -= _D[1];

                // обращаемся к 4-ем S-блокам
                _D[1] ^= Blocks.S1[Methods.GetByte(_D[0], 0)];
                _D[2] -= Blocks.S0[Methods.GetByte(_D[0], 3)];
                //_D[3] ^= Blocks.S1[Methods.GetByte(_D[0], 2)];
                //_D[3] -= Blocks.S0[Methods.GetByte(_D[0], 1)];
                _D[3] -= Blocks.S1[Methods.GetByte(_D[0], 2)];
                _D[3] ^= Blocks.S0[Methods.GetByte(_D[0], 1)];

                Methods.MoveLeft(ref _D[0], 24);
                var temp = _D[0];
                _D[0] = _D[1];
                _D[1] = _D[2];
                _D[2] = _D[3];
                _D[3] = temp;
            }
        }
        //Этап 6: финальное наложение ключа
        public void finalKeying()
        {
            for (int i = 0; i < 4; ++i)
            {
                _D[i] -= _K[36 + i];
            }
        }

        public byte[] GetBytes()
        {
            //var addByte = new List<byte>();
            byte[] res = new byte[] { };
            for(int i = 0; i < _D.Length; ++i)
                //res = BitConverter.GetBytes(_D[i]);
                res = res.Concat(BitConverter.GetBytes(_D[i])).ToArray();
            return res;
        }

        //методы расшифровки

        //1 этап: наложение ключа
        public void DKeyOverlay()
        {
            for (int i = 0; i < 4; ++i)
            {
                _D[i] += _K[36 + i];
            }
        }
        //Этап 2: прямое перемешивание
        public void DForwardPass()
        {
            for (int i = 7; i >= 0; --i)
            {
                var temp = _D[0];
                _D[0] = _D[3];
                _D[3] = _D[2];
                _D[2] = _D[1];
                _D[1] = temp;


                Methods.MoveRight(ref _D[0], 24);
                // обращаемся к 4-ем S-блокам
                _D[3] ^= Blocks.S0[Methods.GetByte(_D[0], 1)];
                _D[3] += Blocks.S1[Methods.GetByte(_D[0], 2)];
                _D[2] += Blocks.S0[Methods.GetByte(_D[0], 3)];
                _D[1] ^= Blocks.S1[Methods.GetByte(_D[0], 0)];

                // также проделаем дополнительные операции смешивания
                if (i == 2 || i == 6)
                    _D[0] += _D[3];
                if (i == 3 || i == 7)
                    _D[0] += _D[1];
            }
             
        }

        //Этап 3, 4: криптопреобразование 
        public void DCrypto()
        {
            for (int i = 15; i >= 0; --i)
            {
                var temp = _D[0];
                _D[0] = _D[3];
                _D[3] = _D[2];
                _D[2] = _D[1];
                _D[1] = temp;

                Methods.MoveRight(ref _D[0], 13);

                var Out = E(_D[0], _K[2 * i + 4], _K[2 * i + 5]);

                _D[2] -= Out[1];

                if (i < 8)
                {
                    _D[1] -= Out[0];
                    _D[3] ^= Out[2];
                }
                else
                {
                    _D[3] -= Out[0];
                    _D[1] ^= Out[2];
                }
            }
            
        }

        //Этап 5: обратное перемешивание
        public void DBackwardPass()
        {
            for (int i = 7; i >= 0; --i)
            {
                var temp = _D[0];
                _D[0] = _D[3];
                _D[3] = _D[2];
                _D[2] = _D[1];
                _D[1] = temp;

                // также проделаем дополнительные операции смешивания
                if (i == 0 || i == 4)
                    _D[0] -= _D[3];
                else if (i == 1 || i == 5)
                    _D[0] -= _D[1];

                Methods.MoveLeft(ref _D[0], 24);

                // обращаемся к 4-ем S-блокам
                _D[3] ^= Blocks.S1[Methods.GetByte(_D[0], 3)];
                _D[2] -= Blocks.S0[Methods.GetByte(_D[0], 2)];
                _D[1] -= Blocks.S1[Methods.GetByte(_D[0], 1)];
                _D[1] ^= Blocks.S0[Methods.GetByte(_D[0], 0)];
            }
            
        }

        //Этап 6: финальное наложение ключа
        public void DfinalKeying()
        {
            for (int i = 0; i < 4; ++i)
            {
                _D[i] -= _K[i];
            }
        }
    }
}
