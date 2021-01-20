using System;

namespace AmiralBatti
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;
            do
            {

                Game game = new Game();
                Console.WriteLine("\n\n\n\n*****AMİRAL BATTI***** \n\n\n\n\n");
                Console.WriteLine("1.Yeni Oyun");
                Console.WriteLine("2.Çıkış");
                c = Console.ReadKey().KeyChar;
                if (c == '1')
                    game.Start();
            } while (c != '1');
        }
    }
}
