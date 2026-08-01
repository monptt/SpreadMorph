namespace Element
{
    /// <summary>
    /// 複素数
    /// </summary>
    public class Complex : Number
    {
        RealNumber re;
        RealNumber im;
        public RealNumber Re => re;
        public RealNumber Im => im;

        public Complex(RealNumber re, RealNumber im)
        {
            this.re = re;
            this.im = im;
        }

        /// <summary>
        /// 和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex Sum(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex Sum(Complex a, RealNumber b)
        {
            return new Complex(a.Re + b, a.Im);
        }

        public static Complex Subtract(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        /// <summary>
        /// 積
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complex Multiply(Complex a, Complex b)
        {
            return new Complex(
                a.Re * b.Re - a.Im * b.Im,
                a.Re * b.Im + a.Im * b.Re
            );
        }

        public static Complex Multiply(Complex a, RealNumber b)
        {
            return new Complex(a.Re * b, a.Im * b);
        }

        public override ElementBase Negate()
        {
            return new Complex(-re, -im);
        }
    }
}