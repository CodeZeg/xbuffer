using System.IO;
namespace xbuffer
{
    class Config
    {
        private const string path_config = "config.ini";            // 配置目录

        public static string path_template = "templates";           // 模板目录
        public static string path_output = "output";                // 输出目录
        public static bool package = false;                         // 打包到一起
        public static string suffix = "cs";                         // 文件后缀

        static Config()
        {
            load();
        }

        public static void load()
        {
            if (!File.Exists(path_config))
                return;

            var lines = File.ReadAllLines(path_config);
            foreach (var line in lines)
            {
                var strs = line.Split('=');
                if (strs.Length < 2)
                    continue;

                var key = strs[0];
                var value = strs[1];

                if (key == "path_template") path_template = value;
                else if (key == "path_output") path_output = value;
                else if (key == "package") package = bool.Parse(value);
                else if (key == "suffix") suffix = value;
            }
        }
    }
}
