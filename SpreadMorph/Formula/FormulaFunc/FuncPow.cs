using System.Collections.Generic;
using Element;

/// <summary>
/// 指数を計算する
/// </summary>
/// <param name="args">引数リスト</param>
/// <returns>合計値</returns>
public class FuncPow : FormulaFuncBase
{
    public static ElementBase Pow(ElementBase baseElement, ElementBase exponent)
    {
        if (baseElement is Polynomial polynomialElement && exponent is Integer exponentIntegerElement)
        {
            return Polynomial.Pow(polynomialElement, exponentIntegerElement);
        }
        return null;
    }
}