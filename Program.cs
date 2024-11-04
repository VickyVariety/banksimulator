using System;
using System.Collections.Generic;

namespace BankSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------- VARIABLER -------------------------
            double saldo = 0; // Saldot sätts till 0 (kr) vid start.

            /* - Användaren välkomnas av en meny och att göra ett val från 1-5. 
               - En while-loop tillåter användaren att få upprepade försök att mata in korrekt vid felaktig inmatning.
               - En switch-sats hanterar användaren val i menyn. 
               - Genom att ha en while-loop inuti varje val-case får användaren möjlighet att antingen fortsätta med sitt val eller ångra och återgå till menyn*/
            while (true)
            {
                // Visa huvudmenyn
                Console.WriteLine("Välkommen! Vänligen gör ett val från menyn genom att mata in motsvarande siffra (1-5) och tryck [ENTER]:\n");
                Console.WriteLine("[1] INSÄTTNING\n[2] UTTAG\n[3] SALDO\n[4] RÄNTEBETALNING\n[5] AVSLUTA\n");

                string inputMenyval = Console.ReadLine();
                Console.Clear();

                // ------------------------- HUVUDMENYN -------------------------
                switch (inputMenyval)
                {
                    case "1":
                        while (true)
                        {
                            Console.WriteLine("Här kan du göra en insättning på ditt saldo.\n");
                            Console.WriteLine("Ange belopp att sätta in och tryck [ENTER]:\n");
                            Console.WriteLine("(Vill du hellre avbryta och återgå till huvudmenyn? Skriv 'Q')\n");
                            string input = Console.ReadLine();
                            Console.Clear();

                            if (input.Length == 1 && input.ToUpper()[0] == 'Q')
                            {
                                Console.Clear();
                                break;  // Återgå till huvudmenyn
                            }

                            double belopp;
                            if (double.TryParse(input, out belopp))
                            {
                                if (belopp <= 0)
                                {
                                    Console.WriteLine("Beloppet måste vara större än 0. Klicka på valfri tangent för försöka igen.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;                                    
                                }
                                Console.Clear();

                                saldo += belopp;
                                Console.WriteLine($"Du har satt in {belopp} kr. Ditt nya saldo är {saldo} kr.\n");
                                GåTillbakaTillMeny();
                                break;  // Avsluta insättningsloopen och återgå till huvudmenyn
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt inmatning. Klicka på valfri tangent för försöka igen.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("Här kan du göra ett uttag på ditt saldo.");
                            Console.WriteLine("Ange belopp att ta ut och tryck [ENTER] (eller skriv 'Q' för att återgå till menyn utan att göra ett uttag):");
                            string input = Console.ReadLine();

                            if (input.Length == 1 && input.ToUpper()[0] == 'Q')
                            {
                                Console.Clear();
                                break;  // Återgå till huvudmenyn
                            }

                            double belopp;
                            if (double.TryParse(input, out belopp))
                            {
                                if (belopp <= 0)
                                {
                                    Console.WriteLine("Beloppet måste vara större än 0. Försök igen.");
                                    continue;
                                }
                                if (belopp > saldo)
                                {
                                    Console.WriteLine("Otillräckligt saldo. Försök igen.");
                                    continue;
                                }

                                saldo -= belopp;
                                Console.WriteLine($"Du har tagit ut {belopp} kr. Ditt nya saldo är {saldo} kr.");
                                GåTillbakaTillMeny();
                                break;  // Avsluta uttagsloopen och återgå till huvudmenyn
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt belopp. Försök igen.");
                            }
                        }
                        break;
                    case "3":
                        // Visa saldo
                        Console.WriteLine($"Ditt saldo är: {saldo} kr.");
                        GåTillbakaTillMeny();
                        break;
                    case "4":
                        // Ränteberäkning
                        Console.WriteLine("Här kan du göra en ränteberäkning och se avkastning på x antal år.");
                        GåTillbakaTillMeny();
                        break;
                    case "5":
                        // Avslutar programmet
                        Environment.Exit(0);
                        break;
                    default:
                        // Felhantering vid felaktig inmatning från användaren
                        Console.WriteLine("Ogiltigt alternativ. Vänligen mata in en siffra mellan 1 och 5.");
                        GåTillbakaTillMeny();
                        continue;
                }
            }
        }

        static void GåTillbakaTillMeny()
        {
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}