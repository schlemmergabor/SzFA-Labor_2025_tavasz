namespace MintaZH01_Tests
{
    // �j projekt, Template-n�l -> nUnit -> C#-ot v�laszd ki
    // Testfixture n�lk�l is megy, de vizsg�n mondd el! :)

    // Add -> Project Reference -> L06-MintaZH1-re pipa !!!

    // Tesztel�sre k�l�n-k�l�n tesztoszt�lyokat csin�lok

    // Az oszt�ly tesztel�si c�lokat szolg�l
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}