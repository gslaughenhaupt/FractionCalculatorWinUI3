using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculatorWinUI3.Models;

    public class Fraction
    {
        public int whole;
        public int top;
        public int bottom;
        public Fraction() { }
        public Fraction(int _whole, int _top, int _bottom)
        {
            whole = _whole;
            top = _top;
            bottom = _bottom;
        }

        public decimal GetAsDecimal()
        {
            decimal result = this.whole;
            if (this.top > 0)
            {
                result = ((decimal)this.top / (decimal)this.bottom) + (decimal)this.whole;
            }
            return result;
        }
    }
