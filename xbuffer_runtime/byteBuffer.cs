/*
 * File Name:               byteBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/11/09
 */

namespace xbuffer
{
    public class byteBuffer
    {
        private static readonly int size = sizeof(byte);

        public unsafe static byte deserialize(byte[] buffer, ref int offset)
        {
            var value = buffer[offset];
            offset += size;
            return value;
        }

        public unsafe static void serialize(byte value, byte[] buffer, ref int offset)
        {
            buffer[offset] = value;
            offset += size;
        }
    }
}