using System.Collections;

namespace BitMatrix
{
    partial class BitMatrix
    {
        public int this[int i, int j]
        {
            get
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return BoolToBit(data[(i * NumberOfColumns) + j]);
            }

            set
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                data[(i * NumberOfColumns) + j] = BitToBool(value);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int i  = 0; i < NumberOfRows * NumberOfColumns; i++)
            {
                yield return BoolToBit(data[i]);   
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
