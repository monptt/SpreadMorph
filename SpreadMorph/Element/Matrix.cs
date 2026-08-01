namespace Element
{
    public abstract class Matrix : ElementBase, INegate
    {
        public abstract int Rows { get; }
        public abstract int Columns { get; }

        public abstract Number[] Elements { get; }

        public Number GetElement(int i, int j)
        {
            return Elements[i * Columns + j];
        }

        public void SetElement(int i, int j, ElementBase element)
        {
            Elements[i * Columns + j] = element as Number;
        }

        public abstract ElementBase Negate();
    }
}