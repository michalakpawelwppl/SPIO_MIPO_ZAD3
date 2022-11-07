namespace Bank
{
    public class MechanizmOdsetkowyC : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            int odsetki = 0;

            if (saldo < 10000)
                odsetki = (int)0.01 * saldo;
            else if (saldo < 50000)
                odsetki = 100 + (int)0.02 * (saldo - 10000);
            else
                odsetki = 100 + 800 + (int)0.03 * (saldo - 50000);

            return odsetki;
        }

        public override string Opis()
        {
            return "Mechanizm A: liniowe obliczanie odsetek od dowolnego salda większego niż 0";
        }
    }
}
