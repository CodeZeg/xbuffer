namespace xbuffer_test
{
    using FlatBuffers;
    using System;
    using xbuffer;
    using proto.test_proto;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var data_xbuffer = getA(1000000);

            Console.WriteLine(" ======================== protobuf =========================== ");
            test_protobuf(data_xbuffer);

            Console.WriteLine(" ======================== flatbuf ============================ ");
            test_flatbuf(data_xbuffer);

            Console.WriteLine(" ======================== xbuffer ============================ ");
            test_xbuffer(data_xbuffer);

            Console.WriteLine("\n统计完成.");
            Console.ReadLine();
        }

        private static void test_xbuffer(A data)
        {
            var steam = new XSteam(1, 1024 * 1024 * 100);

            // 序列化
            uint offset = 0;
            Timer.beginTime();
            ABuffer.serialize(data, steam);
            Timer.endTime("xbuffer 普通模式序列化");

            var buffer = steam.getBytes();
            // 反序列化
            offset = 0;
            Timer.beginTime();
            ABuffer.deserialize(buffer, ref offset);
            Timer.endTime("xbuffer 普通模式反序列化");

            // 泛型模式序列化
            Timer.beginTime();
            Serializer.cachedSteam = steam;
            Serializer.serialize(data);
            Timer.endTime("xbuffer 泛型模式序列化");

            buffer = steam.getBytes();
            // 泛型模式反序列化
            Timer.beginTime();
            Serializer.deserialize<A>(buffer);
            Timer.endTime("xbuffer 泛型模式反序列化");

            // 内存占用
            Console.WriteLine(string.Format(" xbuffer 普通模式总占用内存 {0} byte.", buffer.Length));
        }

        private static void test_protobuf(A data)
        {
            proto_a a = new proto_a();
            a.a.AddRange(data.a);
            a.b.AddRange(data.b);
            a.c.AddRange(data.c);
            a.d.AddRange(data.d);
            foreach (var item in data.e)
            {
                a.e.Add(new proto_e()
                {
                    a = item.a,
                    b = item.b,
                    c = item.c,
                    d = item.d,
                });
            }

            using (var mem = new MemoryStream())
            {
                // 序列化
                Timer.beginTime();
                ProtoBuf.Serializer.Serialize(mem, a);
                Timer.endTime("protobuf 序列化");

                // 反序列化
                Timer.beginTime();
                mem.Position = 0;
                var b = ProtoBuf.Serializer.Deserialize<proto_a>(mem);
                Timer.endTime("protobuf 反序列化");

                // 内存占用
                Console.WriteLine(string.Format(" protobuf 占用内存 {0} byte.", mem.Length));
            }
        }

        private static void test_flatbuf(A data)
        {
            // 序列化
            Timer.beginTime();
            var fbb = new FlatBufferBuilder(1);

            var offset_a = FlatA.CreateAVector(fbb, data.a);
            var offset_b = FlatA.CreateBVector(fbb, data.b);
            var offset_c = FlatA.CreateCVector(fbb, data.c);

            var offset_d_string = new StringOffset[data.d.Length];
            for (int i = 0; i < data.d.Length; i++)
            {
                offset_d_string[i] = fbb.CreateString(data.d[i]);
            }
            var offset_d = FlatA.CreateDVector(fbb, offset_d_string);

            var offset_e_list = new Offset<FlatE>[data.e.Length];
            for (int i = 0; i < data.e.Length; i++)
            {
                var item = data.e[i];
                var offset_e_d = fbb.CreateString(item.d);
                offset_e_list[i] = FlatE.CreateFlatE(fbb, item.a, item.b, item.c, offset_e_d);
            }
            var offset_e = FlatA.CreateEVector(fbb, offset_e_list);

            var offset_flat_a = FlatA.CreateFlatA(fbb, offset_a, offset_b, offset_c, offset_d, offset_e);
            FlatA.FinishFlatABuffer(fbb, offset_flat_a);
            Timer.endTime("flatbuf 序列化");

            // 反序列化
            Timer.beginTime();
            var buffer = fbb.DataBuffer;
            var flatA = FlatA.GetRootAsFlatA(buffer);
            Timer.endTime("flatbuf 反序列化");
            var ret = new A();
            ret.a = new bool[flatA.ALength];
            for (int i = 0; i < flatA.ALength; i++)
            {
                ret.a[i] = flatA.GetA(i);
            }
            ret.b = new int[flatA.BLength];
            for (int i = 0; i < flatA.BLength; i++)
            {
                ret.b[i] = flatA.GetB(i);
            }
            ret.c = new float[flatA.CLength];
            for (int i = 0; i < flatA.CLength; i++)
            {
                ret.c[i] = flatA.GetC(i);
            }
            ret.d = new string[flatA.DLength];
            for (int i = 0; i < flatA.DLength; i++)
            {
                ret.d[i] = flatA.GetD(i);
            }
            ret.e = new E[flatA.ELength];
            for (int i = 0; i < flatA.ELength; i++)
            {
                var tmpE = flatA.GetE(i);
                ret.e[i] = new E()
                {
                    a = tmpE.A,
                    b = tmpE.B,
                    c = tmpE.C,
                    d = tmpE.D,
                };
            }
            Timer.endTime("flatbuf 反序列化并且获取所有数据一次");

            // 内存占用
            Console.WriteLine(string.Format(" flatbuf 总占用内存 {0} byte.", buffer.Length));
        }

        private static A getA(int count)
        {
            var a = new A();
            a.a = new bool[count];
            a.b = new int[count];
            a.c = new float[count];
            a.d = new string[count];
            a.e = new E[count];
            for (int i = 0; i < count; i++)
            {
                a.a[i] = i % 2 == 0;
                a.b[i] = i;
                a.c[i] = i;
                a.d[i] = i.ToString();
                a.e[i] = new E()
                {
                    a = i % 2 == 0,
                    b = i,
                    c = i,
                    d = i.ToString(),
                };
            }

            return a;
        }
    }

    public class Timer
    {
        private static long lastTime;
        private static long curTime;

        public static void beginTime()
        {
            curTime = DateTime.Now.Ticks / 10000;
            lastTime = curTime;
        }

        public static void endTime(string log)
        {
            curTime = DateTime.Now.Ticks / 10000;

            Console.WriteLine(string.Format(" {0} 耗时 : {1} 毫秒.", log, curTime - lastTime));

            lastTime = curTime;
        }
    }
}