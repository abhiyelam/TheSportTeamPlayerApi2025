
using System;
using System.Collections.Generic;
using System.Configuration;
using TheSportTeamPlayerApi.BLogic;
using TheSportTeamPlayerApi.DataBaseLogic;
using TheSportTeamPlayerApi.Entity;

namespace TheSportTeamPlayerApi
{
    public class Program
    {
        public static string ApiUser = "";
        public static string SecretKey = "";

        static void Main(string[] args)
        {
             ApiUser = ConfigurationManager.AppSettings["APIUSER"].ToString();
            SecretKey = ConfigurationManager.AppSettings["SECRETKEY"].ToString();
            //string Id = "ednm96cwxxg0myo";

          
         
            MatchesDal matchesDal = new MatchesDal();
            List<TeamPlayer> matches = matchesDal.GetMatchId();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

            foreach (var t in matches)
            {
                DeleteTeamPlayerData(t.Id);
            }
          
            
            //ReadMatchesData(ApiUser, SecretKey, Id);

            foreach (var t in matches)
            {
                ReadMatchesData(ApiUser, SecretKey, t.Id);
            }


        }

      

        public static void ReadMatchesData(string apiuser, string key, string Id)
        {
            MatchesService matchesService = new MatchesService();
            matchesService.sport_GetTeamPlayer(apiuser, key, Id);

        }
        public static void DeleteTeamPlayerData(string Id)
        {
            MatchesDal matchesDal = new MatchesDal();
            matchesDal.sport_DeleteTeamPlayerData(Id);

        }

    }
}
