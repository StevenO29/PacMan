﻿using System;

class PacMan
{
    static void Main(string[] args)
    {
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
        int powerUp = 1;
        int score = 0;
        int livesPacMan = 3;
        Console.SetWindowSize(94, 33); //merubah ukuran window sesuai map (hapus ini jika dijalankan dengan mac)
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
        Console.Write($"Lives : {livesPacMan}");
        Console.SetCursorPosition(0, 32);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Score : {score}");
        ConsoleKey bacaKey = Console.ReadKey(true).Key;
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
                if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1 && entityPosition[posisiHorizontal + 3, posisiVertical] != 8)
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
            if (bacaKey == ConsoleKey.LeftArrow || bacaKey == ConsoleKey.A) //gerak pacman ke kiri
            {
                if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1 && entityPosition[posisiHorizontal - 3, posisiVertical] != 8)
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
            if (bacaKey == ConsoleKey.UpArrow || bacaKey == ConsoleKey.W) //gerak pacman ke atas
            {
                if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1 && entityPosition[posisiHorizontal, posisiVertical - 1] != 8)
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
            if (bacaKey == ConsoleKey.DownArrow || bacaKey == ConsoleKey.S) //gerak pacman ke bawah
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
            if (statusBlinky <= 41)
            {
                if (statusBlinky <= 40)
                {
                    if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1) //cek atase ada wall
                    {
                        if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical != 4) //atas ada wall, kanan gaada wall, jalan ke kanan
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
                        else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1)//atas wall, kanan wall, jalan ke bawah
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
                        else if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && posisiBlinkyVertical == 4) //kiri gaada wall, bawah ada wall, jalan ke kiri
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
                    else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && posisiBlinkyHorizontal != 90) //atas gaada wall, x e bukan d 90, jalan ke bawah
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
                    }
                    else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && posisiBlinkyHorizontal == 90) //atas gaada wall, bawah gaada wall, x e d 90, jalan ke kiri
                    {
                        if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1)
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
                        else //jalan ke atas
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
                else
                {
                    Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                statusBlinky++;
                //System.Threading.Thread.Sleep(200);
            }
            //scatter Pinky
            if (statusPinky <= 45)
            {
                if (statusPinky <= 44)
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
                        if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1) //cek atase ada wall
                        {
                            if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && posisiPinkyVertical != 4) //atas ada wall, kiri gaada wall, jalan ke kiri
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
                            else if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1)//atas wall, kiri wall, jalan ke bawah
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
                            else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && posisiPinkyVertical == 4) //kanan gaada wall, y di 4, jalan ke kanan
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
                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal != 3) //atas gaada wall, x e bukan d 3, jalan ke bawah
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
                        else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && posisiPinkyHorizontal == 3) //atas gaada wall, bawah gaada wall, x e d 3
                        {
                            if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1) //kanan gaada wall, jalan ke kanan
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
                            else //kanan ada wall, jalan ke bawah
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
                else
                {
                    Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                statusPinky++;
                //System.Threading.Thread.Sleep(200);
            }
            if (score >= 1500)
            {
                //scatter inky
                if (statusInky <= 59)
                {
                    if (statusInky <= 58)
                    {
                        if (statusInky >= 0 && statusInky <= 2) //supaya keluar dari ghost house
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
                        else if (statusInky == 3) //setelah keluar dari ghost house
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
                            if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1) //bawah ada wall
                            {
                                if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && posisiInkyVertical != 29) //bawah ada wall, kanan gaada wall, jalan ke kanan
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
                                else if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && posisiInkyVertical == 29 && posisiInkyHorizontal > 63) //kiri gaada wall, y di 29, x di kanan 63, jalan ke kiri
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
                                else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && (posisiInkyHorizontal == 63 || posisiInkyHorizontal == 78)) //atas gaada wall, x di 63 atau 78, jalan ke atas
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
                            else if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1) //bawah bukan wall
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
                    else
                    {
                        Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".");
                    }
                    statusInky++;
                    //System.Threading.Thread.Sleep(200);
                }
            }
            //chase Blinky
            if (statusBlinky > 41)
            {
                if (tujuanBlinky == 0) //menentukan arah jalan awal blinky
                {
                    if (Math.Abs(posisiHorizontal - posisiBlinkyHorizontal) <= Math.Abs(posisiVertical - posisiBlinkyVertical))
                    {
                        if (posisiHorizontal <= posisiBlinkyHorizontal)
                            tujuanBlinky = 1; //blinky jalan ke kiri
                        else
                            tujuanBlinky = 2; //blinky jalan ke kanan
                    }
                    else
                    {
                        if (posisiVertical <= posisiBlinkyVertical)
                            tujuanBlinky = 3; //blinky jalan ke atas
                        else
                            tujuanBlinky = 4; //blinky jalan ke bawah
                    }
                }
                if (tujuanBlinky == 1) //menentukan rute tercepat dan mengecek wall/ghost/door
                {
                    if (posisiBlinkyHorizontal <= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                    {
                        if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                            tujuanBlinky = 3;
                        else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                            tujuanBlinky = 4;
                        if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                        {
                            if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                        }
                    }
                }
                else if (tujuanBlinky == 2)
                {
                    if (posisiHorizontal <= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                    {
                        if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                            tujuanBlinky = 3;
                        else if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                            tujuanBlinky = 4;
                        if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 5 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 6 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                        {
                            if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            else if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 5 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 6 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                        }
                    }
                }
                else if (tujuanBlinky == 3)
                {
                    if (posisiBlinkyVertical <= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                    {
                        if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                            tujuanBlinky = 1;
                        else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                            tujuanBlinky = 2;
                        if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                        {
                            if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6)
                                tujuanBlinky = 1;
                            else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                        }
                    }
                }
                else if (tujuanBlinky == 4)
                {
                    if (posisiVertical <= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                    {
                        if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                            tujuanBlinky = 1;
                        else if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                            tujuanBlinky = 2;
                        if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 5 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 6 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                        {
                            if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            else if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 5 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 6 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
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
                }
            }
            //chase Pinky
            if (statusPinky > 45)
            {
                if (tujuanPinky == 0 && score >= 100) //menentukan arah jalan awal Pinky
                {
                    if (Math.Abs((posisiHorizontal + 12) - posisiPinkyHorizontal) <= Math.Abs((posisiVertical + 4) - posisiPinkyVertical))
                    {
                        if (posisiHorizontal <= posisiPinkyHorizontal)
                            tujuanPinky = 1; //Pinky jalan ke kiri
                        else
                            tujuanPinky = 2; //Pinky jalan ke kanan
                    }
                    else
                    {
                        if (posisiVertical <= posisiPinkyVertical)
                            tujuanPinky = 3; //Pinky jalan ke atas
                        else
                            tujuanPinky = 4; //Pinky jalan ke atas
                    }
                }
                if (tujuanPinky == 1) //menentukan rute tercepat (target : +12 horizontal dan +4 vertical di depan pacman) dan mengecek wall/ghost/door
                {
                    if (posisiPinkyHorizontal <= posisiHorizontal || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8)
                    {
                        if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                            tujuanPinky = 3;
                        else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                            tujuanPinky = 4;
                        if (tujuanPinky == 1 && (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] == 8))
                        {
                            if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                        }
                    }
                }
                else if (tujuanPinky == 2)
                {
                    if (posisiHorizontal <= posisiPinkyHorizontal || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8)
                    {
                        if (posisiVertical - 4 <= posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                            tujuanPinky = 3;
                        else if (posisiVertical + 4 > posisiPinkyVertical && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                            tujuanPinky = 4;
                        if (tujuanPinky == 2 && (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 1 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 4 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 6 || entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] == 8))
                        {
                            if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 1 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 4 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 6 && entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] != 8)
                                tujuanPinky = 3;
                            else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                tujuanPinky = 4;
                        }
                    }
                }
                else if (tujuanPinky == 3)
                {
                    if (posisiPinkyVertical <= posisiVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8)
                    {
                        if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                            tujuanPinky = 1;
                        else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                            tujuanPinky = 2;
                        if (tujuanPinky == 3 && (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical - 1] == 8))
                        {
                            if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
                        }
                    }
                }
                else if (tujuanPinky == 4)
                {
                    if (posisiVertical <= posisiPinkyVertical || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8)
                    {
                        if (posisiHorizontal - 12 <= posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                            tujuanPinky = 1;
                        else if (posisiHorizontal + 12 > posisiPinkyHorizontal && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                            tujuanPinky = 2;
                        if (tujuanPinky == 4 && (entityPosition[posisiPinkyVertical, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                        {
                            if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 1;
                            else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                tujuanPinky = 2;
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
                }
            }
            if (score >= 1500)
            {
                //chase inky
                if (statusInky > 59)
                {
                    if (tujuanInky == 0 && score >= 1500) //menentukan jalan awal inky
                    {
                        if (Math.Abs(((posisiHorizontal + 6) + posisiBlinkyHorizontal) - posisiInkyHorizontal) <= Math.Abs(((posisiVertical + 2) + posisiBlinkyVertical) - posisiInkyVertical))
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
                        if (posisiInkyHorizontal <= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                        {
                            if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                tujuanInky = 3;
                            if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                tujuanInky = 4;
                            if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                            {
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                            }
                        }
                    }
                    else if (tujuanInky == 2)
                    {
                        if (posisiHorizontal <= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                        {
                            if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                tujuanInky = 3;
                            if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                tujuanInky = 4;
                            if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                            {
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                            }
                        }
                    }
                    else if (tujuanInky == 3)
                    {
                        if (posisiInkyVertical <= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                        {
                            if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                tujuanInky = 1;
                            if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                tujuanInky = 2;
                            if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                            {
                                if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                            }
                        }
                    }
                    else if (tujuanInky == 4)
                    {
                        if (posisiVertical <= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                        {
                            if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                tujuanInky = 1;
                            if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                tujuanInky = 2;
                            if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                            {
                                if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
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
                    }
                }
            }
            if ((posisiHorizontal == posisiBlinkyHorizontal && posisiVertical == posisiBlinkyVertical) || (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical) || (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)) //hantu nabrak pacman (game reset)
            {
                livesPacMan--;
                Console.SetCursorPosition(8, 31);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(livesPacMan);
                if (livesPacMan > 1)
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
                    posisiBlinkyVertical = 10;
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
                else if (livesPacMan < 1) //nyawa habis
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
                    break;
                }
            }
            if (score == 17900) //semua makanan habis
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"
            /$$$$$$$$/$$                        /$$            /$$     /$$               
            |__  $$__| $$                       | $$          |  $$   /$$/               
            | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
            | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
            | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
            | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
            | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
            |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                             YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                break;
            }
            if (entityPosition[posisiHorizontal, posisiVertical] == 7) //pacman makan power up
            {
                entityPosition[posisiHorizontal, posisiVertical] = 0;
                tujuanBlinky = 0;
                tujuanPinky = 0;
                tujuanInky = 0;
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
                                }
                            }
                        }
                        if (tujuanPinky == 0 && score >= 100) //menentukan arah jalan awal Pinky
                        {
                            if (Math.Abs((posisiHorizontal + 12) - posisiPinkyHorizontal) <= Math.Abs((posisiVertical + 4) - posisiPinkyVertical))
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
                        if (tujuanPinky == 1) //menentukan rute tercepat (menjauhi target) dan mengecek wall/ghost/door
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
                                    else if (entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] != 8)
                                        tujuanPinky = 4;
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
                                if (tujuanPinky == 4 && (entityPosition[posisiPinkyVertical, posisiPinkyVertical + 1] == 1 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 4 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 6 || entityPosition[posisiPinkyHorizontal, posisiPinkyVertical + 1] == 8))
                                {
                                    if (entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal - 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 1;
                                    else if (entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 1 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 4 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 6 && entityPosition[posisiPinkyHorizontal + 3, posisiPinkyVertical] != 8)
                                        tujuanPinky = 2;
                                }
                            }
                        }
                        if (tujuanInky == 0 && score >= 1500) //menentukan jalan awal inky
                        {
                            if (Math.Abs(((posisiHorizontal + 6) + posisiBlinkyHorizontal) - posisiInkyHorizontal) <= Math.Abs(((posisiVertical + 2) + posisiBlinkyVertical) - posisiInkyVertical))
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
                        if (tujuanInky == 1) //menentukan rute tercepat (menjauhi target) dan mengecek wall/ghost/door
                        {
                            if (posisiInkyHorizontal >= posisiHorizontal || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8)
                            {
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                    tujuanInky = 3;
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) < posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                if (tujuanInky == 1 && (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] == 8))
                                {
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                }
                            }
                        }
                        else if (tujuanInky == 2)
                        {
                            if (posisiHorizontal >= posisiInkyHorizontal || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8)
                            {
                                if ((posisiVertical - 2) - Math.Abs((posisiVertical - 2) - posisiBlinkyVertical) > posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical] != 8)
                                    tujuanInky = 3;
                                if ((posisiVertical + 2) + Math.Abs((posisiVertical + 2) - posisiBlinkyVertical) <= posisiInkyVertical && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                    tujuanInky = 4;
                                if (tujuanInky == 2 && (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 1 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 4 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 5 || entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] == 8))
                                {
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] != 8)
                                        tujuanInky = 3;
                                    if (entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 1 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 4 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 5 && entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] != 8)
                                        tujuanInky = 4;
                                }
                            }
                        }
                        else if (tujuanInky == 3)
                        {
                            if (posisiInkyVertical >= posisiVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8)
                            {
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                if (tujuanInky == 3 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                {
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
                                }
                            }
                        }
                        else if (tujuanInky == 4)
                        {
                            if (posisiVertical >= posisiInkyVertical || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical + 1] == 8)
                            {
                                if ((posisiHorizontal - 6) - Math.Abs((posisiHorizontal - 6) - posisiBlinkyHorizontal) > posisiInkyHorizontal && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                    tujuanInky = 1;
                                if ((posisiHorizontal + 6) + Math.Abs((posisiHorizontal + 6) - posisiBlinkyHorizontal) <= posisiInkyHorizontal && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                    tujuanInky = 2;
                                if (tujuanInky == 4 && (entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 1 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 4 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 5 || entityPosition[posisiInkyHorizontal, posisiInkyVertical - 1] == 8))
                                {
                                    if (entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal - 3, posisiInkyVertical] != 8)
                                        tujuanInky = 1;
                                    if (entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 1 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 4 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 5 && entityPosition[posisiInkyHorizontal + 3, posisiInkyVertical] != 8)
                                        tujuanInky = 2;
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
                        if (posisiBlinkyHorizontal == posisiHorizontal && posisiBlinkyVertical == posisiVertical)
                        {
                            tujuanBlinky = 5; //supaya tidak kemana-mana (berhenti)
                            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                            Console.Write(" ");
                            Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("C");
                        }
                        if (posisiPinkyHorizontal == posisiHorizontal && posisiPinkyVertical == posisiVertical)
                        {
                            tujuanPinky = 5; //supaya tidak kemana-mana (berhenti)
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.Write(" ");
                            Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("C");
                        }
                        if (posisiInkyHorizontal == posisiHorizontal && posisiInkyVertical == posisiVertical)
                        {
                            tujuanInky = 5; //supaya tidak kemana-mana (berhenti)
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.Write(" ");
                            Console.SetCursorPosition(posisiHorizontal, posisiVertical);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("C");
                        }
                    }
                    if (score == 17900) //semua makanan habis
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(@"
                    /$$$$$$$$/$$                        /$$            /$$     /$$               
                    |__  $$__| $$                       | $$          |  $$   /$$/               
                        | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
                        | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
                        | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
                        | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
                        | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
                        |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 

                                     YOU WIN THIS GAME!!! LET'S PLAY VALORANT :D");
                        break;
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
                            posisiPinkyHorizontal = 51;
                            posisiPinkyVertical = 13;
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
                            posisiInkyHorizontal = 54;
                            posisiInkyVertical = 13;
                            Console.SetCursorPosition(posisiInkyHorizontal, posisiInkyVertical);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("@");
                            break;
                        }
                    }
                    if ((powerUp >= 30 && powerUp < 40 && tujuanBlinky != 5) || (powerUp >= 30 && powerUp < 40 && tujuanPinky != 5) || (powerUp >= 30 && powerUp < 40 && tujuanInky != 5))
                    {
                        if (powerUp >= 30 && powerUp < 40 && tujuanBlinky != 5)
                        {
                            Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("@");
                            break;
                        }
                        if (powerUp >= 30 && powerUp < 40 && tujuanPinky != 5)
                        {
                            Console.SetCursorPosition(posisiPinkyHorizontal, posisiPinkyVertical);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("@");
                            break;
                        }
                        if (powerUp >= 30 && powerUp < 40 && tujuanInky != 5)
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
}