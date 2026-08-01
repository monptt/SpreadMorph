namespace Element
{
    public abstract class Matrix : ElementBase
    {
        public abstract int Rows { get; }
        public abstract int Columns { get; }

        public abstract Integer[] Elements { get; }

        public Integer GetElement(int i, int j)
        {
            return Elements[i * Columns + j];
        }
    }
}