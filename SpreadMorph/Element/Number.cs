namespace Element
{
    /// <summary>
    /// 数
    /// </summary>
    public abstract class Number : ElementBase, IDifferentiable, INegate
    {
        public abstract ElementBase Negate();

        public ElementBase Differentiate()
        {
            return new Integer(0);
        }

        public static Number Sum(Number a, Number b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return new Integer(aInt.Value + bInt.Value);
            }

            return new Integer(0);
        }

        public static Number Multiply(Number a, Number b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return new Integer(aInt.Value * bInt.Value);
            }

            return new Integer(0);
        }

        public static Number operator +(Number a, Number b)
        {
            return Sum(a, b);
        }

        public static Number operator *(Number a, Number b)
        {
            return Multiply(a, b);
        }
    }
}
