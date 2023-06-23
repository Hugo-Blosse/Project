namespace Project
{
    class Fight
    {
        public static bool Rat = false;
        private static int hp = 200;
        private static int hpShow = hp;
        private static int enemyhp = 200;
        private static int n = 1;
        public static bool once = false;
        public static void FightMoves(DifficulityLevel difficulity, Crewmates crew, Saboteur saboteur)
        {
            switch (crew.Name)
            {
                case Names.Aurelia:
                    Fighter(difficulity, Attack.FireBreath, crew, saboteur);
                    break;
                case Names.Bob:
                    Fighter(difficulity, Attack.Throw, crew, saboteur);
                    break;
                case Names.Clobert:
                    Fighter(difficulity, Attack.SuckerPunch, crew, saboteur);
                    break;
            }
        }

        public static void Fighter(DifficulityLevel difficulity, Attack attack, Crewmates crew, Saboteur saboteur)
        {
            bool moreDmg = Menu.Inventory.List.Any(name => name.Name == "Kastety");
            Random random = new Random();
            int enemyDmg = 10;
            switch (difficulity)
            {
                case DifficulityLevel.Easy:
                    enemyDmg = 10;
                    break;
                case DifficulityLevel.Medium:
                    enemyDmg = 20;
                    break;
                case DifficulityLevel.Hard:
                    enemyDmg = 30;
                    break;
            }
            while (hp > 0 && enemyhp > 0)
            {
                Console.Clear();
                int dmgReduction = 1;
                int dmg = 15;
                if (moreDmg) { dmg = 30; }
                Draw(crew, 0);
                int choice = ErrorCatch.Error2("Co robisz?\n 1 - zaatakuj\n 2 - osłoń się przed atakiem");
                if (choice == 1 && (attack != Attack.SuckerPunch || n != 3)) { enemyhp -= random.Next(20) + dmg; Draw(crew, 1); Console.WriteLine("Przeciwnikowi zostaje " + enemyhp + " hp."); }
                if (choice == 2) { dmgReduction = 5; if (attack != Attack.SuckerPunch || n != 3) { Draw(crew, 2); } }
                if (attack != Attack.SuckerPunch || n != 3)
                {
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (enemyhp <= 0)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    if (saboteur.Name != crew.Name.ToString())
                    {
                        Menu.Ending5();
                    }
                    Console.WriteLine(crew.Name + " leży na ziemi. Pokonałeś zdrajcę.");
                    Puzzles.Search("Sprawdzasz czy " + crew.Name + " nie ma przy sobie czegoś przydatnego", "Kartkę z kodem bomby!");
                    Menu.Inventory.AddItem(new Item { Name = "Kartka z kodem bomby", Description = Puzzles.BombCode });
                    once = true;
                    break;
                }
                switch (n)
                {
                    case 1:
                        hp -= (random.Next(15) + enemyDmg) / dmgReduction;
                        n += 1;
                        hpShow = hp;
                        if (hpShow < 0) hpShow = 0;
                        if (dmgReduction == 1) { Draw(crew, 3); Console.WriteLine(crew.Name + " atakuje! Zostało ci " + hpShow + " hp."); }
                        if (dmgReduction == 5) { Draw(crew, 4); Console.WriteLine(crew.Name + " atakuje! Zostało ci " + hpShow + " hp."); }
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                        break;
                    case 2:
                        if (attack == Attack.FireBreath || attack == Attack.Throw)
                        {
                            n += 1;
                            Draw(crew, 0);
                            Console.WriteLine(crew.Name + (" przygotowuje się..."));
                            Console.WriteLine("Kliknij enter, żeby kontynuować.");
                            Console.ReadLine();
                        }
                        if (attack == Attack.SuckerPunch)
                        {
                            hp -= (random.Next(10) + enemyDmg) / dmgReduction;
                            if (dmgReduction == 1) { Draw(crew, 3); }
                            if (dmgReduction == 5) { Draw(crew, 4); }
                            hpShow = hp;
                            if (hpShow < 0) hpShow = 0;
                            Console.WriteLine(crew.Name + " atakuje! Zostało ci " + hpShow+ " hp.");
                            Console.WriteLine(crew.Name + " wygląda na gotowego do skontrowania ataku.");
                            Console.WriteLine("Kliknij enter, żeby kontynuować.");
                            Console.ReadLine();
                            n += 1;
                        }
                        break;
                    case 3:
                        if (attack == Attack.FireBreath)
                        {
                            DrawSpecial(crew, random.Next(2, 7), enemyDmg / dmgReduction);
                        }
                        if (attack == Attack.Throw)
                        {
                            DrawSpecial(crew, 0, dmgReduction);
                            hp -= (enemyDmg / 10) * 150 / dmgReduction;
                            hpShow = hp;
                            if (hpShow < 0) hpShow = 0;
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            Console.WriteLine(crew.Name + " rzuca w kulą ciebie! Zostało ci " + hpShow + " hp.");
                            Console.WriteLine("Kliknij enter, żeby kontynuować.");
                            Console.ReadLine();
                        }
                        if (attack == Attack.SuckerPunch)
                        {
                            hp -= 10 + enemyDmg / 2;
                            hpShow = hp;
                            if (hpShow < 0) hpShow = 0;
                            if (dmgReduction == 1)
                            {
                                hp -= 80;
                                hpShow = hp;
                                if (hpShow < 0) hpShow = 0;
                                Draw(crew, 3);
                                Console.WriteLine(crew.Name + " kontruje twój atak! Zostało ci " + hpShow + " hp.");
                            }
                            else
                            {
                                Draw(crew, 4);
                                Console.WriteLine(crew.Name + " atakuje! Zostało ci " + hpShow + " hp.");
                            }
                            Console.WriteLine("Kliknij enter, żeby kontynuować.");
                            Console.ReadLine();
                        }
                        n = 1;
                        break;
                }
                if (Rat && hp <= 0 && hp >= -149)
                {
                    hp += 150;
                    hpShow = hp;
                    Console.WriteLine("Szczur Franek: Łap to, wyleczysz się!");
                    Console.WriteLine(crew.Name + ": uciekaj stąd przebrzydły szczurze!");
                    Console.WriteLine("Wyleczyłeś się do " + hpShow + " hp! Szczur Franek nie pomoże ci już w tej walce.");
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                    Rat = false;
                }
            }
            if (hp <= 0) { Menu.Ending6(); }
        }
        public static void Draw(Crewmates crew, int action)
        {
            switch (crew.Name)
            {
                case Names.Aurelia:
                    switch (action)
                    {
                        case 0:
                            Console.WriteLine(@"   __              ,,  ");
                            Console.WriteLine(@"  /..\            /..\");
                            Console.WriteLine(@"  \^^/            |  |");
                            Console.WriteLine(@"  .||.O O      O O.||. ");
                            Console.WriteLine(@"  |\ ////      \\\\ /|");
                            Console.WriteLine(@"  |\\/\/        \/\//");
                            Console.WriteLine(@"  |  |             || ");
                            Console.WriteLine(@"  |__|            /__\");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 1:
                            Console.WriteLine(@"   __              ,,  ");
                            Console.WriteLine(@"  /..\            /..\");
                            Console.WriteLine(@"  \^^/            |  |");
                            Console.WriteLine(@"  .||.O______..O O.||. ");
                            Console.WriteLine(@"  |\ //------**\\\\ /|");
                            Console.WriteLine(@"  |\\/          \/\//");
                            Console.WriteLine(@"  |  |             || ");
                            Console.WriteLine(@"  |__|            /__\");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 2:
                            Console.WriteLine(@"   __              ,,  ");
                            Console.WriteLine(@"  /..\  O O       /..\");
                            Console.WriteLine(@"  \^^/  |||       |  |");
                            Console.WriteLine(@"  .||.__|||    O O.||. ");
                            Console.WriteLine(@"  |====='''    \\\\ /|");
                            Console.WriteLine(@"  |  |          \/\//");
                            Console.WriteLine(@"  |  |             || ");
                            Console.WriteLine(@"  |__|            /__\");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 3:
                            Console.WriteLine(@"   __              ,,  ");
                            Console.WriteLine(@"  /..\            /..\");
                            Console.WriteLine(@"  \^^/            |  |");
                            Console.WriteLine(@"  .||.O O..______O.||. ");
                            Console.WriteLine(@"  |\ ////**------\\ /|");
                            Console.WriteLine(@"  |\\/\/          \//");
                            Console.WriteLine(@"  |  |             || ");
                            Console.WriteLine(@"  |__|            /__\");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 4:
                            Console.WriteLine(@"   __              ,,  ");
                            Console.WriteLine(@"  /..\  O O       /..\");
                            Console.WriteLine(@"  \^^/  |||       |  |");
                            Console.WriteLine(@"  .||.__|||._____O.||. ");
                            Console.WriteLine(@"  |====='''*-----\\ /|");
                            Console.WriteLine(@"  |  |            \//");
                            Console.WriteLine(@"  |  |             || ");
                            Console.WriteLine(@"  |__|            /__\");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                    }
                    break;
                case Names.Bob:
                    switch (action)
                    {
                        case 0:
                            Console.WriteLine(@"   __              __ ");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            |ww|");
                            Console.WriteLine(@"  .||.O O     O  O.||.. ");
                            Console.WriteLine(@"  |\ ////     \\ \\ //|");
                            Console.WriteLine(@"  |\\/\/       \/|\// |");
                            Console.WriteLine(@"  |  |           |    |");
                            Console.WriteLine(@"  |__|           |____|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 1:
                            Console.WriteLine(@"   __              __  ");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            |ww|");
                            Console.WriteLine(@"  .||.O_____..O  O.||.. ");
                            Console.WriteLine(@"  |\ //-----**\\ \\ //|");
                            Console.WriteLine(@"  |\\/         \/|\// |");
                            Console.WriteLine(@"  |  |           |    | ");
                            Console.WriteLine(@"  |__|           |____|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 2:
                            Console.WriteLine(@"   __              __  ");
                            Console.WriteLine(@"  /..\  O O       |..|");
                            Console.WriteLine(@"  \^^/  |||       |ww|");
                            Console.WriteLine(@"  .||.__|||   O  O.||.. ");
                            Console.WriteLine(@"  |====='''   \\ \\ //|");
                            Console.WriteLine(@"  |  |         \/|\// |");
                            Console.WriteLine(@"  |  |           |    | ");
                            Console.WriteLine(@"  |__|           |____|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 3:
                            Console.WriteLine(@"   __              __  ");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            |ww|");
                            Console.WriteLine(@"  .||.O O..______O.||..");
                            Console.WriteLine(@"  |\ ////**------\\ //|");
                            Console.WriteLine(@"  |\\/\/         |\// |");
                            Console.WriteLine(@"  |  |           |    | ");
                            Console.WriteLine(@"  |__|           |____|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 4:
                            Console.WriteLine(@"   __              __  ");
                            Console.WriteLine(@"  /..\  O O       |..|");
                            Console.WriteLine(@"  \^^/  |||       |ww|");
                            Console.WriteLine(@"  .||.__|||._____O.||.. ");
                            Console.WriteLine(@"  |_____//**-----\\ //|");
                            Console.WriteLine(@"  |  |           |\// |");
                            Console.WriteLine(@"  |  |           |    | ");
                            Console.WriteLine(@"  |__|           |____|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                    }
                    break;
                case Names.Clobert:
                    switch (action)
                    {
                        case 0:
                            Console.WriteLine(@"   __              ss");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            \  /");
                            Console.WriteLine(@"  .||.O O      O O.||. ");
                            Console.WriteLine(@"  |\ ////      \\\\ /|");
                            Console.WriteLine(@"  |\\/\/        \/\//|");
                            Console.WriteLine(@"  |  |            |  | ");
                            Console.WriteLine(@"  |__|            |__|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 1:
                            Console.WriteLine(@"   __              ss  ");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            \  /");
                            Console.WriteLine(@"  .||.O______..O O.||. ");
                            Console.WriteLine(@"  |\ //------**\\\\ /|");
                            Console.WriteLine(@"  |\\/          \/\//|");
                            Console.WriteLine(@"  |  |            |  | ");
                            Console.WriteLine(@"  |__|            |__|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 2:
                            Console.WriteLine(@"   __              ss  ");
                            Console.WriteLine(@"  /..\  O O       |..|");
                            Console.WriteLine(@"  \^^/  |||       \  /");
                            Console.WriteLine(@"  .||.__|||    O O.||. ");
                            Console.WriteLine(@"  |_____//     \\\\ /|");
                            Console.WriteLine(@"  |  |          \/\//|");
                            Console.WriteLine(@"  |  |            |  | ");
                            Console.WriteLine(@"  |__|            |__|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 3:
                            Console.WriteLine(@"   __              ss  ");
                            Console.WriteLine(@"  /..\            |..|");
                            Console.WriteLine(@"  \^^/            \  /");
                            Console.WriteLine(@"  .||.O O..______O.||. ");
                            Console.WriteLine(@"  |\ ////**------\\ /|");
                            Console.WriteLine(@"  |\\/\/          \//|");
                            Console.WriteLine(@"  |  |            |  | ");
                            Console.WriteLine(@"  |__|            |__|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                        case 4:
                            Console.WriteLine(@"   __              ss  ");
                            Console.WriteLine(@"  /..\  O O       |..|");
                            Console.WriteLine(@"  \^^/  |||       \  /");
                            Console.WriteLine(@"  .||.__|||._____O.||. ");
                            Console.WriteLine(@"  |====='''*-----\\ /|");
                            Console.WriteLine(@"  |  |            \//|");
                            Console.WriteLine(@"  |  |            |  | ");
                            Console.WriteLine(@"  |__|            |__|");
                            Console.WriteLine(@"  \\ \\          // //");
                            Console.WriteLine(@"   \\ \\        // //  ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   || ||        || ||    ");
                            Console.WriteLine(@"   !_\!_\      /_!/_! ");
                            Console.WriteLine(@"-----------------------");
                            Console.WriteLine(@"Kapitan        " + crew.Name);
                            Console.WriteLine(hpShow + "                " + enemyhp);
                            break;
                    }
                    break;
            }
        }
        public static void DrawSpecial(Crewmates crew, int repeat, int damage)
        {
            switch (crew.Name)
            {
                case Names.Aurelia:
                    Console.WriteLine(@"   __                  ,,  ");
                    Console.Write(@"  /..\  O O"); Puzzles.Tips("~ ~  ~~ "); Console.WriteLine(@"   /..\");
                    Console.Write(@"  \^^/  |||"); Puzzles.Tips("~ ~  ~ ~^ "); Console.WriteLine("<|  |");
                    Console.Write(@"  .||.__|||"); Puzzles.Tips("~ ~~ ~"); Console.WriteLine("  O &.||. ");
                    Console.WriteLine(@"  |====='''        \\\\ /|");
                    Console.WriteLine(@"  |  |              \/\//");
                    Console.WriteLine(@"  |  |                 || ");
                    Console.WriteLine(@"  |__|                /__\");
                    Console.WriteLine(@"  \\ \\              // //");
                    Console.WriteLine(@"   \\ \\            // //  ");
                    Console.WriteLine(@"   || ||            || ||    ");
                    Console.WriteLine(@"   || ||            || ||    ");
                    Console.WriteLine(@"   !_\!_\          /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Console.WriteLine(crew.Name + " podpala cię! Zostało ci " + hpShow + " hp.");
                    Console.WriteLine("Kliknij enter, żeby kontynuować");
                    Console.ReadLine();
                    Console.Clear();
                    hp -= 3 * damage;
                    hpShow = hp;
                    if (hpShow < 0) hpShow = 0;
                    if (repeat >= 0) DrawSpecial(crew, repeat - 1, damage);
                    break;
                case Names.Bob:
                    Console.WriteLine(@"   __              __ ");
                    Console.WriteLine(@"  /..\            |..|");
                    Console.WriteLine(@"  \^^/       ()   |ww|");
                    Console.WriteLine(@"  .||.O O     O  O.||.. ");
                    Console.WriteLine(@"  |\ ////     \\ \\ //|");
                    Console.WriteLine(@"  |\\/\/       \/|\// |");
                    Console.WriteLine(@"  |  |           |    |");
                    Console.WriteLine(@"  |__|           |____|");
                    Console.WriteLine(@"  \\ \\          // //");
                    Console.WriteLine(@"   \\ \\        // //  ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   !_\!_\      /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.WriteLine(@"   __              __ ");
                    Console.WriteLine(@"  /..\            |..|");
                    Console.WriteLine(@"  \^^/      ()    |ww|");
                    Console.WriteLine(@"  .||.O O     O  O.||.. ");
                    Console.WriteLine(@"  |\ ////     \\ \\ //|");
                    Console.WriteLine(@"  |\\/\/       \/|\// |");
                    Console.WriteLine(@"  |  |           |    |");
                    Console.WriteLine(@"  |__|           |____|");
                    Console.WriteLine(@"  \\ \\          // //");
                    Console.WriteLine(@"   \\ \\        // //  ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   !_\!_\      /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.WriteLine(@"   __              __ ");
                    Console.WriteLine(@"  /..\            |..|");
                    Console.WriteLine(@"  \^^/     ()     |ww|");
                    Console.WriteLine(@"  .||.O O     O  O.||.. ");
                    Console.WriteLine(@"  |\ ////     \\ \\ //|");
                    Console.WriteLine(@"  |\\/\/       \/|\// |");
                    Console.WriteLine(@"  |  |           |    |");
                    Console.WriteLine(@"  |__|           |____|");
                    Console.WriteLine(@"  \\ \\          // //");
                    Console.WriteLine(@"   \\ \\        // //  ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   !_\!_\      /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.WriteLine(@"   __              __ ");
                    Console.WriteLine(@"  /..\    ()      |..|");
                    Console.WriteLine(@"  \^^/            |ww|");
                    Console.WriteLine(@"  .||.O O     O  O.||.. ");
                    Console.WriteLine(@"  |\ ////     \\ \\ //|");
                    Console.WriteLine(@"  |\\/\/       \/|\// |");
                    Console.WriteLine(@"  |  |           |    |");
                    Console.WriteLine(@"  |__|           |____|");
                    Console.WriteLine(@"  \\ \\          // //");
                    Console.WriteLine(@"   \\ \\        // //  ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   !_\!_\      /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.WriteLine(@"   __              __ ");
                    Console.WriteLine(@"  /..\   ()       |..|");
                    Console.WriteLine(@"  \^^/            |ww|");
                    Console.WriteLine(@"  .||.O O     O  O.||.. ");
                    Console.WriteLine(@"  |\ ////     \\ \\ //|");
                    Console.WriteLine(@"  |\\/\/       \/|\// |");
                    Console.WriteLine(@"  |  |           |    |");
                    Console.WriteLine(@"  |__|           |____|");
                    Console.WriteLine(@"  \\ \\          // //");
                    Console.WriteLine(@"   \\ \\        // //  ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   || ||        || ||    ");
                    Console.WriteLine(@"   !_\!_\      /_!/_! ");
                    Console.WriteLine(@"-----------------------");
                    Console.WriteLine(@"Kapitan        " + crew.Name);
                    Console.WriteLine(hpShow + "                " + enemyhp);
                    Thread.Sleep(100);
                    Console.Clear();
                    if (damage == 1)
                    {
                        Console.WriteLine(@"   __              __ ");
                        Console.WriteLine(@"  /..\  ()        |..|");
                        Console.WriteLine(@"  \^^/            |ww|");
                        Console.WriteLine(@"  .||.O O     O  O.||.. ");
                        Console.WriteLine(@"  |\ ////     \\ \\ //|");
                        Console.WriteLine(@"  |\\/\/       \/|\// |");
                        Console.WriteLine(@"  |  |           |    |");
                        Console.WriteLine(@"  |__|           |____|");
                        Console.WriteLine(@"  \\ \\          // //");
                        Console.WriteLine(@"   \\ \\        // //  ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   !_\!_\      /_!/_! ");
                        Console.WriteLine(@"-----------------------");
                        Console.WriteLine(@"Kapitan        " + crew.Name);
                        Console.WriteLine(hpShow + "                " + enemyhp);
                        Thread.Sleep(100);
                        Console.Clear();
                        Console.WriteLine(@"   __              __ ");
                        Console.WriteLine(@"  /..\ ()         |..|");
                        Console.WriteLine(@"  \^^/            |ww|");
                        Console.WriteLine(@"  .||.O O     O  O.||.. ");
                        Console.WriteLine(@"  |\ ////     \\ \\ //|");
                        Console.WriteLine(@"  |\\/\/       \/|\// |");
                        Console.WriteLine(@"  |  |           |    |");
                        Console.WriteLine(@"  |__|           |____|");
                        Console.WriteLine(@"  \\ \\          // //");
                        Console.WriteLine(@"   \\ \\        // //  ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   !_\!_\      /_!/_! ");
                        Console.WriteLine(@"-----------------------");
                        Console.WriteLine(@"Kapitan        " + crew.Name);
                        Console.WriteLine(hpShow + "                " + enemyhp);
                        Thread.Sleep(100);
                        Console.Clear();
                        Console.WriteLine(@"   __              __ ");
                        Console.WriteLine(@"  /..\()          |..|");
                        Console.WriteLine(@"  \^^/            |ww|");
                        Console.WriteLine(@"  .||.O O     O  O.||.. ");
                        Console.WriteLine(@"  |\ ////     \\ \\ //|");
                        Console.WriteLine(@"  |\\/\/       \/|\// |");
                        Console.WriteLine(@"  |  |           |    |");
                        Console.WriteLine(@"  |__|           |____|");
                        Console.WriteLine(@"  \\ \\          // //");
                        Console.WriteLine(@"   \\ \\        // //  ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   !_\!_\      /_!/_! ");
                        Console.WriteLine(@"-----------------------");
                        Console.WriteLine(@"Kapitan        " + crew.Name);
                    }
                    if (damage == 5)
                    {
                        Console.WriteLine(@"   __              __  ");
                        Console.WriteLine(@"  /..\  O O       |..|");
                        Console.WriteLine(@"  \^^/  |||       |ww|");
                        Console.WriteLine(@"  .||.__|||   O  O.||.. ");
                        Console.WriteLine(@"  |====='''   \\ \\ //|");
                        Console.WriteLine(@"  |  |         \/|\// |");
                        Console.WriteLine(@"  |  |           |    | ");
                        Console.WriteLine(@"  |__|           |____|");
                        Console.WriteLine(@"  \\ \\          // //");
                        Console.WriteLine(@"   \\ \\        // //  ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   || ||        || ||    ");
                        Console.WriteLine(@"   !_\!_\      /_!/_! ");
                        Console.WriteLine(@"-----------------------");
                        Console.WriteLine(@"Kapitan        " + crew.Name);
                    }
                    break;
            }
        }
    }
}

