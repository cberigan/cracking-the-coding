using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC.Problems.Test
{
    [TestFixture]
    public class Chapter1Test
    {

        #region 1.1 IsUniqueTest
        [Test]
        public void IsUniqueTestErrorChecks()
        {
            Assert.False(Chapter1.IsUnique(null));
            Assert.False(Chapter1.IsUnique(""));
            Assert.True(Chapter1.IsUnique("a"));
            Assert.True(Chapter1.IsUnique("-"));
        }

        [Test]
        public void IsUniqueTestFail()
        {
            Assert.False(Chapter1.IsUnique("qwertyuiopasdfghjkl;xcvbnm,q"));
            Assert.False(Chapter1.IsUnique("qwertyuiopasdfghjkl;xcvbnm,q"));

        }

        [Test]
        public void IsUniqueTestPass()
        {
            Assert.True(Chapter1.IsUnique("qwertyuiopasdfghjkl;xcvbnm,"));
            Assert.True(Chapter1.IsUnique("1qazxcdfr567yhnm,ko90"));
        }

        #endregion

        #region 1.2 Check Permutation
        [Test]
        public void CheckPermTest()
        {
            //check errors
            Assert.False(Chapter1.CheckPermutation("abca", null));
            Assert.False(Chapter1.CheckPermutation(null, "abc"));


            //valid permutations
            Assert.True(Chapter1.CheckPermutation("a", "a"));
            Assert.True(Chapter1.CheckPermutation("asdfghjkl", "lkhjdgfsa"));
            Assert.True(Chapter1.CheckPermutation("10293847561029384756", "09876543211234567890"));

            //invalid permutations
            Assert.False(Chapter1.CheckPermutation("alfkjlfk", "aldfkjdlf"));
            Assert.False(Chapter1.CheckPermutation("abca", "abc"));
            Assert.False(Chapter1.CheckPermutation("aba", "abc"));
        }

        #endregion

        #region 1.3 URLify

        [Test]
        public void UrlifyTest()
        {
            Assert.AreEqual("Mr%20John%20Smith", Chapter1.Urlify("Mr John Smith    ", 13));
        }
        #endregion

        #region 1.5 Palindrome Permutation

        [Test]
        public void PalindromeTest()
        {
            Assert.True(Chapter1.PalidromePermutation("Tact Cao"));
        }
        #endregion

        #region 1.6 One Away

        [Test]
        public void OneAwayTest()
        {
            Assert.True(Chapter1.OneAway("abc", "ab"));
            Assert.True(Chapter1.OneAway("ab", "axb"));
            Assert.True(Chapter1.OneAway("abc", "abc"));
            Assert.True(Chapter1.OneAway("apple", "aple"));

            Assert.False(Chapter1.OneAway("abc", "bcc"));
            Assert.False(Chapter1.OneAway("apple", "apples1"));
            Assert.False(Chapter1.OneAway("bac", "abc"));
            Assert.False(Chapter1.OneAway("sdkfjlksd", "askdljalksdj"));

        }
        #endregion

        #region 1.7 String Compression

        [Test]
        public void StringCompressionTest()
        {
            Assert.AreEqual("a2bc5a3",Chapter1.StringCompression("aabcccccaaa"));
            Assert.AreEqual("aabbccddffgghh", Chapter1.StringCompression("aabbccddffgghh"));
        }
        #endregion


        [Test]
        public void RotateMatrixNull()
        {
            Chapter1.RotateMatrix(null);
            Assert.Pass();
        }

        [Test]
        public void RotateMatrixNxm()
        {
            var input = new int[,] { { 1, 2, 3,4 }, { 4, 5, 6,4 }, { 7, 8, 9,4 } };
            var expected = new int[,] { { 1, 2, 3, 4 }, { 4, 5, 6, 4 }, { 7, 8, 9, 4 } };
            Chapter1.RotateMatrix(input);
            CollectionAssert.AreEqual(expected,input);
        }

        [Test]
        public void RotateMatrix3X3()
        {
            var input = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var expected = new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };
            Chapter1.RotateMatrix(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [Test]
        public void RotateMatrix4X4()
        {
            var input = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            var expected = new int[,] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } };
            Chapter1.RotateMatrix(input);
            CollectionAssert.AreEqual(expected, input);
        }




    }
}
