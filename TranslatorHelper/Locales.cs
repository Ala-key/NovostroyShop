namespace NovostroyShop.Models
{
    public class Locales
    {
        public RU RU { get; set; }

        public EN EN { get; set; }

    }

    public class RU
    {
        public List<Dictionary<string, string>> keyValuePairs;
    }

    public class EN
    {
        public List<Dictionary<string, string>> keyValuePairs;
    }
}
