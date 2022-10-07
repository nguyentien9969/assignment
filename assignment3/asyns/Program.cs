namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPrimeNumber(0, 100);
            GetPrimeNumber(100, 200);

            Console.Read();
        }

        static async Task GetPrimeNumber(int min, int max)
        {
            await Task.Run(() =>
            {
                for (int i = min; i < max; i++)
                {
                    if (CheckPrime(i))
                    {
                        Console.WriteLine(" " + i);
                    }
                }
            });
        }

        private static bool CheckPrime(int number)
        {
            int i;

            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            if (i == number)
            {
                return true;
            }
            return false;
        }
    }
}