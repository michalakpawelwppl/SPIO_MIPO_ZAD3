using System;

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
            r13.Wplata(300);
            
            Rachunek r15 = pkoBp.ZalozRachunek("15", "Kazimierz", "Nijaki");
            r15.Wplata(500);
            
            pkoBp.Przelew("13", "11", 100);
            pkoBp.Przelew(r15, r11, 100);

            r11.Odsetki();
            r11.ZmienMechanizmOdsetkowy(new MechanizmOdsetkowyC());
            r11.Odsetki();
            
            Console.WriteLine("R11: ");
            r11.PiszHistorie();
            Console.WriteLine("\nR13: ");
            r13.PiszHistorie();
            Console.WriteLine("\nR15: ");
            r15.PiszHistorie();
            
            Console.ReadKey();
        }
    }
}
