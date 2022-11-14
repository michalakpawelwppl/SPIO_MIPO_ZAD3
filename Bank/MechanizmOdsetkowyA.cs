namespace Bank
{
    public class MechanizmOdsetkowyA : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            if (saldo > 0 && saldo < 1000)
            {
                return (int)(saldo * 0.03);
            }
            else return 0;
        }

        public override string Opis()
        {
            return "Mechanizm odsetkowy A: liniowe obliczanie odsetek od dowolnego salda większego niż 0zł a mniejszego niż 1000zł";
        }
    }
}
