namespace BitMatrix
{
    partial class BitMatrix
    {
        public object Clone()
        {
            BitMatrix clone = new BitMatrix(NumberOfRows, NumberOfColumns);

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    clone[i, j] = this[i, j];
                }
            }

            return clone;
        }
    }
}
