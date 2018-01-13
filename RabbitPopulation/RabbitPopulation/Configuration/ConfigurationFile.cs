using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RabbitPopulation.Configuration
{
    /// <summary>
    /// INI dosyasındaki bilgilerin okunmasını sağlayan sınıftır.
    /// </summary>
    public class ConfigurationFile
    {
        // İNİ dosyasının yol bilgisi tutulur.
        private string filePath;

        /// <summary>
        /// Configuration sınıfının yapıcı methodudur.
        /// </summary>
        /// <param name="filePath"> INI dosyasının yol bilgisidir.</param>
        public ConfigurationFile(string filePath)
        {
            this.filePath = filePath;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// INI dosyasından girilen section ve key bilgisine ait veriyi getiren methoddur.
        /// </summary>
        /// <param name="section">Section Bilgisi</param>
        /// <param name="key">Key bilgisi.</param>
        /// <returns>Key bilgisine ait veri.</returns>
        public string ReadValue(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", stringBuilder, 255, filePath);
            return stringBuilder.ToString();
        }
    }
}
