namespace MyAutoMapper
{
    public class DestOuterComplex
    {
        public string NameDest { get; set; }
        public int AgeDest { get; set; }
        public DestInnerComplex InnerDest { get; set; }
    }
    public class DestInnerComplex
    {
        public string NameDest { get; set; }
        public int AgeDest { get; set; }
    }
}
