namespace Bank
{
    public class Przelew
    {
        public Rachunek RachNadawcy { get; set; }
        public Bank BankNadawcy { get; set; }
        public Rachunek RachOdbiorcy { get; set; }
        public Bank BankOdbiorcy { get; set; }
        public decimal KwotaPrzelewu { get; set; }

        public Przelew(Rachunek rachNadawcy, Bank bankNadawcy, Rachunek rachOdbiorcy, Bank bankOdbiorcy, decimal kwotaPrzelewu)
        {
            RachNadawcy = rachNadawcy;
            BankNadawcy = bankNadawcy;
            RachOdbiorcy = rachOdbiorcy;
            BankOdbiorcy = bankOdbiorcy;
            KwotaPrzelewu = kwotaPrzelewu;
        }

    }
}
