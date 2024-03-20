using System.Linq;

namespace Radix_Sort
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] ints = { 100, 70, 90, 1, 10000, 12 };
            int[] ints2 = RadixSort(ints, ints.Length);
            Console.WriteLine("[{0}]", string.Join(", ", ints2));
        }
        //метод нужен для того чтобы определить макс элемент в массиве, чтобы определить сколько разрядов в нем, это нам в дальнейшем понадобится
        public static int GetMaxVal(int[] arra, int lenght)
        {
            int maxVal = arra[0];
            for(int i = 0; i < lenght; i++)
            {
                if (arra[i] > maxVal)
                {
                    maxVal = arra[i];
                }
            }
            return maxVal;
        }

        public static int[] RadixSort(int[] arra, int lenght)
        {
            int maxVal = GetMaxVal(arra, lenght);
            //берем и выдиляем наши разряды
            for(int exponent = 1; maxVal / exponent > 0; exponent *= 10)
            {
                CountingSort(arra, lenght, exponent);
            }
            return arra;
        }

        public static void CountingSort(int[] arra, int lenght, int exponent)
        {
            //создаем два массива в пером будут хранится элементы отсартированные по каждому разряду 
            //а во втором у нас будут считаться их порядок 
            var outputArr = new int[lenght];
            var occurences = new int[10];
            for (int i = 0; i < 10; i++)
                occurences[i] = 0;
            for (int i = 0; i < lenght; i++)
                occurences[(arra[i] / exponent) % 10]++;
            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];
            for (int i = lenght - 1; i >= 0; i--)
            {
                outputArr[occurences[(arra[i] / exponent) % 10] - 1] = arra[i];
                occurences[(arra[i] / exponent) % 10]--;
            }
            for (int i = 0; i < lenght; i++)
                arra[i] = outputArr[i];
        }
    }
}