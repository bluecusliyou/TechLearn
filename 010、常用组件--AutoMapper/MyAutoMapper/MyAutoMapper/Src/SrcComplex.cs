namespace MyAutoMapper
{
    public class SrcComplex
    {
        public Customer Customer { get; set; }
        public int GetTotal()
        {
            return 33;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
}
