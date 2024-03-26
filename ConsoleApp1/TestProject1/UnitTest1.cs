using TestTask;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test_Discriminant_Less_Than_Zero() =>
       Assert.Throws<ArgumentOutOfRangeException>(() => Solver.QuadraticEquation(1, 0, 1));

        [Test]
        public void Test_Discriminant_Greater_Than_Zero() =>
         Assert.AreEqual(new List<double>() { 0.57, -3.07 }, Solver.QuadraticEquation(2, 5, -3.5).ToList());

        [Test]
        public void Test_Discriminant_Is_Zero() =>
         Assert.AreEqual(new List<double>() { -1 }, Solver.QuadraticEquation(1, 2, 1).ToList());

        [Test]
        public void Test_A_Is_Zero() =>
         Assert.Throws<DivideByZeroException>(() => Solver.QuadraticEquation(0, 5, 1));
    }
}