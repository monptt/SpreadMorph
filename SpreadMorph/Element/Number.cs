namespace Element
{
    /// <summary>
    /// 数
    /// </summary>
    public abstract class Number : ElementBase, IDifferentiable
    {

        public ElementBase Differentiate()
        {
            return new Integer(0);
        }

    }
}
