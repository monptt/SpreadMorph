namespace Element
{
    /// <summary>
    /// 有理数クラス
    /// </summary>
    public class Rational : Number, IInverse
    {
        Integer numerator = new Integer(0);
        public Integer Numerator => numerator;

        Integer denominator = new Integer(1);
        public Integer Denominator => denominator;

        public Rational(Integer numerator, Integer denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            // 分子が0
            if (numerator.Value == 0)
            {
                this.denominator = new Integer(1);
            }

            // 約分
            Integer gcd = FuncGCD.GCD(numerator, denominator);
            this.numerator = (numerator / gcd) as Integer;
            this.denominator = (denominator / gcd) as Integer;
        }

        public ElementBase Inverse()
        {
            return new Rational(this.denominator, this.numerator);
        }

        public static Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return Multiply(a, b);
        }

        public override ElementBase Negate()
        {
            return new Rational(numerator.Negate() as Integer, denominator);
        }
    }
}