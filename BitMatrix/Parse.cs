namespace BitMatrix
{
    partial class BitMatrix
    {
        public static BitMatrix Parse(string s)
        {
            if (s == null || s.Length == 0) throw new ArgumentNullException();

            string[] rows = s.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length == 0) throw new FormatException();

            int numberOfRows = rows.Length;
            int numberOfColumns = rows[0].Length;

            // Sprawdzanie, czy wszystkie wiersze mają taką samą długość
            for (int i = 1; i < numberOfRows; i++)
            {
                if (rows[i].Length != numberOfColumns) throw new FormatException();
            }

            BitMatrix result = new BitMatrix(numberOfRows, numberOfColumns);

            // Parsowanie wartości bitów i ustawianie ich w macierzy
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    char c = rows[i][j];

                    if (c == '0') result[i, j] = 0;
                    else if (c == '1') result[i, j] = 1;
                    else throw new FormatException();
                }
            }

            return result;
        }

        public static bool TryParse(string s, out BitMatrix result)
        {
            result = null;

            if (s == null) return false;

            try
            {
                result = Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
