namespace GilbreathConjecture;
class Program
{
    static void Main()
    {
        // 验证吉尔布雷思猜想
        int primeCount = 40; // 生成前20个素数
        var primes = GeneratePrimes(primeCount);

        Console.WriteLine($"前{primeCount}个素数:");
        Console.WriteLine(string.Join(", ", primes));

        // 构建差分三角形
        var triangle = BuildDifferenceTriangle(primes);

        Console.WriteLine("\n差分三角形:");
        foreach (var row in triangle.Skip(1))
        {
            Console.WriteLine(string.Join(", ", row));
        }
         
        // 验证每行首项是否为1
        Console.WriteLine("\n验证结果:");
        var allFirstOnes = true;
        for (int i = 1; i < triangle.Count; i++)
        {
            if (triangle[i][0] != 1)
            {
                allFirstOnes = false;
                Console.WriteLine($"第{i}行首项不是1: {triangle[i][0]}");
            } 
        }

        if (allFirstOnes)
        {
            Console.WriteLine("所有行首项均为1，验证了吉尔布雷思猜想");
        }
        else
        {
            Console.WriteLine("存在行首项不为1，吉尔布雷思猜想不成立");
        }
    }

    // 生成前n个素数
    static List<int> GeneratePrimes(int count)
    {
        List<int> primes = [];
        int num = 2;

        while (primes.Count < count)
        {
            if (IsPrime(num)) primes.Add(num);
            num++;
        }

        return primes;
    }

    // 判断是否为素数
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // 构建差分三角形
    static List<List<int>> BuildDifferenceTriangle(List<int> primes)
    {
        List<List<int>> triangle =
        [
            [.. primes], // 第一行是原始素数
        ];

        // 生成后续行
        for (int i = 0; i < primes.Count - 1; i++)
        {
            var currentRow = triangle[i];
            List<int> nextRow = [];

            // 计算相邻元素差值的绝对值
            for (int j = 0; j < currentRow.Count - 1; j++)
            {
                nextRow.Add(Math.Abs(currentRow[j] - currentRow[j + 1]));
            }

            triangle.Add(nextRow);
        }

        return triangle;
    }
}
