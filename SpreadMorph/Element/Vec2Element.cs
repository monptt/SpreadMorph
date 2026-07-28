public class Vec2Element : VecElement, INegate
{
    public override int Dim => 2;

    IntegerElement[] elements = new IntegerElement[2];
    public override IntegerElement[] Elements => elements;

    public IntegerElement X => elements[0];
    public IntegerElement Y => elements[1];

    public Vec2Element()
    {
        this.elements[0] = new IntegerElement(0);
        this.elements[1] = new IntegerElement(0);
    }

    public Vec2Element(IntegerElement x, IntegerElement y)
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
    public static Vec2Element Sum(Vec2Element a, Vec2Element b)
    {
        return new Vec2Element(IntegerElement.Sum(a.X, b.X), IntegerElement.Sum(a.Y, b.Y));
    }

    public ElementBase Negate()
    {
        return new Vec2Element(X.Negate() as IntegerElement, Y.Negate() as IntegerElement);
    }
}