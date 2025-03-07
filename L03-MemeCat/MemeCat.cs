using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_MemeCat
{
    internal class MemeCat : IComparable
    {
        // privát adattag, mező, belső változó
        int age;
        string name;

        // Konstruktor, amely inicializálja az életkort és a nevet
        public MemeCat(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        // Az Array.Sort() metódus ezt használja az objektumok összehasonlítására
        // A visszatérési érték:
        // -1: ha az aktuális objektum (this) kisebb, mint az összehasonlított objektum
        //  0: ha egyenlők
        // +1: ha az aktuális objektum nagyobb, mint az összehasonlított objektum
        public int CompareTo(object? obj)
        {
            // Az obj objektumot MemeCat típussá alakítjuk
            MemeCat temp = obj as MemeCat;

            // Ha nem sikerül a MemeCat-é alakítás, akkor ...
            // (Itt, célszerű lenne kivételt dobni
            // Később a félév során erről részletesebben lesz szó)
            if (temp == null) return 0;

            // Életkor (age) mezők szerinti összehasonlítás

            // ha a this után jön a temp (obj)
            if (this.age < temp.age) return -1;

            // ha a temp (obj) után jön a this
            if (this.age > temp.age) return 1;
            
            // ha megegyezik a sorrendjük
            return 0;

        }
    }
}
