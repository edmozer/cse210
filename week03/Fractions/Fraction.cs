using System;

namespace Fractions
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        // Constructor: 1/1
        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        // Constructor: numerator/1
        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        // Constructor: numerator/denominator
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        // Getter and Setter for Numerator
        public int GetNumerator()
        {
            return _numerator;
        }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }

        // Getter and Setter for Denominator
        public int GetDenominator()
        {
            return _denominator;
        }

        public void SetDenominator(int denominator)
        {
            _denominator = denominator;
        }

        // Returns fraction as string
        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Returns decimal value
        public double GetDecimalValue()
        {
            return (double)_numerator / _denominator;
        }
    }
}
