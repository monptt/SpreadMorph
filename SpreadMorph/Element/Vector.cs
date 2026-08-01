namespace Element
{
    public abstract class Vector : ElementBase
    {
        public abstract int Dim { get; }

        public abstract Number[] Elements { get; }

        public Number GetElement(int i)
        {
            return Elements[i];
        }
    }
}
