using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L09_RendezesKereses;

namespace L09_RendezesKereses_Tests
{
    internal class OrderedItemsHandlerTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsOrderedTest(bool expected)
        {
            // növekvő kezdeti tömb
            PhoneBookItem[] tomb = new PhoneBookItem[] {
                new PhoneBookItem() { Name = "Alfa", Number = "egy" },
                new PhoneBookItem() { Name = "Beta", Number = "ketto" },
                new PhoneBookItem() { Name = "Teta", Number = "harom" }
            };

            // tömb kezelés
            OrderedItemsHandler oih = new OrderedItemsHandler(tomb);

            // true -> növekvő -> true
            Assert.That(oih.IsOrdered(expected), Is.EqualTo(expected));
        }

        [Test]
        public void IsNotOrderedTest()
        {
            // ABC-be nincs rendezve most a tömb
            PhoneBookItem[] tomb = new PhoneBookItem[] {
                new PhoneBookItem() { Name = "Teta", Number = "harom" },
                new PhoneBookItem() { Name = "Alfa", Number = "egy" },
                new PhoneBookItem() { Name = "Beta", Number = "ketto" }
            };

            OrderedItemsHandler oih = new OrderedItemsHandler(tomb);

            Assert.That(oih.IsOrdered(), Is.False);
        }

        [TestCase(SortingMethod.Selection)]
        [TestCase(SortingMethod.Insertion)]
        [TestCase(SortingMethod.Bubble)]
        public void SortTest(SortingMethod sm)
        {
            PhoneBookItem[] tomb = new PhoneBookItem[] {
                new PhoneBookItem() { Name = "Teta", Number = "harom" },
                new PhoneBookItem() { Name = "Alfa", Number = "egy" },
                new PhoneBookItem() { Name = "Beta", Number = "ketto" }
            };
            
            // ide teszem, mert majd rendezve ilyen sorrendben várom
            PhoneBookItem[] orderedArray = new PhoneBookItem[]
            {
                tomb[1], tomb[2],tomb[0]
            };

            OrderedItemsHandler oih = new OrderedItemsHandler(tomb);

            // kezdetben nincs rendezve
            Assert.That(oih.IsOrdered(), Is.False);

            // rendezés
            oih.Sort(sm);
            ;
            // most már rendezve van
            Assert.That(oih.IsOrdered(), Is.True);

            // lehetne még egy olyan, hogy az egyes indexeket is ellenőrizzük
            // azért nem itt van az orderedArray, mert ott is lefut a Sort
            Assert.That(oih.X, Is.EqualTo(orderedArray));
        }
    }
}
