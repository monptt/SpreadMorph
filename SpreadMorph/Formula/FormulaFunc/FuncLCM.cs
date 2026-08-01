using System.Collections.Generic;
using Element;

/// <summary>
/// 最小公倍数
/// </summary>
/// <param name="a"></param>
/// <param name="b"></param>
/// <returns>最小公倍数</returns>
public class FuncLCM : FormulaFuncBase
{
    /// <summary>
    /// 最小公倍数を求める
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Integer LCM(Integer a, Integer b)
    {
        ElementBase ret = a * b / FuncGCD.GCD(a, b);
        return ret as Integer;
    }
}
