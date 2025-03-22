using L05_Kivetelek;

namespace L05_Kivetelek_Tests
{
    public class NaturalNumberTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Parse()
        {
            Assert.Throws<WrongNumberException>( ()=> NaturalNumber.Parse("-1"));
        }
    }

    
}