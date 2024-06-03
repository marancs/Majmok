using System.Net;
namespace Majmok.Services
{
    
    public class MonkeyService
    {
        List<Monkey> majmok;

#if DEBUG
    #if ANDROID
        public static readonly string URL = "http://10.0.2.2:3000/{0}";
    #elif WINDOWS
        public static readonly string URL = "http://localhost:3000/{0}";
    #endif
#else
        public static readonly string URL = "http://localhost:3000/{0}";
#endif

        public string res;


        private JsonElement.ArrayEnumerator Json_From_Http(string route)
        {
            try
            {
                string remoteUrl = string.Format(URL, route);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var json = reader.ReadToEnd();
                var document = JsonDocument.Parse(json);
                JsonElement root = document.RootElement;
                root = root.GetProperty("dataset");
                return root.EnumerateArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonElement.ArrayEnumerator();
        }

        public async Task<List<Monkey>> GetMonkeys()
        {
            if (majmok?.Count() > 0)
            {
                return majmok;
            }

            var sorok = Json_From_Http("majmok");
            majmok = new List<Monkey>();
            while (sorok.MoveNext())
            {
                var sor = sorok.Current;
                Monkey majom = JsonSerializer.Deserialize<Monkey>(JsonSerializer.Serialize(sor));
                majmok.Add(majom);
            }


            /*
            var stream = await FileSystem.OpenAppPackageFileAsync("monkeysData.json");
            var reader = new StreamReader(stream);
            var tartalom = await reader.ReadToEndAsync();
            majmok = JsonSerializer.Deserialize(tartalom, MajomContext.Default.ListMonkey);
            */
            return majmok;
        }

    }

    
}
