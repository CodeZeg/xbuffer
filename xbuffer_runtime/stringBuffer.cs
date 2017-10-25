/*
 * File Name:               stringBuffer.cs
 *
 * Description:             基本类型处理
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System.Text;

namespace xbuffer
{
    public class stringBuffer
    {
        private static readonly int size = sizeof(int);

        public unsafe static string deserialize(byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                int byteCount = intBuffer.deserialize(buffer, ref offset);
                string value = Encoding.UTF8.GetString(buffer, offset, byteCount);
                offset += byteCount;
                return value;
            }
        }

        public unsafe static void serialize(string value, byte[] buffer, ref int offset)
        {
            fixed (byte* ptr = buffer)
            {
                int byteCount = Encoding.UTF8.GetBytes(value, 0, value.Length, buffer, offset + size);
                intBuffer.serialize(byteCount, buffer, ref offset);
                offset += byteCount;
            }
        }
    }
}