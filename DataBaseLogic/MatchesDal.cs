using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheSportTeamPlayerApi.Dal;
using TheSportTeamPlayerApi.Entity;

namespace TheSportTeamPlayerApi.DataBaseLogic
{
    public class MatchesDal
    {
        //private readonly SQLHelper _sqlHelper;

        public MatchesDal()
        {
            _sqlHelper = new SQLHelper();
        }
        public List<TeamPlayer> GetMatchId()
        {



            List<TeamPlayer> list = new List<TeamPlayer>();
            //SqlParameter[] para = { new SqlParameter("@siteid", System.Data.SqlDbType.Int)
            //};

            //para[0].Value = siteid;
            try
            {
                DbDataReader reader = null;
                using (reader = _sqlHelper.ExecuteReader("thesport_GetMatchId"))
                {
                    while (reader.Read())
                    {
                        TeamPlayer team = new TeamPlayer();
                        team.Id = reader["id"].ToString();
                        list.Add(team);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;

        }
       
        public bool sport_SaveMatches(List<TeamPlayer> teamPlayers, string id, string teamType)
        {
            bool flag = false;
            try
            {
                foreach (var player in teamPlayers)
                {
                    SqlParameter[] prm = {
                          new SqlParameter("@matchId", SqlDbType.VarChar),
                    new SqlParameter("@playerId", SqlDbType.VarChar),
                    new SqlParameter("@type", SqlDbType.Int),
                    new SqlParameter("@captain", SqlDbType.Int),
                    new SqlParameter("@position", SqlDbType.VarChar),
                    new SqlParameter("@teamType", SqlDbType.VarChar)   // Specify home or away
                   };
                    prm[0].Value = id;
                    prm[1].Value = player.id != null ? player.id : (object)DBNull.Value; ;
                    prm[2].Value = player.Type;
                    prm[3].Value = player.Captain;
                    prm[4].Value = player.Position;
                    prm[5].Value = teamType;
                    bool result = _sqlHelper.ExecuteNonQuery("thesport_SaveMatchesTeamPlayer", prm);
                    if (result)
                    {
                        flag = true;

                    }
                    else
                    {
                        flag = false;
                        break; // Exit loop early since saving failed
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;

        }
        public bool sport_DeleteTeamPlayerData(string id)
        {
            bool flag = false;
            try
            {
               
                    SqlParameter[] prm = {
                          new SqlParameter("@matchId", SqlDbType.VarChar),
                  
                   };
                    prm[0].Value = id;
                 
                   bool result= _sqlHelper.ExecuteNonQuery("thesport_DeleteMatchesTeamPlayer", prm);
                if (result)
                {
                    flag = true;
                }
                
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

    }
}
