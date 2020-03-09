using System;

namespace _020Lab_VecchioCompito {
    public class Ordinazione {
        private int _id;
        private Menu _menuScelto;
        public DateTime Erogato = DateTime.Now.Add(new TimeSpan(0,0,5,0));    //imposto a default che l'ordine sara' pronto fra 5 min
        private bool _evaso;

        public Ordinazione(int id, Menu menuScelto) {   //costruttore di default
            _id = id;
            _menuScelto = menuScelto;
        }

        public int Id => _id;
        public Menu MenuScelto => _menuScelto;   //properties
        public bool Evaso => _evaso;

        public void Evadi() {
            _evaso = true;        //imposta l'ordine com evaso
        }

        public int tempoDiAttesa() {
            return (Erogato - DateTime.Now).Minutes;    //fa il calcolo dei minuti sottraendo dall'ora di erogazione(futuro) l'ora esatta di questo momento.
            
        }

        public override string ToString() {
            return string.Format($"Id: {_id}  Menu scelto: {_menuScelto.Nome}  Evaso: {_evaso}  Erogato: {Erogato}");  //fa uscire la stringa con i valori dell'oggetto
        }
    }

    
}