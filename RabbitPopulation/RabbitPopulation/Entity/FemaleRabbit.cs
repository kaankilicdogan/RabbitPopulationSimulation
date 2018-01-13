using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Entity
{
    /// <summary>
    /// Disi Tavsan sinifi.
    /// </summary>
    public class FemaleRabbit:Rabbit
    {
        /// <summary>
        /// Bir disi tavsanin hamilelik suresi.
        /// </summary>
        public int TotalTimeOfPregnancy;
        /// <summary>
        /// Dogurganligin kaybedildigi ay bilgisi.
        /// </summary>
        public int LoseOfFertility;
        /// <summary>
        /// Dogumda dogan bebek tavsanlarin erkek olma orani.
        /// </summary>
        public int PercentageOfMaleRabbitBorn;
        /// <summary>
        /// Bir dogumda dogan toplam cocuk sayisi.
        /// </summary>
        public int MaximumNumberOfNewbornRabbits;
        /// <summary>
        /// Tavsan hamile ise  kacinci ayda bilgisi.
        /// </summary>
        public int CurrentPregnancyTime;
        /// <summary>
        /// Tavsanin hamile olma bilgisi.
        /// </summary>
        public bool IsPregnant;

        /// <summary>
        /// Disi tavsan yapici sinifidir.
        /// </summary>
        /// <param name="totalTimeOfPregnancy">Bir disi tavsanin hamilelik suresi.</param>
        /// <param name="loseOfFertility">Dogurganligin kaybedildigi ay bilgisi.</param>
        /// <param name="percentageOfMaleRabbitBorn">Dogumda dogan bebek tavsanlarin erkek olma orani.</param>
        /// <param name="maximumNumberOfNewbornRabbits">Bir dogumda dogan toplam cocuk sayisi.</param>
        /// <param name="lifetime">Disi tavsan omru.</param>
        public FemaleRabbit(int totalTimeOfPregnancy, int loseOfFertility, int percentageOfMaleRabbitBorn, int maximumNumberOfNewbornRabbits, int lifetime)
        {
            this.TotalTimeOfPregnancy = totalTimeOfPregnancy;
            this.LoseOfFertility = loseOfFertility;
            this.PercentageOfMaleRabbitBorn = percentageOfMaleRabbitBorn;
            this.MaximumNumberOfNewbornRabbits = maximumNumberOfNewbornRabbits;
            this.Lifetime = lifetime;
            this.Age = 0;
            this.CurrentPregnancyTime = 0;
            this.IsPregnant = false;
        }

        /// <summary>
        /// Disi tavsani hali hazirda hamile ise hamilelik suresini ilerletir. Hamile degil ise hamile kalabilecek yasta ise hamile durumuna getirir.
        /// </summary>
        /// <returns>Bir dogum oldu ise dogan erkek tavsan sayisinidir.</returns>
        public int ControlRabbitAndImprovePregnancy()
        {
            int result = 0;
            if(this.IsPregnant)
            {
                this.CurrentPregnancyTime++; 
                if(this.CurrentPregnancyTime == this.TotalTimeOfPregnancy)
                {
                    this.IsPregnant = false;
                    this.CurrentPregnancyTime = 0;
                    result = (this.MaximumNumberOfNewbornRabbits * this.PercentageOfMaleRabbitBorn) / 100;
                }
            }
            else if(this.Age < this.LoseOfFertility)
            {
                this.IsPregnant = true;
            }

            return result;
        }
    }
}
