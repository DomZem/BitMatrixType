using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BitMatrix
{
    partial class BitMatrix
    {
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BitMatrix bitMatrix = (BitMatrix)obj;
                if (NumberOfRows == bitMatrix.NumberOfRows && NumberOfColumns == bitMatrix.NumberOfColumns)
                {
                    for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
                    {
                        if (data[i] != bitMatrix.data[i]) return false;
                    }

                    return true;
                }

                return false;
            }
        }

        public bool Equals(BitMatrix other)
        {
            if (other == null) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            if (NumberOfRows == other.NumberOfRows && NumberOfColumns == other.NumberOfColumns)
            {
                for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
                {
                    if (data[i] != other.data[i]) return false;
                }

                return true;
            }

            return false;
        }


        public override int GetHashCode() => (NumberOfRows, NumberOfColumns).GetHashCode();

        public static bool operator ==(BitMatrix left, BitMatrix right) => Equals(left, right);

        public static bool operator !=(BitMatrix left, BitMatrix right) => !(left == right);
    }
}
