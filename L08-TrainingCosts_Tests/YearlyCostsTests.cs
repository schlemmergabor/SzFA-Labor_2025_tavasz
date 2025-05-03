using L08_TrainingCosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_TrainingCosts_Tests
{
    [TestFixture]
    internal class YearlyCostsTests
    {
        [Test]
        public void LoadFromNonExistingDirectory()
        {
            Assert.Throws<DirectoryNotFoundException>(() => YearlyCosts.LoadFrom("non_existing_directory"));
        }

        [Test]
        public void LoadFromSuccessful()
        {
            Assert.DoesNotThrow(() => YearlyCosts.LoadFrom(@"..\..\..\csv_files"));

            YearlyCosts yearlyCosts = YearlyCosts.LoadFrom(@"..\..\..\csv_files");
            Assert.That(yearlyCosts.Costs.Length, Is.EqualTo(12));
            for (int i = 0; i < 2; ++i)
            {
                Assert.That(yearlyCosts.Costs, Is.Not.Null);
            }
        }
        [Test]
        public void MonthlyMaxCostTest()
        {
            YearlyCosts yc = YearlyCosts.LoadFrom(@"..\..\..\csv_files");

            Assert.That(yc.MonthlyMaxCost(), Is.EqualTo(0));
        }
    }

}
