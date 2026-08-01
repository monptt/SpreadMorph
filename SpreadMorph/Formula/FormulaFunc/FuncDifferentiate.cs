using System.Collections.Generic;
using Element;

/// <summary>
/// 微分
/// </summary>
public class FuncDifferentiate : FormulaFuncBase
{
    public static ElementBase Differentiate(ElementBase element)
    {
        if (element is IDifferentiable f)
        {
            return f.Differentiate();
        }

        return null;
    }
}
