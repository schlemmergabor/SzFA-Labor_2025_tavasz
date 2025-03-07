namespace L03_MemeCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tömb létrehozása néhány mém macskával tesztelés céljából

            MemeCat[] cats = new MemeCat[]
            {
                // 
                new MemeCat(8, "Nyan Cat"),
                new MemeCat(10, "Grumpy Cat"),
                new MemeCat(2, "Smudge Cat")
            };

            // Beépített rendezés az életkor alapján
            Array.Sort(cats);

            // Breakpoint ellenőrzéshez egy üres utasítás
            ;
        }
    }
}
