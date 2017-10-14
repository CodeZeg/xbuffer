namespace xbuffer
{
    public class intBuffer
    {
        private static readonly int size = sizeof(int);

        public unsafe static int deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(int*)(ptr + offset);
                offset += size;
                return value;
            }
        }

        public unsafe static void serialize(int value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(int*)(ptr + offset) = value;
                offset += size;
            }
        }
    }
}