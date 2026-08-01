namespace Element
{
    public class Vec4 : Vector, INegate
    {
        public override int Dim => 4;

        Integer[] elements = new Integer[4];
        public override Integer[] Elements => elements;


        public Integer X => elements[0];
        public Integer Y => elements[1];
        public Integer Z => elements[2];
        public Integer W => elements[3];

        public Vec4()
        {
            elements[0] = new Integer(0);
            elements[1] = new Integer(0);
            elements[2] = new Integer(0);
            elements[3] = new Integer(0);
        }

        public Vec4(Integer x, Integer y, Integer z, Integer w)
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
            return new Vec4(Integer.Sum(a.X, b.X), Integer.Sum(a.Y, b.Y), Integer.Sum(a.Z, b.Z), Integer.Sum(a.W, b.W));
        }

        public ElementBase Negate()
        {
            return new Vec4(X.Negate() as Integer, Y.Negate() as Integer, Z.Negate() as Integer, W.Negate() as Integer);
        }
    }
}