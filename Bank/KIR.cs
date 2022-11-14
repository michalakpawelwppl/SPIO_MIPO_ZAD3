using System.Collections.Generic;

namespace Bank
{
    public static class KIR
    {
        public static Dictionary<string, Bank> tabelaBanków;

        static KIR()
        {
            tabelaBanków = new Dictionary<string, Bank>();
        }

        public static void przekazPrzelew(Przelew przelew)
        {
            var oddzialBanku = przelew.BankOdbiorcy;

            oddzialBanku.Przelew(przelew.RachNadawcy, przelew.BankNadawcy, przelew.RachOdbiorcy, przelew.BankOdbiorcy, (int)przelew.KwotaPrzelewu);
        }

        public static Bank szukajBank(string nazwa)
        {
            tabelaBanków.TryGetValue(nazwa, out Bank bank);
            return bank;
            
        }

    }
}
