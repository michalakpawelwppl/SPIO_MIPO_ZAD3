namespace Bank
{
    public class MechanizmOdsetkowyB : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            int odsetki = 0;
            var stopaPodstawowa = 0.01;
            if (saldo < 100000)
            {
                odsetki = (int)(saldo * stopaPodstawowa);
            }
            else
            {
                odsetki = (int)(100000 * stopaPodstawowa);
                odsetki += (int)(saldo * 0.05);
            }
            return odsetki;
        }

        public override string Opis()
        {
            return "Mechanizm odsetkowyB: do sdalda 100.000,00 odsetki liczone wg stopy procentowej 1%, saldo powyżej 100.000,00 wg stopy procentowej 5%";

        }
    }
}
