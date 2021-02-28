using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Methods
    {
        static public void MoveLeft(ref uint num, int n)
        {
            n %= 32;
            var ones = num;
            ones >>= (32 - n);
            num <<= n;
            num |= ones;
            //return num;
        }

        static public void MoveRight(ref uint num, int n)
        {
            n %= 32;
            var ones = num;
            ones <<= (32 - n);
            num >>= n;
            num |= ones;
            //return num;
        }

        static public uint GetByte(uint D, int i) 
            {
            return ((D >> 8 * i) & 255);
            }

    static public uint GetBites(uint T, int len)
        {
            len %= 32;
            //uint value = T;
            T <<= (32 - len);
            return T >> (32 - len);
        }
    }
}
