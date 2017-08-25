using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC.Problems.Test
{
    [TestFixture]
    public class Chapter2Test
    {
        /// <summary>
        /// 2.2 remove dup test
        /// </summary>
        [Test]
        public void RemoveDupTest()
        {
            var inputList = new List<int>() {1, 2, 3, 1, 4, 5, 2, 6, 10, 3};
            var input = ListToLinked(inputList);
            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 10 };
            Chapter2.RemoveDup1(input);
            var actual = LinkedToList(input);
            CollectionAssert.AreEqual(expected,actual);

            //run 2nd version
            input = ListToLinked(inputList);
            Chapter2.RemoveDup2(input);
            actual = LinkedToList(input);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindKthToLastTest()
        {
            var inputList = new List<int>() { 1, 2, 3, 1, 4, 5, 2, 6, 10, 3 };
            var input = ListToLinked(inputList);
            Assert.AreEqual(6, Chapter2.FindKthToLast(input, 3).Value);
            Assert.AreEqual(4, Chapter2.FindKthToLast(input, 6).Value);
            Assert.AreEqual(1, Chapter2.FindKthToLast(input, 10).Value);
            Assert.IsNull(Chapter2.FindKthToLast(input, 11));

        }

        [Test]
        public void RemoveMiddleNodeTest()
        {
            var inputList = new List<int>() { 1, 2, 3, 1, 4, 5, 2, 6, 10, 3 };
            var expected = new List<int>() { 1, 2, 3, 1, 5, 2, 6, 10, 3 };
            var input = ListToLinked(inputList);
            var count = 0;
            var middle = input;
            while (count < 4)
            {
                middle = middle.Next;
                count++;
            }

            Chapter2.RemoveMiddleNode(middle);

            CollectionAssert.AreEqual(expected,LinkedToList(input));
        }

        [Test]
        public void PartitionTest()
        {
            var inputList = new List<int>() { 3, 5, 8, 5, 10, 2, 1 };
            var expected = new List<int>() { 3, 2, 1, 5, 10, 5, 8 };
            var input = ListToLinked(inputList);
            
            CollectionAssert.AreEqual(expected, LinkedToList(Chapter2.Partition(input, 5)));
        }


        public List<int> LinkedToList(SinglyNode node)
        {
            var r = new List<int>();
            while (node != null)
            {
                r.Add(node.Value);
                node = node.Next;
            }
            return r;
        }

        public SinglyNode ListToLinked(List<int> l)
        {
            if (l.Count == 0) return null;
            var head = new SinglyNode(l[0]);
            var node = head;
            for (var i = 1; i < l.Count; i++)
            {
                node.Next = new SinglyNode(l[i]);
                node = node.Next;
            }
            return head;
        }

        [Test]
        public void TraverseReverseTest()
        {
            var inputList = new List<int>() {1,2,3,4,5,6,7,8,9};
            var expected = new List<int>() { 9,8,7,6,5,4,3,2,1};
            var input = ListToLinked(inputList);
            var actual = Chapter2.TraverseReverse(input);
            CollectionAssert.AreEqual(expected,LinkedToList(actual));
        }

        [Test]
        public void SumsBackwardsTest()
        {
            var in1 = new List<int>() { 3, 5, 8 };
            var in2 = new List<int>() { 9, 9, 9 };
            var expected = new List<int>() { 2, 5, 8, 1 };
            var input = ListToLinked(in1);
            var input2 = ListToLinked(in2);
            var actual = Chapter2.SumsBackward(input, input2);
            CollectionAssert.AreEqual(expected, LinkedToList(actual));

            in1 = new List<int>() { 3, 5 };
            in2 = new List<int>() { 9, 9, 9 };
            expected = new List<int>() { 2, 5, 0, 1 };
            input = ListToLinked(in1);
            input2 = ListToLinked(in2);
            actual = Chapter2.SumsBackward(input, input2);
            CollectionAssert.AreEqual(expected, LinkedToList(actual));
        }

        [Test]
        public void SumsForwardsTest()
        {
            var in1 = new List<int>() {8, 5, 3};
            var in2 = new List<int>() {9, 9, 9};
            var expected = new List<int>() {1, 8, 5, 2};
            var input = ListToLinked(in1);
            var input2 = ListToLinked(in2);
            var actual = Chapter2.SumsForward(input, input2);
            CollectionAssert.AreEqual(expected, LinkedToList(actual));

            in1 = new List<int>() {5, 3};
            in2 = new List<int>() {9, 9, 9};
            expected = new List<int>() {1, 0, 5, 2};
            input = ListToLinked(in1);
            input2 = ListToLinked(in2);
            actual = Chapter2.SumsForward(input, input2);
            CollectionAssert.AreEqual(expected, LinkedToList(actual));

        }

        [Test]
        public void PalindromeTest()
        {
            var input = ListToLinked(new List<int>() { 1,1,2,2 });
            Assert.AreEqual(true, Chapter2.Palindrome(input));
            input = ListToLinked(new List<int>() { 1});
            Assert.AreEqual(true, Chapter2.Palindrome(input));
            input = ListToLinked(new List<int>() { 1, 2, 3, 4, 5, 4, 3, 2, 1 });
            Assert.AreEqual(true, Chapter2.Palindrome(input));
            Assert.AreEqual(true, Chapter2.Palindrome(null));
            input = ListToLinked(new List<int>() { 1, 1, 2, 1 });
            Assert.AreEqual(false, Chapter2.Palindrome(input));
            input = ListToLinked(new List<int>() { 1, 2, 3, 4, 5, 4, 5, 2, 1 });
            Assert.AreEqual(false, Chapter2.Palindrome(input));

        }

    }
}
