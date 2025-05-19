using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheSportTeamPlayerApi.DataBaseLogic;
using TheSportTeamPlayerApi.Entity;

namespace TheSportTeamPlayerApi.BLogic
{
    public class MatchesService
    {
        //private static readonly HttpClient client = new HttpClient();
        string url = "https://api.thesports.com/v1/cricket/match/lineup/detail?user={0}&secret={1}&uuid={2}";

        public bool sport_GetTeamPlayer(string username, string secretekey, string id)
        {
            //List<TeamPlayer> hometeamlist = new List<TeamPlayer>();
            //List<TeamPlayer> awayteamlist = new List<TeamPlayer>();

            string readurl = string.Format(url, username, secretekey, id);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; 
                response.EnsureSuccessStatusCode();



                string responseBody = response.Content.ReadAsStringAsync().Result; 
                var json = JObject.Parse(responseBody);
                hometeamlist = json["results"]["lineup"]["home"].ToObject<List<TeamPlayer>>();
                awayteamlist = json["results"]["lineup"]["away"].ToObject<List<TeamPlayer>>();


                if (hometeamlist != null)
                {
                    MatchesDal dal = new MatchesDal();
                    dal.sport_SaveMatches(hometeamlist, id, "home");



                }
                if (awayteamlist != null)
                {
                    MatchesDal dal = new MatchesDal();
                    dal.sport_SaveMatches(awayteamlist, id, "away");

                }


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch data: {ex.Message}");
            }

            return false;
        }
    }
}
