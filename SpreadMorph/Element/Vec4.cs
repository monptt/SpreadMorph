namespace Element
{
    public class Vec4 : Vector, INegate
    {
        public override int Dim => 4;

        Number[] elements = new Number[4];
        public override Number[] Elements => elements;


        public Number X => elements[0];
        public Number Y => elements[1];
        public Number Z => elements[2];
        public Number W => elements[3];

        public Vec4()
        {
            elements[0] = new Integer(0);
            elements[1] = new Integer(0);
            elements[2] = new Integer(0);
            elements[3] = new Integer(0);
        }

        public Vec4(Number x, Number y, Number z, Number w)
        {
            elements[0] = x;
            elements[1] = y;
            elements[2] = z;
            elements[3] = w;
        }

        /// <summary>
        /// 和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec4 Sum(Vec4 a, Vec4 b)
        {
            return new Vec4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public ElementBase Negate()
        {
            return new Vec4(X.Negate() as Number, Y.Negate() as Number, Z.Negate() as Number, W.Negate() as Number);
        }
    }
}