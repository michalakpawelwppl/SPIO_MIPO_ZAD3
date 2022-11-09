namespace Bank
{
    public interface IRachunek
    {
        int Wyplata(int kwota);
        int Wplata(int kwota);
        int Saldo();
    }
}
