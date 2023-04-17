using System.Collections;

namespace BitMatrix
{
    public partial class BitMatrix: IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        #region === constructors === 

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException();

            int dataSize = numberOfRows * numberOfColumns;
            data = new BitArray(dataSize, false);

            if (bits != null)
            {
                for (int i = 0; i < bits.Length; i++)
                {
                    if (i < dataSize)
                    {
                        data[i] = BitToBool(bits[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public BitMatrix(int[,] bits)
        {
            if (bits == null)
                throw new NullReferenceException();

            int numberOfRows = bits.GetLength(0);
            int numberOfColumns = bits.GetLength(1);

            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException();

            data = new BitArray(numberOfRows * numberOfColumns, false);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    data[i * numberOfColumns + j] = BitToBool(bits[i, j]);
                }
            }

            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public BitMatrix(bool[,] bits)
        {
            if (bits == null)
                throw new NullReferenceException();

            int numberOfRows = bits.GetLength(0);
            int numberOfColumns = bits.GetLength(1);

            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException();

            data = new BitArray(numberOfRows * numberOfColumns, false);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    data[i * numberOfColumns + j] = bits[i, j];
                }
            }

            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        #endregion

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;
    }
}
