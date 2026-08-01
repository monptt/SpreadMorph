using System.Collections.Generic;

namespace Element
{
    public class Mat4 : Matrix
    {
        public override int Rows => 4;
        public override int Columns => 4;

        Number[] elements = new Number[16];
        public override Number[] Elements => elements;

        public Mat4()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    elements[i * Columns + j] = new Integer(0);
                }
            }
        }

        public Mat4(Number a, Number b, Number c, Number d,
                            Number e, Number f, Number g, Number h,
                            Number i, Number j, Number k, Number l,
                            Number m, Number n, Number o, Number p)
        {
            elements[0] = a;
            elements[1] = b;
            elements[2] = c;
            elements[3] = d;
            elements[4] = e;
            elements[5] = f;
            elements[6] = g;
            elements[7] = h;
            elements[8] = i;
            elements[9] = j;
            elements[10] = k;
            elements[11] = l;
            elements[12] = m;
            elements[13] = n;
            elements[14] = o;
            elements[15] = p;
        }

        public static Vec4 operator *(Mat4 a, Vec4 b)
        {
            Vec4 result = new Vec4();
            for (int i = 0; i < 4; i++)
            {
                result.Elements[i] =
                    Number.Multiply(a.GetElement(i, 0), b.GetElement(0)) +
                    Number.Multiply(a.GetElement(i, 1), b.GetElement(1)) +
                    Number.Multiply(a.GetElement(i, 2), b.GetElement(2)) +
                    Number.Multiply(a.GetElement(i, 3), b.GetElement(3));
            }
            return result;
        }

        public static Mat4 operator *(Mat4 a, Mat4 b)
        {
            Mat4 result = new Mat4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.Elements[i * 4 + j] =
                        Number.Multiply(a.GetElement(i, 0), b.GetElement(0, j)) +
                        Number.Multiply(a.GetElement(i, 1), b.GetElement(1, j)) +
                        Number.Multiply(a.GetElement(i, 2), b.GetElement(2, j)) +
                        Number.Multiply(a.GetElement(i, 3), b.GetElement(3, j));
                }
            }
            return result;
        }

        public override ElementBase Negate()
        {
            Mat4 result = new Mat4();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.SetElement(i, j, GetElement(i, j).Negate());
                }
            }
            return result;
        }
    }
}
