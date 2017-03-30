using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task1
{
    public sealed class Polynomial : ICloneable
    {
        readonly private int power;
        readonly private double[] coefficients = {};
        readonly private static double eps;

        static Polynomial()
        {
            try
            {
                eps = double.Parse(ConfigurationManager.AppSettings["eps"]);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorException("invalid value of epselon");
            }
        }

        public Polynomial(params double[] coefficients)
        {
            if (coefficients.Length < 2) throw new ArgumentOutOfRangeException("Need more then 1 coefficients");
            for (int i = 0; i > coefficients.Length; i++)
                if (Math.Abs(coefficients[i]) < eps)
                    coefficients[i] = 0;
            this.coefficients = (double[])coefficients.Clone();
            power = coefficients.Length - 1;
        }
        ///<summary>
        /// The method calculates Polynomial
        ///</summary>
        /// <param name="x">Input value</param>
        ///<returns>reults</returns>
        public double GetValue(double x)
        {
            double value = 0;
            for (int i = 0; i < coefficients.Length; i++)
                value += coefficients[i] * Math.Pow(x, power - i);
            return value;
        }
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs) => (lhs.power >= rhs.power) ? Add(lhs, rhs) : Add(lhs, rhs);
        public static Polynomial Add(Polynomial a, Polynomial b)
        {
            if (ReferenceEquals(a, b)) throw new ArgumentNullException("a");
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException("a");
            Polynomial newPolynomial = a.Clone();
            int j = a.coefficients.Length - 1;
            if (a.coefficients.Length != b.coefficients.Length)
                j = newPolynomial.coefficients.Length - (newPolynomial.coefficients.Length - b.coefficients.Length);
            for (int i = b.coefficients.Length - 1; i > -1; i--)
                newPolynomial.coefficients[j--] += b.coefficients[i];
            return newPolynomial;
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) => lhs.Subtraction(rhs);
        public Polynomial Subtraction(Polynomial b)
        {
            for (int i = 0; i < b.coefficients.Length; i++)
                b.coefficients[i] *= -1;
            return (this.power >= b.power) ? Add(this, b) : Add(b, this);
        }

        public static Polynomial operator *(Polynomial lhs, double rhs) => Multiplication(lhs, rhs);
        public static Polynomial Multiplication(Polynomial a, double b)
        {
            Polynomial newPolynomial = a.Clone();
            for (int i = 0; i < newPolynomial.coefficients.Length; i++)
                newPolynomial.coefficients[i] *= b;
            return newPolynomial;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b) => Multiplication(a, b);
        public static Polynomial Multiplication(Polynomial a, Polynomial b)
        {
            Polynomial newPolynomial = new Polynomial(b.coefficients.Length + a.coefficients.Length);
            for (int i = 0; i < b.coefficients.Length; i++)
                for (int j = 0; j < a.coefficients.Length; j++)
                {
                    newPolynomial.coefficients[j + i] += a.coefficients[j] * b.coefficients[i];

                }
            return newPolynomial;
        }

        public static Polynomial operator /(Polynomial lhs, double rhs) => Division(lhs, rhs);
        public static Polynomial Division(Polynomial a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            Polynomial newPolynomial = a.Clone();
            for (int i = 0; i < newPolynomial.coefficients.Length; i++)
                newPolynomial.coefficients[i] /= b;
            return newPolynomial;
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Polynomial a, Polynomial b) => !(a == b);

        #region override methods
        ///<summary>
        /// Returns a string that represents the current object.
        ///</summary>
        ///<returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            string view = string.Empty;
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (Math.Abs(coefficients[i]) < eps) coefficients[i] = 0;
                if (coefficients[i] == 0) continue;
                if (power - i == 0 && coefficients[i] < 0)
                {
                    view += String.Format(" " + coefficients[i]);
                    break;
                }
                else if (power - i == 0)
                {
                    view += String.Format(" + " + coefficients[i]);
                    break;
                }
                if (power - i == 1 && coefficients[i] < 0)
                {
                    view += String.Format(" " + coefficients[i] + "x");
                    continue;
                }
                else if (power - i == 1 && i != 0)
                {
                    view += String.Format(" + " + coefficients[i] + "x");
                    continue;
                }
                else if (power - i == 1)
                {
                    view += String.Format(" " + coefficients[i] + "x");
                    continue;
                }
                if (i == 0 || this.coefficients[i] < 0)
                    view += String.Format(" " + coefficients[i] + "x^{0}", power - i);
                else
                    view += String.Format(" + " + coefficients[i] + "x^{0}", power - i);
            }

            return (view == String.Empty) ? "0" : view;
        }

        ///<summary>
        /// Serves as the default hash function.
        ///</summary>
        ///<returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return power ^ ((int)coefficients[0] + 1);
        }

        ///<summary>
        /// Determines whether the specified object is equal to the current object.
        ///</summary>
        ///<param name="obj">The object to compare with the current object.</param>
        ///<returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.coefficients.Length != other.coefficients.Length)
                return false;
            for (int i = 0; i < this.coefficients.Length; i++)
                if (!this.coefficients[i].Equals(other.coefficients[i])) return false;
            return true;
        }

        #endregion
        public Polynomial Clone() => new Polynomial((double[])this.coefficients.Clone());
        object ICloneable.Clone() => (object)Clone();

        private Polynomial(int power)
        {
            coefficients = new double[power];
            this.power = power - 2;
        }
    }
}
