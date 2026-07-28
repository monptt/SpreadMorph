using System.Collections.Generic;

public class Mat4Element : MatElement
{
    public override int Rows => 4;
    public override int Columns => 4;

    IntegerElement[] elements = new IntegerElement[16];
    public override IntegerElement[] Elements => elements;

    public Mat4Element()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                elements[i * Columns + j] = new IntegerElement(0);
            }
        }
    }

    public Mat4Element(IntegerElement a, IntegerElement b, IntegerElement c, IntegerElement d,
                        IntegerElement e, IntegerElement f, IntegerElement g, IntegerElement h,
                        IntegerElement i, IntegerElement j, IntegerElement k, IntegerElement l,
                        IntegerElement m, IntegerElement n, IntegerElement o, IntegerElement p)
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

    public static Vec4Element operator *(Mat4Element a, Vec4Element b)
    {
        Vec4Element result = new Vec4Element();
        for (int i = 0; i < 4; i++)
        {
            result.Elements[i] =
                IntegerElement.Multiply(a.GetElement(i, 0), b.GetElement(0)) +
                IntegerElement.Multiply(a.GetElement(i, 1), b.GetElement(1)) +
                IntegerElement.Multiply(a.GetElement(i, 2), b.GetElement(2)) +
                IntegerElement.Multiply(a.GetElement(i, 3), b.GetElement(3));
        }
        return result;
    }

    public static Mat4Element operator *(Mat4Element a, Mat4Element b)
    {
        Mat4Element result = new Mat4Element();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result.Elements[i * 4 + j] =
                    IntegerElement.Multiply(a.GetElement(i, 0), b.GetElement(0, j)) +
                    IntegerElement.Multiply(a.GetElement(i, 1), b.GetElement(1, j)) +
                    IntegerElement.Multiply(a.GetElement(i, 2), b.GetElement(2, j)) +
                    IntegerElement.Multiply(a.GetElement(i, 3), b.GetElement(3, j));
            }
        }
        return result;
    }
}