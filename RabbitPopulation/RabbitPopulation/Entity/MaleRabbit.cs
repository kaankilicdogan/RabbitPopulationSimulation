using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Entity
{
    /// <summary>
    /// Erkek Tavşan sınıfıdır.
    /// </summary>
    public class MaleRabbit : Rabbit
    {
        /// <summary>
        /// Erkek Tavşan yapıcı sınıfıdır.
        /// </summary>
        /// <param name="lifetime">Erkek Tavşan ömür bilgisidir.</param>
        public MaleRabbit(int lifetime)
        {
            this.Age = 0;
            this.Lifetime = lifetime;
        }
    }
}
