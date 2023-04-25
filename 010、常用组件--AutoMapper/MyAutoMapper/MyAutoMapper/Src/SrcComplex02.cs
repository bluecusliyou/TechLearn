namespace MyAutoMapper
{
    public class SrcComplex02
    {
        public string Name { get; set; }
        public InnerSource InnerSource { get; set; }
        public InnerSource02 InnerSource02 { get; set; }
    }
    public class InnerSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class InnerSource02
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
