/// <summary>
/// 単項式
/// </summary>
public class MonomialElement : ElementBase, INegate
{
    /// <summary>
    /// 係数
    /// </summary>
    IntegerElement coefficient;
    public IntegerElement Coefficient => coefficient;

    /// <summary>
    /// 次数
    /// </summary>
    IntegerElement degree;
    public IntegerElement Degree => degree;

    public MonomialElement(IntegerElement coefficient, IntegerElement degree)
    {
        this.coefficient = coefficient;
        this.degree = degree;
    }

    public ElementBase Negate()
    {
        return new MonomialElement(coefficient.Negate() as IntegerElement, degree);
    }
}