using System;

namespace QuadraticEquationSolver.Models
{
    /// <summary>
    /// Квадратное уравнение y(x) = a * (x)^2 + b * x + c.
    /// </summary>
    /// <remarks>Корни уравнения y(x) = (x - x1) * (x - x2).</remarks>
    internal class QuadraticEquation
    {
        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        /// <summary>
        /// Дискриминант.
        /// </summary>
        public double Discriminant => Math.Pow(B, 2) - 4 * A * C;

        /// <summary>
        /// Количество корней.
        /// </summary>
        public int RootCount => Discriminant switch
        {
            > 0 => 2,
            0 => 1,
            _ => 0
        };

        public double FirstRoot => RootCount == 0
            ? double.NaN 
            : (-B + Math.Sqrt(Discriminant)) / (2 * A);

        public double SecondRoot => RootCount == 0 
            ? double.NaN 
            : (-B - Math.Sqrt(Discriminant)) / (2 * A);
    }
}
