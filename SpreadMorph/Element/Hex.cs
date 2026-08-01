namespace Element
{
    /// <summary>
    /// 16進数
    /// </summary>
    public class Hex : ElementBase
    {
        string value;
        public string Value => value;

        public Hex(string value)
        {
            this.value = value.ToUpper();
        }
    }
}