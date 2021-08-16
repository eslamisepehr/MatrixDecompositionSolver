using System;
using System.Linq;
using System.Text;

namespace MatrixDecompositionSolver
{
    public class Matrix
    {
        private readonly decimal[,] _elements;

        public Matrix(decimal[,] elements)
        {
            _elements = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        public Matrix(decimal[][] elements)
        {
            _elements = To2D(elements);
        }

        public decimal this[int i, int j] => _elements[i, j];

        public int CountOfRows => _elements.GetLength(0);
        public int CountOfColumns => _elements.GetLength(1);


        public decimal[,] GetElements() => _elements;
        public (int Row, int Column) GetSize() => (CountOfRows, CountOfColumns);
        public bool IsSquare => CountOfRows == CountOfColumns;

        public string ToStringPretty()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < CountOfRows; i++)
            {
                for (int j = 0; j < CountOfColumns; j++)
                {
                    sb.Append(_elements[i, j]);
                    sb.Append("\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.GetSize() != right.GetSize())
                throw new Exception("Size of matrix is not correct!");

            var elements = new decimal[left.CountOfRows, left.CountOfColumns];
            for (int i = 0; i < left.CountOfRows; i++)
            {
                for (int j = 0; j < left.CountOfColumns; j++)
                {
                    elements[i, j] = left[i, j] + right[i, j];
                }
            }

            return new Matrix(elements);
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.GetSize() != right.GetSize())
                throw new Exception("Size of matrix is not correct!");

            var elements = new decimal[left.CountOfRows, left.CountOfColumns];
            for (int i = 0; i < left.CountOfRows; i++)
            {
                for (int j = 0; j < left.CountOfColumns; j++)
                {
                    elements[i, j] = left[i, j] - right[i, j];
                }
            }

            return new Matrix(elements);
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.CountOfColumns != right.CountOfRows)
                throw new Exception("Size of matrix is not correct!");

            var elements = new decimal[left.CountOfRows, right.CountOfColumns];

            for (int i = 0; i < left.CountOfRows; i++)
            {
                for (int j = 0; j < right.CountOfColumns; j++)
                {
                    var element = 0m;
                    for (int k = 0; k < left.CountOfColumns; k++)
                    {
                        element += left[i, k] * right[k, j];
                    }
                }
            }

            return new Matrix(elements);
        }

        private T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key;

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Matrix is not rectangular");
            }
        }
    }
}
