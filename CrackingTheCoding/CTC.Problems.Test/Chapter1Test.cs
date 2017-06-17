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

    }
}
