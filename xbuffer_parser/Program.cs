using System;
using System.IO;

namespace xbuffer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("请输入结构文件的路径！");
                Console.ReadLine();
                return;
            }

            var proto = File.ReadAllText(args[0]);
            var proto_classs = new Proto(proto).class_protos;

            var templates = new DirectoryInfo("templates").GetFiles();
            foreach (var template in templates)
            {
                var template_str = File.ReadAllText("templates/" + template.Name);
                var template_name = Path.GetFileNameWithoutExtension(template.Name);

                Console.WriteLine("开始解析模板 " + template_name + " ...");

                Directory.CreateDirectory("output_" + template_name);
                var isBuffer = template_name.Contains("buffer");
                foreach (var proto_class in proto_classs)
                {
                    var output = Parser.parse(proto_class, template_str);
                    File.WriteAllText("output_" + template_name + "/" + proto_class.Class_Name + (isBuffer ? "Buffer" : "") + ".cs", output);
                }
            }

            Console.WriteLine("生成完毕");
            Console.ReadLine();
        }
    }
}