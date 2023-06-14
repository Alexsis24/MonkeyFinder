using System.Data.SqlTypes;
using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    List<Monkey> monkeyList = new List<Monkey>();

    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
        {
            return monkeyList;
        }

        //online
        var url = "https://montemagno.com/monkeys.json";        
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>(); //takes the info from json and reads the monkeys keys
        }

        //offline
        //different approach if you don't have access to link or trouble with emulator
        //there is imbedded monkeydata.json inside folder "Resources" -> "Raw" -> "monkeydata.json" with all the deitals and can be used with following commands:

        using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);

        return monkeyList;
    }
}
