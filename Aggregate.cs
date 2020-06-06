namespace IdFunctorTest
{
    public class Aggregate
    {
        public Aggregate(
            Component1 c1,
            Component2 c2)
        {
            C1 = c1;
            C2 = c2;
        }

        public Component1 C1 { get; }
        public Component2 C2 { get; }

        public static Aggregate Create(
            Component1 c1,
            Component2 c2)
        {
            return new Aggregate(c1, c2);
        }        
    }
}
