namespace MyAutoMapper
{
    public class DestParent
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class DestChild: DestParent
    {
        public string ChildName { get; set; }

        public int ChildAge { get; set; }
    }
}
