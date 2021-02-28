namespace ModeWork
{
    public interface ICoderBlock
    {
        int Size { get; }
        byte[] EncodeBlock(byte[] message);
        byte[] DecodeBlock(byte[] message);
    }
}
