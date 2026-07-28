using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 多項式
/// </summary>
public class PolynomialElement : ElementBase, INegate
{
    /// <summary>
    /// 次数と項のペア
    /// </summary>
    Dictionary<IntegerElement, MonomialElement> terms = new Dictionary<IntegerElement, MonomialElement>();

    public PolynomialElement()
    {
    }

    /// <summary>
    /// 次数と係数から単項式を作成
    /// </summary>
    /// <param name="degree">次数</param>
    /// <param name="coefficient">係数</param>
    public PolynomialElement(IntegerElement degree, IntegerElement coefficient)
    {
        terms.Add(degree, new MonomialElement(coefficient, degree));
    }

    /// <summary>
    /// 定数
    /// </summary>
    /// <param name="c"></param>
    public PolynomialElement(IntegerElement c)
    {
        terms.Add(new IntegerElement(0), new MonomialElement(c, new IntegerElement(0)));
    }

    public override string ToString()
    {
        if (terms.Count == 0)
        {
            return "0";
        }

        // 降べきの順にソート
        var sortedTerms = terms.OrderByDescending(pair => pair.Key.Value).ToList();

        string str = "";
        for (int i = 0; i < sortedTerms.Count; i++)
        {
            var pair = sortedTerms.ElementAt(i);
            MonomialElement term = pair.Value;

            string coefficientStr = ""; // 係数の部分
            string xStr = ""; // x^n の部分

            if (term.Coefficient.Value == 1 && term.Degree.Value != 0)
            {
                coefficientStr = "";
            }
            else
            {
                if (i != 0)
                {
                    if (term.Coefficient.Value > 0)
                    {
                        coefficientStr += "+";
                    }
                }
                coefficientStr += term.Coefficient.ToString();
            }

            if (term.Degree.Value == 0)
            {
                xStr = "";
            }
            else if (term.Degree.Value == 1)
            {
                xStr = "x";
            }
            else
            {
                xStr = $"x^{term.Degree.Value}";
            }

            str += $"{coefficientStr}{xStr}";
        }
        return str;
    }

    public static PolynomialElement Add(PolynomialElement a, PolynomialElement b)
    {
        PolynomialElement result = new PolynomialElement();
        for (int i = 0; i < a.terms.Count; i++)
        {
            var pair = a.terms.ElementAt(i);
            MonomialElement term = pair.Value;
            result.AddTerm(new MonomialElement(term.Coefficient, term.Degree));
        }
        for (int i = 0; i < b.terms.Count; i++)
        {
            var pair = b.terms.ElementAt(i);
            MonomialElement term = pair.Value;
            result.AddTerm(new MonomialElement(term.Coefficient, term.Degree));
        }
        return result;
    }

    public static PolynomialElement Multiply(PolynomialElement a, IntegerElement b)
    {
        // 各項を定数倍
        PolynomialElement result = new PolynomialElement();
        foreach (var pair in a.terms)
        {
            MonomialElement term = pair.Value;
            result.AddTerm(new MonomialElement(term.Coefficient * b, term.Degree));
        }
        return result;
    }

    public ElementBase Negate()
    {
        return Multiply(this, new IntegerElement(-1));
    }

    public static PolynomialElement Multiply(PolynomialElement a, PolynomialElement b)
    {
        PolynomialElement result = new PolynomialElement();
        foreach (var pair in a.terms)
        {
            MonomialElement term = pair.Value;
            foreach (var pair2 in b.terms)
            {
                MonomialElement term2 = pair2.Value;
                result.AddTerm(new MonomialElement(term.Coefficient * term2.Coefficient, term.Degree + term2.Degree));
            }
        }
        return result;
    }

    public static PolynomialElement Pow(PolynomialElement polynomialElement, IntegerElement exponent)
    {
        PolynomialElement result = new PolynomialElement(new IntegerElement(0), new IntegerElement(1));
        for (int i = 0; i < exponent.Value; i++)
        {
            result = Multiply(result, polynomialElement);
        }
        return result;
    }

    void AddTerm(MonomialElement term)
    {
        if (terms.ContainsKey(term.Degree))
        {
            terms[term.Degree] = new MonomialElement(terms[term.Degree].Coefficient + term.Coefficient, term.Degree);
        }
        else
        {
            terms.Add(term.Degree, term);
        }
    }
}