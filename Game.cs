using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class Game
    {
        public static Player player = new Player();
        public void Start()
        {
            AiChange aichange = null;
            int secim = 1;
            Console.WriteLine("Zorluk Seciniz");
            Console.Write("\n  Kolay(1)\n  Orta(2)\n  Zor(3)\n");
            do
            {
                secim = Convert.ToInt32(Console.ReadLine());
                if (secim <= 0 || secim > 3)
                {
                    Console.WriteLine("Lütfen 1 ile 3 arasında bir sayı giriniz!");
                }
            } while (secim <= 0 || secim > 3);



            switch(secim)
            {
                case 1:
                    // Zorluk : Kolay
                    aichange = new AiChange(new AiEasy()); //Strategy Pattern
                    break;
                case 2:
                    // Zorluk : Orta
                    aichange = new AiChange(new AiMedium());
                    break;
                case 3:
                    // Zorluk: Zor
                    aichange = new AiChange(new AiHard());
                    break;
            }

            aichange.Position();
            
            aichange.PlaceShips(aichange.torpedoboat);
             aichange.PlaceShips(aichange.cruiser);
            aichange.PlaceShips(aichange.corvette);
            aichange.PlaceShips(aichange.battleship);
            aichange.PlaceShips(aichange.aircraftcarrier);
            Console.WriteLine("Düşman gemilerini yerleştirirken lütfen bekleyiniz...");


            player.board.Position();
            Console.Clear();
            Console.WriteLine("Gemilerinizi Yerleştirmeye Başlayın\n");
            player.board.Draw();
            player.ShipPlacement(player.torpedoboat);
            player.ShipPlacement(player.cruiser);
            player.ShipPlacement(player.corvette);
            player.ShipPlacement(player.battleship);
            player.ShipPlacement(player.aircraftcarrier);

            do
            {
                int shotX=0;
                int shotY=0;
                bool cntrl;
                int c = 0;
                do
                {
                    
                    cntrl = true;
                    Console.WriteLine("Atış yapmak için enter'a basın");
                    Console.ReadLine();
                    Console.Clear();
                    player.board.DrawShotTable();
                    Console.WriteLine("Atışı yapın");
                    do
                    {
                        
                        try
                        {
                            shotX = int.Parse((Console.ReadKey().KeyChar).ToString());
                            shotY = int.Parse((Console.ReadKey().KeyChar).ToString());
                            shotX--;
                            shotY--;
                            c = 1;
                        }
                        catch { };
                    } while (c == 0);
                    if (shotX < 0 || shotX > 7 || shotY < 0 || shotY > 7)
                    {
                        Console.WriteLine("Karaya ateş edemezsiniz...");
                        cntrl = false;
                    }
                    else if (!player.board.Shots(shotX, shotY))
                    {
                        Console.WriteLine("Bu noktaya daha önce ateş ettiniz...");
                        cntrl = false;
                    }
                } while (cntrl == false);
                Console.Clear();
                string shotShip = aichange.IsShot(shotX, shotY);
                if (shotShip != null)
                {
                    Console.WriteLine("Hedef Vuruldu!!!");
                    String shipn = aichange.isSinked(shotShip);
                    if (shipn != null)
                    {
                        Console.WriteLine("Düşman " + shipn + " batırıldı!!!");
                        Console.WriteLine("Düşmanın Kalan Gemi Sayısı =   " + aichange.GetShipCount());
                        if (aichange.GetShipCount() == 0)
                            break;
                    }
                    player.board.DrawShots(shotX, shotY, "V");
                }
                else
                {
                    Console.WriteLine("Atış Kaçtı...");
                    player.board.DrawShots(shotX, shotY, "X");

                }
                Console.WriteLine("Sıranızı geçmek için enter'a basın");
                Console.ReadLine();
                Console.Clear();
                string s = aichange.TakeShots();
                int x1 = (int)char.GetNumericValue(s[0]);
                int y1 = (int)char.GetNumericValue(s[1]);

                string plyhit = player.IsShot(x1, y1);
                string hitship;
                if (plyhit != null)
                {
                    aichange.AimShot(x1, y1);
                    aichange.IncreaseHitCount();
                    Console.WriteLine("Geminiz vuruldu!!!");
                    hitship = player.isSinked(plyhit);
                    if (hitship != null)
                    {
                        player.board.DrawTakenShots(x1, y1, "V");
                        aichange.ResetTarget();
                        aichange.IsTargetAvailable(hitship, x1, y1);
                        Console.WriteLine("Düşman " + hitship + " geminizi batırdı!!!");
                        Console.WriteLine("Kalan Gemi Sayınız =   " + player.GetShipCount());
                        if (player.GetShipCount() == 0)
                            break;
                    }
                    else
                    {   
                        aichange.SetPreShot(x1, y1);
                    }
                    player.board.SetShotShipPosition(x1, y1);
                    player.board.Draw();
                }
                else
                {
                    Console.WriteLine("Düşman ıskaladı...");
                    aichange.SetFailCount();
                    player.board.DrawTakenShots(x1, y1, "X");
                }
            } while (player.GetShipCount() != 0 && aichange.GetShipCount() != 0);
            Console.WriteLine("Oyun Bitti");
            if(player.GetShipCount()==0)
                Console.WriteLine("Tüm Gemileriniz Battı. Oyunu Kaybettiniz...");
            else
                Console.WriteLine("Düşmaının Tüm Gemilerini Batırdınız. Tebrikler!!!");
            return;
        }
    }
}
