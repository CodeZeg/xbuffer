namespace xbuffer
{
    public static class ABuffer
    {
        public static A deserialize(byte[] buffer, ref int offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// a
			int _a_length = intBuffer.deserialize(buffer, ref offset);
            bool[] _a = new bool[_a_length];
            for (int i = 0; i < _a_length; i++)
            {
                _a[i] = boolBuffer.deserialize(buffer, ref offset);
            }
			// b
			int _b_length = intBuffer.deserialize(buffer, ref offset);
            int[] _b = new int[_b_length];
            for (int i = 0; i < _b_length; i++)
            {
                _b[i] = intBuffer.deserialize(buffer, ref offset);
            }
			// c
			int _c_length = intBuffer.deserialize(buffer, ref offset);
            float[] _c = new float[_c_length];
            for (int i = 0; i < _c_length; i++)
            {
                _c[i] = floatBuffer.deserialize(buffer, ref offset);
            }
			// d
			int _d_length = intBuffer.deserialize(buffer, ref offset);
            string[] _d = new string[_d_length];
            for (int i = 0; i < _d_length; i++)
            {
                _d[i] = stringBuffer.deserialize(buffer, ref offset);
            }
			// e
			int _e_length = intBuffer.deserialize(buffer, ref offset);
            E[] _e = new E[_e_length];
            for (int i = 0; i < _e_length; i++)
            {
                _e[i] = EBuffer.deserialize(buffer, ref offset);
            }

			// value
			return new A() {
				a = _a,
				b = _b,
				c = _c,
				d = _d,
				e = _e,
            };
        }

        public static void serialize(A value, byte[] buffer, ref int offset)
        {

            // null
            boolBuffer.serialize(value == null, buffer, ref offset);
            if (value == null) return;

			// a
            intBuffer.serialize(value.a.Length, buffer, ref offset);
            for (int i = 0; i < value.a.Length; i++)
            {
                boolBuffer.serialize(value.a[i], buffer, ref offset);
            }
			// b
            intBuffer.serialize(value.b.Length, buffer, ref offset);
            for (int i = 0; i < value.b.Length; i++)
            {
                intBuffer.serialize(value.b[i], buffer, ref offset);
            }
			// c
            intBuffer.serialize(value.c.Length, buffer, ref offset);
            for (int i = 0; i < value.c.Length; i++)
            {
                floatBuffer.serialize(value.c[i], buffer, ref offset);
            }
			// d
            intBuffer.serialize(value.d.Length, buffer, ref offset);
            for (int i = 0; i < value.d.Length; i++)
            {
                stringBuffer.serialize(value.d[i], buffer, ref offset);
            }
			// e
            intBuffer.serialize(value.e.Length, buffer, ref offset);
            for (int i = 0; i < value.e.Length; i++)
            {
                EBuffer.serialize(value.e[i], buffer, ref offset);
            }
        }
    }
}
