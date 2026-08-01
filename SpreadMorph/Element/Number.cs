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
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt + bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational + bRational;
            }
            if (a is Complex aComplex && b is Complex bComplex)
            {
                return aComplex + bComplex;
            }

            return null;
        }

        public static Number Multiply(Number a, Number b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt * bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational * bRational;
            }
            if (a is Complex aComplex && b is Complex bComplex)
            {
                return aComplex * bComplex;
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
