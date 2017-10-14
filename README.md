# xbuffer
一种简化版本的 flatbuffer 序列化库

## 与其他序列化库的简单对比
- protobuffer
    - 相同点:使用方便(创建结构,生成文件,仅两个调用接口)
    - 优势: `protobuf`使用了大量的反射,序列化和反序列化效率均较低
- flatbuffer
    - 相同点:序列化和反序列化效率上极高
    - 优势: `flatbuf`使用结构及其麻烦,需要自己实现部分序列化和反序列化的代码
    - 优势: `flatbufs`反序列化之后的数据结构无法在运行时中进行修改,并且每次获取任意数据均会经过大量的数据转换

- 对比测试图
    - ![](test_result.png)
    - 序列化速度是 pb的5倍, fb的7倍
    - 反序列化的速度是 pb的2倍 fb的3倍
    - `flatbuf`的反序列化时间有两个原因是会在具体获取数据的时候才产生耗时操作

## 后续
- 提供`protobuf`那样的泛型接口,更方便使用
- 多语言版本(理论上只需要添加对应的模板文件和基础类型库即可)
- 大小端问题(过两天补上)

## 使用示例
1. 使用类似 `flatbuf` 的idl语言写一个结构描述文件, 任意后缀名
```
class A
{
	a:[bool];
	b:[int];
	c:[float];
	d:[string];
	e:[E];
}

class E
{
	a:bool;
	b:int;
	c:float;
	d:string;
}
```
1. 将该文件拖动到 `xbuffer_parser.exe` 文件上,程序会根据 `templates` 文件夹下的所有模板文件(任意后缀),生成对应目录的代码文件
1. 将生成的代码挪到自己的项目中
1. 将运行时 `xbuffer_runtime.dll` 挪到自己的项目中
- 序列化代码
```
    byte[] buffer;;
    int offset = 0;

    ABuffer.serialize(data, buffer, ref offset);
```
这里使用一个`buffer`来存储需要序列化的数据,`offset`标记从数组的哪个位置开始存储,这样一来可以项目中共用同一个比较大的byte[]来减少频繁的内存分配.
- 反序列化代码
```
    byte[] buffer;
    int offset = 0;

    ABuffer.deserialize(buffer, ref offset);
```
这里的`buffer`可以是从任意地方读取过来的序列化数据,`offset`标记从哪里开始读取.