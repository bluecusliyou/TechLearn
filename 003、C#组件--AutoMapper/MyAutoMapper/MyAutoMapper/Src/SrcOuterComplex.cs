namespace MyAutoMapper
{
    public class SrcOuterComplex
    {
        public string NameSrc { get; set; }
        public int AgeSrc { get; set; }
        public SrcInnerComplex InnerSrc { get; set; }
    }
    public class SrcInnerComplex
    {
        public string NameSrc { get; set; }
        public int AgeSrc { get; set; }
    }
}
