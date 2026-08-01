namespace Element
{
    public class String : ElementBase
    {
        string value;

        public string Value => value;

        public String(string value)
        {
            this.value = value;
        }
    }
}
