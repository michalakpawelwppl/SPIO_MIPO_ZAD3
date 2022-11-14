namespace Bank
{
    public class MechanizmOdsetkowyC : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            if (saldo > 2000)
            {
                return 100 + 800 + (int)0.03 * (saldo - 50000);
            }
            else return 0;
        }

        public override string Opis()
        {
            return "Mechanizm odsetkowy C: liniowe obliczanie odsetek od dowolnego salda większego niż 2000zł";
        }
    }
}
