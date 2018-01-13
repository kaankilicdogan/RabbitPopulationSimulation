using RabbitPopulation.Bussiness;
using RabbitPopulation.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Entity
{
    /// <summary>
    /// Kumes Sinifidir.
    /// </summary>
    public class Coop
    {
        /// <summary>
        /// Kumeste bulunan disi tavsan listesi.
        /// </summary>
        private List<FemaleRabbit> femaleRabbitList = new List<FemaleRabbit>();

        /// <summary>
        /// Kumeste Bulunan Erkek Tavsan Listesi.
        /// </summary>
        private List<MaleRabbit> maleRabbitList = new List<MaleRabbit>();

        /// <summary>
        /// Erkek Tavsanlarin yasini bir ay artirir.
        /// </summary>
        private void GetMaleRabbitsOlder()
        {
            List<MaleRabbit> diedRabbits = new List<MaleRabbit>();
            foreach(MaleRabbit maleRabbit in this.maleRabbitList)
            {
                maleRabbit.GetOneMonthAge();
                if(maleRabbit.HasRabbitDied())
                {
                    diedRabbits.Add(maleRabbit);
                }
            }

            //olen tavsanlar siliniyor
            foreach(MaleRabbit diedRabbit in diedRabbits)
            {
                this.maleRabbitList.Remove(diedRabbit);
            }
        }

        /// <summary>
        /// Disi tavsanlar bir ay yaslandiriliyor ve dogum zamani geldi ise dogum yapiliyor.
        /// </summary>
        private void GetFemaleRabbitsOlder()
        {
            int maleNewborn = 0;
            int femaleNewborn = 0;
            List<FemaleRabbit> diedRabbits = new List<FemaleRabbit>();
            foreach(FemaleRabbit femaleRabbit in this.femaleRabbitList)
            {
                femaleRabbit.GetOneMonthAge();
                if(femaleRabbit.HasRabbitDied())
                {
                    diedRabbits.Add(femaleRabbit);
                }
                else
                {
                    //Hamilelik durumunu kontrol Et.
                    int result = femaleRabbit.ControlRabbitAndImprovePregnancy();
                    if (result > 0)
                    {
                        maleNewborn = maleNewborn + result;
                        femaleNewborn = femaleNewborn + (femaleRabbit.MaximumNumberOfNewbornRabbits - result);
                    }
                }
            }

            //olen tavsanlar siliniyor
            foreach (FemaleRabbit diedRabbit in diedRabbits)
            {
                this.femaleRabbitList.Remove(diedRabbit);
            }

            //yenidogan tavsanlar listeye ekleniyor.
            for(int i = 0 ; i < maleNewborn; i++)
            {
                this.AddMaleRabbitToCoop(new MaleRabbit(RabbitPopulationSimulation.MaleRabbitLifeTime));
            }
            for (int i = 0; i < femaleNewborn; i++)
            {
                this.AddFemaleRabbitToCoop(new FemaleRabbit(RabbitPopulationSimulation.TotalTimeOfPregnancy, RabbitPopulationSimulation.LoseOfFertility, RabbitPopulationSimulation.PercentageOfMaleRabbitBorn, RabbitPopulationSimulation.MaximumNumberOfNewbornRabbits, RabbitPopulationSimulation.FemaleRabbitLifeTime));
            }
        }
        
        /// <summary>
        /// Kumese yeni bir erken Tavsan ekler.
        /// </summary>
        /// <param name="maleRabbit">Erkek tavsan objesi.</param>
        public void AddMaleRabbitToCoop(MaleRabbit maleRabbit)
        {
            this.maleRabbitList.Add(maleRabbit);
        }

        /// <summary>
        /// Kumese yeni bir disi tavsan ekler.
        /// </summary>
        /// <param name="femaleRabbit">Disi tavsan objesi.</param>
        public void AddFemaleRabbitToCoop(FemaleRabbit femaleRabbit)
        {
            this.femaleRabbitList.Add(femaleRabbit);
        }

        /// <summary>
        /// Tum tavsanlar bir ay yaslandiriliyor.
        /// </summary>
        public void GetAllRabbitsOlder()
        {
            //Erkek tavsanlarin yasini artir.
            GetMaleRabbitsOlder();
            // Disi tavsanlarin yasi artiriliyor dogum ve hamile kalma islemi yapiliyor.
            GetFemaleRabbitsOlder();
        }

        /// <summary>
        /// Parametre olarak gonderilen yasda olan erkek tavsan adedini doner.
        /// </summary>
        /// <param name="age">Yas bilgisi.</param>
        /// <returns>Erkek Tavsan adedi.</returns>
        public int GetMaleRabbitCount(int age)
        {
            return this.maleRabbitList.Where(q => q.Age == age).Count();
        }

        /// <summary>
        /// Parametre olarak gonderilen yasda olan disi tavsan adedini doner.
        /// </summary>
        /// <param name="age">Yas bilgisi.</param>
        /// <returns>Erkek Tavsan adedi.</returns>
        public int GetFemaleRabbitCount(int age)
        {
            return this.femaleRabbitList.Where(q => q.Age == age).Count();
        }
    }
}
