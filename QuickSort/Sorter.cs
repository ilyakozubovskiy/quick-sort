using System;

#pragma warning disable SA1611

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 2)
            {
                return;
            }

            int[] stack = new int[array.Length];
            int top = -1;
            stack[++top] = 0;
            stack[++top] = array.Length - 1;

            while (top >= 0)
            {
                int right = stack[top--];
                int left = stack[top--];
                int i = left, j = right;

                while (i <= j)
                {
                    while (array[i] < array[(left + right) / 2])
                    {
                        i++;
                    }

                    while (array[j] > array[(left + right) / 2])
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;

                        i++;
                        j--;
                    }
                }

                if (i < right)
                {
                    stack[++top] = i;
                    stack[++top] = right;
                }

                if (left < j)
                {
                    stack[++top] = left;
                    stack[++top] = j;
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveQuickSort(array, 0, array.Length - 1);
        }

        private static void RecursiveQuickSort(int[] array, int left, int right)
        {
            int i = left, j = right;

            while (i <= j)
            {
                while (array[i] < array[(left + right) / 2])
                {
                    i++;
                }

                while (array[j] > array[(left + right) / 2])
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                RecursiveQuickSort(array, left, j);
            }

            if (i < right)
            {
                RecursiveQuickSort(array, i, right);
            }
        }
    }
}
