using Element;

namespace Element
{
    /// <summary>
    /// 確率
    /// </summary>
    public class Probability : ElementBase
    {
        RealNumber value;
        public RealNumber Value => value;

        public Probability(RealNumber value)
        {
            // 確率は0から1の間
            if (value < new Integer(0) || new Integer(1) < value)
            {
                value = null;
                return;
            }

            this.value = value;
        }
    }
}
