using System.Collections.Generic;

namespace Element
{
    public class Mat3 : Matrix
    {
        public override int Rows => 3;
        public override int Columns => 3;

        Integer[] elements = new Integer[9];
        public override Integer[] Elements => elements;

        public Mat3()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    elements[i * Columns + j] = new Integer(0);
                }
            }
        }

        public Mat3(Integer a, Integer b, Integer c,
                            Integer d, Integer e, Integer f,
                            Integer g, Integer h, Integer i)
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
        }

        public static Vec3 operator *(Mat3 a, Vec3 b)
        {
            Vec3 result = new Vec3();
            for (int i = 0; i < 3; i++)
            {
                result.Elements[i] =
                    Integer.Multiply(a.GetElement(i, 0), b.GetElement(0)) +
                    Integer.Multiply(a.GetElement(i, 1), b.GetElement(1)) +
                    Integer.Multiply(a.GetElement(i, 2), b.GetElement(2));
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
                        Integer.Multiply(a.GetElement(i, 0), b.GetElement(0, j)) +
                        Integer.Multiply(a.GetElement(i, 1), b.GetElement(1, j)) +
                        Integer.Multiply(a.GetElement(i, 2), b.GetElement(2, j));
                }
            }
            return result;
        }
    }
}