namespace xbuffer
{
    public class floatBuffer
    {
        private static readonly int size = sizeof(float);

        public unsafe static float deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(float*)(ptr + offset);
                offset += size;
                return value;
            }
        }

        public unsafe static void serialize(float value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(float*)(ptr + offset) = value;
                offset += size;
            }
        }
    }
}