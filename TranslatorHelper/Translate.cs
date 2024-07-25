using Newtonsoft.Json;
using NovostroyShop.Models;

namespace TranslatorHelper
{
    public class Translate
    {

        public static string GetWordFromArray(string key, string culture, bool longSentence = false)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "words.json");

            string json = File.ReadAllText(jsonFilePath);

            var list = JsonConvert.DeserializeObject<Locales>(json);

            string value = null;

            if (culture == "en")
            {
                var dict = list.EN.keyValuePairs.FirstOrDefault(x => x.TryGetValue(key, out value));
            }
            else
            {
                var dict = list.RU.keyValuePairs.FirstOrDefault(x => x.TryGetValue(key, out value));
            }

            if (string.IsNullOrEmpty(value))
            {
                string stringbyUpperchar = char.ToUpper(key[0]) + key.Substring(1);
                return stringbyUpperchar;
            }

            return value;
        }
    }
}