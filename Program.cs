using System;

namespace _020Lab_VecchioCompito {
    class Program {
        static void Main(string[] args) {
            //creo menu e testo le properties
            Console.WriteLine("*********TEST MENU**********");
            Menu m1 = new Menu("menu 1", 12, "molto buono");
            Console.WriteLine("Costo: " + m1.Costo + "  Descrizione: " + m1.Descrizione + "  Nome: " + m1.Nome);

            Console.WriteLine("\n");

            Console.WriteLine("*********TEST ORDINAZIONE**********");

            //stampo l'ordine
            Ordinazione o1 = new Ordinazione(1, m1);
            Console.WriteLine(o1);
            
            Console.WriteLine("\n");

            //cambio stato ordnine
            Console.WriteLine(o1.Evaso);
            o1.Evadi();
            Console.WriteLine(o1.Evaso);


            Console.WriteLine("\n");

            Console.WriteLine("*********TEST GESTORE ORDINAZIONI**********");

            //creo la lista di ordinazioni
            GestoreOrdinazioni g1 = new GestoreOrdinazioni();

            //aggiungo ordinazioni
            Ordinazione o2 = new Ordinazione(2, new Menu("menu 2", 15, "meno buono"));
            Ordinazione o3 = new Ordinazione(3, new Menu("menu 3", 10, "buono Q.B."));
            Ordinazione o4 = new Ordinazione(4, new Menu("menu 1", 12, "molto buono"));

            g1.AggiungiOrdinazione(o1);
            g1.AggiungiOrdinazione(o2);
            g1.AggiungiOrdinazione(o3);
            g1.AggiungiOrdinazione(o4);
            g1.AggiungiOrdinazione(o1); //aggiungo 2 volte lo stesso per vedere se funziona

            //stampo un ordinazione
            Console.WriteLine(g1.StampaOrdinazione(2));
            Console.WriteLine(g1.StampaOrdinazione(1));
            Console.WriteLine("\n");
            
            
            //tempi di attesa // Se -1 e' gia' stato erogato. il tempo fisso per ogni ordine e' 5 minuti e vanno ad accodarsi in base a questi 5 min
            for (int i = 1; i <= g1.TotaleOrdinazioni; i++) {
                Console.WriteLine(g1.GetTempoAttesa(i));
            }

            Console.WriteLine("\n");
            
            //stampo ordini e rimuovo ordine
            int nOrdini = g1.TotaleOrdinazioni;  //metto nella variabile perche' cosi' ho il numero di ordini costante e il for non mi skippa l'ultimo ordine (siccome il for stampa passando al metodo "i",
                                                 //all' inizio ho 4 ordnini e ne stampa 4 mentre dopo la rimozione ho 3 ordnini e non stampa l'ordine con id 4 perche' il for esce prima per condizione).
            
            for (int i = 1; i <= nOrdini; i++) {
                Console.WriteLine(g1.StampaOrdinazione(i));
            }

            g1.RimuoviOrdinazione(3);
            Console.WriteLine("\n");
            
            for (int i = 1; i <= nOrdini; i++) {
                Console.WriteLine(g1.StampaOrdinazione(i));
            }

            Console.WriteLine("\n");
            
            //conto i non evasi. Sono 2 perche' il 3 e' stato rimosso mentre il primo e' evaso.
            Console.WriteLine(g1.GetNonEvase);
        }
    }
}