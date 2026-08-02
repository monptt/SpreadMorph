namespace Element
{
    /// <summary>
    /// 単項式
    /// </summary>
    public class Monomial : Function, INegate, IDifferentiable
    {
        /// <summary>
        /// 係数
        /// </summary>
        RealNumber coefficient;
        public RealNumber Coefficient => coefficient;

        /// <summary>
        /// 次数
        /// </summary>
        Integer degree;
        public Integer Degree => degree;

        public Monomial(RealNumber coefficient, Integer degree)
        {
            this.coefficient = coefficient;
            this.degree = degree;
        }

        public ElementBase Negate()
        {
            return new Monomial(coefficient.Negate() as RealNumber, degree);
        }

        public ElementBase Differentiate()
        {
            if (degree == new Integer(0))
            {
                return new Integer(0);
            }
            else
            {
                return new Monomial(coefficient * degree, degree - new Integer(1));
            }
        }
    }
}