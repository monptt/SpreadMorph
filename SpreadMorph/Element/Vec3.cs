namespace Element
{
    public class Vec3 : Vector, INegate
    {
        public override int Dim => 3;

        Number[] elements = new Number[3];
        public override Number[] Elements => elements;


        public Number X => elements[0];
        public Number Y => elements[1];
        public Number Z => elements[2];

        public Vec3()
        {
            elements[0] = new Integer(0);
            elements[1] = new Integer(0);
            elements[2] = new Integer(0);
        }

        public Vec3(Number x, Number y, Number z)
        {
            elements[0] = x;
            elements[1] = y;
            elements[2] = z;
        }

        /// <summary>
        /// 和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 Sum(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public ElementBase Negate()
        {
            return new Vec3(X.Negate() as Number, Y.Negate() as Number, Z.Negate() as Number);
        }
    }
}