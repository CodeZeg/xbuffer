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
        private static readonly uint size = sizeof(float);

        public unsafe static float deserialize(byte[] buffer, ref uint offset)
        {
            fixed (byte* ptr = buffer)
            {
                var value = *(float*)(ptr + offset);
                offset += size;
                return BitConverter.IsLittleEndian ? value : utils.toLittleEndian((uint)value);
            }
        }

        public unsafe static void serialize(float value, XSteam steam)
        {
            steam.applySize(size);
            fixed (byte* ptr = steam.contents[steam.index_group])
            {
                *(float*)(ptr + steam.index_cell) = BitConverter.IsLittleEndian ? value : utils.toLittleEndian((uint)value);
                steam.index_cell += size;
            }
        }
    }
}