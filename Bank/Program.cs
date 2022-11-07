namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank pkoBp = new Bank();
            Rachunek r11 = pkoBp.ZalozRachunek("11", "Jan", "Kowalski");
            r11.Wplata(200);
            
            Rachunek r13 = pkoBp.ZalozRachunek("13", "Anna", "Nowak");
            r11.Wplata(300);
            
            Rachunek r15 = pkoBp.ZalozRachunek("15", "Kazimierz", "Nijaki");
            r11.Wplata(500);
            
            pkoBp.Przelew("13", "11", 100);
            pkoBp.Przelew(r15, r11, 100);
            
            Console.Writeline("R11: " + r11.Saldo());
            Console.Writeline("R13: " + r13.Saldo());
            Console.Writeline("R15: " + r15.Saldo());
        }
    }
}
