namespace xbuffer
{
    public static class EBuffer
    {
        public static E deserialize(byte[] buffer, ref int offset)
        {
            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

            // a
            bool _a = boolBuffer.deserialize(buffer, ref offset);
            // b
            int _b = intBuffer.deserialize(buffer, ref offset);
            // c
            float _c = floatBuffer.deserialize(buffer, ref offset);
            // d
            string _d = stringBuffer.deserialize(buffer, ref offset);

            // value
            return new E()
            {
                a = _a,
                b = _b,
                c = _c,
                d = _d,
            };
        }

        public static void serialize(E value, byte[] buffer, ref int offset)
        {
            // null
            boolBuffer.serialize(value == null, buffer, ref offset);
            if (value == null) return;

            // a
            boolBuffer.serialize(value.a, buffer, ref offset);
            // b
            intBuffer.serialize(value.b, buffer, ref offset);
            // c
            floatBuffer.serialize(value.c, buffer, ref offset);
            // d
            stringBuffer.serialize(value.d, buffer, ref offset);
        }
    }
}