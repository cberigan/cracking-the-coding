using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC.Problems
{
    public class Chapter1
    {
        /// <summary>
        /// Algorithm that determines if a string has all unique characters.
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsUnique(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length == 1) return true;

            int[] counts = new int[128];

            for (int i = 0; i < s.Length; i++)
            {
                if (counts[s[i]] > 0) return false;
                else counts[s[i]]++;
            }
            return true;
        }


        /// <summary>
        /// Algorithm to check if string is permutation of another string. 
        /// The function will apply a positive count for a and a negative count for b in the counts array.
        /// The counts array is indexed by ascii value. Every permutation should have a zerod array. 
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool CheckPermutation(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || 
                string.IsNullOrEmpty(b) ||
                a.Length != b.Length)
                return false;

            int[] counts = new int[128];

            for (int i = 0; i < a.Length; i++)
            {
                counts[a[i]]++;
                counts[b[i]]--;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] != 0) return false;
            }
            return true;
        }


    }
}
