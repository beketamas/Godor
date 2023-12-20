namespace Godor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listaMelyseg = File.ReadAllLines("melyseg.txt").Select(x => Convert.ToInt32(x)).ToList();
            Console.WriteLine($"1 .feladat\nA fájl adatainak száma: {listaMelyseg.Count}");
            Console.WriteLine($"2. feladat\nAdjon meg egy távolságértéket!");
            int szam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(listaMelyseg[szam] != 0 ? $"Ezen a helyen a felszín {listaMelyseg[szam]} méter mélyen van" : "Az adott helyen nincs gödör");
            Console.WriteLine($"3. feladat\nAz érintetlen terület aránya " +
                $"{Math.Round(Convert.ToDouble(listaMelyseg.Count(x => x == 0)) / listaMelyseg.Count * 100,2)}%");
            List<string> listaGodrok = new List<string>();
            string s = "";
            for (int i = 0; i < listaMelyseg.Count; i++)
            {
                if (listaMelyseg[i] != 0)
                    s += listaMelyseg[i];
                if (listaMelyseg[i] == 0)
                {
                    listaGodrok.Add(s);
                    s = "";
                }
            }
            File.WriteAllLines("godrok.txt", listaGodrok.Where(x => x != ""));
            Console.WriteLine($"5. feladat\nA gödrök száma: {listaGodrok.Where(x => x != "").Count()}");

        }
    }
}