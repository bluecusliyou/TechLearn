namespace MyAutoMapper
{
    public class DestOuter
    {
        public string OutName { get; set; }

        public int OutAge { get; set; }

        public DestInner Inner { get; set; }
    }

    public class DestInner
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
