using System.Collections.Generic;
using Element;

/// <summary>
/// 引数の合計を計算する
/// </summary>
/// <param name="args">引数リスト</param>
/// <returns>合計値</returns>
public class FuncMultiply : FormulaFuncBase
{
    /// <summary>
    /// 2つの引数に対応する場合
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static ElementBase Multiply(ElementBase a, ElementBase b)
    {
        // 整数、複素数
        {
            if (a is Number aNumber && b is Number bNumber)
            {
                return aNumber * bNumber;
            }
        }


        // 多項式
        {
            if (a is Polynomial polynomialElementA && b is Integer integerElementB)
            {
                return Polynomial.Multiply(polynomialElementA, integerElementB);
            }
            if (a is Integer integerElementA && b is Polynomial polynomialElementB)
            {
                return Polynomial.Multiply(polynomialElementB, integerElementA);
            }
        }

        // 行列・ベクトル
        {
            if (a is Mat2 mat2ElementA)
            {
                if (b is Vec2 vec2ElementB)
                {
                    return mat2ElementA * vec2ElementB;
                }
                if (b is Mat2 mat2ElementB)
                {
                    return mat2ElementA * mat2ElementB;
                }
            }
            if (a is Mat3 mat3ElementA)
            {
                if (b is Vec3 vec3ElementB)
                {
                    return mat3ElementA * vec3ElementB;
                }
                if (b is Mat3 mat3ElementB)
                {
                    return mat3ElementA * mat3ElementB;
                }
            }
            if (a is Mat4 mat4ElementA)
            {
                if (b is Vec4 vec4ElementB)
                {
                    return mat4ElementA * vec4ElementB;
                }
                if (b is Mat4 mat4ElementB)
                {
                    return mat4ElementA * mat4ElementB;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// 3以上の引数に対応する場合
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static ElementBase Multiply(List<ElementBase> args)
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
            Complex product = new Complex(new Integer(1), new Integer(0));
            foreach (ElementBase arg in args)
            {
                if (arg is Complex complexElement)
                {
                    product = Complex.Multiply(product, complexElement);
                }
                else if (arg is Integer integerElement)
                {
                    product = Complex.Multiply(product, integerElement);
                }
            }
            return product;
        }


        if (args[0] is Integer)
        {
            Integer product = new Integer(1);
            foreach (ElementBase arg in args)
            {
                if (arg is Integer numberElement)
                {
                    product = Integer.Multiply(product, numberElement);
                }
            }
            return product;
        }
        return null;
    }
}