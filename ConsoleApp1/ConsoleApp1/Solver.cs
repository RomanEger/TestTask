using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTask;

public class Solver
{
    public static IEnumerable<double> QuadraticEquation(double a, double b, double c)
    {
        if (a == 0)
            throw new DivideByZeroException("a не может равняться 0");

        var discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant < 0)
            throw new ArgumentOutOfRangeException("Дискриминант меньше 0. Решение отсутствует");

        if (discriminant == 0)
            return new List<double>() { -b / 2 * a };

        var discriminantSqrt = Math.Sqrt(discriminant);

        var x1 = (-b + discriminantSqrt) / (2 * a);

        var x2 = (-b - discriminantSqrt) / (2 * a);

        return new List<double>() { Math.Round(x1, 2), Math.Round(x2, 2) };
    }
}
