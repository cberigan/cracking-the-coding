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
    }
}
