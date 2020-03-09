namespace _020Lab_VecchioCompito {
    public class Menu {
        private string _nome;
        private double _costo;
        private string _descrizione;

        public Menu(string nome, double costo, string descrizione) {   //costruttore
            _nome = nome;
            _costo = costo;
            _descrizione = descrizione;
        }

        public string Nome => _nome;
        public double Costo => _costo;  //properties
        public string Descrizione => _descrizione;
    }
}