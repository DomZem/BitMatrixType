using System.Text;

namespace BitMatrix
{
    partial class BitMatrix
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    
                    sb.Append(BoolToBit(data[i * NumberOfColumns + j]) == 1 ? '1' : '0');
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
