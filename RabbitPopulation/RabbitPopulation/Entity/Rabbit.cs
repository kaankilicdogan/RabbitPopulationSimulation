using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Entity
{
    /// <summary>
    /// Tavşan Sınıfı Tavşan turunun ortak ozelliklerini içerir.
    /// </summary>
    public abstract class Rabbit
    {
        /// <summary>
        /// Tavşan ömrü.
        /// </summary>
        public int Lifetime;
        /// <summary>
        /// Tavşanın Yaş bilgisi.
        /// </summary>
        public int Age;

        /// <summary>
        /// Tavşanın ömrünü tamamladıysa true tamamlamadıysa false doner.
        /// </summary>
        /// <returns>Tavşanın ömrünü tamamladıysa true tamamlamadıysa false doner.</returns>
        public bool HasRabbitDied()
        {
            if(Age < Lifetime)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tavsan bir ay yas alir.
        /// </summary>
        public void GetOneMonthAge()
        {
            this.Age++;
        }

    }
}
