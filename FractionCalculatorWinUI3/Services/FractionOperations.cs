using FractionCalculatorWinUI3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculatorWinUI3.Services;

    public static class FractionOperations
    {
        public static Fraction GetImproper(Fraction fraction)
        {
            fraction.top = fraction.bottom * fraction.whole + fraction.top;
            fraction.whole = 0;
            return fraction;
        }
        public static Fraction Add(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            left = GetImproper(left);
            right = GetImproper(right); 
            var temp = left.bottom * right.bottom;
            left.top = (temp / left.bottom) * left.top;
            right.top = (temp / right.bottom) * right.top;
            left.bottom = temp;
            right.bottom = temp;
            result.bottom = temp;
            result.top = left.top + right.top;
            return MakeProper(result);
        }
        public static Fraction Subtract(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            left = GetImproper(left);
            right = GetImproper(right);
            var temp = left.bottom * right.bottom;
            left.top = (temp / left.bottom) * left.top;
            right.top = (temp / right.bottom) * right.top;
            left.bottom = temp;
            right.bottom = temp;
            result.bottom = temp;
            result.top = left.top + right.top;
            if (left.top > right.top)
            {
                result.top = left.top - right.top;
            }
            else
            {
                result.top = right.top - left.top;
            }
            return MakeProper(result);
        }
        public static Fraction Multiply(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            left = GetImproper(left);
            right = GetImproper(right);
            result.top = left.top * right.top;
            result.bottom = left.bottom * right.bottom;
            return MakeProper(result);
        }
        public static Fraction Divide(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            left = GetImproper(left);
            right = GetImproper(right);
            // invert divisor and multiply
            var temp = right.bottom;
            right.bottom = right.top;
            right.top = temp;
            result.top = left.top * right.top;
            result.bottom = left.bottom * right.bottom;
            result = MakeProper(result);
            return result;  
        }
        public static Fraction MakeProper(Fraction fraction)
        {
            if (fraction.top >= fraction.bottom)
            {
                fraction.whole = fraction.top / fraction.bottom;
                fraction.top = fraction.top % fraction.bottom;
            }

            for (var i = 9; i > 1; i--)
            {
                if ((fraction.top % i) == 0 && (fraction.bottom % i) == 0)
                {
                    fraction.top = fraction.top / i;
                    fraction.bottom = fraction.bottom / i;
                    i = 9;
                }
            }
            if(fraction.top == 0)fraction.bottom = 0;   
            return fraction;
        }
    }

