namespace Element
{
    /// <summary>
    /// 数（定数）
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
            {
                if (a is RealNumber aReal && b is RealNumber bReal)
                {
                    return aReal + bReal;
                }
                if (a is Complex aComplex && b is Complex bComplex)
                {
                    return aComplex + bComplex;
                }
            }

            {
                if (a is Complex aComplex && b is RealNumber bReal)
                {
                    return aComplex + new Complex(bReal, new Integer(0));
                }
                if (a is RealNumber aReal && b is Complex bComplex)
                {
                    return new Complex(aReal, new Integer(0)) + bComplex;
                }
            }


            return null;
        }

        public static Number Multiply(Number a, Number b)
        {
            {
                if (a is RealNumber aReal && b is RealNumber bReal)
                {
                    return aReal * bReal;
                }
                if (a is Complex aComplex && b is Complex bComplex)
                {
                    return aComplex * bComplex;
                }
            }
            {
                if (a is Complex aComplex && b is RealNumber bReal)
                {
                    return aComplex * new Complex(bReal, new Integer(0));
                }
                if (a is RealNumber aReal && b is Complex bComplex)
                {
                    return new Complex(aReal, new Integer(0)) * bComplex;
                }
            }

            return null;
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
