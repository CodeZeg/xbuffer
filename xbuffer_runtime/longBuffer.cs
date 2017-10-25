/*
 * File Name:               longBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System;

namespace xbuffer
{
    public class longBuffer
    {
        private static readonly int size = sizeof(long);

        public unsafe static long deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(long*)(ptr + offset);
                offset += size;
                return BitConverter.IsLittleEndian ? value : (long)reverseBytes((ulong)value);
            }
        }

        public unsafe static void serialize(long value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(long*)(ptr + offset) = BitConverter.IsLittleEndian ? value : (long)reverseBytes((ulong)value);
                offset += size;
            }
        }

        private static ulong reverseBytes(ulong value)
        {
            return (((value & 0x00000000000000FFUL) << 56) |
                    ((value & 0x000000000000FF00UL) << 40) |
                    ((value & 0x0000000000FF0000UL) << 24) |
                    ((value & 0x00000000FF000000UL) << 8) |
                    ((value & 0x000000FF00000000UL) >> 8) |
                    ((value & 0x0000FF0000000000UL) >> 24) |
                    ((value & 0x00FF000000000000UL) >> 40) |
                    ((value & 0xFF00000000000000UL) >> 56));
        }
    }
}