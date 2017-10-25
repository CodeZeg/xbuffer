/*
 * File Name:               Serializer.cs
 *
 * Description:             泛型接口
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

namespace xbuffer
{
    public class Serializer
    {
        public static void serialize<T>(T value, byte[] buffer)
        {
            int offset = 0;
            serialize<T>(value, buffer, ref offset);
        }

        public static void serialize<T>(T value, byte[] buffer, ref int offset)
        {
            var bufferType = typeof(T).Assembly.GetType(string.Format("xbuffer.{0}Buffer", typeof(T).FullName));
            var method = bufferType.GetMethod("serialize", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            var args = new object[] { value, buffer, offset };
            method.Invoke(null, args);
            offset = (int)args[2];
        }

        public static T deserialize<T>(byte[] buffer)
        {
            int offset = 0;
            return deserialize<T>(buffer, ref offset);
        }

        public static T deserialize<T>(byte[] buffer, ref int offset)
        {
            var bufferType = typeof(T).Assembly.GetType(string.Format("xbuffer.{0}Buffer", typeof(T).FullName));
            var method = bufferType.GetMethod("deserialize", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            var args = new object[] { buffer, offset };
            var ret = (T)method.Invoke(null, args);
            offset = (int)args[1];
            return ret;
        }
    }
}