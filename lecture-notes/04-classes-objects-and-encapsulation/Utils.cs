using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public static class Utils
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool isSwapped;

            for (int i = 0; i < n - 1; i++)
            {
                isSwapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSwapped = true;
                    }
                }

                // If no two members were swapped by inner loop, then break
                if (!isSwapped) break;
            }
        }
    }
}
