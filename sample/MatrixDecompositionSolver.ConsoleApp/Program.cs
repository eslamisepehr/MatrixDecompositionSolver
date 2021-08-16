using MatrixDecompositionSolver.Algorithms;
using System;

namespace MatrixDecompositionSolver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new decimal[2, 2]
               {
                { 1, 2 },
                { 3, 4 },
               };
            var matrix = new Matrix(elements);
            Console.WriteLine("Original:\n");
            Console.WriteLine(matrix.ToStringPretty());

            Console.WriteLine();

            var (L, U) = LUAlgorithm.Solve(matrix);

            Console.WriteLine("A = L * U");
            Console.WriteLine();

            Console.WriteLine("L:");
            Console.WriteLine(L.ToStringPretty());

            Console.WriteLine("U:");
            Console.WriteLine(U.ToStringPretty());
        }
    }
}
