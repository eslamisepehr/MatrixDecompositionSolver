namespace MatrixDecompositionSolver.Algorithms
{
    public static class LUAlgorithm
    {
        public static (Matrix L, Matrix U) Solve(Matrix matrix)
        {
            var size = matrix.CountOfRows;
            var lower = new decimal[size, size];
            var upper = new decimal[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int k = i; k < size; k++)
                {
                    var sum = 0m;
                    for (int j = 0; j < i; j++)
                        sum += lower[i, j] * upper[j, k];

                    upper[i, k] = matrix[i, k] - sum;
                }

                for (int k = i; k < size; k++)
                {
                    if (i == k)
                        lower[i, i] = 1;
                    else
                    {
                        var sum = 0m;
                        for (int j = 0; j < i; j++)
                            sum += lower[k, j] * upper[j, i];

                        lower[k, i] = (matrix[k, i] - sum) / upper[i, i];
                    }
                }
            }

            return (new Matrix(lower), new Matrix(upper));
        }
    }
}
