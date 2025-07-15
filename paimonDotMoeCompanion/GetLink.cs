using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace paimonDotMoeCompanion
{
    public static class GetLink
    {
        public static string LogLocationGlobal { get; set; }
        public static string LogLocationChina { get; set; }

        public static string LogLocation { get; set; }
        public static string ApiHost { get; set; }

        public static readonly string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public static string FoundLink { get; set; }

        public static void getLink(Logger logger, string region = "global")
        {
            LogLocationGlobal = Path.Combine(userProfile, @"AppData\LocalLow\miHoYo\Genshin Impact\output_log.txt");

            string chinaFolder = $"{(char)0x539f}{(char)0x795e}";
            LogLocationChina = Path.Combine(userProfile, $@"AppData\LocalLow\miHoYo\{chinaFolder}\output_log.txt");

            logger?.Log("Using Global cache location as default");
            LogLocation = LogLocationGlobal;
            ApiHost = "public-operation-hk4e-sg.hoyoverse.com";

            if (region?.ToLower() == "china")
            {
                logger?.Log("Using China cache location");
                LogLocation = LogLocationChina;
                ApiHost = "public-operation-hk4e.mihoyo.com";
            }

            // Backup environment variables into an in-memory Dictionary
            IDictionary envVarsRaw = Environment.GetEnvironmentVariables();
            Dictionary<string, string> envVarsBackup = new Dictionary<string, string>();

            foreach (DictionaryEntry entry in envVarsRaw)
            {
                string key = entry.Key?.ToString() ?? string.Empty;
                string value = entry.Value?.ToString() ?? string.Empty;
                envVarsBackup[key] = value;
            }

            // Example usage
            logger?.Log("Environment variables backed up in memory.");
            logger?.Log("Backup contains " + envVarsBackup.Count + " variables.");

            string path = Environment.ExpandEnvironmentVariables(LogLocation);
            if (!File.Exists(path))
            {
                logger?.Log("Cannot find the log file! Make sure to open the wish history first!", LogLevel.Error);
                return;
            }

            List<string> logs = new List<string>();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    logs.Add(line);
                    //logger?.Log(line);
                }
            }

            // FIXED: Changed from "!= null" to "== null"
            string match = logs.FirstOrDefault(
                l => Regex.IsMatch(l, @".*/(GenshinImpact_Data|YuanShen_Data)"));

            if (match == null)  // This was the bug - should be "== null"
            {
                logger?.Log("Cannot find the wish history url! Make sure to open the wish history first!", LogLevel.Error);
                return;
            }

            var dirMatch = Regex.Match(match, @"(.:/.*?(GenshinImpact_Data|YuanShen_Data))");
            if (!dirMatch.Success)
            {
                logger?.Log("Game directory match failed!", LogLevel.Error);
                return;
            }

            string gameDir = dirMatch.Groups[1].Value.Replace("/", "\\");

            // Based on PowerShell: $webcachePath = Resolve-Path "$gamedir/webCaches"
            // This means webCaches is inside the gameDir
            string webCachesRoot = Path.Combine(gameDir, "webCaches");

            logger?.Log($"Game directory: {gameDir}", LogLevel.Debug);
            logger?.Log($"Looking for webCaches at: {webCachesRoot}", LogLevel.Debug);

            // If not found in gameDir, try parent directory (fallback)
            if (!Directory.Exists(webCachesRoot))
            {
                string gameParentDir = Path.GetDirectoryName(gameDir);
                webCachesRoot = Path.Combine(gameParentDir, "webCaches");
                logger?.Log($"webCaches not found in game directory, trying parent: {webCachesRoot}", LogLevel.Debug);
            }

            if (!Directory.Exists(webCachesRoot))
            {
                logger?.Log("webCaches directory not found.", LogLevel.Error);
                return;
            }

            string latestCache = Directory.GetDirectories(webCachesRoot)
                .OrderByDescending(d => Directory.GetLastWriteTime(d))
                .FirstOrDefault();

            if (latestCache == null)
            {
                logger?.Log("No cache version found.", LogLevel.Error);
                return;
            }

            string cacheFile = Path.Combine(latestCache, @"Cache\Cache_Data\data_2");
            string tmpFile = Path.Combine(Path.GetTempPath(), "ch_data_2");

            if (!File.Exists(cacheFile))
            {
                logger?.Log("Cache file not found.", LogLevel.Error);
                return;
            }

            File.Copy(cacheFile, tmpFile, true);

            string content = File.ReadAllText(tmpFile, Encoding.UTF8);
            File.Delete(tmpFile);

            string[] split = Regex.Split(content, "1/0/");
            var candidates = split.Where(x => x.Contains("webview_gacha")).ToArray();

            if (candidates.Length == 0)
            {
                logger?.Log("No webview_gacha entries found in cache.", LogLevel.Error);
                return;
            }

            for (int i = candidates.Length - 1; i >= 0; i--)
            {
                var matchUrl = Regex.Match(candidates[i], @"https.+?game_biz=");

                if (matchUrl.Success)
                {
                    string testUrl = matchUrl.Value;

                    logger?.Log($"Checking link: {i}...", LogLevel.Debug);

                    if (TestUrlAsync(logger, testUrl).GetAwaiter().GetResult())
                    {
                        FoundLink = testUrl;
                        logger?.Log("Found link!", LogLevel.Success);
                        break;
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            }

            if (FoundLink == null)
            {
                logger?.Log("Cannot find the wish history url! Make sure to open the wish history first!", LogLevel.Error);
                return;
            }

            logger?.Log("Link found. Please press Copy to copy the link and press Open paimon.moe to import wishes data", LogLevel.Success);
        }

        private static async Task<bool> TestUrlAsync(Logger logger, string rawUrl)
        {
            try
            {
                var uri = new UriBuilder(rawUrl)
                {
                    Path = "gacha_info/api/getGachaLog",
                    Host = ApiHost,
                    Fragment = ""
                };

                var query = HttpUtility.ParseQueryString(uri.Query);
                query.Set("lang", "en");
                query.Set("gacha_type", "301");
                query.Set("size", "5");
                query.Add("lang", "en-us");
                uri.Query = query.ToString();

                var http = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };

                string finalUrl = uri.Uri.AbsoluteUri;
                logger?.Log($"Testing URL: {finalUrl}");

                var response = await http.GetAsync(uri.Uri);
                logger?.Log($"Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    logger?.Log($"Request failed with status: {response.StatusCode}");
                    return false;
                }

                string json = await response.Content.ReadAsStringAsync();
                logger?.Log($"Response content length: {json.Length}");
                logger?.Log($"Response contains retcode:0: {json.Contains("\"retcode\":0")}");

                bool result = json.Contains("\"retcode\":0");
                logger?.Log($"Test result: {result}");
                return result;
            }
            catch (Exception ex)
            {
                logger?.Log($"Exception in TestUrlAsync: {ex.Message}");
                logger?.Log($"Exception type: {ex.GetType().Name}");
                if (ex.InnerException != null)
                {
                    logger?.Log($"Inner exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }
    }
}