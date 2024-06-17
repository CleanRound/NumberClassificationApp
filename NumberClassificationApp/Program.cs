class Program
{
    static void Main()
    {
        List<int> numbers = GenerateRandomNumbers(100, 1, 1000);
        List<int> primeNumbers = numbers.Where(IsPrime).ToList();
        List<int> fibonacciNumbers = numbers.Where(IsFibonacci).ToList();

        SaveToFile(primeNumbers, "prime_numbers.txt");
        SaveToFile(fibonacciNumbers, "fibonacci_numbers.txt");

        DisplayStatistics(numbers, primeNumbers, fibonacciNumbers);
    }

    static List<int> GenerateRandomNumbers(int count, int min, int max)
    {
        Random random = new Random();
        List<int> numbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            numbers.Add(random.Next(min, max));
        }
        return numbers;
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsFibonacci(int number)
    {
        int a = 0;
        int b = 1;
        while (a < number)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a == number;
    }

    static void SaveToFile(List<int> numbers, string fileName)
    {
        File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
    }

    static void DisplayStatistics(List<int> allNumbers, List<int> primeNumbers, List<int> fibonacciNumbers)
    {
        Console.WriteLine($"Total numbers generated: {allNumbers.Count}");
        Console.WriteLine($"Prime numbers count: {primeNumbers.Count}");
        Console.WriteLine($"Fibonacci numbers count: {fibonacciNumbers.Count}");
        Console.WriteLine($"Prime numbers: {string.Join(", ", primeNumbers)}");
        Console.WriteLine($"Fibonacci numbers: {string.Join(", ", fibonacciNumbers)}");
    }
}
