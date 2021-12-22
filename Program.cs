using System;

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
        int tujuanBlinky = 0;
        int score = 0;
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
        Console.SetWindowSize(94,32); //merubah ukuran window sesuai map
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
        Console.Write($"Score : {score}");
        ConsoleKey bacaKey = Console.ReadKey(true).Key;
        while (score < 17900) //perulangan game
        {
            int posisiHorizontalOld = posisiHorizontal;
            int posisiVerticalOld = posisiVertical;
            ConsoleKey bacaKeySebelumnya = bacaKey;
            int posisiBLinkyHorizontalOld = posisiBlinkyHorizontal;
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
                case ConsoleKey.LeftArrow:
                    if (entityPosition[posisiHorizontal - 3, posisiVertical] == 1 || entityPosition[posisiHorizontal - 3, posisiVertical] == 8)
                        bacaKey = bacaKeySebelumnya;
                    break;
                case ConsoleKey.UpArrow:
                    if (entityPosition[posisiHorizontal, posisiVertical - 1] == 1 || entityPosition[posisiHorizontal, posisiVertical - 1] == 8)
                        bacaKey = bacaKeySebelumnya;
                    break;
                case ConsoleKey.DownArrow:
                    if (entityPosition[posisiHorizontal, posisiVertical + 1] == 1 || entityPosition[posisiHorizontal, posisiVertical + 1] == 8)
                        bacaKey = bacaKeySebelumnya;
                    break;
            }
            //menggerakkan pacman
            if (bacaKey == ConsoleKey.RightArrow) //gerak pacman ke kanan
            {
                if (entityPosition[posisiHorizontal + 3, posisiVertical] != 1 && entityPosition[posisiHorizontal + 3, posisiVertical] != 8)
                {
                    if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                    {
                        score += 50;
                        Console.SetCursorPosition(8, 31);
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
            if (bacaKey == ConsoleKey.LeftArrow) //gerak pacman ke kiri
            {
                if (entityPosition[posisiHorizontal - 3, posisiVertical] != 1 && entityPosition[posisiHorizontal - 3, posisiVertical] != 8)
                {
                    if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                    {
                        score += 50;
                        Console.SetCursorPosition(8, 31);
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
            if (bacaKey == ConsoleKey.UpArrow) //gerak pacman ke atas
            {
                if (entityPosition[posisiHorizontal, posisiVertical - 1] != 1 && entityPosition[posisiHorizontal, posisiVertical - 1] != 8)
                {
                    if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                    {
                        score += 50;
                        Console.SetCursorPosition(8, 31);
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
            if (bacaKey == ConsoleKey.DownArrow) //gerak pacman ke bawah
            {
                if (entityPosition[posisiHorizontal, posisiVertical + 1] != 1 && entityPosition[posisiHorizontal, posisiVertical + 1] != 8)
                {
                    if (entityPosition[posisiHorizontal, posisiVertical] == 2)
                    {
                        score += 50;
                        Console.SetCursorPosition(8, 31);
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
            if (tujuanBlinky == 1) //mengecek ada wall/tidak dan menentukan rute tercepat
            {
                if (posisiBlinkyHorizontal <= posisiHorizontal || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8)
                {
                    if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                        tujuanBlinky = 3;
                    if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                        tujuanBlinky = 4;
                    if (tujuanBlinky == 1 && (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] == 8))
                    {
                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                            tujuanBlinky = 3;
                        if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                            tujuanBlinky = 4;
                    }
                }
            }
            else
            {
                if (tujuanBlinky == 2)
                {
                    if (posisiHorizontal <= posisiBlinkyHorizontal || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8)
                    {
                        if (posisiVertical <= posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                            tujuanBlinky = 3;
                        if (posisiVertical > posisiBlinkyVertical && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                            tujuanBlinky = 4;
                        if (tujuanBlinky == 2 && (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 1 || entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] == 8))
                        {
                            if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] != 8)
                                tujuanBlinky = 3;
                            if (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 1 && entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] != 8)
                                tujuanBlinky = 4;
                        }
                    }
                }
                else
                {
                    if (tujuanBlinky == 3)
                    {
                        if (posisiBlinkyVertical <= posisiVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8)
                        {
                            if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 1;
                            if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                tujuanBlinky = 2;
                            if (tujuanBlinky == 3 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical - 1] == 8))
                            {
                                if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 1;
                                if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                            }
                        }
                    }
                    else
                    {
                        if (tujuanBlinky == 4)
                        {
                            if (posisiVertical <= posisiBlinkyVertical || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8)
                            {
                                if (posisiHorizontal <= posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 1;
                                if (posisiHorizontal > posisiBlinkyHorizontal && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                    tujuanBlinky = 2;
                                if (tujuanBlinky == 4 && (entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 1 || entityPosition[posisiBlinkyHorizontal, posisiBlinkyVertical + 1] == 8))
                                {
                                    if (entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal - 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 1;
                                    if (entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 1 && entityPosition[posisiBlinkyHorizontal + 3, posisiBlinkyVertical] != 8)
                                        tujuanBlinky = 2;
                                }
                            }
                        }
                    }
                }
            }
            if (tujuanBlinky == 1) //menggerakkan blinky ke kiri
            {
                posisiBlinkyHorizontal -= 3;
                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");
                Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                Console.Write(" ");
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.Write(" ");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 5)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 6)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("o");
                }
            }
            if (tujuanBlinky == 2) //menggerakkan blinky ke kanan
            {
                posisiBlinkyHorizontal += 3;
                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");
                Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                Console.Write(" ");
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.Write(" ");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 5)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 6)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("o");
                }
            }
            if (tujuanBlinky == 3) //menggerakkan blinky ke atas
            {
                posisiBlinkyVertical -= 1;
                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");
                Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                Console.Write(" ");
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.Write(" ");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 5)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 6)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("o");
                }
            }
            if (tujuanBlinky == 4) //menggerakkan blinky ke bawah
            {
                posisiBlinkyVertical += 1;
                Console.SetCursorPosition(posisiBlinkyHorizontal, posisiBlinkyVertical);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");
                Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                Console.Write(" ");
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 0)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.Write(" ");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 2)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 5)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 6)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("@");
                }
                if (entityPosition[posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld] == 7)
                {
                    Console.SetCursorPosition(posisiBLinkyHorizontalOld, posisiBlinkyVerticalOld);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("o");
                }
            }
            System.Threading.Thread.Sleep(400);
        }
        if (score == 17900) //semua makanan habis
        {
            Console.Clear();
            Console.WriteLine(@"
            /$$$$$$$$/$$                        /$$             /$$     /$$               
            |__  $$__| $$                       | $$            |  $$   /$$/               
            | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
            | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
            | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
            | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
            | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
            |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ ");
            Console.SetCursorPosition(44, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("YOU WIN THIS GAME!!!\n\n");
        }
    }
}