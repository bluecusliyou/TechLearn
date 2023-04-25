namespace MyAutoMapper
{
    public class SrcOuter
    {
        public string OutName { get; set; }

        public int OutAge { get; set; }

        public SrcInner Inner { get; set; }
    }

    public class SrcInner
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
