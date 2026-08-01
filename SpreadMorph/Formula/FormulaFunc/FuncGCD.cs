using System.Collections.Generic;
using Element;

/// <summary>
/// 最大公約数
/// </summary>
/// <param name="a"></param>
/// <param name="b"></param>
/// <returns>最大公約数</returns>
public class FuncGCD : FormulaFuncBase
{
    /// <summary>
    /// 互除法により最大公約数を求める
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Integer GCD(Integer a, Integer b)
    {
        if (a.Value < b.Value)
        {
            Integer temp = a;
            a = b;
            b = temp;
        }
        while (b.Value != 0)
        {
            Integer temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
