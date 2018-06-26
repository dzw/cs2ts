using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace cs2ts{
    class Program{
        public static void Main(params string[] args){
            if (args.Length == 0){
                Console.WriteLine("missing file argument");
                return;
            }

            var input = args[0];
            string outputFileName = null;
            var isDirectory = Directory.Exists(input);
            if (isDirectory){
                var enumerateFiles = Directory.EnumerateFiles(input, "*.cs", SearchOption.AllDirectories);
                foreach (string file in enumerateFiles){
                    if (file.Contains("EightFurnacePanelCtrl"))
                        Console.WriteLine("nop");
                    NewMethod(file, file.Replace(".cs", ".ts"));
                }
            }
            else{
                outputFileName = args.Length > 1 ? args[1] : Path.ChangeExtension(input, "ts");
                var exists = File.Exists(input);
                if (exists)
                    NewMethod(input, outputFileName);
            }
        }

        private static void NewMethod(string input, string output){
            Console.WriteLine("translating " + input);

            var csCode = File.ReadAllText(input);
            var visitor = new Transpiler(csCode);
            var tsCode = visitor.ToTypeScript();
            File.WriteAllText(output, tsCode);
        }
    }
}