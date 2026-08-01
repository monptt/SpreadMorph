using System.Collections.Generic;
using Element;

/// <summary>
/// 割り算
/// </summary>
/// <param name="dividend">被除数</param>
/// <param name="divisor">除数</param>
/// <returns>商</returns>
public class FuncDivide : FormulaFuncBase
{
    public static ElementBase Divide(ElementBase dividend, ElementBase divisor)
    {
        {
            if (dividend is Integer a && divisor is Integer b)
            {
                return new Rational(a, b);
            }
        }

        {
            if (dividend is Rational a && divisor is Integer b)
            {
                return a * (b.Inverse() as Rational);
            }
        }


        {
            if (dividend is Integer a && divisor is Rational b)
            {
                return a * (b.Inverse() as Rational);
            }
        }

        {
            if (dividend is Rational a && divisor is Rational b)
            {
                return a * (b.Inverse() as Rational);
            }
        }

        return null;
    }
}