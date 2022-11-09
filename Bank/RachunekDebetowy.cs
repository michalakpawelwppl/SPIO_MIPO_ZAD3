using System;
using System.Collections;

namespace Bank
{
    public class RachunekDebetowy : Rachunek, IRachunek
    {
        private int dopuszczalnyDebet;
        private int debet;

        protected ArrayList historia;


        public RachunekDebetowy(Rachunek obecniePodstawowyRachunek, int dopuszczalnyDebet)
        {
            RachunekPodstawowy = obecniePodstawowyRachunek;
            this.DopuszczalnyDebet = dopuszczalnyDebet;
            if (obecniePodstawowyRachunek is RachunekDebetowy)
            {
                this.DopuszczalnyDebet -= (obecniePodstawowyRachunek as RachunekDebetowy).DopuszczalnyDebet;
            }

            this.historia = obecniePodstawowyRachunek.Historia;
        }

        public int Debet
        {
            get
            {
                if (RachunekPodstawowy is RachunekDebetowy)
                {
                    return (RachunekPodstawowy as RachunekDebetowy).Debet + debet;
                }
                else return debet;
            }
            set
            {
                if (RachunekPodstawowy is RachunekDebetowy)
                {
                    if (DopuszczalnyDebet - debet - value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Kwota przekracza wysokość dopuszczalnego debetu");
                    }
                    else if (DopuszczalnyDebet - (RachunekPodstawowy as RachunekDebetowy).Debet - value < 0)
                    {
                        debet += (value - (DopuszczalnyDebet - (RachunekPodstawowy as RachunekDebetowy).Debet));
                        (RachunekPodstawowy as RachunekDebetowy).Debet = (RachunekPodstawowy as RachunekDebetowy).dopuszczalnyDebet;
                    }
                }
                else
                {
                    debet += value;
                }
            }
        }

        public int DopuszczalnyDebet
        {
            get
            {
                if (RachunekPodstawowy is RachunekDebetowy)
                {
                    return dopuszczalnyDebet + (RachunekPodstawowy as RachunekDebetowy).DopuszczalnyDebet;
                }
                else
                {
                    if (dopuszczalnyDebet == null)
                    {
                        dopuszczalnyDebet = 0;
                    }
                    return dopuszczalnyDebet;
                }
            }
            set
            {
                dopuszczalnyDebet = value;
            }
        }
        public IRachunek RachunekPodstawowy { get; set; }

        public override int Wplata(int kwota)
        {
            if (kwota < 0)
            {
                throw new ArgumentOutOfRangeException("Kwota musi być większa od 0,00");
            }

            if (kwota >= Debet)
            {
                Debet = 0;
                RachunekPodstawowy.Wplata(kwota - Debet);
                historia.Add("Wpłata: " + kwota + ", saldo: (-" + Debet + ")");
                return 0;
            }
            else
            {
                Debet -= kwota;
                historia.Add("Wpłata: " + kwota + ", saldo: (-" + Debet + ")");
                return 0;
            }
        }

        public int Saldo()
        {
            return RachunekPodstawowy.Saldo();
        }

        public override int Wyplata(int kwota)
        {
            if (kwota <= Saldo())
            {
                RachunekPodstawowy.Wyplata(kwota);
                historia.Add("Wypłata: " + kwota + ", saldo: " + Saldo() + ", debet: " + Debet);
                return 0;
            }
            if (kwota > Saldo() && kwota <= Saldo() + DopuszczalnyDebet - Debet)
            {
                Debet += (kwota - Saldo());
                RachunekPodstawowy.Wyplata(Saldo());
                historia.Add("Wypłata: " + kwota + ", saldo: " + Saldo() + ", debet: " + Debet);
                return 0;
            }
            else
            {
                historia.Add("Nieudana wypłata: " + kwota + ", saldo: " + Saldo() + ", debet: " + Debet);
                return -1;
            }
        }
    }
}
