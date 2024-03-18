namespace SortMerge
{
    internal class MergeSort_
    {
        static void Main(string[] args)
        {
            int[] array = {42, 12,112,10,1,13,129};
            Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

            //int[] array = { 420, 1, 11, 100, 9, 12, 19 };
            //Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

            //int[] array = { 1, 0, 112, 10, 2, 3, 500, 44, 50, 90 };
            //Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

            //int[] array = { 1, 12, 3, 10, 88, 33, 229 };
            //Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

            //int[] array = { 400, 5000, 1012, 6000, 231, 153, 10129 };
            //Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));
        }

        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                tempArray[index++] = array[left] < array[right] ? array[left++] : array[right++];
            }

            while (left <= middleIndex)
            {
                tempArray[index++] = array[left++];
            }

            while (right <= highIndex)
            {
                tempArray[index++] = array[right++];
            }

            Array.Copy(tempArray, 0, array, lowIndex, tempArray.Length);
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
    }
}