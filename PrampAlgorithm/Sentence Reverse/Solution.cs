using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Sentence_Reverse
{
    public class Solution
    {
        public char[] ReverseWords(char[] arr)
        {
            int n = arr.Length;
            // 1. reverse the array
            Reverse(arr, 0, n - 1);
            int spaceIndex = -1;
            for (int i = 0; i < n; i++)
            {
                // 2. find the space character
                if (arr[i] == ' ')
                {
                    // 2-1. reverse the word
                    Reverse(arr, spaceIndex + 1, i - 1);
                    spaceIndex = i;
                }
            }
            // 3. reverse the last word
            Reverse(arr, spaceIndex + 1, n - 1);
            return arr;
        }

        private static void Reverse(char[] arr, int start, int end)
        {
            while (start < end)
            {
                var tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
                start++;
                end--;
            }
        }

        public void Run()
        {
            var ans = ReverseWords(new char[] { 'p', 'e', 'r', 'f', 'e', 'c', 't', ' ', 'm', 'a', 'k', 'e', 's', ' ', 'p', 'r', 'a', 'c', 't', 'i', 'c', 'e'});

            Console.WriteLine(new string(ans));
        }
    }
}
