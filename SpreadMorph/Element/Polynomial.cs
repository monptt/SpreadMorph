using System.Collections.Generic;
using System.Linq;

namespace Element
{
    /// <summary>
    /// 多項式
    /// </summary>
    public class Polynomial : Function, INegate, IDifferentiable
    {
        /// <summary>
        /// 次数と項のペア
        /// </summary>
        Dictionary<Integer, Monomial> terms = new Dictionary<Integer, Monomial>();

        public Polynomial()
        {
        }

        /// <summary>
        /// 次数と係数から単項式を作成
        /// </summary>
        /// <param name="degree">次数</param>
        /// <param name="coefficient">係数</param>
        public Polynomial(Integer degree, Integer coefficient)
        {
            terms.Add(degree, new Monomial(coefficient, degree));
        }

        /// <summary>
        /// 定数
        /// </summary>
        /// <param name="c"></param>
        public Polynomial(Integer c)
        {
            terms.Add(new Integer(0), new Monomial(c, new Integer(0)));
        }

        public override string ToString()
        {
            if (terms.Count == 0)
            {
                return "0";
            }

            // 降べきの順にソート
            var sortedTerms = terms.OrderByDescending(pair => pair.Key.Value).ToList();

            string str = "";
            for (int i = 0; i < sortedTerms.Count; i++)
            {
                var pair = sortedTerms.ElementAt(i);
                Monomial term = pair.Value;

                string coefficientStr = ""; // 係数の部分
                string xStr = ""; // x^n の部分

                if (term.Coefficient.Value == 1 && term.Degree.Value != 0)
                {
                    coefficientStr = "";
                }
                else
                {
                    if (i != 0)
                    {
                        if (term.Coefficient.Value > 0)
                        {
                            coefficientStr += "+";
                        }
                    }
                    coefficientStr += term.Coefficient.ToString();
                }

                if (term.Degree.Value == 0)
                {
                    xStr = "";
                }
                else if (term.Degree.Value == 1)
                {
                    xStr = "x";
                }
                else
                {
                    xStr = $"x^{term.Degree.Value}";
                }

                str += $"{coefficientStr}{xStr}";
            }
            return str;
        }

        public static Polynomial Add(Polynomial a, Polynomial b)
        {
            Polynomial result = new Polynomial();
            for (int i = 0; i < a.terms.Count; i++)
            {
                var pair = a.terms.ElementAt(i);
                Monomial term = pair.Value;
                result.AddTerm(new Monomial(term.Coefficient, term.Degree));
            }
            for (int i = 0; i < b.terms.Count; i++)
            {
                var pair = b.terms.ElementAt(i);
                Monomial term = pair.Value;
                result.AddTerm(new Monomial(term.Coefficient, term.Degree));
            }
            return result;
        }

        public static Polynomial Multiply(Polynomial a, Integer b)
        {
            // 各項を定数倍
            Polynomial result = new Polynomial();
            foreach (var pair in a.terms)
            {
                Monomial term = pair.Value;
                result.AddTerm(new Monomial(term.Coefficient * b, term.Degree));
            }
            return result;
        }

        public ElementBase Negate()
        {
            return Multiply(this, new Integer(-1));
        }

        public static Polynomial Multiply(Polynomial a, Polynomial b)
        {
            Polynomial result = new Polynomial();
            foreach (var pair in a.terms)
            {
                Monomial term = pair.Value;
                foreach (var pair2 in b.terms)
                {
                    Monomial term2 = pair2.Value;
                    result.AddTerm(new Monomial(term.Coefficient * term2.Coefficient, term.Degree + term2.Degree));
                }
            }
            return result;
        }

        public static Polynomial Pow(Polynomial polynomialElement, Integer exponent)
        {
            Polynomial result = new Polynomial(new Integer(0), new Integer(1));
            for (int i = 0; i < exponent.Value; i++)
            {
                result = Multiply(result, polynomialElement);
            }
            return result;
        }

        void AddTerm(Monomial term)
        {
            if (terms.ContainsKey(term.Degree))
            {
                terms[term.Degree] = new Monomial(terms[term.Degree].Coefficient + term.Coefficient, term.Degree);
            }
            else
            {
                terms.Add(term.Degree, term);
            }
        }


        public ElementBase Differentiate()
        {
            Polynomial result = new Polynomial();
            foreach (var pair in terms)
            {
                Monomial term = pair.Value;
                result.AddTerm(term.Differentiate() as Monomial);
            }
            return result;
        }
    }
}