/*
 * File Name:               floatBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System;

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
                return BitConverter.IsLittleEndian ? value : (float)reverseBytes((uint)value);
            }
        }

        public unsafe static void serialize(float value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                *(float*)(ptr + offset) = BitConverter.IsLittleEndian ? value : (float)reverseBytes((uint)value);
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