namespace Element
{
    /// <summary>
    /// 数
    /// </summary>
    public class Integer : Number, IInverse, INegate
    {
        int value;
        public int Value => value;

        public Integer(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        /// 和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer Sum(Integer a, Integer b)
        {
            return new Integer(a.Value + b.Value);
        }

        /// <summary>
        /// 差
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer Subtract(Integer a, Integer b)
        {
            return new Integer(a.Value - b.Value);
        }

        /// <summary>
        /// 積
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Integer Multiply(Integer a, Integer b)
        {
            return new Integer(a.Value * b.Value);
        }

        public static Integer operator +(Integer a, Integer b)
        {
            return Sum(a, b);
        }

        public static Integer operator -(Integer a, Integer b)
        {
            return Subtract(a, b);
        }

        public static Integer operator *(Integer a, Integer b)
        {
            return Multiply(a, b);
        }

        public static Integer operator *(Integer a, Rational b)
        {
            return a * (b.Inverse() as Rational);
        }

        public static Integer operator %(Integer a, Integer b)
        {
            return new Integer(a.Value % b.Value);
        }

        public static ElementBase operator /(Integer a, Integer b)
        {
            if (a.value % b.value == 0)
            {
                return new Integer(a.value / b.value);
            }

            return new Rational(a, b);
        }

        public static bool operator ==(Integer a, Integer b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(Integer a, Integer b)
        {
            return a.value != b.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Integer other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public ElementBase Inverse()
        {
            return new Rational(new Integer(1), this);
        }

        public ElementBase Negate()
        {
            return new Integer(-value);
        }
    }
}