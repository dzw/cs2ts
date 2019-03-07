namespace cs2ts
{
    export  class TestClass
    {
        public FieldA: string;
        public FieldB: string;
        public PropertyC: number;
        constructor(a: string, b: number)
        {
            this.FieldA = a;
            this.FieldB = b.ToString();
            this.PropertyC = 12.3;
        }
        public static Test1(): void
        {
            System.Console.WriteLine("Test1");
        }
        public Test2(): void
        {
            System.Console.WriteLine("Test2");
        }
    }
}