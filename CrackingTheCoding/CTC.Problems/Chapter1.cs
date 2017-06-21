using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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


        /// <summary>
        /// Algorithm to check for palindrome permutation. 
        /// If number is greater than one then palindrome is not possible.
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool PalidromePermutation(string s)
        {
            if (s == null) return false;
            
            var lookup = new int[256];
            s = s.ToLower().Replace(" ", "");
            var odds = 0;
            foreach (var t in s)
            {
                lookup[t]++;
                if (lookup[t] % 2 == 0) odds--;
                else odds++;
            }

            return odds <= 1;
        }


        /// <summary>
        /// Algorithm that puts '%20' for every space included. It will iterate over the string from back to front
        /// tracking the character movement. It assumes empty buffer at the end of the string to accomodate modifying the string in place
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="trueLength"></param>
        /// <returns></returns>
        public static string Urlify(string s, int trueLength)
        {
            if (string.IsNullOrEmpty(s)) return s;
            int i = s.Length - 1;
            int curr = i;
            char[] arr = s.ToCharArray();
            for (; i >= 0; i--)
            {
                if (arr[i] != ' ') break;
            }

            for (; i >= 0; i--)
            {
                if (s[i] != ' ') arr[curr--] = arr[i];
                else
                {
                    arr[curr--] = '0';
                    arr[curr--] = '2';
                    arr[curr--] = '%';
                }
            }

            return new string(arr);
        }


        /// <summary>
        /// Checks if two strings have 0 or 1 changes away from each other in 
        /// terms of insert, delete, and replace operations.
        /// 
        /// If string lengths have diff of 2 or more then they must have more than 1 change.
        /// If strings are equal, then the program needs to check for more than one difference.
        /// If strings have a difference of 1, then choose shorter string as first string and compare them 
        /// to test for an insertion. False if more than one difference is found.
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool OneAway(string a, string b)
        {
            if (a == null || b == null) return false;
            if (Math.Abs(a.Length - b.Length) > 1) return false;

            if (a.Length == b.Length)
            {
                var diff = false;
                for (var i = 0; i < a.Length; i++)
                {
                    if (a[i] == b[i]) continue;
                    if (diff) return false;
                    diff = true;
                }
            }
            else
            {
                var s1 = a.Length < b.Length ? a : b;
                var s2 = a.Length < b.Length ? b : a;

                var idx1 = 0;
                var idx2 = 0;
                var diff = false;
                while (idx1 < s1.Length && idx2 < s2.Length)
                {
                    if (s1[idx1] != s2[idx2])
                    {
                        if (diff) return false;
                        diff = true;
                        idx2++;
                    }
                    else
                    {
                        idx1++;
                        idx2++;
                    }
                }
            }
            return true;
        }

        public static string StringCompression(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var currChar = s[0];
            var count = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == currChar) count++;
                else
                {
                    count = Apply(sb, currChar, count);
                    currChar = s[i];
                }
            }
            Apply(sb, currChar, count);
            var result = sb.ToString();
            return result.Length < s.Length ? result: s;
        }

        private static int Apply(StringBuilder sb, char c, int count)
        {
            int retCount = count;
            sb.Append(c);
            if (count > 1)
            {
                sb.Append(count);
                retCount = 1;
            }
            return retCount;
        }
    }
}
