using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GOOGLE CALENDAR NON PLUS ULTRA");

            string[] attivita = new string[100];

            bool continua = true;
            while (continua)
            {
                stampaMenu();
                Console.Write("Scegliere la prossima operazione: ");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        visualizza(attivita);
                        break;

                    case "2":
                        Console.Write("Inserire il titolo dell'attività: ");
                        string titolo = Console.ReadLine();
                        Console.Write("Inserire la descrizione dell'attività: ");
                        string descrizione = Console.ReadLine();
                        Console.Write("Inserire l'anno dell'attività: ");
                        int anno = int.Parse(Console.ReadLine());
                        Console.Write("Inserire il mese dell'attività a 2 cifre: ");
                        int mese = int.Parse(Console.ReadLine()); // Idea: string meseFormattato = mese.ToString("00");
                        bool meseValido = false;
                        while (!meseValido)
                        {
                            if (mese >= 1 && mese <= 12)
                            {
                                meseValido = true;
                            }
                            else
                            {
                                Console.Write("Mese non valido. Inserire un mese compreso tra 1 e 12 a 2 cifre: ");
                                mese = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.Write("Inserire il giorno dell'attività: ");
                        int giorno = int.Parse(Console.ReadLine());
                        bool giornoValido = false;
                        while (!giornoValido) // Idea: se il mese è febbraio, il giorno deve essere compreso tra 1 e 28 (o 29 se l'anno è bisestile)
                        {
                            if (giorno >= 1 && giorno <= 31)
                            {
                                giornoValido = true;
                            }
                            else
                            {
                                Console.Write("Giorno non valido. Inserire un giorno compreso tra 1 e 31: ");
                                giorno = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.Write("Inserire l'ora dell'attività: ");
                        int ora = int.Parse(Console.ReadLine());
                        Console.Write("Inserire i minuti dell'attività: ");
                        int minuti = int.Parse(Console.ReadLine());

                        string stringaData = anno + "." + mese + "." + giorno + "-" + ora + ":" + minuti;
                        string nuovaAttivita = stringaData + " | " + titolo + " | " + descrizione;

                        bool inserimentoRiuscito = inserisci(attivita, nuovaAttivita);
                        if (inserimentoRiuscito)
                        {
                            Console.WriteLine("Attività inserita con successo!");
                        }
                        else
                        {
                            Console.WriteLine("Attività non inserita (si è già raggiunto il massimo numero di attività memorizzabili).");
                        }
                        break;
                    case "3":
                        ordina(attivita);
                        Console.WriteLine("Attività ordinate con successo!");
                        break;

                    case "4":
                        visualizza(attivita);
                        Console.Write("Inserire l'indice dell'attività da eliminare: ");
                        int indice = int.Parse(Console.ReadLine());

                        if (indice >= 0 && indice < attivita.Length && attivita[indice] != null)
                        {
                            for (int i = indice; i < attivita.Length - 1; i++)
                            {
                                attivita[i] = attivita[i + 1];
                            }
                            attivita[attivita.Length - 1] = null;

                            Console.WriteLine("Attività eliminata con successo!");
                        }
                        else
                        {
                            Console.WriteLine("Indice non valido.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Bye bye!");
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }

        static void stampaMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("1 - Visualizza le attività");
            Console.WriteLine("2 - Inserisci attività");
            Console.WriteLine("3 - Ordina attività per data");
            Console.WriteLine("4 - Elimina attività");
            Console.WriteLine("0 - ESCI");
        }

        static void visualizza(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    Console.WriteLine($"- {array[i]}");
                }
            }
        }

        static bool inserisci(string[] array, string elem)
        {
            if (elem != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == null)
                    {
                        array[i] = elem;
                        return true;
                    }
                }
            }
            return false;
        }

        // Errore perche gli array sono delle stringhe e non puo confrontarle con i segni maggiore/minore
        /*
        static void ordina(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] != null && array[j] != null)
                    {
                        if (array[i] > array[j])
                        {
                            string temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
        */
    }
}
