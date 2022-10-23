internal class Program
{
    private static void Main(string[] args)
    {
        int[] Array = Console.ReadLine()
            .Split(',',' ')
            .Select(s => int.TryParse(s.Trim(),out int result)?result:0)
            .ToArray();
        int[]swapArray = Swap(Array);
       foreach (var number in swapArray)
        {
            Console.WriteLine(number);
        }
    }
    private static int[] Swap(int[] number)
    {
        int length = number.Length;
        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[length - i-1] = number[i];
        }
        return result;
        
    }
}
