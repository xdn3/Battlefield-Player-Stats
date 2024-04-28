using System.Net;

namespace BattlefieldStats
{
    class BattlefieldStats
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Incorrect arguments! Use bfstats -h to display help.");
                return 1;
            }
            if (args[0] == "--stats")
            {
                string? playerName = Console.ReadLine();
                if (string.IsNullOrEmpty(playerName)) { System.Console.WriteLine("Invalid username!"); return 0; }
                string statsUnprocessed = getStats(playerName, "pc");
                Console.WriteLine(statsUnprocessed);
            }
            else if (args[0] == "--status")
            {

            }
            return 0;
        }
        static async Task<string> sendRequest(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }
        static string getStatus(string server)
        {

            return "";
        }
        static string getStats(string player, string platform, bool skipBattlelog = false, string language = "en-us", bool formatValues = true)
        {
            Uri uri = new Uri(String.Format("https://api.gametools.network/bf1/stats/?format_values={0}&name={1}&platform={2}&skip_battlelog={3}&lang={4}", formatValues.ToString().ToLower(), player, platform, skipBattlelog.ToString().ToLower(), language));
            string response = sendRequest(uri).Result;
            return response;
        }
    }
}