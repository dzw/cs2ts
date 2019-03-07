
namespace cs2ts
{


    class Program
    {


        public static void Main(params string[] args)
        {
            string dir=  System.IO.Path.GetDirectoryName( typeof(Program).Assembly.Location);
            dir = System.IO.Path.Combine(dir, "..", "..", "..");
            dir = System.IO.Path.GetFullPath(dir);

            string input = System.IO.Path.Combine(dir, "TestClass.cs");
            string outputFileName = System.IO.Path.Combine(dir, "TestClass.ts");
            
            // https://stackoverflow.com/questions/38434337/how-to-create-an-extension-method-in-typescript-for-date-data-type
            // https://www.c-sharpcorner.com/article/learn-about-extension-methods-in-typescript/
            NewMethod(input, outputFileName);


            // https://github.com/praeclarum/Netjs/tree/master/Netjs
            // http://www.damirscorner.com/blog/posts/20180216-VariableNumberOfArgumentsInTypescript.html


            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        }


        public static void OldMain(params string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("missing file argument");
                return;
            }

            string input = args[0];
            string outputFileName = null;
            bool isDirectory = System.IO.Directory.Exists(input);
            if (isDirectory)
            {
                var enumerateFiles = System.IO.Directory.EnumerateFiles(input, "*.cs", System.IO.SearchOption.AllDirectories);
                foreach (string file in enumerateFiles)
                {
                    if (file.Contains("EightFurnacePanelCtrl"))
                        nop();

                    NewMethod(file, file.Replace(".cs", ".ts"));
                }
            }
            else
            {
                outputFileName = args.Length > 1 ? args[1] : System.IO.Path.ChangeExtension(input, "ts");
                var exists = System.IO.File.Exists(input);
                if (exists)
                    NewMethod(input, outputFileName);
            }
        }


        private static void nop()
        {
        }


        private static void NewMethod(string input, string output)
        {
            System.Console.WriteLine("translating " + input);

            var csCode = System.IO.File.ReadAllText(input);
            var visitor = new Transpiler(csCode);
            var tsCode = visitor.ToTypeScript();
            System.IO.File.WriteAllText(output, tsCode);
        }


    }


}
