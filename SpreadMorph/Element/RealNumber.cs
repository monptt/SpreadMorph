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
            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt - bInt;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational - bRational;
            }

            return null;
        }

        public static RealNumber operator -(RealNumber a)
        {
            return a.Negate() as RealNumber;
        }

        public static bool operator ==(RealNumber a, RealNumber b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }

            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt.Value == bInt.Value;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                return aRational.Numerator.Value == bRational.Numerator.Value
                    && aRational.Denominator.Value == bRational.Denominator.Value;
            }
            return false;
        }

        public static bool operator !=(RealNumber a, RealNumber b)
        {
            return !(a == b);
        }

        public static bool operator >(RealNumber a, RealNumber b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            if (a is Integer aInt && b is Integer bInt)
            {
                return aInt.Value > bInt.Value;
            }
            if (a is Rational aRational && b is Rational bRational)
            {
                int left = aRational.Numerator.Value * bRational.Denominator.Value;
                int right = bRational.Numerator.Value * aRational.Denominator.Value;
                return left > right;
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