using System.Collections.Generic;

namespace Element
{
    public class Mat3 : Matrix
    {
        public override int Rows => 3;
        public override int Columns => 3;

        Number[] elements = new Number[9];
        public override Number[] Elements => elements;

        public Mat3()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    SetElement(i, j, new Integer(0));
                }
            }
        }

        public Mat3(Number a, Number b, Number c,
                            Number d, Number e, Number f,
                            Number g, Number h, Number i)
        {
            SetElement(0, 0, a);
            SetElement(0, 1, b);
            SetElement(0, 2, c);
            SetElement(1, 0, d);
            SetElement(1, 1, e);
            SetElement(1, 2, f);
            SetElement(2, 0, g);
            SetElement(2, 1, h);
            SetElement(2, 2, i);
        }

        public static Vec3 operator *(Mat3 a, Vec3 b)
        {
            Vec3 result = new Vec3();
            for (int i = 0; i < 3; i++)
            {
                result.Elements[i] =
                    Number.Multiply(a.GetElement(i, 0), b.GetElement(0)) +
                    Number.Multiply(a.GetElement(i, 1), b.GetElement(1)) +
                    Number.Multiply(a.GetElement(i, 2), b.GetElement(2));
            }
            return result;
        }

        public static Mat3 operator *(Mat3 a, Mat3 b)
        {
            Mat3 result = new Mat3();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.Elements[i * 3 + j] =
                        Number.Multiply(a.GetElement(i, 0), b.GetElement(0, j)) +
                        Number.Multiply(a.GetElement(i, 1), b.GetElement(1, j)) +
                        Number.Multiply(a.GetElement(i, 2), b.GetElement(2, j));
                }
            }
            return result;
        }

        public override ElementBase Negate()
        {
            Mat3 result = new Mat3();
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
