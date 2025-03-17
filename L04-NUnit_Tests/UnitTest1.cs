using L04_PrimeTool;
using Moq;

namespace L04_NUnit_Tests
{
    public class Tests
    {
        // SetUp c�mk�vel megjel�lt met�dusok minden teszt el�tt lefutnak
        [SetUp]
        public void Setup()
        {
            // Console.WriteLine("Tesztel�s folyamatban...");
        }

        // Test c�mk�vel megjel�lt met�dus-ok lesznek a Teszt-ek
        // VS-b-en Test men�pont -> Run All Tests
        [Test]
        public void PrimeToolTest1()
        {

            PrimeTool pt1 = new PrimeTool(2);
            if (pt1.IsPrime() == true)
            {
                Assert.Pass();
            }
            Assert.Fail();

        }

        [Test]
        public void PrimeToolTest2()
        {

            PrimeTool pt1 = new PrimeTool(10);

            Assert.That(pt1.IsPrime(), Is.EqualTo(false));
        }

        // TestCase -> param�terezheted a tesztjeidet
        // itt konkr�t �rt�keket �rsz
        [TestCase(true, 5)]
        [TestCase(false, 20)]
        [TestCase(true, 17)]
        [TestCase(false, 15)]

        // met�dusn�l egyeztetni kell a param�terek t�pus�t!
        public void PrimeToolTestWithTestCases(bool exp, int num)
        {

            PrimeTool pt1 = new PrimeTool(num);

            Assert.That(pt1.IsPrime(), Is.EqualTo(exp));
        }


        [TestCase(true)]
        [TestCase(false)]
        public void MockTest(bool ret)
        {
            // mock p�ld�ny k�sz�t�se
            Mock<IPrimeTool> mock = new Mock<IPrimeTool>();

            // met�dus be�ll�t�sa -> melyikre -> milyen v�laszt adjon
            // IsPrime() h�v�sakor true �rt�ket adjon vissza
            mock.Setup(x => x.IsPrime()).Returns(ret);

            // PTM k�sz�t�se -> mock Object-et kell �tadni
            PrimeToolManager ptm = new PrimeToolManager(mock.Object);

            // v�rt sz�veg el��ll�t�sa
            string exp = "It's " + (ret ? "" : "not ") + "a Prime.";

            // teszteled, mintha nem mock lenne...
            Assert.That(ptm.IsPrime2Text(), Is.EqualTo(exp));
        }

        [TestCase(35, new int[] { 4, 3, 2, 1, 10, 15 })]
        [TestCase(31, new int[] { 4, 3, -2, 1, 10, 15 })]
        [TestCase(1, new int[] { -4, -3, 2, 1, -10, 15 })]
        public void TotalTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);

            Assert.That(A.Total(), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 }, 3)]
        [TestCase(false, new int[] { 7, 8, 3 }, 9)]
        [TestCase(true, new int[] { 1, 2, 3 }, 2)]
        public void ContainsTest(bool vartErtek, int[] t�mb, int szam)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.Contains(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 })]
        [TestCase(true, new int[] { 1, 1, 3 })]
        [TestCase(false, new int[] { 1, 2, -3 })]
        public void SortedTest(bool vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.Sorted(), Is.EqualTo(vartErtek));
        }

        [TestCase(8, new int[] { 1, 10, 3 }, 1)]
        [TestCase(8, new int[] { 1, 7, 3 }, -1)]
        [TestCase(-11, new int[] { 3, -10, -3 }, 0)]
        public void FirstGreaterTest(int szam, int[] t�mb, int vartErtek)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.FirstGreater(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 1, 3 })]
        [TestCase(3, new int[] { 10, 2, -30 })]
        public void CountEvensTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.CountEvens(), Is.EqualTo(vartErtek));
        }
        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 10, 1, 3 })]
        [TestCase(0, new int[] { 10, 2, -30 })]
        public void MaxIndexTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.MaxIndex(), Is.EqualTo(vartErtek));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, -3 })]
        [TestCase(new int[] { -1, -10, 0 })]
        public void SortTest(int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            // Rendezz�k
            A.Sort();
            // Megn�zz�k, hogy rendezett-e
            Assert.That(A.Sorted(), Is.EqualTo(true));

        }
    }
}