using System.Collections;

namespace BitMatrix
{
    partial class BitMatrix
    {
        // jawna
        // int[,] => BitMatrix
        public static explicit operator BitMatrix(int[,] matrix)
        {
            if (matrix == null) throw new NullReferenceException();

            if (matrix.GetLength(0) < 0 || matrix.GetLength(1) < 0) throw new ArgumentOutOfRangeException();

            return new BitMatrix(matrix);
        }

        // bool[,] => BitMatrix
        public static explicit operator BitMatrix(bool[,] matrix)
        {
            if (matrix == null) throw new NullReferenceException();

            if (matrix.GetLength(0) < 0 || matrix.GetLength(1) < 0) throw new ArgumentOutOfRangeException();

            return new BitMatrix(matrix);
        }

        // BitMatrix => BitArray
        public static explicit operator BitArray(BitMatrix matrix)
        {
            bool[] result = new bool[matrix.NumberOfRows * matrix.NumberOfColumns];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    result[i * matrix.NumberOfColumns + j] = BitToBool(matrix[i, j]);
                }
            }

            return new BitArray(result);
        }


        // niejawna - automatyczna
        // BitMatrix => int[,]
        public static implicit operator int[,](BitMatrix matrix)
        {
            int[,] result = new int[matrix.NumberOfRows, matrix.NumberOfColumns];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            return result;
        }

        // BitMatrix => bool[,]
        public static implicit operator bool[,](BitMatrix matrix)
        {
            bool[,] result = new bool[matrix.NumberOfRows, matrix.NumberOfColumns];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    result[i, j] = BitToBool(matrix[i, j]);
                }
            }

            return result;
        }
    }
}
