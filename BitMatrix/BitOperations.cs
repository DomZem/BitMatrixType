namespace BitMatrix
{
    partial class BitMatrix
    {
        public BitMatrix And(BitMatrix other)
        {
            ValidateOperation(other);

            ValidateOperation(other);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] &= other.data[i];
            }

            return this;

        }

        public BitMatrix Or(BitMatrix other)
        {
            ValidateOperation(other);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] |= other.data[i];
            }

            return this;
        }

        public BitMatrix Xor(BitMatrix other)
        {
            ValidateOperation(other);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= other.data[i];
            }

            return this;
        }

        public BitMatrix Not()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = !data[i];
            }

            return this;
        }

        public static BitMatrix operator &(BitMatrix left, BitMatrix right)
        {
            if(left == null || right  == null) throw new ArgumentNullException();

            if (left.NumberOfRows != right.NumberOfRows && left.NumberOfColumns != right.NumberOfColumns) throw new ArgumentException();

            BitMatrix clone = (BitMatrix)left.Clone();

            return clone.And(right);
        }

        public static BitMatrix operator |(BitMatrix left, BitMatrix right)
        {
            if(left == null || right  == null) throw new ArgumentNullException();
            
            if (left.NumberOfRows != right.NumberOfRows && left.NumberOfColumns != right.NumberOfColumns) throw new ArgumentException();

            BitMatrix clone = (BitMatrix)left.Clone();

            return clone.Or(right);
        }

        public static BitMatrix operator ^(BitMatrix left, BitMatrix right)
        {
            if(left == null || right  == null) throw new ArgumentNullException();

            if (left.NumberOfRows != right.NumberOfRows && left.NumberOfColumns != right.NumberOfColumns) throw new ArgumentException();

            BitMatrix clone = (BitMatrix)left.Clone();

            return clone.Xor(right); 
        }

        public static BitMatrix operator !(BitMatrix m)
        {
            if(m == null) throw new ArgumentNullException();    

            BitMatrix clone = (BitMatrix)m.Clone();

            return clone.Not();
        }

        private void ValidateOperation(BitMatrix other)
        {
            if (other == null) throw new ArgumentNullException();

            if (this.NumberOfRows != other.NumberOfRows && this.NumberOfColumns != other.NumberOfColumns) throw new ArgumentException();
        }
    }
}
