using System.Collections.Generic;
using Element;

/// <summary>
/// 絶対値を計算する
/// </summary>
public class FuncAbsolute : FormulaFuncBase
{
    public static ElementBase Absolute(ElementBase element)
    {
        if (element is IAbsolute absoluteElement)
        {
            return absoluteElement.Absolute();
        }
        return null;
    }
}