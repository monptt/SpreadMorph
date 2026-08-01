using System.Collections.Generic;
using Element;

/// <summary>
/// 引数の合計を計算する
/// </summary>
/// <param name="args">引数リスト</param>
/// <returns>合計値</returns>
public class FuncSum : FormulaFuncBase
{
    /// <summary>
    /// 2つの引数に対応する場合
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static ElementBase Sum(ElementBase a, ElementBase b)
    {
        {
            if (a is Integer integerElementA && b is Integer integerElementB)
            {
                return Integer.Sum(integerElementA, integerElementB);
            }
            if (a is Complex complexElementA && b is Complex complexElementB)
            {
                return Complex.Sum(complexElementA, complexElementB);
            }
        }

        // 多項式
        {
            if (a is Polynomial polynomialElementA && b is Polynomial polynomialElementB)
            {
                return Polynomial.Add(polynomialElementA, polynomialElementB);
            }
        }
        {
            if (a is Polynomial polynomialElementA && b is Integer integerElementB)
            {
                return Polynomial.Add(polynomialElementA, new Polynomial(integerElementB));
            }
        }

        return null;
    }

    /// <summary>
    /// 3以上の引数に対応する場合
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static ElementBase Sum(List<ElementBase> args)
    {
        if (args.Count == 0)
        {
            return null;
        }

        if (args.Count == 1)
        {
            return args[0];
        }

        // 複素数が含まれてたら複素数として計算
        bool isComplex = false;
        foreach (ElementBase arg in args)
        {
            if (arg is Complex)
            {
                isComplex = true;
                break;
            }
        }
        if (isComplex)
        {
            Complex sum = new Complex(new Integer(0), new Integer(0));
            foreach (ElementBase arg in args)
            {
                if (arg is Complex complexElement)
                {
                    sum = Complex.Sum(sum, complexElement);
                }
                else if (arg is Integer integerElement)
                {
                    sum = Complex.Sum(sum, integerElement);
                }
            }
            return sum;
        }

        if (args[0] is Integer)
        {
            Integer sum = new Integer(0);
            foreach (ElementBase arg in args)
            {
                if (arg is Integer numberElement)
                {
                    sum = Integer.Sum(sum, numberElement);
                }
            }
            return sum;
        }
        else if (args[0] is Vec2)
        {
            Vec2 sum = new Vec2(new Integer(0), new Integer(0));
            foreach (ElementBase arg in args)
            {
                if (arg is Vec2 vec2Element)
                {
                    sum = Vec2.Sum(sum, vec2Element);
                }
            }
            return sum;
        }
        else if (args[0] is Vec3)
        {
            Vec3 sum = new Vec3(new Integer(0), new Integer(0), new Integer(0));
            foreach (ElementBase arg in args)
            {
                if (arg is Vec3 vec3Element)
                {
                    sum = Vec3.Sum(sum, vec3Element);
                }
            }
            return sum;
        }
        return null;
    }
}