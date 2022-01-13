using System;
using System.Runtime.InteropServices;
class Program
{
    public static void Beep(int frequency, int duration) { }
    static void Main(string[] args)
    {
        //DECLARE VARIABLE
        int posisiHorizontal = 51;
        int posisiVertical = 22;
        int posisiBlinkyHorizontal = 48;
        int posisiBlinkyVertical = 10;
        int posisiPinkyHorizontal = 50;
        int posisiPinkyVertical = 13;
        int posisiInkyHorizontal = 52;
        int posisiInkyVertical = 13;
        int statusBlinky = 0;
        int statusInky = 0;
        int statusPinky = 0;
        int tujuanBlinky = 0;
        int tujuanPinky = 0;
        int tujuanInky = 0;
        int score = 0;
        int lifesPacMan = 3;
        //

        //INTRO PAGE
        ///SetWindowSize untuk merubah size window ketika di run sesuai dengan map
        ///Title untuk merubah nama judul program ketika di run
        ///SetCursorPosition untuk mengganti posisi cursor (by default (0,0))
        ///ForegroundColor untuk mengganti warna character
        ///ReadKey untuk membaca key yang dipencet
        Console.SetWindowSize(94, 34); //merubah ukuran window sesuai map (hapus ini jika dijalankan dengan mac)
        Console.Title = "PacMan";
        Console.SetCursorPosition(41, 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("PAC-MAN");
        Console.SetCursorPosition(41, 5);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Made By : ");
        Console.SetCursorPosition(38, 6);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Angeline Ivana");
        Console.SetCursorPosition(35, 7);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Fahrizal Dwi Rinaldi");
        Console.SetCursorPosition(38, 8);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Jemmie Renard");
        Console.SetCursorPosition(38, 9);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Patricia Lowis");
        Console.SetCursorPosition(35, 10);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Steven Ongkowidjojo");
        Console.SetCursorPosition(32, 15);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Press ENTER to start....");
        Console.ReadKey();

        Console.Beep(400, 200);
        Console.Beep(500, 300);
        Console.Beep(600, 300);
        Console.Beep(700, 300);
        Console.Beep(800, 300);
    //

    //CHOOSE STAGE LEVEL PAGE
    stagePage:
        Console.Clear();
        Console.SetCursorPosition(39, 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Choose Level : ");
        Console.SetCursorPosition(40, 5);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1. Level 1");
        Console.SetCursorPosition(40, 7);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("2. Level 2");
        Console.SetCursorPosition(40, 9);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("3. Level 3");
        Console.SetCursorPosition(42, 12);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("4. Exit\n\n");
        Console.BackgroundColor = ConsoleColor.Black; //mengembalikan warna background jadi semula
        ConsoleKey pilihLevel = Console.ReadKey(true).Key;
        //

        if (pilihLevel == ConsoleKey.D1 || pilihLevel == ConsoleKey.NumPad1 || pilihLevel == ConsoleKey.D2 || pilihLevel == ConsoleKey.NumPad2 || pilihLevel == ConsoleKey.D3 || pilihLevel == ConsoleKey.NumPad3)
        {
            Console.Beep(400, 500);
            // Declare ulang untuk mereset game
            ///pacman
            posisiHorizontal = 51;
            posisiVertical = 22;
            Console.SetCursorPosition(posisiHorizontal, posisiVertical);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("C");
            ///blinky
            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
            Console.Write(" ");
            posisiBlinkyHorizontal = 48;
            posisiBlinkyVertical = 10;
            tujuanBlinky = 0;
            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
            ///pinky
            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
            Console.Write(" ");
            posisiPinkyHorizontal = 50;
            posisiPinkyVertical = 13;
            tujuanPinky = 0;
            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("@");
            ///inky
            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
            Console.Write(" ");
            posisiInkyHorizontal = 52;
            posisiInkyVertical = 13;
            tujuanInky = 0;
            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@");
            ///status
            statusBlinky = 0;
            statusInky = 0;
            statusPinky = 0;
            lifesPacMan = 3;
            score = 0;
            //
        }

        //GAME
        if (pilihLevel == ConsoleKey.D1 || pilihLevel == ConsoleKey.NumPad1)
        {
            //MENCETAK MAP
            ///Clear untuk menghapus INTRO PAGE sebelumnya
            ///Map dibuat menggunakan MULTIDIMENSIONAL ARRAY yang dibuat pada class lain agar terlihat rapi
            ///Array untuk map diisi dengan value 1-8
            ///Untuk mencetak map, menggunakan for dalam for (for pertama untuk mencetak secara vertical, for kedua untuk mencetak secara horizontal)
            Console.Clear();
            int[,] entityPosition = new int[94, 31]; //koordinat entity(keseluruhan) = (x,y)
            Map pacManEntity = new Map();
            entityPosition = pacManEntity.mapEntity();
            for (int verticalEntity = 0; verticalEntity < 31; verticalEntity++)
            {
                for (int horizontalEntity = 0; horizontalEntity < 94; horizontalEntity++)
                {
                    if (entityPosition[horizontalEntity, verticalEntity] == 0) //space
                        Console.Write(" ");
                    if (entityPosition[horizontalEntity, verticalEntity] == 1) //wall
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 2) //food
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 3) //pacman
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 4) //blinky
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 5) //pinky
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 6) //inky
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 7) //power up
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("o");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 8) //ghost's door
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }
            Console.SetCursorPosition(0, 31);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Lifes : {lifesPacMan}");
            Console.SetCursorPosition(0, 32);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score : {score}");
            Console.SetCursorPosition(0, 33);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Level : 1");
            ConsoleKey bacaKey = Console.ReadKey(true).Key; //mengecek key yang dipencet
                                                            //

            //GAME
            ///Game akan dijalankan selama score < 17900 / semua makanan habis
            ///Jika PACMAN makan GHOST / POWER UP, score tidak bertambah
            ///Score akan bertambah 50 / food
            ///Variabel bacaKeySebelumnya digunakan untuk melakukan perulangan tanpa harus menekan key berkali-kali
            ///Variabel Old digunakan untuk menghapus/mengganti entity dari map setelah menggerakkan PACMAN atau GHOST
            while (score < 17900) //perulangan game
            {
                int posisiHorizontalOld = posisiHorizontal;
                int posisiVerticalOld = posisiVertical;
                ConsoleKey bacaKeySebelumnya = bacaKey;
                int posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                int posisiBlinkyVerticalOld = posisiBlinkyVertical;
                int posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                int posisiPinkyVerticalOld = posisiPinkyVertical;
                int posisiInkyHorizontalOld = posisiInkyHorizontal;
                int posisiInkyVerticalOld = posisiInkyVertical;
                if (Console.KeyAvailable) //baca key yang dipencet
                    bacaKey = Console.ReadKey(true).Key;
                switch (bacaKey) //cek ada wall atau tidak
                {
                    case ConsoleKey.RightArrow:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.D:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.A:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.UpArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.W:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.DownArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.S:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                }
                //menggerakkan pacman
                if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                {
                    if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal += 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                {
                    if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal -= 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                {
                    if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical--;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                {
                    if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical++;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                //scatter Blinky
                if (statusBlinky <= 41) //BLINKY jalan sebanyak 41 steps
                {
                    if (statusBlinky <= 40) //BLINKY jalan sebanyak 40 steps
                    {
                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1) //Jika diatas BLINKY ada wall
                        {
                            if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical != 4) //Jika dikanan BLINKY tidak ada wall dan posisi Blinky secara vertical tidak di 4, jalan ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("-");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1)//Jika kanan BLINKY ada wall, jalan ke bawah
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical == 4) //Jika kiri BLINKY tidak ada wall dan posisi BLINKY secara vertical di 4, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && posisiBlinkyHorizontal != 90) //Jika atas BLINKY bukan wall dan posisi BLINKY secara horizontal tidak di 90
                        {
                            posisiBlinkyVertical--;
                            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && posisiBlinkyHorizontal == 90) //Jika bawah BLINKY bukan wall dan posisi BLINKY secara horizontal di 90
                        {
                            if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1) //Jika kiri BLINKY bukan wall, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else //Jika kiri blinky adalah wall, jalan ke bawah
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kanan atas tidak mencetak Blinky
                    {
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusBlinky++;
                }
                //scatter Pinky
                if (statusPinky <= 45) //PINKY jalan sebanyak 45 steps
                {
                    if (statusPinky <= 44) //PINKY jalan sebanyak 44 steps
                    {
                        if (statusPinky >= 0 && statusPinky <= 2) //supaya keluar dari ghost house (jalan ke atas)
                        {
                            posisiPinkyVertical--;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (statusPinky == 3) //setelah keluar dari ghost house, jalan ke kiri
                        {
                            posisiPinkyHorizontal -= 2;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else
                        {
                            if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1) //Jika diatas PINKY ada wall
                            {
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && posisiPinkyVertical != 4) //Jika dikiri PINKY bukan wall dan posisi PINKY secara vertical tidak di 4, jalan ke kiri
                                {
                                    posisiPinkyHorizontal -= 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1)//Jika kiri PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && posisiPinkyVertical == 4) //Jika kanan PINKY bukan wall dan posisi PINKY secara vertical di 4, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("o");
                                    }
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal != 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal bukan di 3, jalan ke bawah
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal == 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal di 3
                            {
                                if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1) //Jika kanan PINKY bukan wall, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else //Jika kanan PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kiri atas tidak mencetak PINKY
                    {
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusPinky++;
                }
                if (score >= 1500)
                {
                    //scatter inky
                    if (statusInky <= 65) //INKY jalan sebanyak 65 steps
                    {
                        if (statusInky <= 64) //INKY jalan sebanyak 64 steps
                        {
                            if (statusInky >= 0 && statusInky <= 2) //supaya INKY keluar dari ghost house
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("-");
                                }
                            }
                            else if (statusInky == 3) //setelah INKY keluar dari ghost house
                            {
                                posisiInkyHorizontal += 2;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else
                            {
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1) //Jika bawah INKY ada wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && posisiInkyVertical != 29) //Jika kanan INKY bukan wall dan posisi INKY secara vertical bukan di 29, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.Write(" ");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("o");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && posisiInkyVertical == 29 && posisiInkyHorizontal > 63) //Jika kiri INKY bukan wall dan posisi INKY secara vertical di 29 dan horizontal > 63, jalan ke kiri
                                    {
                                        posisiInkyHorizontal -= 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78)) //Jika atas INKY bukan wall dan posisi INKY secara horizontal di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                                else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1) //Jika bawah INKY bukan wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && (posisiInkyHorizontal == 63 || posisiInkyVertical == 23 || posisiInkyVertical == 26)) //bawah gaada wall, kanan gaada wall, x di 63 atau y di 23/25, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal != 63 && posisiInkyHorizontal != 78) //x bukan di 53 dan 78, jalan ke bawah
                                    {
                                        posisiInkyVertical++;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78) //x di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                            }
                        }
                        else //Supaya di pojok kanan bawah tidak mencetak INKY
                        {
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        statusInky++;
                    }
                }
                //chase Blinky
                if (statusBlinky > 41) //Keluar dari Scatter
                {
                    if (tujuanBlinky == 0) //Prioritas arah gerak = kiri -> kanan -> atas -> bawah
                    {
                        if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical)) //menentukan arah jalan awal blinky
                        {
                            if (posisiHorizontal <= posisiBlinkyHorizontal) //Jika PACMAN berada di kiri BLINKY
                                tujuanBlinky = 1; //blinky jalan ke kiri
                            else
                                tujuanBlinky = 2; //blinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiBlinkyVertical) //Jika PACMAN berada di atas BLINKY
                                tujuanBlinky = 3; //blinky jalan ke atas
                            else
                                tujuanBlinky = 4; //blinky jalan ke bawah
                        }
                    }
                    if (tujuanBlinky == 1) //menentukan rute tercepat dan mengecek wall/ghost/door
                    {
                        //Jika BLINKY berada di kiri PACMAN atau kiri BLINKY ada halangan
                        if (posisiBlinkyHorizontal <= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kiri dan ada halangan
                            if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                            }
                        }
                    }
                    else if (tujuanBlinky == 2)
                    {
                        //Jika PACMAN berada di kiri BLINKY atau kanan BLINKY ada halangan
                        if (posisiHorizontal <= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kanan dan ada halangan
                            if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                            }
                        }
                    }
                    else if (tujuanBlinky == 3)
                    {
                        //Jika BLINKY berada di atas PACMAN atau bawah BLINKY ada halangan
                        if (posisiBlinkyVertical <= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY tidak ada halangan, kanan ke kanan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke atas dan ada halangan
                            if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                            }
                        }
                    }
                    else if (tujuanBlinky == 4)
                    {
                        //Jika PACMAN berada di atas BLINKY atau bawah BLINKY ada halangan
                        if (posisiVertical <= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY ada halangan
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY ada halangan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke bawah dan ada halangan
                            if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                            }
                        }
                    }
                    if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                    {
                        posisiBlinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                    {
                        posisiBlinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                    {
                        posisiBlinkyVertical--;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                    {
                        posisiBlinkyVertical++;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                //chase Pinky
                if (statusPinky > 45)
                {
                    if (tujuanPinky == 0 && score >= 100) //score >= 100 supaya PINKY jalan setelah PACMAN makan 2 food
                    {
                        if (Math.Abs((posisiHorizontal + 12) - posisiPinkyHorizontal) <= Math.Abs((posisiVertical + 4) - posisiPinkyVertical))//menentukan arah jalan awal Pinky
                        {
                            if (posisiHorizontal <= posisiPinkyHorizontal) //Jika PACMAN di kiri PINKY
                                tujuanPinky = 1; //Pinky jalan ke kiri
                            else
                                tujuanPinky = 2; //Pinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiPinkyVertical) //Jika PACMAN di atas PINKY
                                tujuanPinky = 3; //Pinky jalan ke atas
                            else
                                tujuanPinky = 4; //Pinky jalan ke atas
                        }
                    }
                    if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                    {
                        //Jika PINKY berada di kiri PACMAN dan kiri PINKY ada halangan
                        if (posisiPinkyHorizontal <= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kiri dan ada halangan
                            if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                            }
                        }
                    }
                    else if (tujuanPinky == 2)
                    {
                        //Jika PACMAN berada di kiri PINKY atau kanan PINKY ada halangan
                        if (posisiHorizontal <= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kanan dan ada halangan
                            if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                            }
                        }
                    }
                    else if (tujuanPinky == 3)
                    {
                        //Jika PINKY berada di atas PACMAN atau atas PINKY ada halangan
                        if (posisiPinkyVertical <= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke atas dan ada halangan
                            if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                            }
                        }
                    }
                    else if (tujuanPinky == 4)
                    {
                        //Jika PACMAN berada di atas PINKY atau bawah PINKY ada halangan
                        if (posisiVertical <= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke bawah dan ada halangan
                            if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                            }
                        }
                    }
                    if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                    {
                        posisiPinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                    {
                        posisiPinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                    {
                        posisiPinkyVertical--;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                    {
                        posisiPinkyVertical++;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                if (score >= 1500) //Supaya INKY keluar setelah PACMAN makan 30 food
                {
                    //chase inky
                    if (statusInky > 65)
                    {
                        if (tujuanInky == 0)
                        {
                            if (Math.Abs(((posisiHorizontal + 6) + posisiBlinkyHorizontal) - posisiInkyHorizontal) <= Math.Abs(((posisiVertical + 2) + posisiBlinkyVertical) - posisiInkyVertical)) //menentukan jalan awal inky
                            {
                                if (posisiHorizontal <= posisiInkyHorizontal) //Jika PACMAN berada di kiri INKY
                                    tujuanInky = 1; //INKY jalan ke kiri
                                else
                                    tujuanInky = 2; //INKY jalan ke kanan
                            }
                            else
                            {
                                if (posisiVertical <= posisiInkyVertical) //Jika PACMAN berada di atas INKY
                                    tujuanInky = 3; //INKY jalan ke atas
                                else
                                    tujuanInky = 4; //INKY jalan ke bawah
                            }
                        }
                        if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                        {
                            //Jika INKY berada di kiri PACMAN atau kiri INKY ada halangan
                            if (posisiInkyHorizontal <= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kiri dan kiri INKY ada halangan
                                if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                }
                            }
                        }
                        else if (tujuanInky == 2)
                        {
                            //Jika PACMAN berada di kiri INKY atau kiri INKY ada halangan
                            if (posisiHorizontal <= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kanan dan kanan INKY ada halangan
                                if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                }
                            }
                        }
                        else if (tujuanInky == 3)
                        {
                            //Jika INKY berada di atas PACMAN atau atas INKY ada halangan
                            if (posisiInkyVertical <= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke atas dan atas INKY ada halangan
                                if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                }
                            }
                        }
                        else if (tujuanInky == 4)
                        {
                            //Jika PACMAN berada di atas INKY atau bawah INKY ada halangan
                            if (posisiVertical <= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke bawah dan bawah INKY ada halangan
                                if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                }
                            }
                        }
                        if (tujuanInky == 1) //menggerakkan inky ke kiri
                        {
                            posisiInkyHorizontal -= 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 2) //menggerakkan inky ke kanan
                        {
                            posisiInkyHorizontal += 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 3) //menggerakkan inky ke atas
                        {
                            posisiInkyVertical--;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 4) //menggerakkan inky ke bawah
                        {
                            posisiInkyVertical++;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                    }
                }
                //Jika GHOST menabrak PACMAN
                if ((posisiHorizontal == posisiBlinkyHorizontal && posisiVertical == posisiBlinkyVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)) //hantu nabrak pacman (game reset)
                {
                    Console.Beep(300, 500);
                    lifesPacMan--;
                    Console.SetCursorPosition(8, 31);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(lifesPacMan);
                    if (lifesPacMan >= 1) //jika nyawa masih >= 1
                    {
                        //pacman
                        posisiHorizontal = 51;
                        posisiVertical = 22;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        //blinky
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.Write(" ");
                        posisiBlinkyHorizontal = 48;
                        posisiBlinkyVertical = 13;
                        tujuanBlinky = 0;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        //pinky
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.Write(" ");
                        posisiPinkyHorizontal = 50;
                        posisiPinkyVertical = 13;
                        tujuanPinky = 0;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        //inky
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.Write(" ");
                        posisiInkyHorizontal = 52;
                        posisiInkyVertical = 13;
                        tujuanInky = 0;
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                        //status
                        statusBlinky = 0;
                        statusInky = 0;
                        statusPinky = 0;
                    }
                    else if (lifesPacMan < 1) //Jika nyawa habis
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"
                        ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                         ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                          ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                          ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                          ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                           ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                         ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                         ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                         ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                         ░ ░                           ░                  ░      ");
                        Console.Beep(300, 300);
                        Console.Beep(200, 500);
                        System.Threading.Thread.Sleep(3000);
                        goto stagePage;
                    }
                }
                if (score == 17900) //Jika semua makanan habis
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                    Console.Beep(500, 200);
                    Console.Beep(600, 300);
                    Console.Beep(700, 300);
                    Console.Beep(800, 500);
                    System.Threading.Thread.Sleep(3000);
                    goto stagePage;
                }
                if (entityPosition[posisiHorizontal, posisiVertical] == 7) //Jika pacman makan power up
                {
                    Console.Beep(500, 300);
                    ///Declare ulang untuk tujuan GHOST dan membuat nilai Array pada posisi PACMAN menjadi 0
                    ///Menambahkan powerUp untuk menentukan setelah PACMAN makan power up, FRIGHTENED PHASE akan berlangsung selama 40 kali GHOST/PACMAN berjalan
                    ///Isi while sama dengan di atas, bedanya pada penentuan rute GHOST
                    ///Saat menentukan rute GHOST beberapa tanda akan dibalik, sisanya sama
                    ///Menambahkan jika PACMAN memakan GHOST dan respawn GHOST
                    ///Mengubah warna GHOST menjadi biru tua saat FRIGHTENED PHASE dan saat tersisa 10 detik, akan menjadi warna putih sebagai penanda waktu akan habis sebelum kembali ke warna awal
                    entityPosition[posisiHorizontal, posisiVertical] = 0;
                    tujuanBlinky = 0;
                    tujuanPinky = 0;
                    tujuanInky = 0;
                    int powerUp = 1;
                    while (powerUp <= 40)
                    {
                        posisiHorizontalOld = posisiHorizontal;
                        posisiVerticalOld = posisiVertical;
                        bacaKeySebelumnya = bacaKey;
                        posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                        posisiBlinkyVerticalOld = posisiBlinkyVertical;
                        posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                        posisiPinkyVerticalOld = posisiPinkyVertical;
                        posisiInkyHorizontalOld = posisiInkyHorizontal;
                        posisiInkyVerticalOld = posisiInkyVertical;
                        if (Console.KeyAvailable)
                            bacaKey = Console.ReadKey(true).Key;
                        switch (bacaKey) //cek ada wall atau tidak
                        {
                            case ConsoleKey.RightArrow:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.D:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.A:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.UpArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.W:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.DownArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.S:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                        }
                        //menggerakkan pacman
                        if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                        {
                            if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1 && entityPosition[posisiHorizontal + 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal += 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                        {
                            if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1 && entityPosition[posisiHorizontal - 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal -= 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1 && entityPosition[posisiHorizontal, posisiVertical - 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical--;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical++;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (powerUp % 2 == 0) //frightened phase/power up
                        {
                            if (tujuanBlinky == 0)
                            {
                                if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiBlinkyHorizontal)
                                        tujuanBlinky = 1;
                                    else
                                        tujuanBlinky = 2;
                                }
                                else
                                {
                                    if (posisiVertical >= posisiBlinkyVertical)
                                        tujuanBlinky = 3;
                                    else
                                        tujuanBlinky = 4;
                                }
                            }
                            if (tujuanBlinky == 1) //menentukan rute tercepat (menjauhi pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiBlinkyHorizontal >= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 2)
                            {
                                if (posisiHorizontal >= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 3)
                            {
                                if (posisiBlinkyVertical >= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 4)
                            {
                                if (posisiVertical >= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                    }
                                }
                            }
                            if (tujuanPinky == 0 && score >= 100) //menentukan arah jalan awal Pinky
                            {
                                if (Math.Abs(posisiHorizontal - posisiPinkyHorizontal) <= Math.Abs(posisiVertical - posisiPinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiPinkyHorizontal)
                                        tujuanPinky = 1; //Pinky jalan ke kiri
                                    else
                                        tujuanPinky = 2; //Pinky jalan ke kanan
                                }
                                else
                                {
                                    if (posisiVertical >= posisiPinkyVertical)
                                        tujuanPinky = 3; //Pinky jalan ke atas
                                    else
                                        tujuanPinky = 4; //Pinky jalan ke atas
                                }
                            }
                            if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiPinkyHorizontal >= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                    }
                                }
                            }
                            else if (tujuanPinky == 2)
                            {
                                if (posisiHorizontal >= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                    }
                                }
                            }
                            else if (tujuanPinky == 3)
                            {
                                if (posisiPinkyVertical >= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                    }
                                }
                            }
                            else if (tujuanPinky == 4)
                            {
                                if (posisiVertical >= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                    }
                                }
                            }
                            if (statusInky > 2)
                            {
                                if (tujuanInky == 0 && score >= 1500) //menentukan jalan awal inky
                                {
                                    if (Math.Abs(posisiHorizontal - posisiInkyHorizontal) <= Math.Abs(posisiVertical - posisiInkyVertical))
                                    {
                                        if (posisiHorizontal <= posisiInkyHorizontal)
                                            tujuanInky = 1;
                                        else
                                            tujuanInky = 2;
                                    }
                                    else
                                    {
                                        if (posisiVertical <= posisiInkyVertical)
                                            tujuanInky = 3;
                                        else
                                            tujuanInky = 4;
                                    }
                                }
                                if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                                {
                                    if (posisiInkyHorizontal >= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                        }
                                    }
                                }
                                else if (tujuanInky == 2)
                                {
                                    if (posisiHorizontal >= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                        }
                                    }
                                }
                                else if (tujuanInky == 3)
                                {
                                    if (posisiInkyVertical >= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                        }
                                    }
                                }
                                else if (tujuanInky == 4)
                                {
                                    if (posisiVertical >= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                        }
                                    }
                                }
                            }
                            if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                            {
                                posisiBlinkyVertical--;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                            {
                                posisiPinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                            {
                                posisiPinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                            {
                                posisiPinkyVertical++;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanInky == 1) //menggerakkan inky ke kiri
                            {
                                posisiInkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 2) //menggerakkan inky ke kanan
                            {
                                posisiInkyHorizontal += 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 3) //menggerakkan inky ke atas
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 4) //menggerakkan inky ke bawah
                            {
                                posisiInkyVertical++;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        if ((posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical))
                        {
                            Console.Beep(500, 300);
                            if (posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical)
                            {
                                tujuanBlinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical)
                            {
                                tujuanPinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)
                            {
                                tujuanInky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                        }
                        if (score == 17900) //Jika semua makanan habis
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                            Console.Beep(500, 200);
                            Console.Beep(600, 300);
                            Console.Beep(700, 300);
                            Console.Beep(800, 500);
                            System.Threading.Thread.Sleep(3000);
                            goto stagePage;
                        }
                        if ((powerUp == 40 || tujuanBlinky == 5) || (powerUp == 40 || tujuanPinky == 5) || (powerUp == 40 || tujuanInky == 5))
                        {
                            if (powerUp == 40 || tujuanBlinky == 5) //respawn blinky
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                tujuanBlinky = 0;
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                statusBlinky = 0;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 40 || tujuanPinky == 5) //respawn pinky
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                tujuanPinky = 0;
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                statusPinky = 0;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 40 || tujuanInky == 5) //respawn inky
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                tujuanInky = 0;
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                statusInky = 0;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                break;
                            }
                        }
                        if ((powerUp >= 35 && powerUp < 40 && tujuanBlinky != 5) || (powerUp >= 35 && powerUp < 40 && tujuanPinky != 5) || (powerUp >= 35 && powerUp < 40 && tujuanInky != 5))
                        {
                            if (powerUp >= 35 && powerUp < 40 && tujuanBlinky != 5)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 35 && powerUp < 40 && tujuanPinky != 5)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 35 && powerUp < 40 && tujuanInky != 5)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                        }
                        System.Threading.Thread.Sleep(400);
                        powerUp++;
                    }
                }
                System.Threading.Thread.Sleep(400);
            }
        }
        else if (pilihLevel == ConsoleKey.D2 || pilihLevel == ConsoleKey.NumPad2)
        {
            //MENCETAK MAP
            ///Clear untuk menghapus INTRO PAGE sebelumnya
            ///Map dibuat menggunakan MULTIDIMENSIONAL ARRAY yang dibuat pada class lain agar terlihat rapi
            ///Array untuk map diisi dengan value 1-8
            ///Untuk mencetak map, menggunakan for dalam for (for pertama untuk mencetak secara vertical, for kedua untuk mencetak secara horizontal)
            Console.Clear();
            int[,] entityPosition = new int[94, 31]; //koordinat entity(keseluruhan) = (x,y)
            Map pacManEntity = new Map();
            entityPosition = pacManEntity.mapEntity();
            for (int verticalEntity = 0; verticalEntity < 31; verticalEntity++)
            {
                for (int horizontalEntity = 0; horizontalEntity < 94; horizontalEntity++)
                {
                    if (entityPosition[horizontalEntity, verticalEntity] == 0) //space
                        Console.Write(" ");
                    if (entityPosition[horizontalEntity, verticalEntity] == 1) //wall
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 2) //food
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 3) //pacman
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 4) //blinky
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 5) //pinky
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 6) //inky
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 7) //power up
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("o");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 8) //ghost's door
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }
            Console.SetCursorPosition(0, 31);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Lifes : {lifesPacMan}");
            Console.SetCursorPosition(0, 32);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score : {score}");
            Console.SetCursorPosition(0, 33);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Level : 2");
            ConsoleKey bacaKey = Console.ReadKey(true).Key; //mengecek key yang dipencet
                                                            //

            //GAME
            ///Game akan dijalankan selama score < 17900 / semua makanan habis
            ///Jika PACMAN makan GHOST / POWER UP, score tidak bertambah
            ///Score akan bertambah 50 / food
            ///Variabel bacaKeySebelumnya digunakan untuk melakukan perulangan tanpa harus menekan key berkali-kali
            ///Variabel Old digunakan untuk menghapus/mengganti entity dari map setelah menggerakkan PACMAN atau GHOST
            while (score < 17900) //perulangan game
            {
                int posisiHorizontalOld = posisiHorizontal;
                int posisiVerticalOld = posisiVertical;
                ConsoleKey bacaKeySebelumnya = bacaKey;
                int posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                int posisiBlinkyVerticalOld = posisiBlinkyVertical;
                int posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                int posisiPinkyVerticalOld = posisiPinkyVertical;
                int posisiInkyHorizontalOld = posisiInkyHorizontal;
                int posisiInkyVerticalOld = posisiInkyVertical;
                if (Console.KeyAvailable) //baca key yang dipencet
                    bacaKey = Console.ReadKey(true).Key;
                switch (bacaKey) //cek ada wall atau tidak
                {
                    case ConsoleKey.RightArrow:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.D:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.A:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.UpArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.W:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.DownArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.S:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                }
                //menggerakkan pacman
                if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                {
                    if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal += 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                {
                    if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal -= 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                {
                    if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical--;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                {
                    if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical++;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                //scatter Blinky
                if (statusBlinky <= 36) //BLINKY jalan sebanyak 36 steps
                {
                    if (statusBlinky <= 35) //BLINKY jalan sebanyak 35 steps
                    {
                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1) //Jika diatas BLINKY ada wall
                        {
                            if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical != 4) //Jika dikanan BLINKY tidak ada wall dan posisi Blinky secara vertical tidak di 4, jalan ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1)//Jika kanan BLINKY ada wall, jalan ke atas
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical == 4) //Jika kiri BLINKY tidak ada wall dan posisi BLINKY secara vertical di 4, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && posisiBlinkyHorizontal != 90) //Jika atas BLINKY bukan wall dan posisi BLINKY secara horizontal tidak di 90
                        {
                            posisiBlinkyVertical--;
                            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && posisiBlinkyHorizontal == 90) //Jika bawah BLINKY bukan wall dan posisi BLINKY secara horizontal di 90
                        {
                            if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1) //Jika kiri BLINKY bukan wall, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else //Jika kiri blinky adalah wall, jalan ke atas
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");

                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kanan atas tidak mencetak Blinky
                    {
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusBlinky++;
                }
                //scatter Pinky
                if (statusPinky <= 40) //PINKY jalan sebanyak 40 steps
                {
                    if (statusPinky <= 39) //PINKY jalan sebanyak 39 steps
                    {
                        if (statusPinky >= 0 && statusPinky <= 2) //supaya keluar dari ghost house (jalan ke atas)
                        {
                            posisiPinkyVertical--;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (statusPinky == 3) //setelah keluar dari ghost house, jalan ke kiri
                        {
                            posisiPinkyHorizontal -= 2;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else
                        {
                            if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1) //Jika diatas PINKY ada wall
                            {
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && posisiPinkyVertical != 4) //Jika dikiri PINKY bukan wall dan posisi PINKY secara vertical tidak di 4, jalan ke kiri
                                {
                                    posisiPinkyHorizontal -= 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1)//Jika kiri PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && posisiPinkyVertical == 4) //Jika kanan PINKY bukan wall dan posisi PINKY secara vertical di 4, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("o");
                                    }
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal != 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal bukan di 3, jalan ke bawah
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal == 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal di 3
                            {
                                if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1) //Jika kanan PINKY bukan wall, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else //Jika kanan PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kiri atas tidak mencetak PINKY
                    {
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusPinky++;
                }
                if (score >= 1500)
                {
                    //scatter inky
                    if (statusInky <= 60) //INKY jalan sebanyak 60 steps
                    {
                        if (statusInky <= 59) //INKY jalan sebanyak 59 steps
                        {
                            if (statusInky >= 0 && statusInky <= 2) //supaya INKY keluar dari ghost house
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("-");
                                }
                            }
                            else if (statusInky == 3) //setelah INKY keluar dari ghost house
                            {
                                posisiInkyHorizontal += 2;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else
                            {
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1) //Jika atas INKY ada wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && posisiInkyVertical != 29) //Jika kanan INKY bukan wall dan posisi INKY secara vertical bukan di 29, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.Write(" ");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("o");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && posisiInkyVertical == 29 && posisiInkyHorizontal > 63) //Jika kiri INKY bukan wall dan posisi INKY secara vertical di 29 dan horizontal > 63, jalan ke kiri
                                    {
                                        posisiInkyHorizontal -= 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78)) //Jika atas INKY bukan wall dan posisi INKY secara horizontal di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                                else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1) //Jika bawah INKY bukan wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && (posisiInkyHorizontal == 63 || posisiInkyVertical == 23 || posisiInkyVertical == 26)) //bawah gaada wall, kanan gaada wall, x di 63 atau y di 23/25, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal != 63 && posisiInkyHorizontal != 78) //x bukan di 53 dan 78, jalan ke bawah
                                    {
                                        posisiInkyVertical++;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78) //x di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                            }
                        }
                        else //Supaya di pojok kanan bawah tidak mencetak INKY
                        {
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        statusInky++;
                    }
                }
                //chase Blinky
                if (statusBlinky > 36) //Keluar dari Scatter
                {
                    if (tujuanBlinky == 0) //Prioritas arah gerak = kiri -> kanan -> atas -> bawah
                    {
                        if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical)) //menentukan arah jalan awal blinky
                        {
                            if (posisiHorizontal <= posisiBlinkyHorizontal) //Jika PACMAN berada di kiri BLINKY
                                tujuanBlinky = 1; //blinky jalan ke kiri
                            else
                                tujuanBlinky = 2; //blinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiBlinkyVertical) //Jika PACMAN berada di atas BLINKY
                                tujuanBlinky = 3; //blinky jalan ke atas
                            else
                                tujuanBlinky = 4; //blinky jalan ke bawah
                        }
                    }
                    if (tujuanBlinky == 1) //menentukan rute tercepat dan mengecek wall/ghost/door
                    {
                        //Jika BLINKY berada di kiri PACMAN atau kiri BLINKY ada halangan
                        if (posisiBlinkyHorizontal <= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kiri dan ada halangan
                            if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                            }
                        }
                    }
                    else if (tujuanBlinky == 2)
                    {
                        //Jika PACMAN berada di kiri BLINKY atau kanan BLINKY ada halangan
                        if (posisiHorizontal <= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kanan dan ada halangan
                            if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                            }
                        }
                    }
                    else if (tujuanBlinky == 3)
                    {
                        //Jika BLINKY berada di atas PACMAN atau bawah BLINKY ada halangan
                        if (posisiBlinkyVertical <= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY tidak ada halangan, kanan ke kanan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke atas dan ada halangan
                            if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                            }
                        }
                    }
                    else if (tujuanBlinky == 4)
                    {
                        //Jika PACMAN berada di atas BLINKY atau bawah BLINKY ada halangan
                        if (posisiVertical <= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY ada halangan
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY ada halangan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke bawah dan ada halangan
                            if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                            }
                        }
                    }
                    if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                    {
                        posisiBlinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                    {
                        posisiBlinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                    {
                        posisiBlinkyVertical--;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                    {
                        posisiBlinkyVertical++;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                //chase Pinky
                if (statusPinky > 40)
                {
                    if (tujuanPinky == 0 && score >= 100) //score >= 100 supaya PINKY jalan setelah PACMAN makan 2 food
                    {
                        if (Math.Abs((posisiHorizontal + 12) - posisiPinkyHorizontal) <= Math.Abs((posisiVertical + 4) - posisiPinkyVertical))//menentukan arah jalan awal Pinky
                        {
                            if (posisiHorizontal <= posisiPinkyHorizontal) //Jika PACMAN di kiri PINKY
                                tujuanPinky = 1; //Pinky jalan ke kiri
                            else
                                tujuanPinky = 2; //Pinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiPinkyVertical) //Jika PACMAN di atas PINKY
                                tujuanPinky = 3; //Pinky jalan ke atas
                            else
                                tujuanPinky = 4; //Pinky jalan ke atas
                        }
                    }
                    if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                    {
                        //Jika PINKY berada di kiri PACMAN dan kiri PINKY ada halangan
                        if (posisiPinkyHorizontal <= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kiri dan ada halangan
                            if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                            }
                        }
                    }
                    else if (tujuanPinky == 2)
                    {
                        //Jika PACMAN berada di kiri PINKY atau kanan PINKY ada halangan
                        if (posisiHorizontal <= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kanan dan ada halangan
                            if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                            }
                        }
                    }
                    else if (tujuanPinky == 3)
                    {
                        //Jika PINKY berada di atas PACMAN atau atas PINKY ada halangan
                        if (posisiPinkyVertical <= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke atas dan ada halangan
                            if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                            }
                        }
                    }
                    else if (tujuanPinky == 4)
                    {
                        //Jika PACMAN berada di atas PINKY atau bawah PINKY ada halangan
                        if (posisiVertical <= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke bawah dan ada halangan
                            if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                            }
                        }
                    }
                    if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                    {
                        posisiPinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                    {
                        posisiPinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                    {
                        posisiPinkyVertical--;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                    {
                        posisiPinkyVertical++;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                if (score >= 1500) //Supaya INKY keluar setelah PACMAN makan 30 food
                {
                    //chase inky
                    if (statusInky > 60)
                    {
                        if (tujuanInky == 0)
                        {
                            if (Math.Abs(((posisiHorizontal + 6) + posisiBlinkyHorizontal) - posisiInkyHorizontal) <= Math.Abs(((posisiVertical + 2) + posisiBlinkyVertical) - posisiInkyVertical)) //menentukan jalan awal inky
                            {
                                if (posisiHorizontal <= posisiInkyHorizontal) //Jika PACMAN berada di kiri INKY
                                    tujuanInky = 1; //INKY jalan ke kiri
                                else
                                    tujuanInky = 2; //INKY jalan ke kanan
                            }
                            else
                            {
                                if (posisiVertical <= posisiInkyVertical) //Jika PACMAN berada di atas INKY
                                    tujuanInky = 3; //INKY jalan ke atas
                                else
                                    tujuanInky = 4; //INKY jalan ke bawah
                            }
                        }
                        if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                        {
                            //Jika INKY berada di kiri PACMAN atau kiri INKY ada halangan
                            if (posisiInkyHorizontal <= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kiri dan kiri INKY ada halangan
                                if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                }
                            }
                        }
                        else if (tujuanInky == 2)
                        {
                            //Jika PACMAN berada di kiri INKY atau kiri INKY ada halangan
                            if (posisiHorizontal <= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kanan dan kanan INKY ada halangan
                                if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                }
                            }
                        }
                        else if (tujuanInky == 3)
                        {
                            //Jika INKY berada di atas PACMAN atau atas INKY ada halangan
                            if (posisiInkyVertical <= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke atas dan atas INKY ada halangan
                                if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                }
                            }
                        }
                        else if (tujuanInky == 4)
                        {
                            //Jika PACMAN berada di atas INKY atau bawah INKY ada halangan
                            if (posisiVertical <= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke bawah dan bawah INKY ada halangan
                                if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                }
                            }
                        }
                        if (tujuanInky == 1) //menggerakkan inky ke kiri
                        {
                            posisiInkyHorizontal -= 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 2) //menggerakkan inky ke kanan
                        {
                            posisiInkyHorizontal += 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 3) //menggerakkan inky ke atas
                        {
                            posisiInkyVertical--;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 4) //menggerakkan inky ke bawah
                        {
                            posisiInkyVertical++;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                    }
                }
                //Jika GHOST menabrak PACMAN
                if ((posisiHorizontal == posisiBlinkyHorizontal && posisiVertical == posisiBlinkyVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)) //hantu nabrak pacman (game reset)
                {
                    Console.Beep(300, 500);
                    lifesPacMan--;
                    Console.SetCursorPosition(8, 31);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(lifesPacMan);
                    if (lifesPacMan >= 1) //jika nyawa masih >= 1
                    {
                        //pacman
                        posisiHorizontal = 51;
                        posisiVertical = 22;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        //blinky
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.Write(" ");
                        posisiBlinkyHorizontal = 48;
                        posisiBlinkyVertical = 13;
                        tujuanBlinky = 0;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        //pinky
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.Write(" ");
                        posisiPinkyHorizontal = 50;
                        posisiPinkyVertical = 13;
                        tujuanPinky = 0;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        //inky
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.Write(" ");
                        posisiInkyHorizontal = 52;
                        posisiInkyVertical = 13;
                        tujuanInky = 0;
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                        //status
                        statusBlinky = 0;
                        statusInky = 0;
                        statusPinky = 0;
                    }
                    else if (lifesPacMan < 1) //Jika nyawa habis
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"
                        ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                         ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                          ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                          ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                          ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                           ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                         ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                         ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                         ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                         ░ ░                           ░                  ░      ");
                        Console.Beep(300, 300);
                        Console.Beep(200, 500);
                        System.Threading.Thread.Sleep(3000);
                        goto stagePage;
                    }
                }
                if (score == 17900) //Jika semua makanan habis
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                    Console.Beep(500, 200);
                    Console.Beep(600, 300);
                    Console.Beep(700, 300);
                    Console.Beep(800, 500);
                    System.Threading.Thread.Sleep(3000);
                    goto stagePage;
                }
                if (entityPosition[posisiHorizontal, posisiVertical] == 7) //Jika pacman makan power up
                {
                    Console.Beep(500, 300);
                    ///Declare ulang untuk tujuan GHOST dan membuat nilai Array pada posisi PACMAN menjadi 0
                    ///Menambahkan powerUp untuk menentukan setelah PACMAN makan power up, FRIGHTENED PHASE akan berlangsung selama 40 kali GHOST/PACMAN berjalan
                    ///Isi while sama dengan di atas, bedanya pada penentuan rute GHOST
                    ///Saat menentukan rute GHOST beberapa tanda akan dibalik, sisanya sama
                    ///Menambahkan jika PACMAN memakan GHOST dan respawn GHOST
                    ///Mengubah warna GHOST menjadi biru tua saat FRIGHTENED PHASE dan saat tersisa 10 detik, akan menjadi warna putih sebagai penanda waktu akan habis sebelum kembali ke warna awal
                    entityPosition[posisiHorizontal, posisiVertical] = 0;
                    tujuanBlinky = 0;
                    tujuanPinky = 0;
                    tujuanInky = 0;
                    int powerUp = 1;
                    while (powerUp <= 35)
                    {
                        posisiHorizontalOld = posisiHorizontal;
                        posisiVerticalOld = posisiVertical;
                        bacaKeySebelumnya = bacaKey;
                        posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                        posisiBlinkyVerticalOld = posisiBlinkyVertical;
                        posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                        posisiPinkyVerticalOld = posisiPinkyVertical;
                        posisiInkyHorizontalOld = posisiInkyHorizontal;
                        posisiInkyVerticalOld = posisiInkyVertical;
                        if (Console.KeyAvailable)
                            bacaKey = Console.ReadKey(true).Key;
                        switch (bacaKey) //cek ada wall atau tidak
                        {
                            case ConsoleKey.RightArrow:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.D:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.A:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.UpArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.W:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.DownArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.S:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                        }
                        //menggerakkan pacman
                        if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                        {
                            if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1 && entityPosition[posisiHorizontal + 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal += 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                        {
                            if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1 && entityPosition[posisiHorizontal - 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal -= 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1 && entityPosition[posisiHorizontal, posisiVertical - 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical--;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical++;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (powerUp % 2 == 0) //frightened phase/power up
                        {
                            if (tujuanBlinky == 0)
                            {
                                if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiBlinkyHorizontal)
                                        tujuanBlinky = 1;
                                    else
                                        tujuanBlinky = 2;
                                }
                                else
                                {
                                    if (posisiVertical >= posisiBlinkyVertical)
                                        tujuanBlinky = 3;
                                    else
                                        tujuanBlinky = 4;
                                }
                            }
                            if (tujuanBlinky == 1) //menentukan rute tercepat (menjauhi pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiBlinkyHorizontal >= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 2)
                            {
                                if (posisiHorizontal >= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 3)
                            {
                                if (posisiBlinkyVertical >= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 4)
                            {
                                if (posisiVertical >= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                    }
                                }
                            }
                            if (tujuanPinky == 0 && score >= 100) //menentukan arah jalan awal Pinky
                            {
                                if (Math.Abs(posisiHorizontal - posisiPinkyHorizontal) <= Math.Abs(posisiVertical - posisiPinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiPinkyHorizontal)
                                        tujuanPinky = 1; //Pinky jalan ke kiri
                                    else
                                        tujuanPinky = 2; //Pinky jalan ke kanan
                                }
                                else
                                {
                                    if (posisiVertical >= posisiPinkyVertical)
                                        tujuanPinky = 3; //Pinky jalan ke atas
                                    else
                                        tujuanPinky = 4; //Pinky jalan ke atas
                                }
                            }
                            if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiPinkyHorizontal >= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                    }
                                }
                            }
                            else if (tujuanPinky == 2)
                            {
                                if (posisiHorizontal >= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                    }
                                }
                            }
                            else if (tujuanPinky == 3)
                            {
                                if (posisiPinkyVertical >= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                    }
                                }
                            }
                            else if (tujuanPinky == 4)
                            {
                                if (posisiVertical >= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                    }
                                }
                            }
                            if (statusInky > 2)
                            {
                                if (tujuanInky == 0 && score >= 1500) //menentukan jalan awal inky
                                {
                                    if (Math.Abs(posisiHorizontal - posisiInkyHorizontal) <= Math.Abs(posisiVertical - posisiInkyVertical))
                                    {
                                        if (posisiHorizontal <= posisiInkyHorizontal)
                                            tujuanInky = 1;
                                        else
                                            tujuanInky = 2;
                                    }
                                    else
                                    {
                                        if (posisiVertical <= posisiInkyVertical)
                                            tujuanInky = 3;
                                        else
                                            tujuanInky = 4;
                                    }
                                }
                                if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                                {
                                    if (posisiInkyHorizontal >= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                        }
                                    }
                                }
                                else if (tujuanInky == 2)
                                {
                                    if (posisiHorizontal >= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                        }
                                    }
                                }
                                else if (tujuanInky == 3)
                                {
                                    if (posisiInkyVertical >= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                        }
                                    }
                                }
                                else if (tujuanInky == 4)
                                {
                                    if (posisiVertical >= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                        }
                                    }
                                }
                            }
                            if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                            {
                                posisiBlinkyVertical--;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                            {
                                posisiPinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                            {
                                posisiPinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                            {
                                posisiPinkyVertical++;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanInky == 1) //menggerakkan inky ke kiri
                            {
                                posisiInkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 2) //menggerakkan inky ke kanan
                            {
                                posisiInkyHorizontal += 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 3) //menggerakkan inky ke atas
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 4) //menggerakkan inky ke bawah
                            {
                                posisiInkyVertical++;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        if ((posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical))
                        {
                            Console.Beep(500, 300);
                            if (posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical)
                            {
                                tujuanBlinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical)
                            {
                                tujuanPinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)
                            {
                                tujuanInky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                        }
                        if (score == 17900) //Jika semua makanan habis
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                            Console.Beep(500, 200);
                            Console.Beep(600, 300);
                            Console.Beep(700, 300);
                            Console.Beep(800, 500);
                            System.Threading.Thread.Sleep(3000);
                            goto stagePage;
                        }
                        if ((powerUp == 35 || tujuanBlinky == 5) || (powerUp == 35 || tujuanPinky == 5) || (powerUp == 35 || tujuanInky == 5))
                        {
                            if (powerUp == 35 || tujuanBlinky == 5) //respawn blinky
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                tujuanBlinky = 0;
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                statusBlinky = 0;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 35 || tujuanPinky == 5) //respawn pinky
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                tujuanPinky = 0;
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                statusPinky = 0;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 35 || tujuanInky == 5) //respawn inky
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                tujuanInky = 0;
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                statusInky = 0;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                break;
                            }
                        }
                        if ((powerUp >= 30 && powerUp < 35 && tujuanBlinky != 5) || (powerUp >= 30 && powerUp < 35 && tujuanPinky != 5) || (powerUp >= 30 && powerUp < 35 && tujuanInky != 5))
                        {
                            if (powerUp >= 30 && powerUp < 35 && tujuanBlinky != 5)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 30 && powerUp < 35 && tujuanPinky != 5)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 30 && powerUp < 35 && tujuanInky != 5)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                        }
                        System.Threading.Thread.Sleep(400);
                        powerUp++;
                    }
                }
                System.Threading.Thread.Sleep(400);
            }
        }
        else if (pilihLevel == ConsoleKey.D3 || pilihLevel == ConsoleKey.NumPad3)
        {
            //MENCETAK MAP
            ///Clear untuk menghapus INTRO PAGE sebelumnya
            ///Map dibuat menggunakan MULTIDIMENSIONAL ARRAY yang dibuat pada class lain agar terlihat rapi
            ///Array untuk map diisi dengan value 1-8
            ///Untuk mencetak map, menggunakan for dalam for (for pertama untuk mencetak secara vertical, for kedua untuk mencetak secara horizontal)
            Console.Clear();
            int[,] entityPosition = new int[94, 31]; //koordinat entity(keseluruhan) = (x,y)
            Map pacManEntity = new Map();
            entityPosition = pacManEntity.mapEntity();
            for (int verticalEntity = 0; verticalEntity < 31; verticalEntity++)
            {
                for (int horizontalEntity = 0; horizontalEntity < 94; horizontalEntity++)
                {
                    if (entityPosition[horizontalEntity, verticalEntity] == 0) //space
                        Console.Write(" ");
                    if (entityPosition[horizontalEntity, verticalEntity] == 1) //wall
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 2) //food
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 3) //pacman
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 4) //blinky
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 5) //pinky
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 6) //inky
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 7) //power up
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("o");
                    }
                    if (entityPosition[horizontalEntity, verticalEntity] == 8) //ghost's door
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }
            Console.SetCursorPosition(0, 31);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Lifes : {lifesPacMan}");
            Console.SetCursorPosition(0, 32);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score : {score}");
            Console.SetCursorPosition(0, 33);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Level : 3");
            ConsoleKey bacaKey = Console.ReadKey(true).Key; //mengecek key yang dipencet
                                                            //

            //GAME
            ///Game akan dijalankan selama score < 17900 / semua makanan habis
            ///Jika PACMAN makan GHOST / POWER UP, score tidak bertambah
            ///Score akan bertambah 50 / food
            ///Variabel bacaKeySebelumnya digunakan untuk melakukan perulangan tanpa harus menekan key berkali-kali
            ///Variabel Old digunakan untuk menghapus/mengganti entity dari map setelah menggerakkan PACMAN atau GHOST
            while (score < 17900) //perulangan game
            {
                int posisiHorizontalOld = posisiHorizontal;
                int posisiVerticalOld = posisiVertical;
                ConsoleKey bacaKeySebelumnya = bacaKey;
                int posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                int posisiBlinkyVerticalOld = posisiBlinkyVertical;
                int posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                int posisiPinkyVerticalOld = posisiPinkyVertical;
                int posisiInkyHorizontalOld = posisiInkyHorizontal;
                int posisiInkyVerticalOld = posisiInkyVertical;
                if (Console.KeyAvailable) //baca key yang dipencet
                    bacaKey = Console.ReadKey(true).Key;
                switch (bacaKey) //cek ada wall atau tidak
                {
                    case ConsoleKey.RightArrow:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.D:
                        if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.A:
                        if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.UpArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.W:
                        if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.DownArrow:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                    case ConsoleKey.S:
                        if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                            bacaKey = bacaKeySebelumnya;
                        break;
                }
                //menggerakkan pacman
                if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                {
                    if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal += 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                {
                    if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiHorizontal -= 3;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                {
                    if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical--;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                else if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                {
                    if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                    {
                        if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                        {
                            score += 50;
                            Console.SetCursorPosition(8, 32);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(score);
                        }
                        posisiVertical++;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                        Console.Write(" ");
                        entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                    }
                }
                //scatter Blinky
                if (statusBlinky <= 31) //BLINKY jalan sebanyak 31 steps
                {
                    if (statusBlinky <= 30) //BLINKY jalan sebanyak 30 steps
                    {
                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1) //Jika diatas BLINKY ada wall
                        {
                            if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical != 4) //Jika dikanan BLINKY tidak ada wall dan posisi Blinky secara vertical tidak di 4, jalan ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1)//Jika kanan BLINKY ada wall, jalan ke atas
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical == 4) //Jika kiri BLINKY tidak ada wall dan posisi BLINKY secara vertical di 4, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && posisiBlinkyHorizontal != 90) //Jika atas BLINKY bukan wall dan posisi BLINKY secara horizontal tidak di 90
                        {
                            posisiBlinkyVertical--;
                            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && posisiBlinkyHorizontal == 90) //Jika bawah BLINKY bukan wall dan posisi BLINKY secara horizontal di 90
                        {
                            if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1) //Jika kiri BLINKY bukan wall, jalan ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else //Jika kiri blinky adalah wall, jalan ke atas
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");

                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kanan atas tidak mencetak Blinky
                    {
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusBlinky++;
                }
                //scatter Pinky
                if (statusPinky <= 35) //PINKY jalan sebanyak 35 steps
                {
                    if (statusPinky <= 34) //PINKY jalan sebanyak 34 steps
                    {
                        if (statusPinky >= 0 && statusPinky <= 2) //supaya keluar dari ghost house (jalan ke atas)
                        {
                            posisiPinkyVertical--;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (statusPinky == 3) //setelah keluar dari ghost house, jalan ke kiri
                        {
                            posisiPinkyHorizontal -= 2;
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else
                        {
                            if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1) //Jika diatas PINKY ada wall
                            {
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && posisiPinkyVertical != 4) //Jika dikiri PINKY bukan wall dan posisi PINKY secara vertical tidak di 4, jalan ke kiri
                                {
                                    posisiPinkyHorizontal -= 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1)//Jika kiri PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && posisiPinkyVertical == 4) //Jika kanan PINKY bukan wall dan posisi PINKY secara vertical di 4, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("o");
                                    }
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal != 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal bukan di 3, jalan ke bawah
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                            }
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal == 3) //Jika atas PINKY bukan wall dan posisi PINKY secara horizontal di 3
                            {
                                if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1) //Jika kanan PINKY bukan wall, jalan ke kanan
                                {
                                    posisiPinkyHorizontal += 3;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                                else //Jika kanan PINKY ada wall, jalan ke bawah
                                {
                                    posisiPinkyVertical++;
                                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("@");
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                    if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.Write(" ");
                                    }
                                    else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                    {
                                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(".");
                                    }
                                }
                            }
                        }
                    }
                    else //Supaya di pojok kiri atas tidak mencetak PINKY
                    {
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusPinky++;
                }
                if (score >= 1500)
                {
                    //scatter inky
                    if (statusInky <= 55) //INKY jalan sebanyak 55 steps
                    {
                        if (statusInky <= 54) //INKY jalan sebanyak 54 steps
                        {
                            if (statusInky >= 0 && statusInky <= 2) //supaya INKY keluar dari ghost house
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("-");
                                }
                            }
                            else if (statusInky == 3) //setelah INKY keluar dari ghost house
                            {
                                posisiInkyHorizontal += 2;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else
                            {
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1) //Jika atas INKY ada wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && posisiInkyVertical != 29) //Jika kanan INKY bukan wall dan posisi INKY secara vertical bukan di 29, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.Write(" ");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                        else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("o");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && posisiInkyVertical == 29 && posisiInkyHorizontal > 63) //Jika kiri INKY bukan wall dan posisi INKY secara vertical di 29 dan horizontal > 63, jalan ke kiri
                                    {
                                        posisiInkyHorizontal -= 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78)) //Jika atas INKY bukan wall dan posisi INKY secara horizontal di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                                else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1) //Jika bawah INKY bukan wall
                                {
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && (posisiInkyHorizontal == 63 || posisiInkyVertical == 23 || posisiInkyVertical == 26)) //bawah gaada wall, kanan gaada wall, x di 63 atau y di 23/25, jalan ke kanan
                                    {
                                        posisiInkyHorizontal += 3;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal != 63 && posisiInkyHorizontal != 78) //x bukan di 53 dan 78, jalan ke bawah
                                    {
                                        posisiInkyVertical++;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                    else if (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78) //x di 63 atau 78, jalan ke atas
                                    {
                                        posisiInkyVertical--;
                                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("@");
                                        Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                        Console.Write(" ");
                                        if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                        {
                                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(".");
                                        }
                                    }
                                }
                            }
                        }
                        else //Supaya di pojok kanan bawah tidak mencetak INKY
                        {
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        statusInky++;
                    }
                }
                //chase Blinky
                if (statusBlinky > 31) //Keluar dari Scatter
                {
                    if (tujuanBlinky == 0) //Prioritas arah gerak = kiri -> kanan -> atas -> bawah
                    {
                        if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical)) //menentukan arah jalan awal blinky
                        {
                            if (posisiHorizontal <= posisiBlinkyHorizontal) //Jika PACMAN berada di kiri BLINKY
                                tujuanBlinky = 1; //blinky jalan ke kiri
                            else
                                tujuanBlinky = 2; //blinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiBlinkyVertical) //Jika PACMAN berada di atas BLINKY
                                tujuanBlinky = 3; //blinky jalan ke atas
                            else
                                tujuanBlinky = 4; //blinky jalan ke bawah
                        }
                    }
                    if (tujuanBlinky == 1) //menentukan rute tercepat dan mengecek wall/ghost/door
                    {
                        //Jika BLINKY berada di kiri PACMAN atau kiri BLINKY ada halangan
                        if (posisiBlinkyHorizontal <= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kiri dan ada halangan
                            if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                            }
                        }
                    }
                    else if (tujuanBlinky == 2)
                    {
                        //Jika PACMAN berada di kiri BLINKY atau kanan BLINKY ada halangan
                        if (posisiHorizontal <= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                        {
                            //Jika PACMAN berada di atas BLINKY dan atas BLINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            //Jika PACMAN berada di bawah BLINKY dan bawah BLINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                            //Jika BLINKY gerak ke kanan dan ada halangan
                            if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                            {
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                            }
                        }
                    }
                    else if (tujuanBlinky == 3)
                    {
                        //Jika BLINKY berada di atas PACMAN atau bawah BLINKY ada halangan
                        if (posisiBlinkyVertical <= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY tidak ada halangan, kanan ke kanan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke atas dan ada halangan
                            if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika bawah BLINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                    tujuanBlinky = 4;
                            }
                        }
                    }
                    else if (tujuanBlinky == 4)
                    {
                        //Jika PACMAN berada di atas BLINKY atau bawah BLINKY ada halangan
                        if (posisiVertical <= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                        {
                            //Jika PACMAN berada di kiri BLINKY dan kiri BLINKY ada halangan
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            //Jika PACMAN berada di kanan BLINKY dan kanan BLINKY ada halangan
                            else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            //Jika BLINKY gerak ke bawah dan ada halangan
                            if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                            {
                                //Jika kiri BLINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 1;
                                //Jika kanan BLINKY tidak ada halangan, kanan ke kanan
                                else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                //Jika atas BLINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                    tujuanBlinky = 3;
                            }
                        }
                    }
                    if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                    {
                        posisiBlinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                    {
                        posisiBlinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                    {
                        posisiBlinkyVertical--;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                    {
                        posisiBlinkyVertical++;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                //chase Pinky
                if (statusPinky > 35)
                {
                    if (tujuanPinky == 0 && score >= 100) //score >= 100 supaya PINKY jalan setelah PACMAN makan 2 food
                    {
                        if (Math.Abs((posisiHorizontal + 12) - posisiPinkyHorizontal) <= Math.Abs((posisiVertical + 4) - posisiPinkyVertical))//menentukan arah jalan awal Pinky
                        {
                            if (posisiHorizontal <= posisiPinkyHorizontal) //Jika PACMAN di kiri PINKY
                                tujuanPinky = 1; //Pinky jalan ke kiri
                            else
                                tujuanPinky = 2; //Pinky jalan ke kanan
                        }
                        else
                        {
                            if (posisiVertical <= posisiPinkyVertical) //Jika PACMAN di atas PINKY
                                tujuanPinky = 3; //Pinky jalan ke atas
                            else
                                tujuanPinky = 4; //Pinky jalan ke atas
                        }
                    }
                    if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                    {
                        //Jika PINKY berada di kiri PACMAN dan kiri PINKY ada halangan
                        if (posisiPinkyHorizontal <= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kiri dan ada halangan
                            if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                            }
                        }
                    }
                    else if (tujuanPinky == 2)
                    {
                        //Jika PACMAN berada di kiri PINKY atau kanan PINKY ada halangan
                        if (posisiHorizontal <= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                        {
                            //Jika TARGET PINKY (posisiVertical - 4 (-4 karena ke atas)) berada di atas PINKY dan atas PINKY tidak ada halangan, jalan ke atas
                            if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            //Jika TARGET PINKY (posisiVertical + 4 (+4 karena ke bawah)) berada di bawah PINKY dan bawah PINKY tidak ada halangan, jalan ke bawah
                            else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                            //Jika PINKY gerak ke kanan dan ada halangan
                            if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                            {
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                            }
                        }
                    }
                    else if (tujuanPinky == 3)
                    {
                        //Jika PINKY berada di atas PACMAN atau atas PINKY ada halangan
                        if (posisiPinkyVertical <= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke atas dan ada halangan
                            if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika bawah PINKY tidak ada halangan, jalan ke bawah
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                    tujuanPinky = 4;
                            }
                        }
                    }
                    else if (tujuanPinky == 4)
                    {
                        //Jika PACMAN berada di atas PINKY atau bawah PINKY ada halangan
                        if (posisiVertical <= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                        {
                            //Jika TARGET PINKY (posisiHorizontal - 12 (-12 karena ke kiri spasi 3)) berada di kiri PINKY dan kiri PINKY tidak ada halangan, jalan ke kiri
                            if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            //Jika TARGET PINKY (posisiHorizontal + 12 (+12 karena ke kanan spasi 3)) berada di kanan PINKY dan kanan PINKY tidak ada halangan, jalan ke kanan
                            else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                            //Jika PINKY gerak ke bawah dan ada halangan
                            if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                            {
                                //Jika kiri PINKY tidak ada halangan, jalan ke kiri
                                if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 1;
                                //Jika kanan PINKY tidak ada halangan, jalan ke kanan
                                else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                    tujuanPinky = 2;
                                //Jika atas PINKY tidak ada halangan, jalan ke atas
                                else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                    tujuanPinky = 3;
                            }
                        }
                    }
                    if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                    {
                        posisiPinkyHorizontal -= 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                    {
                        posisiPinkyHorizontal += 3;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                    {
                        posisiPinkyVertical--;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                    else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                    {
                        posisiPinkyVertical++;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                        Console.Write(" ");
                        if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.Write(" ");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("o");
                        }
                        else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 8)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("-");
                        }
                    }
                }
                if (score >= 1500) //Supaya INKY keluar setelah PACMAN makan 30 food
                {
                    //chase inky
                    if (statusInky > 55)
                    {
                        if (tujuanInky == 0)
                        {
                            if (Math.Abs(((posisiHorizontal + 6) + posisiBlinkyHorizontal) - posisiInkyHorizontal) <= Math.Abs(((posisiVertical + 2) + posisiBlinkyVertical) - posisiInkyVertical)) //menentukan jalan awal inky
                            {
                                if (posisiHorizontal <= posisiInkyHorizontal) //Jika PACMAN berada di kiri INKY
                                    tujuanInky = 1; //INKY jalan ke kiri
                                else
                                    tujuanInky = 2; //INKY jalan ke kanan
                            }
                            else
                            {
                                if (posisiVertical <= posisiInkyVertical) //Jika PACMAN berada di atas INKY
                                    tujuanInky = 3; //INKY jalan ke atas
                                else
                                    tujuanInky = 4; //INKY jalan ke bawah
                            }
                        }
                        if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                        {
                            //Jika INKY berada di kiri PACMAN atau kiri INKY ada halangan
                            if (posisiInkyHorizontal <= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kiri dan kiri INKY ada halangan
                                if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                }
                            }
                        }
                        else if (tujuanInky == 2)
                        {
                            //Jika PACMAN berada di kiri INKY atau kiri INKY ada halangan
                            if (posisiHorizontal <= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                            {
                                //Jika TARGET INKY ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di atas INKY dan atas INKY tidak ada halangan, jalan ke atas
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                    tujuanInky = 3;
                                //Jika TARGET INKY ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di bawah INKY dan bawah INKY tidak ada halangan, jalan ke bawah
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                //Jika INKY gerak ke kanan dan kanan INKY ada halangan
                                if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                {
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                }
                            }
                        }
                        else if (tujuanInky == 3)
                        {
                            //Jika INKY berada di atas PACMAN atau atas INKY ada halangan
                            if (posisiInkyVertical <= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke atas dan atas INKY ada halangan
                                if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika bawah INKY tidak ada halangan, jalan ke bawah
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                }
                            }
                        }
                        else if (tujuanInky == 4)
                        {
                            //Jika PACMAN berada di atas INKY atau bawah INKY ada halangan
                            if (posisiVertical <= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                            {
                                //Jika TARGET INKY ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kiri INKY dan kiri INKY tidak ada halangan, jalan ke kiri
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                //Jika TARGET INKY ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical target INKY = +2 di depan pacman (temp titik) + jarak BLINKY ke temp titik) berada di kanan INKY dan kanan INKY tidak ada halangan, jalan ke kanan
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                //Jika INKY gerak ke bawah dan bawah INKY ada halangan
                                if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                {
                                    //Jika kiri INKY tidak ada halangan, jalan ke kiri
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    //Jika kanan INKY tidak ada halangan, jalan ke kanan
                                    else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                    //Jika atas INKY tidak ada halangan, jalan ke atas
                                    else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                }
                            }
                        }
                        if (tujuanInky == 1) //menggerakkan inky ke kiri
                        {
                            posisiInkyHorizontal -= 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 2) //menggerakkan inky ke kanan
                        {
                            posisiInkyHorizontal += 3;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 3) //menggerakkan inky ke atas
                        {
                            posisiInkyVertical--;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                        else if (tujuanInky == 4) //menggerakkan inky ke bawah
                        {
                            posisiInkyVertical++;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                            Console.Write(" ");
                            if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(".");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("o");
                            }
                            else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 8)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("-");
                            }
                        }
                    }
                }
                //Jika GHOST menabrak PACMAN
                if ((posisiHorizontal == posisiBlinkyHorizontal && posisiVertical == posisiBlinkyVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)) //hantu nabrak pacman (game reset)
                {
                    Console.Beep(300, 500);
                    lifesPacMan--;
                    Console.SetCursorPosition(8, 31);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(lifesPacMan);
                    if (lifesPacMan >= 1) //jika nyawa masih >= 1
                    {
                        //pacman
                        posisiHorizontal = 51;
                        posisiVertical = 22;
                        Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("C");
                        //blinky
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.Write(" ");
                        posisiBlinkyHorizontal = 48;
                        posisiBlinkyVertical = 13;
                        tujuanBlinky = 0;
                        Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                        //pinky
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.Write(" ");
                        posisiPinkyHorizontal = 50;
                        posisiPinkyVertical = 13;
                        tujuanPinky = 0;
                        Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("@");
                        //inky
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.Write(" ");
                        posisiInkyHorizontal = 52;
                        posisiInkyVertical = 13;
                        tujuanInky = 0;
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@");
                        //status
                        statusBlinky = 0;
                        statusInky = 0;
                        statusPinky = 0;
                    }
                    else if (lifesPacMan < 1) //Jika nyawa habis
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"
                        ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                         ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                          ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                          ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                          ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                           ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                         ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                         ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                         ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                         ░ ░                           ░                  ░      ");
                        Console.Beep(300, 300);
                        Console.Beep(200, 500);
                        System.Threading.Thread.Sleep(3000);
                        goto stagePage;
                    }
                }
                if (score == 17900) //Jika semua makanan habis
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                    Console.Beep(500, 200);
                    Console.Beep(600, 300);
                    Console.Beep(700, 300);
                    Console.Beep(800, 500);
                    System.Threading.Thread.Sleep(3000);
                    goto stagePage;
                }
                if (entityPosition[posisiHorizontal, posisiVertical] == 7) //Jika pacman makan power up
                {
                    Console.Beep(500, 300);
                    ///Declare ulang untuk tujuan GHOST dan membuat nilai Array pada posisi PACMAN menjadi 0
                    ///Menambahkan powerUp untuk menentukan setelah PACMAN makan power up, FRIGHTENED PHASE akan berlangsung selama 40 kali GHOST/PACMAN berjalan
                    ///Isi while sama dengan di atas, bedanya pada penentuan rute GHOST
                    ///Saat menentukan rute GHOST beberapa tanda akan dibalik, sisanya sama
                    ///Menambahkan jika PACMAN memakan GHOST dan respawn GHOST
                    ///Mengubah warna GHOST menjadi biru tua saat FRIGHTENED PHASE dan saat tersisa 10 detik, akan menjadi warna putih sebagai penanda waktu akan habis sebelum kembali ke warna awal
                    entityPosition[posisiHorizontal, posisiVertical] = 0;
                    tujuanBlinky = 0;
                    tujuanPinky = 0;
                    tujuanInky = 0;
                    int powerUp = 1;
                    while (powerUp <= 30)
                    {
                        posisiHorizontalOld = posisiHorizontal;
                        posisiVerticalOld = posisiVertical;
                        bacaKeySebelumnya = bacaKey;
                        posisiBlinkyHorizontalOld = posisiBlinkyHorizontal;
                        posisiBlinkyVerticalOld = posisiBlinkyVertical;
                        posisiPinkyHorizontalOld = posisiPinkyHorizontal;
                        posisiPinkyVerticalOld = posisiPinkyVertical;
                        posisiInkyHorizontalOld = posisiInkyHorizontal;
                        posisiInkyVerticalOld = posisiInkyVertical;
                        if (Console.KeyAvailable)
                            bacaKey = Console.ReadKey(true).Key;
                        switch (bacaKey) //cek ada wall atau tidak
                        {
                            case ConsoleKey.RightArrow:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.D:
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 1 || entityPosition[posisiHorizontal + 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.A:
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.UpArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.W:
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.DownArrow:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                            case ConsoleKey.S:
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                                    bacaKey = bacaKeySebelumnya;
                                break;
                        }
                        //menggerakkan pacman
                        if (bacaKey == ConsoleKey.RightArrow || bacaKey == ConsoleKey.D) //gerak pacman ke kanan
                        {
                            if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1 && entityPosition[posisiHorizontal + 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal + 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal += 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
                        {
                            if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1 && entityPosition[posisiHorizontal - 3, posisiVertical] != 8)
                            {
                                if (entityPosition[posisiHorizontal - 3, posisiVertical] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiHorizontal -= 3;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1 && entityPosition[posisiHorizontal, posisiVertical - 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical - 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical--;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
                        {
                            if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                            {
                                if (entityPosition[posisiHorizontal, posisiVertical + 1] == 2)
                                {
                                    score += 50;
                                    Console.SetCursorPosition(8, 32);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(score);
                                }
                                posisiVertical++;
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                                Console.SetCursorPosition(posisiHorizontalOld, posisiVerticalOld);
                                Console.Write(" ");
                                entityPosition[posisiHorizontalOld, posisiVerticalOld] = 0;
                            }
                        }
                        if (powerUp % 2 == 0) //frightened phase/power up
                        {
                            if (tujuanBlinky == 0)
                            {
                                if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiBlinkyHorizontal)
                                        tujuanBlinky = 1;
                                    else
                                        tujuanBlinky = 2;
                                }
                                else
                                {
                                    if (posisiVertical >= posisiBlinkyVertical)
                                        tujuanBlinky = 3;
                                    else
                                        tujuanBlinky = 4;
                                }
                            }
                            if (tujuanBlinky == 1) //menentukan rute tercepat (menjauhi pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiBlinkyHorizontal >= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 2)
                            {
                                if (posisiHorizontal >= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                                {
                                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                        tujuanBlinky = 3;
                                    else if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                        tujuanBlinky = 4;
                                    if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                        else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 3)
                            {
                                if (posisiBlinkyVertical >= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                            tujuanBlinky = 4;
                                    }
                                }
                            }
                            else if (tujuanBlinky == 4)
                            {
                                if (posisiVertical >= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    else if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                    if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 1;
                                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                            tujuanBlinky = 2;
                                        else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                            tujuanBlinky = 3;
                                    }
                                }
                            }
                            if (tujuanPinky == 0 && score >= 100) //menentukan arah jalan awal Pinky
                            {
                                if (Math.Abs(posisiHorizontal - posisiPinkyHorizontal) <= Math.Abs(posisiVertical - posisiPinkyVertical))
                                {
                                    if (posisiHorizontal >= posisiPinkyHorizontal)
                                        tujuanPinky = 1; //Pinky jalan ke kiri
                                    else
                                        tujuanPinky = 2; //Pinky jalan ke kanan
                                }
                                else
                                {
                                    if (posisiVertical >= posisiPinkyVertical)
                                        tujuanPinky = 3; //Pinky jalan ke atas
                                    else
                                        tujuanPinky = 4; //Pinky jalan ke atas
                                }
                            }
                            if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                            {
                                if (posisiPinkyHorizontal >= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                    }
                                }
                            }
                            else if (tujuanPinky == 2)
                            {
                                if (posisiHorizontal >= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                                {
                                    if (posisiVertical - 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                        tujuanPinky = 3;
                                    else if (posisiVertical + 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
                                    if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                    }
                                }
                            }
                            else if (tujuanPinky == 3)
                            {
                                if (posisiPinkyVertical >= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                            tujuanPinky = 4;
                                    }
                                }
                            }
                            else if (tujuanPinky == 4)
                            {
                                if (posisiVertical >= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                                {
                                    if (posisiHorizontal - 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (posisiHorizontal + 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                    if (tujuanPinky == 4 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                                    {
                                        if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 1;
                                        else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                            tujuanPinky = 2;
                                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                            tujuanPinky = 3;
                                    }
                                }
                            }
                            if (statusInky > 2)
                            {
                                if (tujuanInky == 0 && score >= 1500) //menentukan jalan awal inky
                                {
                                    if (Math.Abs(posisiHorizontal - posisiInkyHorizontal) <= Math.Abs(posisiVertical - posisiInkyVertical))
                                    {
                                        if (posisiHorizontal <= posisiInkyHorizontal)
                                            tujuanInky = 1;
                                        else
                                            tujuanInky = 2;
                                    }
                                    else
                                    {
                                        if (posisiVertical <= posisiInkyVertical)
                                            tujuanInky = 3;
                                        else
                                            tujuanInky = 4;
                                    }
                                }
                                if (tujuanInky == 1) //menentukan rute tercepat (target : +6 horizontal atau +2 vertical) dan mengecek wall/ghost/door
                                {
                                    if (posisiInkyHorizontal >= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                        }
                                    }
                                }
                                else if (tujuanInky == 2)
                                {
                                    if (posisiHorizontal >= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                                    {
                                        if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) - posisiBlinkyHorizontal > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                            tujuanInky = 3;
                                        else if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) + posisiBlinkyHorizontal <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                            tujuanInky = 4;
                                        if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                            else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                        }
                                    }
                                }
                                else if (tujuanInky == 3)
                                {
                                    if (posisiInkyVertical >= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                                tujuanInky = 4;
                                        }
                                    }
                                }
                                else if (tujuanInky == 4)
                                {
                                    if (posisiVertical >= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                                    {
                                        if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) - posisiBlinkyVertical > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                            tujuanInky = 1;
                                        else if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) + posisiBlinkyVertical <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                            tujuanInky = 2;
                                        if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8))
                                        {
                                            if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                                tujuanInky = 1;
                                            else if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                                tujuanInky = 2;
                                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                                tujuanInky = 3;
                                        }
                                    }
                                }
                            }
                            if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
                            {
                                posisiBlinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
                            {
                                posisiBlinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 3) //menggerakkan blinky ke atas
                            {
                                posisiBlinkyVertical--;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
                            {
                                posisiBlinkyVertical++;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanPinky == 1) //menggerakkan pinky ke kiri
                            {
                                posisiPinkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 2) //menggerakkan pinky ke kanan
                            {
                                posisiPinkyHorizontal += 3;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 3) //menggerakkan pinky ke atas
                            {
                                posisiPinkyVertical--;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanPinky == 4) //menggerakkan pinky ke bawah
                            {
                                posisiPinkyVertical++;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiPinkyHorizontalOld, posisiPinkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            if (tujuanInky == 1) //menggerakkan inky ke kiri
                            {
                                posisiInkyHorizontal -= 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 2) //menggerakkan inky ke kanan
                            {
                                posisiInkyHorizontal += 3;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 3) //menggerakkan inky ke atas
                            {
                                posisiInkyVertical--;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                            else if (tujuanInky == 4) //menggerakkan inky ke bawah
                            {
                                posisiInkyVertical++;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("@");
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 0)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.Write(" ");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 2)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(".");
                                }
                                else if (entityPosition[posisiInkyHorizontalOld, posisiInkyVerticalOld] == 7)
                                {
                                    Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("o");
                                }
                            }
                        }
                        if ((posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical))
                        {
                            Console.Beep(500, 300);
                            if (posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical)
                            {
                                tujuanBlinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical)
                            {
                                tujuanPinky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                            if (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)
                            {
                                tujuanInky = 5; //supaya tidak kemana-mana (berhenti)
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.Write(" ");
                                Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("C");
                            }
                        }
                        if (score == 17900) //Jika semua makanan habis
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@"
              /$$$$$$$$/$$                        /$$             /$$     /$$               
             |__  $$__| $$                       | $$            |  $$   /$$/               
                | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                            Console.Beep(500, 200);
                            Console.Beep(600, 300);
                            Console.Beep(700, 300);
                            Console.Beep(800, 500);
                            System.Threading.Thread.Sleep(3000);
                            goto stagePage;
                        }
                        if ((powerUp == 30 || tujuanBlinky == 5) || (powerUp == 30 || tujuanPinky == 5) || (powerUp == 30 || tujuanInky == 5))
                        {
                            if (powerUp == 30 || tujuanBlinky == 5) //respawn blinky
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontalOld, posisiBlinkyVerticalOld);
                                Console.Write(" ");
                                tujuanBlinky = 0;
                                posisiBlinkyHorizontal = 48;
                                posisiBlinkyVertical = 13;
                                statusBlinky = 0;
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 30 || tujuanPinky == 5) //respawn pinky
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontalOld, posisiPinkyVerticalOld);
                                Console.Write(" ");
                                tujuanPinky = 0;
                                posisiPinkyHorizontal = 50;
                                posisiPinkyVertical = 13;
                                statusPinky = 0;
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp == 30 || tujuanInky == 5) //respawn inky
                            {
                                Console.SetCursorPosition(posisiInkyHorizontalOld, posisiInkyVerticalOld);
                                Console.Write(" ");
                                tujuanInky = 0;
                                posisiInkyHorizontal = 52;
                                posisiInkyVertical = 13;
                                statusInky = 0;
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                break;
                            }
                        }
                        if ((powerUp >= 25 && powerUp < 30 && tujuanBlinky != 5) || (powerUp >= 25 && powerUp < 30 && tujuanPinky != 5) || (powerUp >= 25 && powerUp < 30 && tujuanInky != 5))
                        {
                            if (powerUp >= 25 && powerUp < 30 && tujuanBlinky != 5)
                            {
                                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 25 && powerUp < 30 && tujuanPinky != 5)
                            {
                                Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                            if (powerUp >= 25 && powerUp < 30 && tujuanInky != 5)
                            {
                                Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("@");
                                break;
                            }
                        }
                        System.Threading.Thread.Sleep(400);
                        powerUp++;
                    }
                }
                System.Threading.Thread.Sleep(400);
            }
        }
        else if (pilihLevel == ConsoleKey.D4 || pilihLevel == ConsoleKey.NumPad4)
        {
            Console.Beep(300, 400);
            System.Environment.Exit(0);
        }
    }
}