namespace Element
{
    public abstract class Matrix : ElementBase, INegate
    {
        public abstract int Rows { get; }
        public abstract int Columns { get; }

        public abstract Integer[] Elements { get; }

        public Integer GetElement(int i, int j)
        {
            return Elements[i * Columns + j];
        }

        public void SetElement(int i, int j, Integer element)
        {
            Elements[i * Columns + j] = element;
        }

        public abstract ElementBase Negate();
    }
}