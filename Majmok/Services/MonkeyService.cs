
namespace Majmok.Services
{
    
    public class MonkeyService
    {
        List<Monkey> majmok;

        public async Task<List<Monkey>> GetMonkeys()
        {
            if (majmok?.Count() > 0)
            {
                return majmok;
            }

            var stream = await FileSystem.OpenAppPackageFileAsync("monkeysData.json");
            var reader = new StreamReader(stream);
            var tartalom = await reader.ReadToEndAsync();
            majmok = JsonSerializer.Deserialize(tartalom, MajomContext.Default.ListMonkey);
            return majmok;
        }

    }

    
}
