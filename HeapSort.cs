namespace ALGOS_LABA2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 12, 11, 13, 5, 6, 7 };

            //HeapSort ob = new HeapSort();
            //ob.SortHeap(arr);
            //ob.PrintArray(arr);

            int[] arr = { 20, 10, 33, 5, 6, 7 };

            HeapSort ob = new HeapSort();
            ob.SortHeap(arr);
            ob.PrintArray(arr);

            //int[] arr = { 14, 111, 13, 9, 2, 12 };

            //HeapSort ob = new HeapSort();
            //ob.SortHeap(arr);
            //ob.PrintArray(arr);

            //int[] arr = { 112, 141, 103, 50, 66, 75 };

            //HeapSort ob = new HeapSort();
            //ob.SortHeap(arr);
            //ob.PrintArray(arr);
        }
    }
    public class HeapSort
    {
        public void SortHeap(int[] array)
        {
            int n = array.Length;
            // Построение кучи (перегруппируем массив)
            BuildMaxHeap(array, n);
            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i > 0; i--)
            {
                // Перемещаем текущий корень в конец
                Swap(array, 0, i);
                // вызываем процедуру heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        private void BuildMaxHeap(int[] array, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }
        }
        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в arr[]. n - размер кучи
        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            // Если левый дочерний элемент больше корня
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }
            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }
            // Если самый большой элемент не корень
            if (largest != i)
            {
                Swap(array, i, largest);
                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(array, n, largest);
            }
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /* Вспомогательная функция для вывода на экран массива размера n */
        public void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
        }
    }
}