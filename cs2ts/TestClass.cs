namespace cs2ts
{
    public class TestClass
    {

        public string FieldA;
        public string FieldB;

        public float PropertyC { get; set; }
        

        public TestClass(string a, double b)
        {
            FieldA = a;
            FieldB = b.ToString();
            PropertyC = 12.3f;
        }

        public static void Test1()
        {
            System.Console.WriteLine("Test1");
        }


        public void Test2()
        {
            System.Console.WriteLine("Test2");
        }

    }
}