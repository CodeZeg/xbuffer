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

            var templates = new DirectoryInfo(Config.path_template).GetFiles();
            foreach (var template in templates)
            {
                var template_str = File.ReadAllText(Config.path_template + "/" + template.Name);
                var template_name = Path.GetFileNameWithoutExtension(template.Name);
                var isBuffer = template_name.Contains("buffer");

                Console.WriteLine("开始解析模板 " + template_name + " ...");

                if (Config.package)
                    Directory.CreateDirectory(Config.path_output);
                else
                    Directory.CreateDirectory(Config.path_output + "/" + template_name);
                var output = "";
                foreach (var proto_class in proto_classs)
                {
                    if(Config.package)
                    {
                        output += Parser.parse(proto_class, template_str);
                        output += "\n\n";
                    }
                    else
                    {
                        output = Parser.parse(proto_class, template_str);
                        File.WriteAllText(Config.path_output + "/" + template_name + "/" + proto_class.Class_Name + (isBuffer ? "Buffer" : "") + "." + Config.suffix, output);
                    }
                }
                if (Config.package)
                    File.WriteAllText(Config.path_output + "/" + template_name + "." + Config.suffix, output);
            }

            Console.WriteLine("生成完毕");
            Console.ReadLine();
        }
    }
}