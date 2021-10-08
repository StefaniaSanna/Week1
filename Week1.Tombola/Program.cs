using System;

namespace Week1.Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Benvenuto a Tombola!");
            Console.ResetColor();
            do
            {

                int[] numeriUtente = SceltaNumeri();  // array di interi scelti da me
                for (int i = 0; i < numeriUtente.Length; i++)
                {
                    Console.Write($"{numeriUtente[i]} ");
                }
                //per ora salto la parte 3

                // inizia parte 4
                int[] numeriEstrattiPc = Estrazionepc(); // array di interi estratti dal pc

                Console.WriteLine();
                //parte 5
                //for (int i = 0; i < numeriEstrattiPc.Length; i++) // non serve visualizzarli, ma è un buon check
                //{
                //    Console.Write($"{numeriEstrattiPc[i]} ");
                //}

                Console.WriteLine();
                int numvincenti = Vittoria(numeriUtente, numeriEstrattiPc);
                Console.WriteLine($"Hai azzeccato {numvincenti} numeri");
              
                switch (numvincenti)
                {
                    case 2:
                        Console.WriteLine("Hai fatto ambo!");
                        break;
                    case 3:
                        Console.WriteLine("Hai fatto terna!");
                        break;
                    case 4:
                        Console.WriteLine("Hai fatto quaterna!");
                        break;
                    case 5:
                        Console.WriteLine("Hai fatto cinquina!");
                        break;
                    default:
                        Console.WriteLine("Hai perso!");
                        break;
                }

                int[] n = NumeriVincenti(numeriUtente, numeriEstrattiPc); // parte 6 print dei numeri corretti
                Console.WriteLine("\nSi desidera rigiocare? In caso premere 1, per abbandonare premere qualunque altro tasto");
            }
            while (Console.ReadKey().KeyChar == '1');
        }
        private static int[] SceltaNumeri() 
        {
            Console.WriteLine("L'utente deve scegliere 5 numeri compresi tra 1 e 90");

            int n = 5;

            int[] NumeriDefinitiviUtente = new int[n];

            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                int numeroprovvisorio;

                if (num > 0 && num < 91)
                {
                    numeroprovvisorio = num;

                    if (i == 0)
                    {
                        NumeriDefinitiviUtente[i] = numeroprovvisorio;
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (numeroprovvisorio == NumeriDefinitiviUtente[j])
                            {
                                Console.WriteLine("Attenzione, il numero deve essere diverso riprova");
                                --i;

                            }
                            else
                            {
                                NumeriDefinitiviUtente[i] = numeroprovvisorio;
                            }
                        }                       
                    }
                }
                else
                {
                    Console.WriteLine("Attenzione, il numero deve essere compreso tra 1 e 90, riprova");
                    --i;
                }
            }

            return NumeriDefinitiviUtente;
        }

        // programma per estrarre i numeri
        private static int[] Estrazionepc()
        {
            int[] numeriestrazioni = new int[20];
            Random random = new Random();

            for (int i = 0; i < numeriestrazioni.Length; i++)
            {
                int possibilenum = random.Next(1, 92); 
                
                if (i == 0)
                {
                    numeriestrazioni[0] = possibilenum;

                }
                else
                {
                    if (possibilenum != numeriestrazioni[i - 1]) // sbagliato perchè due numeri non consecutivi possono essere uguali
                    {
                        numeriestrazioni[i] = possibilenum;
                    }
                    else
                    {
                        --i;
                    }
                }

            }
            return numeriestrazioni;

        }

        private static int Vittoria(int[] mieinumeri, int[] numeriestratti)
        {
            int contatore = 0;

            for (int i = 0; i < mieinumeri.Length; i++)
            {
                for (int j = 0; j < numeriestratti.Length; j++)
                {
                    if (mieinumeri[i] == numeriestratti[j])
                    {
                        contatore++;
                    }
                }
            }
            return contatore;

        }
        // ricopio lo stesso programma perchè da qui voglio un array dei numeri vincenti
        private static int[] NumeriVincenti(int[] mieinumeri, int[] numeriestratti)
        {

            int[] numVincenti = new int[5];

            for (int i = 0; i < mieinumeri.Length; i++)
            {
                for (int j = 0; j < numeriestratti.Length; j++)
                {
                    if (mieinumeri[i] == numeriestratti[j])
                    {
                        numVincenti[i] = mieinumeri[i];  // così però mi segna i numeri con lo zero

                    }
                }
            }
            // voglio eliminare gli zeri dall'array

            for (int j = 0; j < 5; j++)
            {
                if (numVincenti[j] != 0)
                {
                    Console.Write($" {numVincenti[j]}");
                }
            }

            return numVincenti;
        }        
    }
}
