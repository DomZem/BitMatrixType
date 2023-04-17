namespace BitMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        void Step1()
        {
            // macierz bitów 4x3 wypełniona
            // domyślną wartością
            var m = new BitMatrix(4, 3);
            Console.WriteLine(m.ToString());

            // macierz bitów 3x4 wypełniona 1
            m = new BitMatrix(3, 4, 1);
            Console.WriteLine(m);

        }
        void Step2()
        {
            // konstruktor BitMatrix(int, int, params int[])
            // macierz 2x2, komplet danych w tablicy
            var m = new BitMatrix(2, 2, new int[] { 1, 0, 0, 1 });
            Console.WriteLine(m);

            m = new BitMatrix(2, 2, 1, 0, 0, 0);
            Console.WriteLine(m);

            // konstruktor BitMatrix(int, int, params int[])
            // macierz 2x2, za dużo danych w tablicy
            var n = new BitMatrix(2, 2, 1, 0, 0, 1, 1, 1, 0);
            Console.WriteLine(n);

            // macierz 3x2, za mało danych w tablicy
            n = new BitMatrix(3, 2, 1, 0, 0, 1, 1);
            Console.WriteLine(n);

            // konstruktor BitMatrix(int[,])
            int[,] arr = new int[,] { { 1, 0, 1 }, { 0, 1, 1 } };
            var f = new BitMatrix(arr);
            Console.WriteLine(arr.GetLength(0) == f.NumberOfRows);
            Console.WriteLine(arr.GetLength(1) == f.NumberOfColumns);
            Console.Write(f.ToString());
        }
    }
}