using RabbitPopulation.Configuration;
using RabbitPopulation.Entity;
using RabbitPopulation.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Bussiness
{
    /// <summary>
    /// Simulasyonun Koşulduğu sınıfdır.
    /// </summary>
    public class RabbitPopulationSimulation
    {
        public static int MaleRabbitLifeTime;
        public static int FemaleRabbitLifeTime;
        public static int TotalTimeOfPregnancy;
        public static int LoseOfFertility;
        public static int PercentageOfMaleRabbitBorn;
        public static int MaximumNumberOfNewbornRabbits;

        private bool ReadConfigurationFile()
        {            
            string filePath = System.Environment.CurrentDirectory + "\\Configuration\\RabbitPopulationSettings.ini";
            ConfigurationFile configuration = new ConfigurationFile(filePath);
            string maleLifeTime = configuration.ReadValue(Section.Rules.ToString(), Setting.Erkek_Tavsan_Omru.ToString());
            string femaleLifeTime = configuration.ReadValue(Section.Rules.ToString(), Setting.Disi_Tavsan_Omru.ToString());
            string totalTimeOfPregnancy = configuration.ReadValue(Section.Rules.ToString(), Setting.Hamilelik_Suresi.ToString());
            string loseOfFertility = configuration.ReadValue(Section.Rules.ToString(), Setting.Disi_Tavsan_Dogurganlik_Bitis_Suresi.ToString());
            string percentageOfMaleRabbitBorn = configuration.ReadValue(Section.Rules.ToString(), Setting.Dogan_Tavsan_Erkek_Yuzdesi.ToString());
            string maximumNumberOfNewbornRabbits = configuration.ReadValue(Section.Rules.ToString(), Setting.Tek_Seferde_Dogan_Tavsan_Adedi.ToString());

            if(!int.TryParse(maleLifeTime, out MaleRabbitLifeTime))
            {
                Console.WriteLine("Erkek Tavşan Ömrü Tamsayı Olmalıdır.");
                return false;
            }
            else if(MaleRabbitLifeTime < 1)
            {
                Console.WriteLine("Erkek Tavşan Ömrü 0 dan Buyuk Tamsayı Olmalıdır.");
                return false;
            }
            else if (!int.TryParse(femaleLifeTime, out FemaleRabbitLifeTime))
            {
                Console.WriteLine("Dişi Tavşan Ömrü Tamsayı Olmalıdır.");
                return false;
            }
            else if (MaleRabbitLifeTime < 1)
            {
                Console.WriteLine("Dişi Tavşan Ömrü 0 dan Buyuk Tamsayı Olmalıdır.");
                return false;
            }
            else if (!int.TryParse(totalTimeOfPregnancy, out TotalTimeOfPregnancy))
            {
                Console.WriteLine("Hamilelik Süresi Tamsayı Olmalıdır.");
                return false;
            }
            else if (TotalTimeOfPregnancy < 1)
            {
                Console.WriteLine("Hamilelik Süresi 0 dan Buyuk Tamsayı Olmalıdır.");
                return false;
            }
            else if (!int.TryParse(loseOfFertility, out LoseOfFertility))
            {
                Console.WriteLine("Doğurganlık Bitiş Süresi Tamsayı Olmalıdır.");
                return false;
            }
            else if (LoseOfFertility < 1)
            {
                Console.WriteLine("Dogurganlik Bitis Süresi 0 dan Buyuk Tamsayı Olmalıdır.");
                return false;
            }
            else if (!int.TryParse(percentageOfMaleRabbitBorn, out PercentageOfMaleRabbitBorn))
            {
                Console.WriteLine("Doğan Erkek Tavşan Oranı Tamsayı Olmalıdır.");
                return false;
            }
            else if (PercentageOfMaleRabbitBorn < 0 || PercentageOfMaleRabbitBorn > 100)
            {
                Console.WriteLine("Doğan Erkek Tavşan Oranı 0 ile 100 Arasinda Tamsayı Olmalıdır.");
                return false;
            }
            else if (!int.TryParse(maximumNumberOfNewbornRabbits, out MaximumNumberOfNewbornRabbits))
            {
                Console.WriteLine("Tek Seferde Doğan Tavşan Sayisi Tamsayı Olmalıdır.");
                return false;
            }
            else if (MaximumNumberOfNewbornRabbits < 1)
            {
                Console.WriteLine("Tek Seferde Doğan Tavşan Sayisi 0 dan Buyuk Tamsayı Olmalıdır.");
                return false;
            }
            return true;
        }

        public void StartSimulation(int month)
        {
            //INI Dosyası Okunuyor
            if (ReadConfigurationFile())
            {
                //Simulasyonu baslat
                Coop coop = new Coop();
                // T 0 Anindan Bir disi bir erkek tavsan olusturuluyor.
                coop.AddFemaleRabbitToCoop(new FemaleRabbit(TotalTimeOfPregnancy, LoseOfFertility, PercentageOfMaleRabbitBorn, MaximumNumberOfNewbornRabbits, FemaleRabbitLifeTime));
                coop.AddMaleRabbitToCoop(new MaleRabbit(MaleRabbitLifeTime));

                for (int currentMonth = 1; currentMonth <= month; currentMonth++)
                {
                    // Tavsanlar bir ay yaslandiriliyor.
                    coop.GetAllRabbitsOlder();
                }

                //simulasyon sonucu yazdiriliyor
                int maxAge = MaleRabbitLifeTime > FemaleRabbitLifeTime ? MaleRabbitLifeTime : FemaleRabbitLifeTime;
                for (int currentMonth = 0; currentMonth < maxAge; currentMonth++)
                {
                    Console.WriteLine(currentMonth + " Aylık " + coop.GetMaleRabbitCount(currentMonth) + " Erkek " + coop.GetFemaleRabbitCount(currentMonth) + " Dişi");
                }

                //debug esnasinda sonuclari gorebilmek icin bu satir eklendi.
                Console.ReadLine();
            }
        }
    }
}
