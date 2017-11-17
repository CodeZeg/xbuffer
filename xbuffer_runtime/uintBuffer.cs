/*
 * File Name:               uintBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System;

namespace xbuffer
{
    public class uintBuffer
    {
        private static readonly int size = sizeof(uint);

        public unsafe static uint deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(uint*)(ptr + offset);
                offset += size;
                return BitConverter.IsLittleEndian ? value : reverseBytes(value);
            }
        }

        public unsafe static void serialize(uint value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(uint*)(ptr + offset) = BitConverter.IsLittleEndian ? value : reverseBytes(value);
                offset += size;
            }
        }

        private static uint reverseBytes(uint value)
        {
            return ((value & 0x000000FFU) << 24) |
                    ((value & 0x0000FF00U) << 8) |
                    ((value & 0x00FF0000U) >> 8) |
                    ((value & 0xFF000000U) >> 24);
        }
    }
}