namespace Element
{
    /// <summary>
    /// 単項式
    /// </summary>
    public class Monomial : ElementBase, INegate
    {
        /// <summary>
        /// 係数
        /// </summary>
        Integer coefficient;
        public Integer Coefficient => coefficient;

        /// <summary>
        /// 次数
        /// </summary>
        Integer degree;
        public Integer Degree => degree;

        public Monomial(Integer coefficient, Integer degree)
        {
            this.coefficient = coefficient;
            this.degree = degree;
        }

        public ElementBase Negate()
        {
            return new Monomial(coefficient.Negate() as Integer, degree);
        }
    }
}