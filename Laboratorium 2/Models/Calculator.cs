using static Laboratorium_2.Controllers.CalculatorController;

namespace Laboratorium_2.Models
{
    using System;

    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public string Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Sub:
                        return "-";
                    case Operators.Mul:
                        return "*";
                    case Operators.Div:
                        return "/";
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.Add:
                    return (double)(X + Y);
                case Operators.Sub:
                    return (double)(X - Y);
                case Operators.Mul:
                    return (double)(X * Y);
                case Operators.Div:
                    if (Y != 0)
                        return (double)(X / Y);
                    else
                        return double.NaN;
                default:
                    return double.NaN;
            }
        }
    }
}

