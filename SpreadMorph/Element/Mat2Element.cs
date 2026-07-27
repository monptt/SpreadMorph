using System.Collections.Generic;

public class Mat2Element : MatElement, INegate
{
    public override int Rows => 2;
    public override int Columns => 2;

    IntegerElement[] elements = new IntegerElement[4];
    public override IntegerElement[] Elements => elements;

    public Mat2Element()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                elements[i * Columns + j] = new IntegerElement(0);
            }
        }
    }

    public Mat2Element(IntegerElement a, IntegerElement b, IntegerElement c, IntegerElement d)
    {
        elements[0] = a;
        elements[1] = b;
        elements[2] = c;
        elements[3] = d;
    }

    public static Mat2Element operator +(Mat2Element a, Mat2Element b)
    {
        Mat2Element result = new Mat2Element();
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.elements[i * a.Columns + j] = IntegerElement.Sum(a.GetElement(i, j), b.GetElement(i, j));
            }
        }
        return result;
    }

    public static Mat2Element operator -(Mat2Element a)
    {
        Mat2Element result = new Mat2Element();
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.elements[i * a.Columns + j] = a.GetElement(i, j).Negate() as IntegerElement;
            }
        }
        return result;
    }

    public static Mat2Element operator -(Mat2Element a, Mat2Element b)
    {
        return a + (-b);
    }

    public ElementBase Negate()
    {
        return -this;
    }

    public static Vec2Element operator *(Mat2Element a, Vec2Element b)
    {
        Vec2Element result = new Vec2Element();
        for (int i = 0; i < 2; i++)
        {
            result.Elements[i] = IntegerElement.Sum(
                IntegerElement.Multiply(a.GetElement(i, 0), b.GetElement(0)),
                IntegerElement.Multiply(a.GetElement(i, 1), b.GetElement(1))
            );
        }
        return result;
    }

    public static Mat2Element operator *(Mat2Element a, Mat2Element b)
    {
        Mat2Element result = new Mat2Element();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result.Elements[i * 2 + j] = IntegerElement.Sum(
                    IntegerElement.Multiply(a.GetElement(i, 0), b.GetElement(0, j)),
                    IntegerElement.Multiply(a.GetElement(i, 1), b.GetElement(1, j))
                );
            }
        }
        return result;
    }
}