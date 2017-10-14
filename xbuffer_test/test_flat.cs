// automatically generated, do not modify

using FlatBuffers;

public sealed class FlatA : Table {
  public static FlatA GetRootAsFlatA(ByteBuffer _bb) { return GetRootAsFlatA(_bb, new FlatA()); }
  public static FlatA GetRootAsFlatA(ByteBuffer _bb, FlatA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public FlatA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public bool GetA(int j) { int o = __offset(4); return o != 0 ? 0!=bb.Get(__vector(o) + j * 1) : false; }
  public int ALength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public int GetB(int j) { int o = __offset(6); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int BLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public float GetC(int j) { int o = __offset(8); return o != 0 ? bb.GetFloat(__vector(o) + j * 4) : (float)0; }
  public int CLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public string GetD(int j) { int o = __offset(10); return o != 0 ? __string(__vector(o) + j * 4) : null; }
  public int DLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public FlatE GetE(int j) { return GetE(new FlatE(), j); }
  public FlatE GetE(FlatE obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int ELength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<FlatA> CreateFlatA(FlatBufferBuilder builder,
      VectorOffset a = default(VectorOffset),
      VectorOffset b = default(VectorOffset),
      VectorOffset c = default(VectorOffset),
      VectorOffset d = default(VectorOffset),
      VectorOffset e = default(VectorOffset)) {
    builder.StartObject(5);
    FlatA.AddE(builder, e);
    FlatA.AddD(builder, d);
    FlatA.AddC(builder, c);
    FlatA.AddB(builder, b);
    FlatA.AddA(builder, a);
    return FlatA.EndFlatA(builder);
  }

  public static void StartFlatA(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddA(FlatBufferBuilder builder, VectorOffset aOffset) { builder.AddOffset(0, aOffset.Value, 0); }
  public static VectorOffset CreateAVector(FlatBufferBuilder builder, bool[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddBool(data[i]); return builder.EndVector(); }
  public static void StartAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddB(FlatBufferBuilder builder, VectorOffset bOffset) { builder.AddOffset(1, bOffset.Value, 0); }
  public static VectorOffset CreateBVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartBVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddC(FlatBufferBuilder builder, VectorOffset cOffset) { builder.AddOffset(2, cOffset.Value, 0); }
  public static VectorOffset CreateCVector(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddFloat(data[i]); return builder.EndVector(); }
  public static void StartCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddD(FlatBufferBuilder builder, VectorOffset dOffset) { builder.AddOffset(3, dOffset.Value, 0); }
  public static VectorOffset CreateDVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddE(FlatBufferBuilder builder, VectorOffset eOffset) { builder.AddOffset(4, eOffset.Value, 0); }
  public static VectorOffset CreateEVector(FlatBufferBuilder builder, Offset<FlatE>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartEVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<FlatA> EndFlatA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatA>(o);
  }
  public static void FinishFlatABuffer(FlatBufferBuilder builder, Offset<FlatA> offset) { builder.Finish(offset.Value); }
};

public sealed class FlatE : Table {
  public static FlatE GetRootAsFlatE(ByteBuffer _bb) { return GetRootAsFlatE(_bb, new FlatE()); }
  public static FlatE GetRootAsFlatE(ByteBuffer _bb, FlatE obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public FlatE __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public bool A { get { int o = __offset(4); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public int B { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public float C { get { int o = __offset(8); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public string D { get { int o = __offset(10); return o != 0 ? __string(o + bb_pos) : null; } }

  public static Offset<FlatE> CreateFlatE(FlatBufferBuilder builder,
      bool a = false,
      int b = 0,
      float c = 0,
      StringOffset d = default(StringOffset)) {
    builder.StartObject(4);
    FlatE.AddD(builder, d);
    FlatE.AddC(builder, c);
    FlatE.AddB(builder, b);
    FlatE.AddA(builder, a);
    return FlatE.EndFlatE(builder);
  }

  public static void StartFlatE(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddA(FlatBufferBuilder builder, bool a) { builder.AddBool(0, a, false); }
  public static void AddB(FlatBufferBuilder builder, int b) { builder.AddInt(1, b, 0); }
  public static void AddC(FlatBufferBuilder builder, float c) { builder.AddFloat(2, c, 0); }
  public static void AddD(FlatBufferBuilder builder, StringOffset dOffset) { builder.AddOffset(3, dOffset.Value, 0); }
  public static Offset<FlatE> EndFlatE(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatE>(o);
  }
};

