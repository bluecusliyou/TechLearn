namespace MyAutoMapper
{
    public class SrcParent
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class SrcChild : SrcParent
    {
        public string ChildName { get; set; }

        public int ChildAge { get; set; }
    }
}
