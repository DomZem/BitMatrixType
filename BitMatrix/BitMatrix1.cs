namespace BitMatrix
{
    partial class BitMatrix
    {
        public override string ToString()
        {
            string result = "";
                
            for(int i = 0; i < NumberOfRows; i++)
            {
                for(int j = 0; j < NumberOfColumns; j++)
                {
                    result += (data[i] == false ? "0" : "1");
                }
                result += $"{Environment.NewLine}";
            }
            
            return result;
        }
    }
}
