using System;
using System.Collections;

namespace Bank
{
    public class Rachunek : IRachunek
    {
        private String numer;
        private String imie, nazwisko;
        private int saldo;

        protected ArrayList historia = new ArrayList();

        public ArrayList Historia
        {
            get
            {
                return historia;
            }
            set
            {
                historia = value;
            }
        }

        private int dopuszczalnyDebet;
        private MechanizmOdsetkowy _mechanizmOdsetkowy;

        /// <summary>
        /// Utworzenie rachunku.
        /// </summary>
        /// <param name="numer">Numer rachunku</param>
        /// <param name="imie">Imię właściciela rachunku</param>
        /// <param name="nazwisko">Nazwisko właściciela rachunku</param>
        public Rachunek(String numer, String imie, String nazwisko, MechanizmOdsetkowy mechanizmOdsetkowy)
        {
            this.numer = numer;
            this.imie = imie;
            this.nazwisko = nazwisko;
            saldo = 0;
            _mechanizmOdsetkowy = mechanizmOdsetkowy;
        }

        public Rachunek(String numer, String imie, String nazwisko)
        {
            numer = numer;
            imie = imie;
            nazwisko = nazwisko;
            saldo = 0; 
            _mechanizmOdsetkowy = new MechanizmOdsetkowyA();

        }

        /// <summary>
        /// Zmienia mechanizm odsetkowy.
        /// </summary>
        public void ZmienMechanizmOdsetkowy(MechanizmOdsetkowy nowyMechanizm)
        {
            this._mechanizmOdsetkowy = nowyMechanizm;
        }
        public Rachunek()
        {

        }

        /// <summary>
        /// Zwraca numer rachunku.
        /// </summary>
        public String Numer()
        {
            return numer;
        }

        /// <summary>
        /// Zwraca właściciela rachunku.
        /// </summary>
        public String Wlasciciel()
        {
            return imie + " " + nazwisko;
        }

        /// <summary>
        /// Zwraca saldo rachunku
        /// </summary>
        public int Saldo()
        {
            return saldo;
        }

        /// <summary>
        /// Wyświetla historię rachunku.
        /// </summary>
        public void PiszHistorie()
        {
            foreach(var item in historia)
                Console.WriteLine(item);
        }

        /// <summary>
        /// Wpłaca podaną kwotę na rachunek.
        /// </summary>
        /// <param name="kwota">Wysokość wpłacanej kwoty</param>
        /// <returns>0</returns>
        public virtual int Wplata(int kwota)
        {
            saldo += kwota;
            historia.Add("Wpłata: " + kwota + ", saldo: " + saldo);
            return 0;
        }

        /// <summary>
        /// Wypłaca podaną kwotę z rachunku.
        /// </summary>
        /// <param name="kwota"></param>
        /// <returns>0 - jeżeli operacja powiedzie się, -1 - jeżeli nie powiedzie się</returns>
        public virtual int Wyplata(int kwota)
        {
            if (saldo >= kwota)
            {
                saldo -= kwota;
                historia.Add("Wypłata: " + kwota + ", saldo: " + saldo);
                return 0;
            }
            else
            historia.Add("Nieudana wypłata: " + kwota + ", saldo: " + saldo);
            return -1;
        }

        /// <summary>
        /// Zwraca wartość należnych odsetek.
        /// </summary>
        public int Odsetki()
        {
            var odsetki = _mechanizmOdsetkowy.ObliczOdsetki(Saldo());
            saldo+=odsetki;

            historia.Add("Naliczono odsetki w kwocie " + odsetki+", saldo: "+saldo);
            historia.Add(_mechanizmOdsetkowy.Opis());

            return odsetki;
        }
    }
}
