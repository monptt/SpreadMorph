using System.Collections.Generic;

namespace Element
{
    public class Mat2 : Matrix
    {
        public override int Rows => 2;
        public override int Columns => 2;

        Integer[] elements = new Integer[4];
        public override Integer[] Elements => elements;

        public Mat2()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    SetElement(i, j, new Integer(0));
                }
            }
        }

        public Mat2(Integer a, Integer b, Integer c, Integer d)
        {
            SetElement(0, 0, a);
            SetElement(0, 1, b);
            SetElement(1, 0, c);
            SetElement(1, 1, d);
        }

        public static Mat2 operator +(Mat2 a, Mat2 b)
        {
            Mat2 result = new Mat2();
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result.SetElement(i, j, Integer.Sum(a.GetElement(i, j), b.GetElement(i, j)));
                }
            }
            return result;
        }

        public static Mat2 operator -(Mat2 a)
        {
            Mat2 result = new Mat2();
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result.SetElement(i, j, a.GetElement(i, j).Negate() as Integer);
                }
            }
            return result;
        }

        public static Mat2 operator -(Mat2 a, Mat2 b)
        {
            return a + (-b);
        }

        public override ElementBase Negate()
        {
            return -this;
        }

        public static Vec2 operator *(Mat2 a, Vec2 b)
        {
            Vec2 result = new Vec2();
            for (int i = 0; i < 2; i++)
            {
                result.Elements[i] = Integer.Sum(
                    Integer.Multiply(a.GetElement(i, 0), b.GetElement(0)),
                    Integer.Multiply(a.GetElement(i, 1), b.GetElement(1))
                );
            }
            return result;
        }

        public static Mat2 operator *(Mat2 a, Mat2 b)
        {
            Mat2 result = new Mat2();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result.Elements[i * 2 + j] = Integer.Sum(
                        Integer.Multiply(a.GetElement(i, 0), b.GetElement(0, j)),
                        Integer.Multiply(a.GetElement(i, 1), b.GetElement(1, j))
                    );
                }
            }
            return result;
        }
    }
}