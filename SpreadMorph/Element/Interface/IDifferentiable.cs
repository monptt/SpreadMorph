using Element;

/// <summary>
/// 微分可能
/// </summary>
public interface IDifferentiable
{
    /// <summary>
    /// 導関数を返す
    /// </summary>
    /// <returns>導関数</returns>
    public abstract ElementBase Differentiate();
}
