using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_RendezesKereses
{
    // Rendezési algoritmusokhoz enum
    public enum SortingMethod
    {
        Selection, Bubble, Insertion
    }

    // Rendezett elem kezelésére osztály
    public class OrderedItemsHandler
    {
        // mezők, adattagok
        // azért lett x, mert a jegyzetben is x a tömb neve!
        IComparable[] x;

        // Metódus referencia, delegált
        // ezt fogjuk használni a növekvő, csökkenő rendezettséghez
        Func<IComparable, IComparable, bool> Method;

        // ctor
        public OrderedItemsHandler(IComparable[] x)
        {
            this.x = x;
        }

        // Property -> teszteléshez készítettem
        // public get (teszthez), private set
        public IComparable[] X { get => x; private set => x = value; }

        // Metódusok, feladatok megoldása

        // private setMethod -> beállítjuk a met. ref. (delegált)at.
        // ha true, akkor növekvő, ha false, akkor csökkenő rendezettség lesz
        // minden további metódus meghívása előtt ezt fogjuk beállítani
        private void SetMethod(bool isAscending = true)
        {
            if (isAscending)
                Method = (a, b) => a.CompareTo(b) <= 0; // növekvő
            else
                Method = (a, b) => a.CompareTo(b) >= 0; // csökkenő
        }

        // 1. feladat - rendezett-E a tömb?
        // jegyzet - növekvő rendezettség vizsgálat 28.oldal
        // Early Exit-el egyszerűbb lenne? :)
        public bool IsOrdered(bool isAscending = true)
        {
            // beállítjuk a delegáltat
            SetMethod(isAscending);

            int n = x.Length - 1; // indexelés miatt -1

            int i = 1 - 1; // indexelés miatt -1

            while ((i <= n - 1) && (Method(x[i], x[i + 1])))
                i++;

            bool rendezett = i > n - 1;
            return rendezett;
        }

        // 2. feladat -> Rendezés
        public void Sort(SortingMethod sortingMethod,
            bool isAscending = true)
        {
            // beállítjuk a delegáltat
            SetMethod(isAscending);

            // eldöntjük, hogy melyik algoritmussal
            switch (sortingMethod)
            {
                case SortingMethod.Selection:
                    SelectionSort();
                    break;
                case SortingMethod.Bubble:
                    BubbleSort();
                    break;
                case SortingMethod.Insertion:
                    InsertionSort();
                    break;
                default:
                    break;
            }
            // ha nem volt SetMethod hívás, és fordított sorrend kellene
            // akkor itt lenne egy Reverse() hívás még
        }

        // tömb megfordítása
        private void Reverse()
        {
            // helyben cseréljük, segédtömb nélkül
            // for (int i = 0; i < x.Length / 2; i++)
            // {
            //    (x[i], x[x.Length - 1 - i]) = (x[x.Length - 1 - i], x[i]);
            // }

            // segédtömb segítségével cseréljük
            IComparable[] result = new IComparable[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                result[i] = x[x.Length - 1 - i];
            }
            x = result;
        }
        private void SelectionSort()
        {
            int n = this.x.Length - 1; // indexelés miatt -1

            for (int i = 1 - 1; i <= n - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j <= n; j++)
                {
                    if (this.Method(x[j], this.x[min]))
                        min = j;
                }
                (this.x[i], this.x[min]) = (this.x[min], this.x[i]); // csere
            }
        }

        // javított beillesztéses rendezés
        // lásd jegyzet 106. oldal
        private void BubbleSort()
        {
            int i = this.x.Length - 1;
            while (i >= 2)
            {
                int idx = 0;
                for (int j = 1 - 1; j <= i - 1; j++)
                {
                    if (this.Method(this.x[j + 1], this.x[j]))
                    {
                        (this.x[j], this.x[j + 1]) = (this.x[j + 1], this.x[j]);
                        idx = j;
                    }
                }
                i = idx;
            }
        }
        private void InsertionSort()
        {
            for (int i = 1; i < x.Length; i++)
            {
                int j = i - 1;
                IComparable temp = x[i];

                while ((j >= 0) && this.Method(temp, x[j]))
                {
                    x[j + 1] = x[j];
                    j--;
                }
                x[j + 1] = temp;
            }
        }
        // Bináris keresés - iteratív (ciklussal) módon
        public bool BinarySearch(IComparable value)
        {
            return true;
        }
    }
}