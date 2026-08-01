namespace Element
{
    public class Vec2 : Vector, INegate
    {
        public override int Dim => 2;

        Number[] elements = new Number[2];
        public override Number[] Elements => elements;

        public Number X => elements[0];
        public Number Y => elements[1];

        public Vec2()
        {
            this.elements[0] = new Integer(0);
            this.elements[1] = new Integer(0);
        }

        public Vec2(Number x, Number y)
        {
            elements[0] = x;
            elements[1] = y;
        }

        /// <summary>
        /// 和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec2 Sum(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }

        public ElementBase Negate()
        {
            return new Vec2(X.Negate() as Number, Y.Negate() as Number);
        }
    }
}