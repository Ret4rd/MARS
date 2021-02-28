using System.Threading;
using System.Threading.Tasks;

namespace Crypto
{
    public interface ICoder 
    {
        Task<byte[]> Encode(byte[] message);
        Task<byte[]> Decode(byte[] message);
    }
}
