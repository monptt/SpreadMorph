namespace Element
{
    /// <summary>
    /// 実数
    /// </summary>
    public abstract class RealNumber : Number
    {
        public override abstract ElementBase Negate();

        public static RealNumber Sum(RealNumber a, RealNumber b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt + bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational + bRational;
            }

            return null;
        }

        public static RealNumber Multiply(RealNumber a, RealNumber b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt * bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational * bRational;
            }
            return null;
        }

        public static RealNumber operator +(RealNumber a, RealNumber b)
        {
            return Sum(a, b);
        }

        public static RealNumber operator *(RealNumber a, RealNumber b)
        {
            return Multiply(a, b);
        }

        public static RealNumber operator -(RealNumber a, RealNumber b)
        {
            return a - b;
        }

        public static RealNumber operator -(RealNumber a)
        {
            return a.Negate() as RealNumber;
        }

        public static bool operator ==(RealNumber a, RealNumber b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt == bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational == bRational;
            }
            return false;
        }

        public static bool operator !=(RealNumber a, RealNumber b)
        {
            return !(a == b);
        }

        public static bool operator >(RealNumber a, RealNumber b)
        {
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt > bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational > bRational;
            }
            return false;
        }

        public static bool operator <(RealNumber a, RealNumber b)
        {
            return b > a;
        }

        public static bool operator >=(RealNumber a, RealNumber b)
        {
            return a > b || a == b;
        }

        public static bool operator <=(RealNumber a, RealNumber b)
        {
            return a < b || a == b;
        }
    }
}