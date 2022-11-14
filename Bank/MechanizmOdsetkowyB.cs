namespace Bank
{
    public class MechanizmOdsetkowyB : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            if (saldo > 1000 && saldo < 2000)
            {
                return 100 + (int)0.02 * (saldo - 10000);
            }
            return 0;
        }

        public override string Opis()
        {
            return "Mechanizm odsetkowy B: liniowe obliczanie odsetek dla salda pomiędzy 1000zł a 2000zł ";

        }
    }
}
