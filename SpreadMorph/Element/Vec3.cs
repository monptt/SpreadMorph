namespace Element
{
    public class Vec3 : Vector, INegate
    {
        public override int Dim => 3;

        Integer[] elements = new Integer[3];
        public override Integer[] Elements => elements;


        public Integer X => elements[0];
        public Integer Y => elements[1];
        public Integer Z => elements[2];

        public Vec3()
        {
            elements[0] = new Integer(0);
            elements[1] = new Integer(0);
            elements[2] = new Integer(0);
        }

        public Vec3(Integer x, Integer y, Integer z)
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
            return new Vec3(Integer.Sum(a.X, b.X), Integer.Sum(a.Y, b.Y), Integer.Sum(a.Z, b.Z));
        }

        public ElementBase Negate()
        {
            return new Vec3(X.Negate() as Integer, Y.Negate() as Integer, Z.Negate() as Integer);
        }
    }
}