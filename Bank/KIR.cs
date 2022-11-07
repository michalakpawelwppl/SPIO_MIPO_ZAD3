using System.Collections.Generic;

namespace Bank
{
    public static class KIR
    {
        public static Dictionary<string, Bank> tabelaBanków { get; private set; }

        public static void przekazPrzelew(Przelew przelew)
        {
            var oddzialBanku = przelew.BankOdbiorcy;

            oddzialBanku.Przelew(przelew.RachNadawcy, przelew.BankNadawcy, przelew.RachOdbiorcy, przelew.BankOdbiorcy, (int)przelew.KwotaPrzelewu);
        }

        public static Bank szukajBank(string nazwa)
        {
            if (tabelaBanków[nazwa] != null)
            {
                return tabelaBanków[nazwa];
            }
            else return null;
        }

    }
}
