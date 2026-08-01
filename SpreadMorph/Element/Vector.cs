namespace Element
{
    public abstract class Vector : ElementBase
    {
        public abstract int Dim { get; }

        public abstract Integer[] Elements { get; }

        public Integer GetElement(int i)
        {
            return Elements[i];
        }
    }
}
