/*
 * File Name:               boolBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

namespace xbuffer
{
    public class boolBuffer
    {
        private static readonly int size = sizeof(bool);

        public unsafe static bool deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(bool*)(ptr + offset);
                offset += size;
                return value;
            }
        }

        public unsafe static void serialize(bool value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(bool*)(ptr + offset) = value;
                offset += size;
            }
        }
    }
}