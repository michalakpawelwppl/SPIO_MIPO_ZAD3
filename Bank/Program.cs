using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank pkoBp = new Bank();

            KIR.tabelaBanków.Add("pkoBp", pkoBp);
            
            Rachunek r11 = pkoBp.ZalozRachunek("11", "Jan", "Kowalski");
            r11.Wplata(200);
            
            Rachunek r13 = pkoBp.ZalozRachunek("13", "Anna", "Nowak");
            r11.Wplata(300);
            
            Rachunek r15 = pkoBp.ZalozRachunek("15", "Kazimierz", "Nijaki");
            r11.Wplata(500);
            
            pkoBp.Przelew("13", "pkoBP", "11", "pkoBP", 100);
            pkoBp.Przelew(r15, pkoBp, r11, pkoBp, 100);
            
            Console.WriteLine("R11: " + r11.Saldo());
            Console.WriteLine("R13: " + r13.Saldo());
            Console.WriteLine("R15: " + r15.Saldo());
        }
    }
}
