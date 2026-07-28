using System.Collections.Generic;

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
            if (a is IntegerElement integerElementA && b is IntegerElement integerElementB)
            {
                return IntegerElement.Multiply(integerElementA, integerElementB);
            }
            if (a is ComplexElement complexElementA && b is ComplexElement complexElementB)
            {
                return ComplexElement.Multiply(complexElementA, complexElementB);
            }
        }


        // 多項式
        {
            if (a is PolynomialElement polynomialElementA && b is IntegerElement integerElementB)
            {
                return PolynomialElement.Multiply(polynomialElementA, integerElementB);
            }
            if (a is IntegerElement integerElementA && b is PolynomialElement polynomialElementB)
            {
                return PolynomialElement.Multiply(polynomialElementB, integerElementA);
            }
        }

        // 行列・ベクトル
        {
            if (a is Mat2Element mat2ElementA)
            {
                if (b is Vec2Element vec2ElementB)
                {
                    return mat2ElementA * vec2ElementB;
                }
                if (b is Mat2Element mat2ElementB)
                {
                    return mat2ElementA * mat2ElementB;
                }
            }
            if (a is Mat3Element mat3ElementA)
            {
                if (b is Vec3Element vec3ElementB)
                {
                    return mat3ElementA * vec3ElementB;
                }
                if (b is Mat3Element mat3ElementB)
                {
                    return mat3ElementA * mat3ElementB;
                }
            }
            if (a is Mat4Element mat4ElementA)
            {
                if (b is Vec4Element vec4ElementB)
                {
                    return mat4ElementA * vec4ElementB;
                }
                if (b is Mat4Element mat4ElementB)
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
            if (arg is ComplexElement)
            {
                isComplex = true;
                break;
            }
        }
        if (isComplex)
        {
            ComplexElement product = new ComplexElement(new IntegerElement(1), new IntegerElement(0));
            foreach (ElementBase arg in args)
            {
                if (arg is ComplexElement complexElement)
                {
                    product = ComplexElement.Multiply(product, complexElement);
                }
                else if (arg is IntegerElement integerElement)
                {
                    product = ComplexElement.Multiply(product, integerElement);
                }
            }
            return product;
        }


        if (args[0] is IntegerElement)
        {
            IntegerElement product = new IntegerElement(1);
            foreach (ElementBase arg in args)
            {
                if (arg is IntegerElement numberElement)
                {
                    product = IntegerElement.Multiply(product, numberElement);
                }
            }
            return product;
        }
        return null;
    }
}