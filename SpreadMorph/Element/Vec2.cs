namespace Element
{
    public class Vec2 : Vector, INegate
    {
        public override int Dim => 2;

        Integer[] elements = new Integer[2];
        public override Integer[] Elements => elements;

        public Integer X => elements[0];
        public Integer Y => elements[1];

        public Vec2()
        {
            this.elements[0] = new Integer(0);
            this.elements[1] = new Integer(0);
        }

        public Vec2(Integer x, Integer y)
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
            return new Vec2(Integer.Sum(a.X, b.X), Integer.Sum(a.Y, b.Y));
        }

        public ElementBase Negate()
        {
            return new Vec2(X.Negate() as Integer, Y.Negate() as Integer);
        }
    }
}