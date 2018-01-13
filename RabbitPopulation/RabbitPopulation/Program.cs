using RabbitPopulation.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation
{
    class Program
    {        
        static void Main(string[] args)
        {
            //Kullanıcıdan Veri Alınıyor
            Console.WriteLine("Simulasyon Kaç Ay Çalıştırılacak :");
            while(true)
            {
                string value = Console.ReadLine();
                int month;
                if(Int32.TryParse(value, out month))
                {
                    if(month > 0)
                    {
                        RabbitPopulationSimulation simulation = new RabbitPopulationSimulation();
                        simulation.StartSimulation(month);
                        break;
                    } 
                    else if (month == 0)
                    {
                        Console.WriteLine("0 Aylık 1 Erkek 1 Dişi");
                        break;
                    }

                    Console.WriteLine("Lütfen Pozitif Bir Tam Sayı Giriniz.");
                }
                else
                {
                    // Hatalı Kayıt mesaj verilip tekrar veri alınacak
                    Console.WriteLine("Hatalı Veri Girdiniz. Ay Bilgisi tam sayı olmalıdır. Tekrar Giriniz.");
                }
            }
            
        }
    }
}
