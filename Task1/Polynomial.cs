using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        
        public double[] Coefficients { get; private set; }
        public int Power { get; private set; }

        #region constructors;
        private Polynomial(int power)
        {
            Coefficients = new double[power + 1];
            this.Power = power;
        }

        public Polynomial(int power, double coefficient1, double coefficient2)
        {
            if (power < 1) throw new ArgumentException("Invalid format of Polynomial");
            Coefficients = new double[power + 1];
            Coefficients.SetValue(coefficient1, 0);
            Coefficients.SetValue(coefficient2, 1);
            this.Power = power;
        }

        public Polynomial(int power, double coefficient1, double coefficient2, double coefficient3)
        {
            if (power < 2) throw new ArgumentException("Invalid format of Polynomial");
            Coefficients = new double[power + 1];
            Coefficients.SetValue(coefficient1, 0);
            Coefficients.SetValue(coefficient2, 1);
            Coefficients.SetValue(coefficient3, 2);
            this.Power = power;
        }

        public Polynomial(int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4)
        {
            if (power < 3) throw new ArgumentException("Invalid format of Polynomial");
            Coefficients = new double[power + 1];
            Coefficients.SetValue(coefficient1, 0);
            Coefficients.SetValue(coefficient2, 1);
            Coefficients.SetValue(coefficient3, 2);
            Coefficients.SetValue(coefficient4, 3);
            this.Power = power;
        }

        public Polynomial(int power, params double[] coefficients)
        {
            if (coefficients.Length < 2) throw new ArgumentOutOfRangeException("Need more then 1 coefficients");
            if (power < coefficients.Length) throw new ArgumentException("Invalid format of Polynomial");
            this.Coefficients = coefficients;
            Power = power;
        }
        #endregion

        public static Polynomial operator + (Polynomial a, Polynomial b) => (a.Power >= b.Power)? Add(a,b) : Add(b, a);


        private static Polynomial Add(Polynomial a, Polynomial b)
        {
            int j = 0;
            Polynomial newPolynomial = new Polynomial(a.Power);
            for(int i = a.Power; i> b.Power; i--)
                newPolynomial.Coefficients[j] = a.Coefficients[j++];
            for (int i = 0; i< b.Coefficients.Length; i++)
                newPolynomial.Coefficients[j] = a.Coefficients[j++] + b.Coefficients[i];
            return newPolynomial;
            

        }
        public double GetValue(double x)
        {
            double value = 0;
            for (int i = 0; i < Coefficients.Length; i++)
                value += Coefficients[i] * Math.Pow(x, Power - i);
            return value;
        }


        public static Polynomial operator -(Polynomial a, Polynomial b) => a.Subtraction(b);
        private  Polynomial Subtraction (Polynomial b)
        {
            for (int i = 0; i < b.Coefficients.Length; i++)
                b.Coefficients[i] *= -1;           
            return (this.Power >= b.Power) ? Add(this, b) : Add(b, this);
        }

        public static Polynomial operator *(Polynomial a, double b) => Multiplication(a, b);
        private static Polynomial Multiplication(Polynomial a, double b)
        {
            if (b == double.MaxValue) throw new ArgumentOutOfRangeException();
            Polynomial newPolynomial = new Polynomial(a.Power);
            for (int i = 0; i < a.Coefficients.Length; i++)
                newPolynomial.Coefficients[i] = a.Coefficients[i] * b;
            return newPolynomial;
        }       

        public static Polynomial operator *(Polynomial a, Polynomial b) => Multiplication( a, b);
        private static Polynomial Multiplication(Polynomial a, Polynomial b)
        {
            Polynomial newPolynomial = new Polynomial(b.Power + a.Power);
            for (int i = 0; i < b.Coefficients.Length; i++)
                for (int j = 0; j < a.Coefficients.Length; j++)
                    newPolynomial.Coefficients[j+i] += a.Coefficients[j] * b.Coefficients[i];
            return newPolynomial;
        }

        public static Polynomial operator /(Polynomial a, double b) => Division(a, b);
        private static Polynomial Division(Polynomial a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            Polynomial newPolynomial = new Polynomial(a.Power);
            for (int i = 0; i < a.Coefficients.Length; i++)
                newPolynomial.Coefficients[i] = a.Coefficients[i] / b;
            return newPolynomial;
        }

        public static bool operator ==(Polynomial a, Polynomial b)=>a.Equals(b);
        public static bool operator !=(Polynomial a, Polynomial b) => !(a == b); 


        #region override methods
        public override string ToString()
        {
            string view = string.Empty;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] == 0) continue;
                if (Power - i == 0 && Coefficients[i] < 0)
                {
                    view += String.Format(" " + Coefficients[i]);
                    break;
                }
                else if(Power - i == 0 )
                {
                    view += String.Format(" + " + Coefficients[i]);
                    break;
                }
                if(Power - i == 1 && Coefficients[i] < 0)
                {
                    view += String.Format(" " + Coefficients[i] + "x");
                    continue;
                }
                else if (Power - i == 1)
                {
                    view += String.Format(" + " + Coefficients[i] + "x");
                    continue;
                }
                if ( i == 0 || this.Coefficients[i] < 0)
                    view += String.Format(" " + Coefficients[i] + "x^{0}", Power - i);
                else
                    view +=String.Format(" + " + Coefficients[i] +"x^{0}",Power - i);
            }
                
            return (view == String.Empty)?"0":view;
        }

        public override int GetHashCode()
        {
            return Power^(int)Coefficients[0]+1;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial) || this.GetHashCode() != obj.GetHashCode())
                return false;
            Polynomial pol = obj as Polynomial;
            for (int i = 0; i < this.Coefficients.Length; i++)
                if (pol.Coefficients[i] != this.Coefficients[i]) return false;
            return true;
        }

        #endregion


    }

}
