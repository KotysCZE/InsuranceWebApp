using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace MVCProjekt.Extensions
{
    public static class Extension
    {
        // where T : new() označuje, že daný typ musí poskytovat bezparametrický konstruktor
        public static T DeserializeToObject<T>(this ITempDataDictionary tempData, string key) where T : new()
        {
            //Hledáme cokoliv, co je uložené pod daným klíčem v TempData
            string entry = tempData[key]?.ToString();
            //pokud jsme pod daným klíčem něco našli, deserializujeme to z json na daný typ
            //pokud ne, vrátíme novou instanci daného typu

            T result = entry is null ? new T() : JsonConvert.DeserializeObject<T>(entry);

            return result;
        }

        public static void SerializeObject<T>(this ITempDataDictionary tempdata, T obj, string key)
        {
            tempdata[key] = JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
