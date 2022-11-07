namespace Bank
{
    public class MechanizmOdsetkowyA : MechanizmOdsetkowy
    {
        public override int ObliczOdsetki(int saldo)
        {
            if (saldo > 0)
            {
                return (int)(saldo * 0.01); ;
            }
            else return 0;
        }

        public override string Opis()
        {
            return "Mechanizm A: liniowe obliczanie odsetek od dowolnego salda większego niż 0";
        }
    }
}
