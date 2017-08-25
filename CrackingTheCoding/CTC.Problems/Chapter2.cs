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

    public class LinkedListSingly
    {
        public SinglyNode Head { get; private set; }

        public LinkedListSingly(SinglyNode head)
        {
            this.Head = head;
        }

        public void Add(int value)
        {
            var newNode = new SinglyNode(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var node = Head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
        }

        public void Remove(int val)
        {
            if (Head == null) return;

            if (Head.Value == val)
                Head = Head.Next;
            else
            {
                var node = Head;
                while (node.Next != null)
                {
                    if (node.Next.Value == val)
                    {
                        node.Next = node.Next.Next;
                        break;
                    }
                    node = node.Next;
                }
            }
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


        /// <summary>
        /// 
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static SinglyNode FindKthToLast(SinglyNode head, int k)
        {
            if (head == null) return null;
            if (k < 1) return null;
            var space = 0;
            var curr = head;
            var run = head;
            while (space < k)
            {
                if (run == null) return null;
                run = run.Next;
                space++;
            }

            while (run != null)
            {
                run = run.Next;
                curr = curr.Next;
            }

            return curr;
        }

        public static void RemoveMiddleNode(SinglyNode node)
        {
            if (node?.Next == null) return;

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
        }


        /// <summary>
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public static SinglyNode Partition(SinglyNode head, int partition)
        {
            if (head == null) return null;
            var left = head;
            var right = head.Next;
            while (left != null && right != null)
            {
                if (left.Value < partition)
                {
                    left = left.Next;
                    right = left.Next;
                    continue;
                }

                if (right.Value >= partition)
                {
                    right = right.Next;
                    continue;
                }

                var temp = left.Value;
                left.Value = right.Value;
                right.Value = temp;
            }

            return head;
        }


        /// <summary>
        /// Time: O(n)
        /// SPace: O(1)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static SinglyNode SumsBackward(SinglyNode l1, SinglyNode l2)
        {
            var head = new SinglyNode(0);
            var node = head;
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                var sum = 0;
                if (l1 != null)
                {
                    sum = l1.Value;
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    sum += l2.Value;
                    l2 = l2.Next;
                }

                sum += carry;
                carry = 0;

                if (sum > 9)
                {
                    carry = 1;
                    sum -= 10;
                }

                node.Next = new SinglyNode(sum);
                node = node.Next;
            }
            if (carry == 1)
            {
                node.Next = new SinglyNode(1);
            }
            return head.Next; // true head
        }

        /// <summary>
        /// Time: O(n)
        /// SPace O(1)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static SinglyNode SumsForward(SinglyNode l1, SinglyNode l2)
        {
            //traverse and reverse
            l1 = TraverseReverse(l1);
            l2 = TraverseReverse(l2);
            var list = SumsBackward(l1, l2);
            return TraverseReverse(list);

        }

        /// <summary>
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool Palindrome(SinglyNode head)
        {
            if (head == null) return true;
            var stack = new Stack<int>();
            //get count
            var count = CountLinkedList(head);
            var middle = (int) Math.Floor((double)count / 2);
            //travel to middle adding values to stack

            var node = head;
            var index = 0;
            while (index <= middle)
            {
                index++;
                stack.Push(node.Value);
                node = node.Next;
            }
            //pop middle if odd count. doesnt matter
            if (count % 2 == 1) stack.Pop();

            while (node != null && stack.Count > 0)
            {
                //traverse along rght side of list while comparing top of stack
                var compare = stack.Pop();
                if (node.Value != compare) return false;
                node = node.Next;
            }
            return true;

        }

        public static int CountLinkedList(SinglyNode head)
        {
            var count = 0;
            var node = head;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }
        /// <summary>
        /// 
        /// node -> next -> next/next -> next^3
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static SinglyNode TraverseReverse(SinglyNode head)
        {
            var node = head;
            var next = head.Next;

            while (next != null)
            {
                var tempNext = next.Next;
                next.Next = node;
                node = next;
                next = tempNext;
            }
            head.Next = null;
            return node;
        }


        public static SinglyNode Intersection(SinglyNode l1, SinglyNode l2)
        {
            if (l1 == null || l2 == null) return null;

            var lookup = new HashSet<SinglyNode>();

            var node = l1;
            while (node != null)
            {
                lookup.Add(node);
                node = node.Next;
            }

            node = l2;
            while (node != null)
            {
                if (lookup.Contains(node))
                    return node;

            }
            return null;
        }



    }
}
