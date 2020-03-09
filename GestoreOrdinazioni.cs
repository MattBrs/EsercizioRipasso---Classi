using System;
using System.Collections.Generic;
using System.Linq;

namespace _020Lab_VecchioCompito {
    public class GestoreOrdinazioni {
        private List<Ordinazione> _ordinazioni;

        public GestoreOrdinazioni() {
            _ordinazioni = new List<Ordinazione>();    //costruttore
        }

        public int TotaleOrdinazioni => _ordinazioni.Count;
        public List<Ordinazione> TutteLeOrdinazioni => _ordinazioni;   //properties

        public bool AggiungiOrdinazione(Ordinazione obj) {
            if (_ordinazioni.Contains(obj)) return false;
            if (_ordinazioni.Any()) {
                obj.Erogato = _ordinazioni[_ordinazioni.Count - 1].Erogato.Add(new TimeSpan(0, 5, 0));   //metodo per aggiungere l'ordine. controlla se l'ordine c'e' gia' e imposta la coda di preparazione
            }
            else {
                obj.Erogato = DateTime.Now.Add(new TimeSpan(0, 5, 0));
            }

            _ordinazioni.Add(obj);
            return true;
        }

        public string StampaOrdinazione(int id) {
            var pos = _ordinazioni.FindIndex(x => x.Id == id);  //metodo per stampare un ordinazione
            return pos >= 0 ? _ordinazioni[pos].ToString() : "";                       //se l'id e' presente stampa lo stato interno dell'oggetto(ordine) altrimenti stampa una stringa vuota
        }

        public bool RimuoviOrdinazione(int id) {
            var tmp = _ordinazioni.Find(x => x.Id == id);  //cerca l'id e se lo trova rimuove la prima occorrenza. Siccome gli id sono unici non possono esserci doppioni.
            return _ordinazioni.Remove(tmp);
        }

        public int GetTempoAttesa(int id) {
            var pos = _ordinazioni.FindIndex(x => x.Id == id);
            return pos >= 0 && !_ordinazioni[pos].Evaso ? _ordinazioni[pos].tempoDiAttesa() : -1;  //cerca la posizione dell'ordine in base al'id. Se lo trova utilizza il metodo dell'oggetto per stampare lo stato interno.conrolla anche che non sia gia' stato servito.
        }

        public bool EvadiOrdinazione(int id) {
            var pos = _ordinazioni.FindIndex(x => x.Id == id);            //cerca la pos dell'id. se lo trova e non e' gia' stato evaso imposta l'ordine come servito.
            if (pos >= 0 && !_ordinazioni[pos].Evaso) _ordinazioni[pos].Evadi();
            else return false;
            return true;
        }

        public double IncassoTotale => _ordinazioni.Sum(x => x.MenuScelto.Costo);  //metodi per vedere quanti ordini ci sono e quanti sono quelli non ancora serviti.
        public int GetNonEvase => _ordinazioni.Count(x => x.Evaso == false);
    }
}