using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class Program
    {
        public static List<MotorSzerviz> motorok = new List<MotorSzerviz>();
        static void Main(string[] args)
        {
            MotorSzerviz m1 = new MotorSzerviz("Kiss Péter", "Yamaha MT-07", "Fékhiba", 15000, 8000, false);
            motorok.Add(m1);
            MotorSzerviz m2 = new MotorSzerviz("Nagy János", "Honda CBF600", "Olajcsere", 11000, 7000, true);
            motorok.Add(m2);
            MotorSzerviz m3 = new MotorSzerviz("Tóth Gábor", "Ktm Duke 390", "Vezérműlánc csere", 28000, 13000, false);
            motorok.Add(m3);
            MotorSzerviz m4 = new MotorSzerviz("Balogh Gábor", "Kawasaki Z125", "Gumicsere", 24000, 6000, true);
            motorok.Add(m4);
            MotorSzerviz m5 = new MotorSzerviz("Kiss Gyula", "Aprilia rs 125", "Kuplung javítás", 28000, 15000,false);
            motorok.Add(m5);
            while (true)
            {
               

                Console.WriteLine("Válasz az alábbi menüpontok közül és ird be a számát!");
                Console.WriteLine("1.Szerelésre váró motorok");
                Console.WriteLine("2.Motor állapot lekérdezése");
                Console.WriteLine("3.Motor hozzáadása");
                Console.WriteLine("4.Szerelés árának lekérdezése");
                Console.WriteLine("5.Javitás állapotának frissitése");
                Console.WriteLine("6.Kilépes");
                int mp = int.Parse(Console.ReadLine());
                if (mp == 1)
                {

                    Console.WriteLine("Szerelésre váró motorok:");
                    foreach (var item in szerelesalatt(motorok))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("\n Nyomj egy entert a menühöz");
                    Console.ReadLine();
                    Console.Clear();

                }
                if (mp == 2)
                {
                    if (allapotlekeres(motorok))
                    {
                        Console.WriteLine("Ez a motor már elkészült!");
                    }
                    else
                    {
                        Console.WriteLine("Ez a motor még szerelés alatt van");
                    }

                    Console.WriteLine("\n Nyomj egy entert a menühöz");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (mp == 3)
                {
                    Console.WriteLine(motorhozzaad(motorok));
                    Console.WriteLine();
                    Console.WriteLine("Szerelésre váró motorok:");
                    foreach (var item in szerelesalatt(motorok))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("\n Nyomj egy entert a menühöz");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (mp == 4)
                {
                    Console.WriteLine("{0}ft a motor javitási költsége", vegosszeg(motorok));
                    Console.WriteLine("\n Nyomj egy entert a menühöz");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (mp == 5)
                {
                    Console.WriteLine(allapotvaltoztatas(motorok));
                    Console.WriteLine("\n Nyomj egy entert a menühöz");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (mp == 6) { break;}
            }
            Console.ReadLine();
            

        }


        public static List<string> szerelesalatt(List<MotorSzerviz> motorok)
        {
            List<string> list = new List<string>();

            foreach (var item in motorok)
            {
                if(item.Allapot == false)
                {
                    list.Add(item.Motortipus);
                    
                    
                }

            }
            return list;
        }
        public static bool allapotlekeres(List<MotorSzerviz> motorok)
        {
            Console.WriteLine("Milyen néven lett rögzitve a jármnű:");
            string n = Console.ReadLine();
            bool elkeszult = false;

            foreach (var item in motorok) 
            {
                if (item.Tulajdonos == n)
                {
                    if (item.Allapot)
                    {
                        elkeszult = true;
                    }
                    if (!item.Allapot)
                    {
                        elkeszult = false;
                       
                    }
                }
              
            }
            return elkeszult;
        }

        public static string motorhozzaad(List<MotorSzerviz> motorok)
        {
            string kiiras = "";
            Console.Write("Add meg a neved:");
            string n = Console.ReadLine();
            Console.Write("Add meg a motor tipusát:");
            string m = Console.ReadLine();
            Console.Write("Mit kell rajta elvégezni?");
            string h = Console.ReadLine();
            Console.Write("alkatrész ára:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Munkadíj:");
            int md = int.Parse(Console.ReadLine());

            MotorSzerviz uj = new MotorSzerviz(n,m,h,a,md,false);
            motorok.Add(uj);

            ;
            if (motorok.Contains(uj))
            {
                kiiras = "Sikeresen hozzáadtad motort!";
            }

            return kiiras;

        }

        public static double vegosszeg(List<MotorSzerviz> motorok)
        {
            Console.Write("Melyik motort szeretnéd kifizetni? ");
            string m = Console.ReadLine();
            double ar = 0;
            bool volt = false;

            foreach (var item in motorok)
            {
                if (m == item.Motortipus)
                {
                    volt = true;
                    if (item.Allapot)
                    {
                        ar = item.Alkatreszar + item.Munkadij;
                    }
                    else
                    {
                        Console.WriteLine("Még szerelés alatt van.");
                    }
                    break; 
                }
            }

            if (!volt)
            {
                Console.WriteLine("Nincs ilyen motor a szervizben.");
            }

            return ar;
        }

        public static string allapotvaltoztatas(List<MotorSzerviz> motorok)
        {
            string kiiras = "";
            bool valt = false;
            Console.Write("Melyik motor javitása keszült el?");
            string m = Console.ReadLine();

            foreach (var item in motorok) 
            {
                if (item.Motortipus == m)
                {
                    item.Allapot = true;
                    valt = true;
                }
                else 
                {
                    kiiras = "Nincs ilyen motor";  
                }
            }

            if (valt)
            {
                kiiras =  $"{m} tipusu motor elkészült";
            }
            return kiiras;
        }
    

        public class MotorSzerviz
        {
            private string tulajdonos;
            private string motortipus;
            private string hiba;
            private int alkatreszar;
            private int munkadij;
            private bool allapot;

            public string Tulajdonos
            {
                get => tulajdonos;
                set => tulajdonos = value;
            }
            public string Motortipus
            {
                get => motortipus;
                set => motortipus = value;
            }

            public string Hiba
            {
                get => hiba;
                set => hiba = value;
            }

            public int Alkatreszar
            {
                get => alkatreszar;
                set => alkatreszar = value;

            }
            public int Munkadij
            {
                get => munkadij;
                set => munkadij = value;
            }
            
            public bool Allapot
            {
                get => allapot;
                set => allapot = value;
            }

            public MotorSzerviz(string tulajdonos, string motortipus, string hiba, int alkatreszar,int munkadij, bool allapot)
            {
                Tulajdonos = tulajdonos;
                Motortipus = motortipus;
                Hiba = hiba;
                Alkatreszar = alkatreszar;
                Munkadij = munkadij;
                Allapot = allapot;

            }
        }
    }
}
