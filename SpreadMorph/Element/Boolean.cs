namespace Element
{
    /// <summary>
    /// bool
    /// </summary>
    public class Boolean : ElementBase
    {
        bool value = false;
        public bool Value => value;

        public Boolean(bool value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            if (value)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
