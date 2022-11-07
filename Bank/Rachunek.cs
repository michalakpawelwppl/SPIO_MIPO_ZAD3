using System;
using System.Collections;

namespace Bank
{
    public class Rachunek
    {
        private String numer;
        private String imie, nazwisko;
        private int saldo;
        private int dopuszczalnyDebet;
        private ArrayList historia = new ArrayList();

        /// <summary>
        /// Utworzenie rachunku.
        /// </summary>
        /// <param name="numer">Numer rachunku</param>
        /// <param name="imie">Imię właściciela rachunku</param>
        /// <param name="nazwisko">Nazwisko właściciela rachunku</param>
        public Rachunek(String numer, String imie, String nazwisko)
        {
            numer = numer;
            imie = imie;
            nazwisko = nazwisko;
            saldo = 0;
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
        /// Ustawia dopuszczalny debet na podaną wartość.
        /// </summary>
        /// <param name="debet">Wartość dopuszczalnego debetu</param>
        public void UstawDebet(int debet)
        {
            if (debet > 100)
                dopuszczalnyDebet = debet;
        }

        /// <summary>
        /// Zwraca wartość dopuszczalnego debetu.
        /// </summary>
        public int DopuszczalnyDebet()
        {
            return dopuszczalnyDebet;
        }

        /// <summary>
        /// Wyświetla historię rachunku.
        /// </summary>
        public void PiszHistorie()
        {
            Console.WriteLine(historia);
        }

        /// <summary>
        /// Wpłaca podaną kwotę na rachunek.
        /// </summary>
        /// <param name="kwota">Wysokość wpłacanej kwoty</param>
        /// <returns>0</returns>
        public int Wplata(int kwota)
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
        public int Wyplata(int kwota)
        {
            if (saldo + dopuszczalnyDebet >= kwota)
            {
                saldo -= kwota;
                historia.Add("Wypłata: " + kwota + ", saldo: " + saldo);
                return 0;
            }
            historia.Add("Nieudana wypłata: " + kwota + ", saldo: " + saldo);
            return -1;
        }

        /// <summary>
        /// Zwraca wartość należnych odsetek.
        /// </summary>
        public int Odsetki()
        {
            int odsetki = 0;

            if (saldo < 10000)
                odsetki = (int)0.01 * saldo;
            else if (saldo < 50000)
                odsetki = 100 + (int)0.02 * (saldo - 10000);
            else
                odsetki = 100 + 800 + (int)0.03 * (saldo - 50000);

            historia.Add("Naliczono odsetki w kwocie " + odsetki);

            return odsetki;
        }
    }
}
