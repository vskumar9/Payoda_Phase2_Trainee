using Moq;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        public int i = 50, j = 20;
        public bool result;
        [SetUp] 
        public void CheckNonNegative()
        {
            if (i > 0 && j > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        [Test] 
        public void TestAdd()
        {
            if (result)
            {
                
                MathOpe mth = new MathOpe();
                
                var res = mth.add(20, 20);
                Assert.AreEqual(40, res);
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        [TestCase(100, 25, 4)]
        [TestCase(50, 2, 25)]
        public void TestDiv(int a, int b, int expected)
        {
           
            MathOpe mth = new MathOpe();
            
            var res = mth.Div(a, b);
            
            Assert.AreEqual(expected, res);
        }
        [Test]
        public void TestSub()
        {
            var res = new MathOpe().Sub(10, 30);
            Assert.AreEqual(-20, res);
        }
        [Test]
        public void TestPro()
        {
           
            MathOpe mth = new MathOpe();
            var res = mth.Pro(i, j);
            Assert.AreEqual(1000, res);
        }
        [Test]
        public void MockTest()
        {
            Mock<MathOpe> mck = new Mock<MathOpe>();
            mck.Setup(x => x.CheckValues()).Returns(true);
            Assert.AreEqual(true, mck.Object.CheckValues());
        }
    }
}