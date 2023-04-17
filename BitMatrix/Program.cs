namespace BitMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void Step1()
        {
            // macierz bitów 4x3 wypełniona
            // domyślną wartością
            var m = new BitMatrix(4, 3);
            Console.WriteLine(m.ToString());

            // macierz bitów 3x4 wypełniona 1
            m = new BitMatrix(3, 4, 1);
            Console.WriteLine(m);

        }

        static void Step2()
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

        static void Step3()
        {
            // `Equals` różne wartości komórek
            var m1 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            var m2 = new BitMatrix(2, 3, 0, 0, 0, 1, 1, 1);
            Console.WriteLine(m1.Equals(m2));
            m1 = new BitMatrix(1, 1, 0);
            m2 = new BitMatrix(1, 1, 1);
            Console.WriteLine(m1.Equals(m2));

            // `Equals` te same wartości
            var m3 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            var m4 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            Console.WriteLine(m3.Equals(m4));
            m3 = new BitMatrix(1, 1, 0);
            m4 = new BitMatrix(1, 1, 0);
            Console.WriteLine(m3.Equals(m4));

            // operator `==`, `!=`
            // zgodne wartości
            var m5 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            var m6 = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            Console.WriteLine(m5 != m6);
            Console.WriteLine(m5 == m6);
            Console.WriteLine(m6 != m5);
            Console.WriteLine(m6 == m5);

            m5 = new BitMatrix(1, 1, 1);
            m6 = new BitMatrix(1, 1, 1);
            Console.WriteLine(m5 == m6);
            Console.WriteLine(m5 != m6);
        }

        static void Step4()
        {
            // indekser - poprawne indeksy
            var m = new BitMatrix(3, 4);
            m[0, 0] = 1;
            Console.WriteLine(m[0, 0]);

            m[2, 3] = 1;
            Console.WriteLine(m[2, 3]);

            m[1, 1] = 1;
            Console.WriteLine(m[1, 1]);

            // forach - poprawny porządek
            var n = new BitMatrix(2, 2);
            n[0, 1] = 1;
            n[1, 0] = 1;
            var expected = "0110";
            string s = "";
            foreach (var x in n)
                s += x;
            Console.WriteLine(expected == s);
        }

        static void Step5()
        {
            // weryfikacja implementacji
            // interfejsu `ICloneable`
            var m1 = new BitMatrix(1, 1);
            Console.WriteLine(m1 is ICloneable);

            // sprawdzenie, czy tworzona
            // jest niezależna kopia
            var m2 = new BitMatrix(2, 3);
            var m3 = (BitMatrix)(m2.Clone());
            m2[0, 0] = 1;
            Console.WriteLine(m2[0, 0] != m3[0, 0]);

            // sprawdzenie, czy
            // klon ma takie same wymiary
            var m4 = new BitMatrix(2, 3);
            var m5 = (BitMatrix)(m4.Clone());
            Console.WriteLine(m4.NumberOfRows == m5.NumberOfRows);
            Console.WriteLine(m4.NumberOfColumns == m5.NumberOfColumns);
        }

        static void Step6()
        {
            // Parse, dane poprawne
            string s = @"1111
0000
1100";
            Console.WriteLine(BitMatrix.Parse(s));

            s = @"11
00
11";
            Console.WriteLine(BitMatrix.Parse(s));

            s = @"1";
            Console.WriteLine(BitMatrix.Parse(s));

            s = @"1101";
            Console.WriteLine(BitMatrix.Parse(s));

            // TryParse, poprawne dane
            BitMatrix m = null;
            string s2 = @"1111
0000
1100";
            Console.WriteLine(
              BitMatrix.TryParse(s2, out m)
            );
            s2 = @"1";
            Console.WriteLine(
              BitMatrix.TryParse(s2, out m)
            );
            s2 = @"11
00
11";
            Console.WriteLine(
              BitMatrix.TryParse(s2, out m)
            );
        }
    }
}