using System;
using System.Collections.Generic;

namespace Bank
{
    public class Bank
    {
        private Dictionary<String, Rachunek> rachunki = new Dictionary<String, Rachunek>();

        /// <summary>
        /// Zakładanie rachunku. Rachunek zostanie stworzony i zapamiętany przez bank.
        /// </summary>
        /// <param name="numer">Numer rachunku</param>
        /// <param name="imie">Imię właściciela rachunku</param>
        /// <param name="nazwisko">Nazwisko właściela rachunku</param>
        /// <returns>Obiekt rachunku</returns>
        public Rachunek ZalozRachunek(String numer, String imie, String nazwisko)
        {
            Rachunek rach = new Rachunek(numer, imie, nazwisko);
            rachunki.Add(numer, rach);
            return rach;
        }

        /// <summary>
        /// Ustawia dopuszczalny debet na podaną wartość.
        /// </summary>
        /// <param name="debet">Wartość dopuszczalnego debetu</param>
        public void UstawDebet(Rachunek rachunek, int dopuszczalnyDebet)
        {
            if (rachunek is RachunekDebetowy)
            {
                rachunki[rachunek.Numer()] = new RachunekDebetowy(rachunek, dopuszczalnyDebet - (rachunek as RachunekDebetowy).DopuszczalnyDebet);
            }
            rachunki[rachunek.Numer()] = new RachunekDebetowy(rachunek, dopuszczalnyDebet);
        }

        /// <summary>
        /// Wyszukiwanie rachunku.
        /// </summary>
        /// <param name="numer">Numer rachunku</param>
        /// <returns>Obiekt rachunku, jeźeli zostanie znaleziony, i null, jeżeli go nie ma.</returns>
        public Rachunek Szukaj(String numer)
        {
            return (Rachunek)rachunki[numer];
        }

        /// <summary>
        /// Przelew w kwocie "kwota" z rachunku o numerze "numer1" na rachunek o numerze "numer2"
        /// </summary>
        /// <param name="numer1"></param>
        /// <param name="numer2"></param>
        /// <param name="kwota"></param>
        /// <returns>0 - jeżeli przelew się nie powiedzie, 1 - jeżeli przelew się powiedzie</returns>
        public int Przelew(String numer1, String numer2, int kwota)
        {
            Rachunek rachunek1 = Szukaj(numer1);
            Rachunek rachunek2 = Szukaj(numer2);

            return Przelew(rachunek1, rachunek2, kwota);
        }

        /// <summary>
        /// Przelew w kwocie "kwota" z rachunku "rachunek1" na rachunek "rachunek2"
        /// </summary>
        /// <param name="rachunek1"></param>
        /// <param name="rachunek2"></param>
        /// <param name="kwota"></param>
        /// <returns>0 - jeżeli przelew się nie powiedzie, 1 - jeżeli przelew się powiedzie</returns>
        public int Przelew(Rachunek rachunek1, Rachunek rachunek2, int kwota)
        {
            if (rachunek1.Wyplata(kwota) == 0)
            {
                rachunek2.Wplata(kwota);
                return 1;
            }

            return 0;
        }
    }
}
