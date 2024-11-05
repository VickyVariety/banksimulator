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
                // Visa huvudmenyn där användaren ombeds mata in sitt val
                Console.WriteLine("Välkommen! Vänligen gör ett val från menyn och tryck [ENTER]:\n");
                Console.WriteLine("[I]NSÄTTNING\n[U]TTAG\n[S]ALDO\n[R]ÄNTEBETALNING\n[A]VSLUTA\n");

                char inputMenyval = Console.ReadLine().ToUpper()[0];
                Console.Clear();

                // ------------------------- HUVUDMENYN -------------------------
                switch (inputMenyval)
                {
                    case 'I': // INSÄTTNING
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

                            // Felhantering om användaren försöker sätta in ett belopp på 0 eller mindre kr.
                            double belopp;
                            if (double.TryParse(input, out belopp))
                            {
                                if (belopp <= 0)
                                {
                                    Console.WriteLine("Beloppet måste vara större än 0. Tryck på valfri tangent för försöka igen.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;                                    
                                }
                                Console.Clear();

                                saldo += belopp;
                                Console.WriteLine($"Du har satt in {belopp} kr. Ditt nya saldo är {saldo} kr.\n");

                                // Metod för återgå till huvudmenyn.
                                TillbakaTillMeny();
                                break;
                            }
                            else
                            {   //Felhantering vid felaktig inmatning.
                                Console.WriteLine("Ogiltigt inmatning. Tryck på valfri tangent för försöka igen.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 'U': // UTTAG
                        while (true)
                        {
                            Console.WriteLine("Här kan du göra ett uttag på ditt saldo.\n");
                            Console.WriteLine("Ange belopp att ta ut och tryck [ENTER]:\n");
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
                                    Console.WriteLine("Beloppet måste vara större än 0. Tryck på valfri tangent för att försöka igen.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                if (belopp > saldo)
                                {
                                    Console.WriteLine($"Otillräckligt saldo. Ditt saldo är: {saldo} kr.");
                                    Console.WriteLine("\nTryck på valfri tangent för att försöka igen.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }

                                saldo -= belopp;
                                Console.WriteLine($"Du har tagit ut {belopp} kr. Ditt nya saldo är {saldo} kr.\n");

                                // Metod för återgå till huvudmenyn.
                                TillbakaTillMeny();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt inmatning. Tryck på valfri tangent för att försöka igen.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 'S': // VISA SALDO                        
                        Console.WriteLine($"Ditt saldo är: {saldo} kr.\n");
                        TillbakaTillMeny();
                        break;
                    case 'R': // RÄNTEBERÄKNING                        
                        BeraknaRanta();
                        break;
                    case 'A':
                        // Avslutar programmet
                        Environment.Exit(0);
                        break;
                    default:
                        // Felhantering vid felaktig inmatning från användaren
                        Console.WriteLine("Ogiltigt alternativ. Vänligen mata in en siffra mellan 1 och 5.");
                        TillbakaTillMeny();
                        continue;
                }
            }
        }

        // Metod för ränteberäkningen
        static void BeraknaRanta()
        {
            double startkapital;
            double rantesats;
            int antalAr;

            Console.WriteLine("Här kan du göra en ränteberäkning och se avkastning på ett visst antal år.\n");

            while (true)
            {
                // Användaren får mata in startkapital eller Q för att återvända till huvudmenyn.

                Console.WriteLine("Ange startkapital och tryck [ENTER]:\n");
                Console.WriteLine("(Vill du hellre avbryta och återgå till huvudmenyn? Skriv 'Q')\n");
                string inputStartkapital = Console.ReadLine();
                Console.Clear();

                if (inputStartkapital.Length == 1 && inputStartkapital.ToUpper()[0] == 'Q')
                {
                    Console.Clear();
                    return;  // Återgå till huvudmenyn
                }

                // Felhantering om användaren försöker sätta startkapital på 0 eller mindre kr. 
                if (!double.TryParse(inputStartkapital, out startkapital) || startkapital <= 0)
                {
                    Console.WriteLine("Beloppet måste vara större än 0. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                if (!double.TryParse(inputStartkapital, out startkapital))
                {
                    Console.WriteLine("Ogiltigt inmatning. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                break;
            }

            // Användaren får mata in räntesats (i procent)
            while (true)
            {
                Console.WriteLine("Ange räntesats (i procent) och tryck [ENTER]:");
                string inputRanta = Console.ReadLine();
                Console.Clear();

                if (!double.TryParse(inputRanta, out rantesats) || rantesats <= 0)
                {
                    Console.WriteLine("Beloppet måste vara större än 0. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (!double.TryParse(inputRanta, out rantesats))
                {
                    Console.WriteLine("Ogiltigt inmatning. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                break;
            }

            // Användaren får mata in antal år
            while (true)
            {
                Console.WriteLine("Ange antal år för sparande och tryck [ENTER]:");
                string inputAr = Console.ReadLine();
                Console.Clear();

                if (!Int32.TryParse(inputAr, out antalAr) || antalAr <= 0)
                {
                    Console.WriteLine("Antal år måste vara större än 0. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (!Int32.TryParse(inputAr, out antalAr) || antalAr <= 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Antal år måste vara ett heltal. Tryck på valfri tangent för försöka igen.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                break;
            }

            // Ränteberäkningen
            double framtidaSaldo = startkapital;
            for (int i = 1; i <= antalAr; i++)
            {
                framtidaSaldo += framtidaSaldo * (rantesats / 100); // Räkna ränta på ränta
                Console.WriteLine($"År {i}: {framtidaSaldo:F2} kr");
            }

            Console.WriteLine($"\nEfter {antalAr} år kommer ditt saldo att vara {framtidaSaldo:f2} kr, om du har en avkastning på {rantesats}%.\n");
            TillbakaTillMeny();
        }

        static void TillbakaTillMeny()
        {
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}