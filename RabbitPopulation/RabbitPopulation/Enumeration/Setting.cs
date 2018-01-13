using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitPopulation.Enumeration
{
    /// <summary>
    /// INI dosyasında tanımlanan parametreler bulunmaktadır.
    /// Yeni Parametre eklenirse ilgili değer bu enumada eklenmelidir.
    /// </summary>
    public enum Setting
    {
        Erkek_Tavsan_Omru,
        Disi_Tavsan_Omru,
        Tek_Seferde_Dogan_Tavsan_Adedi,
        Dogan_Tavsan_Erkek_Yuzdesi,
        Hamilelik_Suresi,
        Disi_Tavsan_Dogurganlik_Bitis_Suresi
    }
}
