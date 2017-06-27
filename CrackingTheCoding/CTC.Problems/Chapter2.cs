using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC.Problems
{
    public class SinglyNode
    {
        public SinglyNode Next { get; set; }
        public int Value { get; set; }

        public SinglyNode(int v)
        {
            this.Value = v;
        }
    }

    public class Chapter2
    {
        /// <summary>
        /// Hashset version to remove dups from singly linked list.
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="node"></param>
        public static void RemoveDup1(SinglyNode node)
        {
            if (node == null) return;
            var s = new HashSet<int>();
            SinglyNode prev = null;
            while (node != null)
            {
                if (s.Contains(node.Value))
                {
                    prev.Next = node.Next;
                }
                else
                {
                    s.Add(node.Value);
                }
                prev = node;
                node = node.Next;
            }
        }

        /// <summary>
        /// Remove duplicates in linked list without data structure
        /// Time: O(n^2)
        /// Space: O(1)
        /// </summary>
        /// <param name="node"></param>
        public static void RemoveDup2(SinglyNode node)
        {
            if (node == null) return;

            while (node != null)
            {
                var run = node.Next;
                var prev = node;
                while (run != null)
                {
                    if (node.Value == run.Value) prev.Next = run.Next;
                    prev = run;
                    run = run.Next;
                }
                node = node.Next;
            }
        }
    }
}
