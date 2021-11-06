using NUnit.Framework;
using NUnit.Framework;

namespace Lists.Test
{
    public class Tests
    {
        #region AddTests
        [TestCase(1, new int[] { 2, 3, 4, 5}, new int[] { 2, 3, 4, 5, 1})]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase()]
        public 

        #endregion
    }
}