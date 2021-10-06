using System;

namespace Week1.Erboristeria
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] CODICI = new string[6] { "P1", "P2", "C1", "C2", "I1", "I2"};
            string[] NOMI = new string[] { "Rossetto", "Smalto", "Energia", "Concentrazione", "Rilassante", "Digestiva" };
            string[] CATEGORIE = new string[] { "COSMETICO", "COSMETICO", "INTEGRATORE", "INTEGRATORE", "INFUSO", "INFUSO" };
            double[] PREZZI = new double[] { 2.99, 3.99, 1.99, 6.99, 1.99, 9.99 };

            //trovare il prezzo più alto
            double max = PREZZI[0];
            int indice;

            for (int i = 1; i< PREZZI.Length; i++)
            { 
                if (max < PREZZI[i])
                {
                    max = PREZZI[i];
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Il prezzo più alto è " + max);
            //Risaliamo all'indice
            for (int i = 0; i < PREZZI.Length; i++) {
                if (PREZZI[i] == max)
                {
                    Console.WriteLine("L'indice è " + i);
                    indice = i;
                    Console.WriteLine($"{CODICI[indice]} - {NOMI[indice]} in {CATEGORIE[indice]}: {PREZZI[indice]} Euro ");
                }
            }
            








            
            


        }
    }
}
