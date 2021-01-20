# AmiralBatti
A simple battleship game to play vs AI only. It is text-based .

Amiral Battı Oyun Kullanım Kılavuzu

- Oyun tahtası 8x8 kareden oluşmaktadır.
- Oyuncu bilgisayara karşı oynar.
-Her iki oyuncunun 5'er adet gemisi bulunmaktadır.
 Bu gemiler yatay veya dikey olarak tahtaya yerleştirilmektedir.
 Gemiler lineerdir.
 Gemi tipleri ve uzunlukları : 
    -Uçak gemisi (5 birim)
    - Zırhlı  (4 birim)
    -Kruvazör (3 birim)
    -Korvet   (3 birim)
    -Torpido Botu (2 birim)

-İlk Açılan ekranda oyuncu yeni oyun seçeneğini girerek (1) oyuna başlar .  
- Oyuncu 1 ile 3 arasında bir sayı girerek 3 zorluk seviyesinden birini seçmesi
 ve entera basması gerekmektedir.
  (1(kolay) -2(orta zorluk) -3 (zor) )

-İlk olarak yapay zeka gemilerini seçilen zorluğa göre yerleştirir.
- Zorluk seviyesine göre bekleme süresi değişmektedir.(~1-20 saniye)
-Ardından gelen ekranda oyuncu gemilerini oyun tahtasına dizebilir.

-Oyun tahtası solundaki ve üstündeki koordinatlar (1-8 arası) kullanılarak;
 oyuncu sırasıyla gemilerini yerleştirir.



Gemi yerleştirme örnek :   1  2  3     Komut : 11r (veya 13L)
			 1 K  K  K
Kruvazör(3 birim)        2 *  *  *
                         3 *  *  *


  1 2 3 4(x)
 1  z 
 2  z         Yerleştirilen gemi : Zırhlı (4 birim) Komut : 12d (veya 42u)
 3  z
 4  z
(y)


Verilen örneklerde de görüleceği üzere geminin yerleştirilmek istenen noktası koordinat düzleminden seçilir(y dikey - x yatay)

Ör : 1e 2 noktası seçilsin. Ardından bir yön belirlememiz gerekecek. Sağ için r tuşu, sol 'l' , yukarı 'u' ve aşağı 'd' olmak üzere.
Gemi bu noktadan itibaren boyutu ve seçtiğiniz yöne göre tahtaya yerleştirilecektir.
Büyük küçük harf farketmemektedir ancak komut bitişik yazılmalıdır.( 45u gibi )
Aksi takdirde yerleştirme yapılmayacaktır.
Yine tahta dışına ve gemiler üst üste gelecek şekilde yerleştirme yapılamamaktadır.


- Oyuncular gemilerini yerleştirdikten sonra , sırayla atış yapacaktır.

-Atış için sadece koordinat girilmesi yetmektedir. (11, 24, 67 gibi)

-Oyuncu savaş tablosunu ve atışlarında başarılı olup olmadığını tahtada ve yazılı uyarı olarak görecektir.
-Oyuncunun gemisi hasar alırsa veya rakip oyuncu ıskalarsa, yine oyuncuya bildirilecektir.

-Rakibin tüm gemilerini önce batıran oyunu kazanır.

-İyi Oyunlar!
